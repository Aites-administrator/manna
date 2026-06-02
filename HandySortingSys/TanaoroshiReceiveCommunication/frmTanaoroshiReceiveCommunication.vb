Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Public Class frmTanaoroshiReceiveCommunication
  Inherits FormRecieveCommunication
  Private Const RECEIVE_FOLDER As String = "RECEIVE\"
  Private Const RECEIVE_NYUKA_FILE_NAME As String = RECEIVE_FOLDER & "IN_TANA.DAT"
  Private SqlServer As New clsSqlServer
  Private Const DATE_LIST_TABLE_NAME As String = "TANAOROSHI_ZUMI_DATE_LIST"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextDataGrid = DgvList1

    Me.TextDisplayName = "6.棚卸作業"
    AddHandler BtnRecieveHandy1.ReceiveCompleted, AddressOf AfterReceiveProcess
    MyBase.OnLoad(e)
  End Sub

  Private Sub AfterReceiveProcess()
    '日付登録
    Try

      SqlServer.Execute(BtnRecieveHandy1.SqlInsDateList(DATE_LIST_TABLE_NAME, BtnRecieveHandy1.DATE_LIST))
      SqlServer.Execute(BtnRecieveHandy1.SqlDelDateList(DATE_LIST_TABLE_NAME))

    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub

  Private Sub BtnRecieveHandy1_Click(sender As Object, e As EventArgs) Handles BtnRecieveHandy1.Click
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpItemUpdColumn As New List(Of String)

    Try
      'ComMessageBox("ハンディターミナルを送信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)
      ShowProcessing("データ取得中…")

      BtnRecieveHandy1.Handy = Handy
      Me.TextHandy = Handy

      Handy.TargetFolder = PROJECT_DIR_NAME & RECEIVE_FOLDER
      BtnRecieveHandy1.TargetFileName = PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME

      Handy.CreateAcquisitionFlag(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME)
      Handy.DeleteAcquisitionFlag()

      '条件項目生成
      tmpWhere.Add("TANAOROSHI_DATE")
      tmpWhere.Add("SAGYO_YOTEI_DATE")
      tmpWhere.Add("JISYA_SHOHIN_CD")

      '更新項目生成
      tmpUpdColumn.Add("GOUKI")
      tmpUpdColumn.Add("TANTO_CD")
      tmpUpdColumn.Add("RECEIVE_DATE")
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")
      tmpUpdColumn.Add("TANA_JISSEKI_CASE")
      tmpUpdColumn.Add("TANA_JISSEKI_BARA")

      '商品更新項目生成
      tmpItemUpdColumn.Add("SHOMIKIGEN")

      BtnRecieveHandy1.TargetDataGridView = DgvList1
      BtnRecieveHandy1.TargetLenClumn = LenColumnInTanaoroshi
      BtnRecieveHandy1.TargetTableName = "TRN_TANAOROSHI"
      BtnRecieveHandy1.TargetWhere = tmpWhere
      BtnRecieveHandy1.TargetUpdColumn = tmpUpdColumn
      BtnRecieveHandy1.TargetUpdStatus = CInt(TANAOROSHI_STATUS.TANAOROSHI_ZUMI)
      BtnRecieveHandy1.TargetItemUpdColumn = tmpItemUpdColumn
      BtnRecieveHandy1.TargetMappingName = "棚卸予定データ"
      BtnRecieveHandy1.TargetOutputFileName = "TANA_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"

    Catch ex As Exception
      AfterReceiveProcess()
      ComWriteErrLog(ex, False)
    End Try

  End Sub


End Class
