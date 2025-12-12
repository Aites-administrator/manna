Imports T.R.ZCommonClass.clsCommonFnc
Public Class frmMainMenu
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
End Class