Public Class BtnPrint
  Inherits BtnBase

  ' 印刷ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 印刷ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを印刷します。")
    Me.AccessKey = Keys.F1
    Me.BtnText = "印刷"

  End Sub

#End Region

End Class
