Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonCtrl
Public Class TanaoroshiMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Sub TanaoroshiMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "TanaMenuBackGroundImage.png"
    SetBackGroundImage(Me, path)

    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

    CaptionDateDisp()
    'ボタン設定
    BottonSetting()

  End Sub

  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_SHUKKA_TORIKOMI "
    sql &= "      ,  MAX(SEND_DATE) AS MAX_SHUKKA_SEND	 "
    sql &= "      ,  MAX(RECEIVE_DATE) AS MAX_SHUKKA_RECEIVE  "
    sql &= " FROM TRN_TANAOROSHI "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_SHUKKA_SEND").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_SHUKKA_RECEIVE").ToString()

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "ﾊﾟｿｺﾝ⇒ﾊﾝﾃﾞｨ" & vbCrLf & "棚卸(F1)"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaSendImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#add8e6")
    BtnMainMenuBase1.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase1.AccessKey = Keys.F1

    BtnMainMenuBase2.Title = "ﾊﾝﾃﾞｨ⇒ﾊﾟｿｺﾝ" & vbCrLf & "棚卸(F2)"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaReceiveImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#04cfe3")
    BtnMainMenuBase2.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase2.AccessKey = Keys.F2

    BtnMainMenuBase3.Title = "　棚卸報告書(F3)"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaOutputImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#0494e3")
    BtnMainMenuBase3.Font = New Font("Meiryo", 20, FontStyle.Bold)
    BtnMainMenuBase3.AccessKey = Keys.F3

  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M42", "EXE", IniFileName))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    ComGetProcessByFilePath(GetIniString("M43", "EXE", IniFileName))
  End Sub

End Class
