Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass
Imports T.R.ZCommonCtrl
Public Class frmMasterMaintenance
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Const MAX_NYUKA_TORIKOMI As Integer = 0
  Private Const MAX_SHUKKA_TORIKOMI As Integer = 1

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMenuBase1.Click
    'Dim tmpstr As String = Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe"
    'ComWriteLog(tmpstr, "d:\manna.log")
    'Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
    '                          , "StartUpControlSam.exe")
  End Sub

  Private Sub BtnMenuBase4_Click(sender As Object, e As EventArgs) Handles BtnMenuBase4.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M01", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMenuBase3.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M11", "EXE", IniFileName)))

  End Sub


  Private Sub frmMasterMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

    CaptionDateDisp()

  End Sub
  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM TRN_NYUKA "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM TRN_SHUKKA "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(MAX_NYUKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(MAX_SHUKKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
    LblProcDateTime3.Text = ""
    LblProcDateTime4.Text = ""
    LblProcDateTime5.Text = ""
    LblProcDateTime6.Text = ""
    LblProcDateTime7.Text = ""
    LblProcDateTime8.Text = ""
    LblProcDateTime9.Text = ""

  End Sub

End Class
