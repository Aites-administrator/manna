Public Class TxtPostCode
  Inherits TxtBase

#Region "コンストラクタ"
  Public Sub New()
    MyBase.New("999-9999".Length)
  End Sub
#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' アクティブ時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtBase_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    ' IMEモードをOFFに
    'Me.ImeMode = ImeMode.Off
  End Sub

#End Region

End Class
