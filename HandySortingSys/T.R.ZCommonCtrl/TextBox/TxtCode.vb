Public Class TxtCode
  Inherits TxtCodeBase

  ' 汎用コード入力テキストボックス

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
  Private Sub TxtMultiName_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    ' IMEモードを半角英数字に
    Me.ImeMode = ImeMode.Alpha
  End Sub

#End Region

End Class
