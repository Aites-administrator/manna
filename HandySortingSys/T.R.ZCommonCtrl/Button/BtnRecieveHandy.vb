Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports ClsHandyCommunication

Public Class BtnRecieveHandy
  Inherits BtnBase

#Region "プライベート"
  Private OUTPUT_DIR_NAME As String = "OUTPUT\"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：ファイル名
  Public Property TargetFileName As String

  ' プロパティ：出力ファイル名
  Public Property TargetOutputFileName As String
  Public Property Handy As New ClsHandyCommunication.clsHandyCommunication(TargetFileName)
  ' プロパティ：データグリッド
  Public Property TargetDataGridView As DgvList
  ' プロパティ：項目長
  Public Property TargetLenClumn As New List(Of Tuple(Of String, Integer))
  ' プロパティ：更新テーブル
  Public Property TargetTableName As String
  ' プロパティ：更新条件
  Public Property TargetWhere As New List(Of String)
  ' プロパティ：更新項目
  Public Property TargetUpdColumn As New List(Of String)
  ' プロパティ：更新項目
  Public Property TargetItemUpdColumn As New List(Of String)
  ' プロパティ：更新ステータス
  Public Property TargetUpdStatus As String
  ' プロパティ：通信時間更新
  Public Property TargetCommunicationDate As New Dictionary(Of String, String)
  ' プロパティ：マッピング名
  Public Property TargetMappingName As String

  ' 受信完了イベント
  Public Event ReceiveCompleted()
#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 受信ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("受信を行います。")

    Me.AccessKey = Keys.F6
    Me.BtnText = "受信"
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
    Try

      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！

      '通信ツール開示
      Handy.OpenCommunicationTool()

      Dim TargetReceiveFlg As Boolean = False
      Handy.WatchAndReceiveFiles(TargetFileName, TargetReceiveFlg)

      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！
      Handy.CloseCommunicationTool()



      ''状態管理ファイル作成チェック
      'If Not Handy.WaitCommunicationFlagCreated() Then
      '  Exit Sub
      'Else
      '  Console.WriteLine("ファイル作成OK")

      'End If
      ''状態管理ファイルチェック
      'If Not Handy.WaitCommunicationFlagDeleted() Then
      '  Exit Sub
      'Else
      '  Console.WriteLine("状態管理OK")
      'End If
      'ﾃｽﾄ用に無視するようにしている！！！ここまで！！！

      WriteProgressLog($"取込ファイル準備開始: {TargetFileName}")

      tmpDt = ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn)

      Dim mapper As New clsDtHeaderMapping

      Dim tmpDtJP As New DataTable
      tmpDtJP = mapper.ConvertColumnNamesToJapanese(ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn), TargetMappingName)
      TargetDataGridView.TargetColumnName = "取込状況FLG"
      TargetDataGridView.SetData(tmpDtJP)

      WriteProgressLog($"取込ファイルをGridに表示完了: {TargetFileName}")

      Handy.MoveToBackupFolder(TargetFileName)

      SqlServer.TrnStart()

      WriteProgressLog($"データベース更新開始:")

      For Each tmpRow In tmpDt.Rows

        ''検証用にJAN、ITFが空の場合無視する 本番では不要
        'If String.IsNullOrWhiteSpace(tmpRow("JAN").ToString) AndAlso
        '  String.IsNullOrWhiteSpace(tmpRow("ITF").ToString) Then
        '  Continue For
        'End If

        '更新項目生成
        Dim tmpUpdColumn As New Dictionary(Of String, String)
        For Each UpdColumn In TargetUpdColumn
          If UpdColumn = "TORIKOMI_JOKYO_FLG" Then
            If tmpRow("TORIKOMI_JOKYO_FLG").ToString = "1" Then
              tmpUpdColumn.Add(UpdColumn, TargetUpdStatus)
            End If
            If TargetTableName <> "TRN_NYUKA" _
              OrElse TargetTableName <> "TRN_TANAOROSHI" Then
              Continue For
            End If
          ElseIf UpdColumn.Contains("RECEIVE_DATE") Then
            If Not String.IsNullOrEmpty(tmpRow(UpdColumn).ToString()) Then
              tmpUpdColumn.Add(UpdColumn, DateTimeConvert(tmpRow(UpdColumn).ToString))
            End If
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

        '条件項目生成
        If TargetItemUpdColumn.Count <> 0 Then
          Dim tmpItemUpdColumn As New Dictionary(Of String, String)
          For Each ItemUpdColumn In TargetItemUpdColumn
            tmpItemUpdColumn.Add(ItemUpdColumn, tmpRow(ItemUpdColumn).ToString)
          Next

          tmpWhere.Clear()
          tmpWhere.Add("SHOHIN_CD", tmpRow("JISYA_SHOHIN_CD").ToString)

          '更新処理
          SqlServer.Execute(CreateUpdateSql("MST_ITEM", tmpItemUpdColumn, tmpWhere))

        End If


      Next

      SqlServer.TrnCommit()

      'Excel出力
      DataTable2Excel(tmpDtJP, PROJECT_DIR_NAME & OUTPUT_DIR_NAME & TargetOutputFileName)

      ComMessageBox("受信が完了しました。", "確認", typMsgBox.MSG_NORMAL)
      RaiseEvent ReceiveCompleted()

    Catch ex As Exception
      SqlServer.TrnRollBack()
      ComWriteErrLog(ex, False)
      'ﾃｽﾄ用に無視するようにしている！！！ここから！！！
      Handy.CloseCommunicationTool()
    Finally
    End Try
  End Sub

#End Region

#Region "ファンクション"
  Private Function DateTimeConvert(prmStrDate As String)
    Dim rtn As String
    If String.IsNullOrWhiteSpace(prmStrDate) OrElse prmStrDate.Length <> 14 Then
      Return ""
    End If

    Dim dt As DateTime = DateTime.ParseExact(prmStrDate, "yyyyMMddHHmmss", Nothing)
    rtn = dt.ToString("yyyy/MM/dd HH:mm:ss")

    Return rtn
  End Function
  Private Function SqlUpdItem(prmItemCd As String) As String
    Dim sql As String = String.Empty

    sql += " UPDATE MST_ITEM "
    sql += " WHERE ITEM_CODE = '" & prmItemCd & "'"

    Return sql
  End Function
#End Region



End Class