Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMultiCellBase
  Inherits CmbMstBase

#Region "コンストラクタ"
  Public Sub New()

  End Sub

  Public Sub New(prmCodeFormat As String)

    MyBase.New(prmCodeFormat)
    MyBase.DrawMode = DrawMode.OwnerDrawFixed
  End Sub

#End Region

#Region "メソッド"
#Region "プライベート"
  Public Sub AdjustComboListWidth()
    Dim g As Graphics = MyBase.CreateGraphics()
    Dim f As Font = MyBase.Font
    Dim max As Single = MyBase.Width
    Dim s As String

    For Each s In MyBase.Items
      max = Math.Max(max, g.MeasureString(s, f).Width)
    Next

    MyBase.DropDownWidth = CInt(max)
  End Sub
#End Region
#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' アイテム描画時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks>
  ''' 選択リストにコードと名称を横並び2列で表示する
  ''' </remarks>
  Private Sub ComboBox1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
    Dim cb As ComboBox = DirectCast(sender, ComboBox)
    Dim dt As DataTable = MyBase.DataSource

    Dim bLineX As Single
    Dim p As Pen = New Pen(Color.Gray)
    Dim b As Brush = New SolidBrush(e.ForeColor)

    e.DrawBackground()

    e.Graphics.DrawString(Convert.ToString(dt.Rows(e.Index)("ItemCode")), e.Font, b, e.Bounds.X, e.Bounds.Y)

    Dim g As Graphics = cb.CreateGraphics()
    Dim sf As SizeF = g.MeasureString(New String("0"c, dt.Rows(0)("ItemCode").ToString().Length), cb.Font)
    g.Dispose()

    bLineX = sf.Width
    e.Graphics.DrawLine(p, bLineX, e.Bounds.Top, bLineX, e.Bounds.Bottom)

    e.Graphics.DrawString(Convert.ToString(dt.Rows(e.Index)("SecondCell")), e.Font, b, bLineX, e.Bounds.Y)

    'e.DrawFocusRectangle()
    If CBool(e.State And DrawItemState.Selected) Then ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds)

  End Sub

  ''' <summary>
  ''' キー入力時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks>
  ''' 数字とバックスペースのみ入力可
  ''' </remarks>
  Private Sub CmbDateBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
        AndAlso e.KeyChar <> ControlChars.Back Then
      e.Handled = True
    End If

  End Sub

#End Region

End Class
