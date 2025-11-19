Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class frmMasterMaintenance
  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMenuBase1.Click
    Dim tmpstr As String = Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe"
    ComWriteLog(tmpstr, "d:\manna.log")
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , "StartUpControlSam.exe")
  End Sub
End Class
