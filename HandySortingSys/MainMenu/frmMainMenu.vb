Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmMainMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String
  Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "MainMenuBackGroundImage.png"
    If IO.File.Exists(path) Then
      Me.BackgroundImage = Image.FromFile(path)
      Me.BackgroundImageLayout = ImageLayout.Stretch
    End If

    path = PROJECT_DIR_NAME & IMAGE_FORDER & "information.png"
    If IO.File.Exists(path) Then

      PanelBase1.BackColor = ColorTranslator.FromHtml("#212480")
      With Label18
        .Text = "Information"
        .ForeColor = Color.White
        .Font = New Font("Meiryo UI", 24, FontStyle.Bold)
        .BackColor = Color.Transparent
      End With

      With PictureBox1
        .Image = Image.FromFile(path)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        .BackColor = Color.Transparent
      End With
    End If

    'ボタン設定
    BottonSetting()

    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"
    CaptionDateDisp()
  End Sub

  Private Sub frmMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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


  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "F1:入荷処理"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#dce7f8")
    BtnMainMenuBase1.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase1.SetAccessKey = Keys.F1

    BtnMainMenuBase2.Title = "F2:総出し"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#83a0df")
    BtnMainMenuBase2.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase2.SetAccessKey = Keys.F2

    BtnMainMenuBase3.Title = "F3:種まき"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanemakiImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#335294")
    BtnMainMenuBase3.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase3.SetAccessKey = Keys.F3

    BtnMainMenuBase4.Title = "F4:出荷処理"
    BtnMainMenuBase4.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ShukkaCheckImage.png")
    BtnMainMenuBase4.ButtonColor = ColorTranslator.FromHtml("#5ddee6")
    BtnMainMenuBase4.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase4.SetAccessKey = Keys.F4

    BtnMainMenuBase5.Title = "F5:棚卸処理"
    BtnMainMenuBase5.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaoroshiImage.png")
    BtnMainMenuBase5.ButtonColor = ColorTranslator.FromHtml("#3156f1")
    BtnMainMenuBase5.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase5.SetAccessKey = Keys.F5

    BtnMainMenuBase6.Title = "F6:その他処理"
    BtnMainMenuBase6.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SettingImage.png")
    BtnMainMenuBase6.ButtonColor = ColorTranslator.FromHtml("#7d82f7")
    BtnMainMenuBase6.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase6.SetAccessKey = Keys.F6
  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M00", "EXE", IniFileName))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    ComGetProcessByFilePath(GetIniString("M10", "EXE", IniFileName))
  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
    ComGetProcessByFilePath(GetIniString("M20", "EXE", IniFileName))
  End Sub
End Class