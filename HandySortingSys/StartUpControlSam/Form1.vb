Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData

Public Class Form1

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    ' 起動元モジュール確認
    ' パスワード入力画面以外から起動の場合はプログラムを終了する
    If False = ValidateParentModuleName() Then
      Me.Close()
    End If

  End Sub
End Class
