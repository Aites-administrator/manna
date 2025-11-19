Public Class BtnCancel
  Inherits BtnBase

#Region "コンストラクタ"

  ''' <summary>
  ''' 複写ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("キャンセルします。")
    Me.AccessKey = Keys.F1
    Me.BtnText = "キャンセル"

  End Sub

#End Region

End Class
