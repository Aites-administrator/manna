Public Class TxtNumericPhoneBase
  Inherits TxtBase

  ' 電話(FAX)番号入力専用テキストボックス

#Region "メンバ"
#Region "プライベート"
  Private _InputPoint As Boolean
#End Region
#End Region

#Region "コンストラクタ"
  Public Sub New()
    Me.New(13)
  End Sub

  Public Sub New(prmMaxChar As Integer _
                 , Optional prmInputPoint As Boolean = False)
    Me.ImeMode = ImeMode.Alpha        ' IMEモード設定(半角英数字)
    MyBase.SetMaxChar(prmMaxChar)     ' 入力可能最大文字数設定
    _InputPoint = prmInputPoint
    Me.TextAlign = HorizontalAlignment.Left
  End Sub

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' キー入力時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtNumericBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    ' 数値とバックスペースとマイナス符号のみ入力可
    If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
      AndAlso e.KeyChar <> ControlChars.Back _
      AndAlso e.KeyChar <> "-"c Then
      e.Handled = True
    End If

  End Sub

#End Region

End Class
