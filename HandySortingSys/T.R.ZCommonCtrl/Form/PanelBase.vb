
Imports System.Drawing.Drawing2D
Public Class PanelBase
  Inherits Panel

  Public Property BorderColor As Color = Color.Black
  Public Property BorderWidth As Integer = 2
  Public Property CornerRadius As Integer = 30


#Region "コンストラクタ"
  Public Sub New()
    ' 共通の色やスタイルをここで指定
    Me.BackColor = SystemColors.ActiveCaption
    Me.BorderStyle = BorderStyle.None
  End Sub

#End Region

  Private Sub Panel1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    UpdateRegion()
    Me.Invalidate()

  End Sub

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    MyBase.OnPaint(e)

    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    Dim rect = Me.ClientRectangle
    rect.Inflate(-1, -1)

    Using path As GraphicsPath = CreateRoundedPath(rect, CornerRadius)
      Using pen As New Pen(BorderColor, BorderWidth)
        pen.Alignment = PenAlignment.Inset
        e.Graphics.DrawPath(pen, path)
      End Using
    End Using

  End Sub



  Private Sub UpdateRegion()
    Dim path As GraphicsPath = CreateRoundedPath(Me.ClientRectangle, CornerRadius)
    Me.Region = New Region(path)
  End Sub

  Private Function CreateRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
    Dim path As New GraphicsPath()
    Dim d = radius * 2

    ' 左上
    path.AddArc(rect.X, rect.Y, d, d, 180, 90)
    ' 右上
    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)

    ' 右下（直線）
    path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom)

    ' 左下（直線）
    path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)

    ' 左上へ戻る（直線）
    path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + radius)

    'path.AddArc(rect.X, rect.Y, d, d, 180, 90)
    'path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
    'path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
    'path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
    path.CloseFigure()

    Return path
  End Function


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