Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Public Class frmNyukaReceiveCommunication
  Inherits FormCommunication

  Private Const RECEIVE_FOLDER As String = "RECEIVE\"
  Private Const RECEIVE_NYUKA_FILE_NAME As String = RECEIVE_FOLDER & "IN_ITEM.DAT"

  Private Sub BtnRecieveHandy1_Click(sender As Object, e As EventArgs) Handles BtnRecieveHandy1.Click
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpItemUpdColumn As New List(Of String)

    Try
      'ComMessageBox("ハンディターミナルを送信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      Handy.CreateCommnicationFile(PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME, PROJECT_DIR_NAME & RECEIVE_FOLDER)
      Handy.DeleteCommnicationFile()

      '条件項目生成
      tmpWhere.Add("HACHU_NO")
      tmpWhere.Add("GYO_NO")

      '更新項目生成
      tmpUpdColumn.Add("GOUKI")
      tmpUpdColumn.Add("TANTO_CD")
      tmpUpdColumn.Add("RECEIVE_DATE")
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")
      tmpUpdColumn.Add("NYUKA_JISSEKISU_MAKER")
      tmpUpdColumn.Add("NYUKA_JISSEKISU_JISYA")

      '商品更新項目生成
      tmpItemUpdColumn.Add("SHOMIKIGEN")

      BtnRecieveHandy1.Handy = Handy
      BtnRecieveHandy1.TargetFileName = PROJECT_DIR_NAME & RECEIVE_NYUKA_FILE_NAME
      BtnRecieveHandy1.TargetDataGridView = DgvList1
      BtnRecieveHandy1.TargetLenClumn = LenColumnInNyuka
      BtnRecieveHandy1.TargetTableName = "TRN_NYUKA"
      BtnRecieveHandy1.TargetWhere = tmpWhere
      BtnRecieveHandy1.TargetUpdColumn = tmpUpdColumn
      BtnRecieveHandy1.TargetUpdStatus = CInt(NYUKA_STATUS.KEPINZUMI)
      BtnRecieveHandy1.TargetItemUpdColumn = tmpItemUpdColumn
      BtnRecieveHandy1.TargetOutputFileName = "OUTPUT_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

End Class
