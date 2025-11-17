Public Class DgvCCC
  Inherits DataGridView

  <System.Security.Permissions.UIPermission(
      System.Security.Permissions.SecurityAction.Demand,
      Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)>
  Protected Overrides Function ProcessDialogKey(
          ByVal keyData As Keys) As Boolean
    If (keyData And Keys.KeyCode) = Keys.Enter _
        AndAlso MyBase.CurrentCell.RowIndex = (MyBase.Rows.Count - 1) Then
      Dim tmpCurrentCell = MyBase.CurrentCell

      Return Me.ProcessTabKey(keyData)
    End If
    Return MyBase.ProcessDialogKey(keyData)
  End Function

  <System.Security.Permissions.SecurityPermission(
      System.Security.Permissions.SecurityAction.Demand,
      Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)>
  Protected Overrides Function ProcessDataGridViewKey(
          ByVal e As KeyEventArgs) As Boolean
    'Enterキーが押された時は、Tabキーが押されたようにする
    If e.KeyCode = Keys.Enter _
        AndAlso MyBase.CurrentCell.RowIndex = (MyBase.Rows.Count - 1) Then
      Dim tmpCurrentCell = MyBase.CurrentCell
      '  MyBase.EndEdit()
      '  MyBase.CurrentCell = Nothing
      '  MyBase.CurrentCell = tmpCurrentCell
      '  Return True
      Return Me.ProcessTabKey(e.KeyCode)
    End If
    Return MyBase.ProcessDataGridViewKey(e)
  End Function


End Class
