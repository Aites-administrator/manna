Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
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
  Public Property TargetLenClumn As List(Of Tuple(Of String, Integer))
  ' プロパティ：更新テーブル
  Public Property TargetTableName As String
  ' プロパティ：更新条件
  Public Property TargetWhere As List(Of String)
  ' プロパティ：更新項目
  Public Property TargetUpdColumn As List(Of String)
  ' プロパティ：更新ステータス
  Public Property TargetUpdStatus As String
  ' プロパティ：通信時間更新
  Public Property TargetCommunicationDate As New Dictionary(Of String, String)

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
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    Dim tmpDt As New DataTable

    Try
      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！

      ''通信ツール開示
      'Handy.OpenCommunicationTool()

      ''状態管理ファイル作成チェック
      'If Not Handy.CreateChkStatusFlagFile() Then
      '  Exit Sub
      'Else
      '  Console.WriteLine("ファイル作成OK")
      'End If
      ''状態管理ファイルチェック
      'If Not Handy.ChkStatusFlagFile() Then
      '  Exit Sub
      'Else
      '  Console.WriteLine("状態管理OK")
      'End If

      'ﾃｽﾄ用に無視するようにしている！！！ここまで！！！


      tmpDt = ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn)

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

        '更新処理
        SqlServer.Execute(CreateUpdateSql(TargetTableName, tmpUpdColumn, tmpWhere))

      Next

      SqlServer.TrnCommit()

      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！

      'Handy.CloseCommunicationTool()

      ComMessageBox("送信が完了しました。", "確認", typMsgBox.MSG_NORMAL)
    Catch ex As Exception
      ComWriteErrLog(ex, False)
      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！
      'Handy.CloseCommunicationTool()
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

End Class