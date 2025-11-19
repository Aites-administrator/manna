Public Class BtnOk
  Inherits BtnBase

#Region "コンストラクタ"

  ''' <summary>
  ''' 複写ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("OK")
    Me.AccessKey = Keys.F2
    Me.BtnText = "OK"

  End Sub

#End Region

End Class
