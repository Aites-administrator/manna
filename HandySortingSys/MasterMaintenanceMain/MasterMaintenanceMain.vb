Imports T.R.ZCommonClass
Imports T.R.ZCommonCtrl
Public Class MasterMaintenanceMain
  Private Sub MasterMaintenanceMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim args = Environment.GetCommandLineArgs()

    '    args(0) = 自分自身のEXE
    '    args(1) = COURSE / TANA / TANTO / ITEM
    '    args(2) = （通常なし）
    '

    If args.Length >= 2 Then
      Select Case args(1).ToUpper()

        Case "COURSE"
          Dim frm As New FormComMasterMente(New clsCourseMasterDefine())
          frm.ShowDialog()

        Case "TANA"
          Dim frm As New FormComMasterMente(New clsTanaMasterDefine())
          frm.ShowDialog()

        Case "TANTO"
          Dim frm As New FormComMasterMente(New clsTantoMasterDefine())
          frm.ShowDialog()

        Case "ITEM"
          'Dim frm As New FormComMasterMente(New clsItemMasterDefine())
          'frm.ShowDialog()

        Case Else
          ' 不明な引数 → デフォルトでコース
          Dim frm As New FormComMasterMente(New clsCourseMasterDefine())
          frm.ShowDialog()

      End Select
    Else
      ' 引数なし → デフォルトでコース
      Dim frm As New FormComMasterMente(New clsCourseMasterDefine())
      frm.ShowDialog()
    End If

    ' Me.Close()

    Me.Hide()

  End Sub
End Class
