
Imports System.Drawing.Drawing2D
Public Class PanelBase
  Inherits Panel

#Region "コンストラクタ"
  Public Sub New()
    ' 共通の色やスタイルをここで指定
    Me.BackColor = SystemColors.ActiveCaption
    Me.BorderStyle = BorderStyle.FixedSingle
  End Sub

#End Region

  Private Sub Panel1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    MakeRoundedPanel(Me, 30)
  End Sub

  Private Sub MakeRoundedPanel(pnl As Panel, radius As Integer)
    Dim path As New GraphicsPath()
    path.AddArc(0, 0, radius, radius, 180, 90)
    path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90)
    path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90)
    path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90)
    path.CloseAllFigures()
    pnl.Region = New Region(path)
  End Sub
End Class