Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Imports ClsHandyCommunication

Public Class BtnSendHandy
  Inherits BtnBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：ファイル名
  Public Property TargetFileName As String
  Public Property Handy As New ClsHandyCommunication.clsHandyCommunication(TargetFileName)
  ' プロパティ：項目長
  Public Property TargetLenClumn As New List(Of Tuple(Of String, Integer))
  ' プロパティ：更新テーブル
  Public Property TargetTableName As String
  ' プロパティ：更新条件
  Public Property TargetWhere As List(Of String) = New List(Of String)

  ' プロパティ：更新項目
  Public Property TargetUpdColumn As List(Of String) = New List(Of String)

  ' プロパティ：更新ステータス
  Public Property TargetUpdStatus As String
  ' プロパティ：通信時間更新
  Public Property TargetCommunicationDate As New Dictionary(Of String, String)

  Public Property TargetCancelParentClick As Boolean = False

  ' 送信完了イベント
  Public Event SendCompleted()

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 送信ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("送信を行います。")

    Me.AccessKey = Keys.F5
    Me.BtnText = "送信"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black

    MakeRoundedButton(Me, 20)
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    Dim tmpDt As New DataTable
    Dim filename As String = String.Empty
    Try
      If TargetCancelParentClick Then
        Exit Sub
      End If

      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！

      '通信ツール開示
      Handy.OpenCommunicationTool()

      Dim TargetSendFlg As Boolean = False
      Handy.WatchAndArchiveSentFiles(TargetFileName, TargetSendFlg)
      'ﾃｽﾄ用に無視するようにしている！！！ここまで！！！

      If Not (TargetLenClumn.Equals(LenColumnInMstItem) Or TargetLenClumn.Equals(LenColumnInMstTanto)) Then
        tmpDt = ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn)
      End If

      'ﾃｽﾄ用に無視するようにしている
      Handy.MoveToBackupFolder(TargetFileName)


      For Each tmpRow In tmpDt.Rows
        '更新項目生成
        Dim tmpUpdColumn As New Dictionary(Of String, String)
        For Each UpdColumn In TargetUpdColumn
          If UpdColumn = "TORIKOMI_JOKYO_FLG" Then
            tmpUpdColumn.Add(UpdColumn, TargetUpdStatus)
          Else
            tmpUpdColumn.Add(UpdColumn, tmpRow(UpdColumn).ToString)
          End If
        Next

        For Each tmpCommunicationDate In TargetCommunicationDate
          tmpUpdColumn.Add(tmpCommunicationDate.Key, tmpCommunicationDate.Value)
        Next

        tmpUpdColumn.Add("UPDATE_DATE", ComGetProcTime)

        '条件項目生成
        Dim tmpWhere As New Dictionary(Of String, String)
        For Each Where In TargetWhere
          tmpWhere.Add(Where, tmpRow(Where).ToString)
        Next

        '更新件数チェック
        Dim cntSql As String = SqlSelGetCount(TargetTableName, tmpWhere)
        Dim tmpCntDt As New DataTable
        SqlServer.GetResult(tmpCntDt, cntSql)
        Dim recCount As Integer = tmpCntDt.Rows(0).Item("CNT").ToString
        '0件チェック
        If recCount = 0 Then
          Throw New Exception("更新対象データが存在しません。")
        End If

        '更新処理
        If TargetTableName IsNot Nothing Then
          If recCount <> SqlServer.Execute(CreateUpdateSql(TargetTableName, tmpUpdColumn, tmpWhere)) Then
            Throw New Exception("更新に失敗しました。")
          End If
        End If

      Next

      SqlServer.TrnCommit()

      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！

      Handy.CloseCommunicationTool()

      ComMessageBox("送信が完了しました。", "確認", typMsgBox.MSG_NORMAL)

      RaiseEvent SendCompleted()

    Catch ex As Exception
      SqlServer.TrnRollBack()
      ComWriteErrLog(ex, False)
      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！
      Handy.CloseCommunicationTool()
    Finally
    End Try
  End Sub

#End Region

  Private Function DateTimeConvert(prmStrDate As String)
    Dim rtn As String
    If String.IsNullOrWhiteSpace(prmStrDate) OrElse prmStrDate.Length <> 14 Then
      Return ""
    End If

    Dim dt As DateTime = DateTime.ParseExact(prmStrDate, "yyyyMMddHHmmss", Nothing)
    rtn = dt.ToString("yyyy/MM/dd HH:mm:ss")

    Return rtn
  End Function


  'なかったので仮に作成したので頂ければ削除！
  Private Function ComCreateInsertItem(prmKeyValuez As Dictionary(Of String, String)) As Dictionary(Of String, String)
    Dim result As New Dictionary(Of String, String)

    ' 列名をカンマ区切りで連結
    Dim keys As String = String.Join(",", prmKeyValuez.Keys)

    ' 値をカンマ区切りで連結（シングルクォートで囲む）
    Dim values As String = String.Join(",", prmKeyValuez.Values.Select(Function(v) $"'{v}'"))

    result("Keyz") = keys
    result("Valuez") = values

    Return result
  End Function

  Private Function SqlSelGetCount(prmTableName As String, prmWhereDic As Dictionary(Of String, String)) As String
    Dim sql As String = String.Empty

    sql &= " SELECT COUNT(*) CNT "
    sql &= " FROM  " & prmTableName

    If prmWhereDic.Count > 0 Then
      sql &= " WHERE "
      sql &= String.Join(" AND ",
        prmWhereDic.Select(Function(kv) $"{kv.Key} = '{kv.Value}'"))
    End If



    Return sql
  End Function

End Class