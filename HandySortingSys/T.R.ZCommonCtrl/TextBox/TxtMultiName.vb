Public Class TxtMultiName
  Inherits TxtWideCharBase

  ' 汎用入力テキストボックス

#Region "イベントプロシージャー"

  ''' <summary>
  ''' アクティブ時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtMultiName_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    ' IMEモードを全角入力に
    Me.ImeMode = ImeMode.Hiragana     'ひらがな
  End Sub

#End Region

End Class
