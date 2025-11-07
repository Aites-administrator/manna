Public Class TxtPriceBase
  Inherits TxtBase

  ' 単価入力専用テキストボックス

#Region "コンストラクタ"
  Public Sub New()
    Me.New(9)
  End Sub

  Public Sub New(prmMaxChar As Integer)
    Me.ImeMode = ImeMode.Alpha        ' IMEモード設定(半角英数字)
    MyBase.SetMaxChar(prmMaxChar)     ' 入力可能最大文字数設定
    Me.TextAlign = HorizontalAlignment.Right
  End Sub

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' キー入力時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtNumericBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    ' 数値とバックスペースとマイナス符号と小数点のみ入力可
    If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
      AndAlso e.KeyChar <> ControlChars.Back _
      AndAlso e.KeyChar <> "-"c _
      AndAlso (e.KeyChar <> "."c OrElse SelectionStart > 3) Then
      e.Handled = True
    End If

  End Sub


#End Region

End Class
