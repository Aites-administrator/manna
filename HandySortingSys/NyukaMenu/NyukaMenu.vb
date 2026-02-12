Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Public Class NyukaMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String
  Private FileName As String = String.Empty

  Private Sub NyukaMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaMenuBackGroundImage.png"
    SetBackGroundImage(Me, path)

    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

    CaptionDateDisp()
    'ボタン設定
    BottonSetting()

  End Sub

  Private Sub NyukaMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
  End Sub


  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_NYUKA_TORIKOMI "
    sql &= "      ,  MAX(SEND_DATE) AS MAX_NYUKA_SEND "
    sql &= "      ,  MAX(RECEIVE_DATE) AS MAX_NYUKA_RECEIVE "
    sql &= "      ,  MAX(OUTPUT_DATE) AS MAX_NYUKA_OUTPUT "
    sql &= " FROM TRN_NYUKA "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_SEND").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_RECEIVE").ToString()
    LblProcDateTime3.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_OUTPUT").ToString()

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "　ﾊﾟｿｺﾝ⇒ﾊﾝﾃﾞｨ" & vbCrLf & "入荷(F1)"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaSendImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#add8e6")
    BtnMainMenuBase1.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase1.AccessKey = Keys.F1

    BtnMainMenuBase2.Title = "　ﾊﾝﾃﾞｨ⇒ﾊﾟｿｺﾝ" & vbCrLf & "入荷(F2)"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaReceiveImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#04cfe3")
    BtnMainMenuBase2.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase2.AccessKey = Keys.F2

    BtnMainMenuBase3.Title = "　入荷検品書(F3)"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaOutputImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#0494e3")
    BtnMainMenuBase3.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase3.AccessKey = Keys.F3

  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    FileName = GetIniString("M02", "EXE", IniFileName)
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M02", "EXE", IniFileName), , True))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    FileName = GetIniString("M03", "EXE", IniFileName)
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M03", "EXE", IniFileName), , True))

  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
    FileName = GetIniString("M04", "EXE", IniFileName)
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M04", "EXE", IniFileName)))
  End Sub

  Private Sub LblProcDateTime1_Click(sender As Object, e As EventArgs) Handles LblProcDateTime1.Click

  End Sub

  Private Sub NyukaMenu_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    KillProcessByFileName(FileName)
  End Sub
End Class
