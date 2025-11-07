Public Class TxtHalfCharBase
  Inherits TxtBase

  ' バイト文字入力用テキストボックス

#Region "コンストラクタ"
  Public Sub New()

  End Sub

  Public Sub New(prmMaxChar As Integer)
    MyBase.SetMaxChar(prmMaxChar)     ' 入力可能最大文字数設定
  End Sub
#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' アクティブ時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtBase_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    ' IMEモードを半角入力に
    Me.ImeMode = ImeMode.Disable    '半角
  End Sub


#End Region

End Class
