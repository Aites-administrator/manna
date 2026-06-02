Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Public Class frmNyukaReceiveCommunication
  Inherits FormRecieveCommunication

  'test用
  Private _isFirstActivated As Boolean = True


  Private Const RECEIVE_FOLDER As String = "RECEIVE\"
  Private Const RECEIVE_NYUKA_FILE_NAME As String = RECEIVE_FOLDER & "IN_ITEM.DAT"
  Private SqlServer As New clsSqlServer
  Private Const DATE_LIST_TABLE_NAME As String = "NYUKA_ZUMI_DATE_LIST"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextDataGrid = DgvList1

    Me.TextDisplayName = "1.入荷検品"
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

      BtnRecieveHandy1.TargetDataGridView = DgvList1
      BtnRecieveHandy1.TargetLenClumn = LenColumnInNyuka
      BtnRecieveHandy1.TargetTableName = "TRN_NYUKA"
      BtnRecieveHandy1.TargetWhere = tmpWhere
      BtnRecieveHandy1.TargetUpdColumn = tmpUpdColumn
      BtnRecieveHandy1.TargetUpdStatus = CInt(NYUKA_STATUS.KEPINZUMI)
      BtnRecieveHandy1.TargetItemUpdColumn = tmpItemUpdColumn
      BtnRecieveHandy1.TargetMappingName = "入荷予定データ"
      BtnRecieveHandy1.TargetOutputFileName = "NYUKA_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"

    Catch ex As Exception
      HideProcessing()
      ComWriteErrLog(ex, False)
    End Try

  End Sub

  'Private Sub frmNyukaReceiveCommunication_Activated(sender As Object, e As EventArgs) Handles Me.Activated
  '  If _isFirstActivated Then
  '    _isFirstActivated = False
  '    Return   ' ← 初回は何もせず終了
  '  End If

  '  Me.BtnRecieveHandy1.PerformClick()

  'End Sub
End Class
