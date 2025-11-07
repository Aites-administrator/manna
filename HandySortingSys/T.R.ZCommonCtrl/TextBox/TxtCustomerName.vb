Public Class TxtCustomerName
  Inherits TxtWideCharBase

  ' 得意先名入力テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 入力可能文字数設定
    'MyBase.New(25)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("25文字まで入力できます。")
  End Sub

#End Region
End Class
