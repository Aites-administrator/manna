Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonCtrl
Public Class SoudashiMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Sub SoudashiMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

    CaptionDateDisp()
    'ボタン設定
    BottonSetting()

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
    BtnMainMenuBase1.Title = "ﾊﾝﾃﾞｨ総出し" & vbCrLf & "送信"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = Color.LightBlue

    BtnMainMenuBase2.Title = "ﾊﾝﾃﾞｨ総出し" & vbCrLf & "受信"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = Color.Blue


  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M02", "EXE", IniFileName))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    ComGetProcessByFilePath(GetIniString("M03", "EXE", IniFileName))

  End Sub
End Class
