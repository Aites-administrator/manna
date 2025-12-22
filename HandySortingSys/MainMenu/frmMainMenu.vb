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
    BtnMainMenuBase1.Title = "入荷処理"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = Color.LightBlue

    BtnMainMenuBase2.Title = "総出し"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = Color.Blue

    BtnMainMenuBase3.Title = "種まき"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanemakiImage.png")
    BtnMainMenuBase3.ButtonColor = Color.DarkBlue

    BtnMainMenuBase4.Title = "出荷処理"
    BtnMainMenuBase4.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ShukkaCheckImage.png")
    BtnMainMenuBase4.ButtonColor = Color.Aqua

    BtnMainMenuBase5.Title = "棚卸処理"
    BtnMainMenuBase5.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaoroshiImage.png")
    BtnMainMenuBase5.ButtonColor = Color.AliceBlue

    BtnMainMenuBase6.Title = "その他処理"
    BtnMainMenuBase6.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SettingImage.png")
    BtnMainMenuBase6.ButtonColor = Color.Aquamarine
  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M00", "EXE", IniFileName))

  End Sub


  'Private SqlServer As New clsSqlServer
  'Private IniFileName As String
  'Private Const IMAGE_FORDER As String = "IMAGE\"
  'Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  '  Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "MainMenuBackGroundImage.png"
  '  If IO.File.Exists(path) Then
  '    Me.BackgroundImage = Image.FromFile(path)
  '    Me.BackgroundImageLayout = ImageLayout.Stretch
  '  End If


  '  IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"
  '  CaptionDateDisp()
  'End Sub

  'Private Sub frmMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
  '  CaptionDateDisp()
  'End Sub

  'Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs)
  '  ComGetProcessByFilePath(GetIniString("M01", "EXE", IniFileName))

  'End Sub

  'Private Sub BtnMenuBase5_Click(sender As Object, e As EventArgs)
  '  ComGetProcessByFilePath(GetIniString("M02", "EXE", IniFileName))

  'End Sub

  'Private Sub BtnMenuBase8_Click(sender As Object, e As EventArgs)
  '  ComGetProcessByFilePath(GetIniString("M03", "EXE", IniFileName))

  'End Sub

  'Private Sub BtnMenuBase9_Click(sender As Object, e As EventArgs)
  '  ComGetProcessByFilePath(GetIniString("M04", "EXE", IniFileName))

  'End Sub


  'Private Function SqlSelNyukaMaxDate() As String
  '  Dim sql As String = String.Empty

  '  sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_NYUKA_TORIKOMI "
  '  sql &= "      ,  MAX(SEND_DATE) AS MAX_NYUKA_SEND "
  '  sql &= "      ,  MAX(RECEIVE_DATE) AS MAX_NYUKA_RECEIVE "
  '  sql &= "      ,  MAX(OUTPUT_DATE) AS MAX_NYUKA_OUTPUT "
  '  sql &= " FROM TRN_NYUKA "

  '  Return sql

  'End Function

  'Public Sub CaptionDateDisp()
  '  Dim tmpNyukaDt As New DataTable
  '  SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

  '  'LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_TORIKOMI").ToString()
  '  'LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_SEND").ToString()
  '  'LblProcDateTime3.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_RECEIVE").ToString()
  '  'LblProcDateTime4.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_OUTPUT").ToString()
  '  LblProcDateTime5.Text = ""
  '  LblProcDateTime6.Text = ""
  '  LblProcDateTime7.Text = ""
  '  LblProcDateTime8.Text = ""
  '  LblProcDateTime9.Text = ""
  '  LblProcDateTime10.Text = ""
  '  LblProcDateTime11.Text = ""
  '  LblProcDateTime12.Text = ""
  '  LblProcDateTime13.Text = ""

  'End Sub
End Class