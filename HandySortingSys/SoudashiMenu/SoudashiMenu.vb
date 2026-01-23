Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonCtrl
Public Class SoudashiMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Sub SoudashiMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "SoudashiMenuBackGroundImage.png"
    SetBackGroundImage(Me, path)

    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

    CaptionDateDisp()
    'ボタン設定
    BottonSetting()

  End Sub

  Private Sub SoudashiMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
  End Sub


  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_SHUKKA_TORIKOMI "
    sql &= "      ,  MAX(SOUDASHI_SEND_DATE) AS MAX_SHUKKA_SEND	 "
    sql &= "      ,  MAX(SOUDASHI_RECEIVE_DATE) AS MAX_SHUKKA_RECEIVE  "
    sql &= " FROM TRN_SHUKKA "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_SHUKKA_SEND").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_SHUKKA_RECEIVE").ToString()

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "ﾊﾟｿｺﾝ⇒ﾊﾝﾃﾞｨ" & vbCrLf & "総出し(F1)"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaSendImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#add8e6")
    BtnMainMenuBase1.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase1.AccessKey = Keys.F1

    BtnMainMenuBase2.Title = "　ﾊﾝﾃﾞｨ⇒ﾊﾟｿｺﾝ" & vbCrLf & "総出し(F2)"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaReceiveImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#04cfe3")
    BtnMainMenuBase2.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase2.AccessKey = Keys.F2

  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M12", "EXE", IniFileName)))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M13", "EXE", IniFileName)))

  End Sub

End Class
