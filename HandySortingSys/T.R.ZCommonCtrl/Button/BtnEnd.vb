Public Class BtnEnd
  Inherits BtnBase

  ' 終了ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 終了ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("終了します。")
    Me.AccessKey = Keys.Escape
    Me.BtnText = "終了"

  End Sub

#End Region

End Class
