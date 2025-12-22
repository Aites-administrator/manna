Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass
Public Class frmMasterMaintenance

  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMenuBase1.Click
    Dim tmpstr As String = Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe"
    ComWriteLog(tmpstr, "d:\manna.log")
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , "StartUpControlSam.exe")
  End Sub

  Private Sub BtnMenuBase4_Click(sender As Object, e As EventArgs) Handles BtnMenuBase4.Click
    ComGetProcessByFilePath(GetIniString("M01", "EXE", IniFileName))
  End Sub

  Private Sub frmMasterMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

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

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_TORIKOMI").ToString()
    LblProcDateTime2.Text = ""
    LblProcDateTime3.Text = ""
    LblProcDateTime4.Text = ""
    LblProcDateTime5.Text = ""
    LblProcDateTime6.Text = ""

  End Sub

End Class
