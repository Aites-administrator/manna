Public Class clsCustomGrid
  Inherits GrapeCity.Win.MultiRow.GcMultiRow

  Protected Overrides Sub WndProc(ByRef m As Message)
　　　　' マウスホイール操作のキャンセル
　　　　Const WM_MOUSEWHEEL As Integer = &H20A
    If m.Msg = WM_MOUSEWHEEL Then
      m.Msg = 0
    End If

    ' 本来の動作の実行
    MyBase.WndProc(m)

  End Sub
End Class