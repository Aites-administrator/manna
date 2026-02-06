Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef

Public Class frmShukkaCheckRecieveCommunication
  Inherits FormRecieveCommunication
  Private Const RECEIVE_FOLDER As String = "RECEIVE\"
  Private Const RECEIVE_NYUKA_FILE_NAME As String = RECEIVE_FOLDER & "SHOPITEM.DAT"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextDataGrid = DgvList1
    Me.TextDisplayName = "4.出荷検品"
    MyBase.OnLoad(e)
  End Sub


  Private Sub BtnRecieveHandy1_Click(sender As Object, e As EventArgs) Handles BtnRecieveHandy1.Click
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpItemUpdColumn As New List(Of String)

    Try
      'ComMessageBox("ハンディターミナルを送信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      BtnRecieveHandy1.Handy = Handy
      Me.TextHandy = Handy

      Handy.TargetFolder = PROJECT_DIR_NAME & RECEIVE_FOLDER
      BtnRecieveHandy1.TargetFileName = PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME

      Handy.CreateAcquisitionFlag(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME)
      Handy.DeleteAcquisitionFlag()

      '条件項目生成
      tmpWhere.Add("NOUHINBI")
      tmpWhere.Add("JIGYOSHO_CD")
      tmpWhere.Add("JISYA_SHOHIN_CD")

      '更新項目生成
      tmpUpdColumn.Add("KENPIN_GOUKI")
      tmpUpdColumn.Add("KENPIN_TANTO_CD")
      tmpUpdColumn.Add("KENPIN_RECEIVE_DATE")
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      BtnRecieveHandy1.TargetDataGridView = DgvList1
      BtnRecieveHandy1.TargetLenClumn = LenColumnInShukkaCheck
      BtnRecieveHandy1.TargetTableName = "TRN_SHUKKA"
      BtnRecieveHandy1.TargetWhere = tmpWhere
      BtnRecieveHandy1.TargetUpdColumn = tmpUpdColumn
      BtnRecieveHandy1.TargetUpdStatus = CInt(SHUKKA_STATUS.KENPIN_ZUMI)
      BtnRecieveHandy1.TargetItemUpdColumn = tmpItemUpdColumn
      BtnRecieveHandy1.TargetMappingName = "出荷検品データ"
      BtnRecieveHandy1.TargetOutputFileName = "SHUKKA_KENPIN_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub
End Class
