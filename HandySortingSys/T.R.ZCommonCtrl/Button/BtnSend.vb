Public Class BtnSend
  Inherits BtnBase

  ' 送信ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 編集ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを送信します。")
    Me.AccessKey = Keys.F12
    Me.BtnText = "送信"

  End Sub

#End Region

End Class
