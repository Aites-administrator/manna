Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmMainMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String
  Private Const IMAGE_FORDER As String = "IMAGE\"
  Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "MainMenuBackGroundImage.png"
    If IO.File.Exists(path) Then
      Me.BackgroundImage = Image.FromFile(path)
      Me.BackgroundImageLayout = ImageLayout.Stretch
    End If


    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"
    CaptionDateDisp()
  End Sub

  Private Sub frmMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
  End Sub

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M01", "EXE", IniFileName))

  End Sub

  Private Sub BtnMenuBase5_Click(sender As Object, e As EventArgs) Handles BtnMenuBase5.Click
    ComGetProcessByFilePath(GetIniString("M02", "EXE", IniFileName))

  End Sub

  Private Sub BtnMenuBase8_Click(sender As Object, e As EventArgs) Handles BtnMenuBase8.Click
    ComGetProcessByFilePath(GetIniString("M03", "EXE", IniFileName))

  End Sub

  Private Sub BtnMenuBase9_Click(sender As Object, e As EventArgs) Handles BtnMenuBase9.Click
    ComGetProcessByFilePath(GetIniString("M04", "EXE", IniFileName))

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

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_TORIKOMI").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_SEND").ToString()
    LblProcDateTime3.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_RECEIVE").ToString()
    LblProcDateTime4.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_OUTPUT").ToString()
    LblProcDateTime5.Text = ""
    LblProcDateTime6.Text = ""
    LblProcDateTime7.Text = ""
    LblProcDateTime8.Text = ""
    LblProcDateTime9.Text = ""
    LblProcDateTime10.Text = ""
    LblProcDateTime11.Text = ""
    LblProcDateTime12.Text = ""
    LblProcDateTime13.Text = ""

  End Sub
End Class