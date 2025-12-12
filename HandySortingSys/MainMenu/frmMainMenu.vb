Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Public Class frmMainMenu
  Private SqlServer As New clsSqlServer

  Private Sub frmMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
  End Sub

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMenuBase1.Click

    ComGetProcessByFilePath(GetIniString("M01", "EXE", "D:\manna\INI\menu.ini"))

  End Sub

  Private Sub BtnMenuBase5_Click(sender As Object, e As EventArgs) Handles BtnMenuBase5.Click
    ComGetProcessByFilePath(GetIniString("M02", "EXE", "D:\manna\INI\menu.ini"))

  End Sub

  Private Sub BtnMenuBase8_Click(sender As Object, e As EventArgs) Handles BtnMenuBase8.Click
    ComGetProcessByFilePath(GetIniString("M03", "EXE", "D:\manna\INI\menu.ini"))

  End Sub

  Private Sub BtnMenuBase9_Click(sender As Object, e As EventArgs) Handles BtnMenuBase9.Click
    ComGetProcessByFilePath(GetIniString("M04", "EXE", "D:\manna\INI\menu.ini"))

  End Sub

  Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CaptionDateDisp()
  End Sub

  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_NYUKA_TORIKOMI "
    sql &= "      ,  MAX(SEND_DATE) AS MAX_NYUKA_SEND "
    sql &= "      ,  MAX(RECEIVE_DATE) AS MAX_NYUKA_RECEIVE "
    sql &= " FROM TRN_NYUKA "

    Return sql

  End Function

  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_TORIKOMI").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_SEND").ToString()
    LblProcDateTime3.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_RECEIVE").ToString()

  End Sub
End Class