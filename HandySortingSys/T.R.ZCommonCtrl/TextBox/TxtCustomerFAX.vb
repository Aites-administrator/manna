Public Class TxtCustomerFAX
  Inherits TxtNumericBase

  ' 得意先FAX番号入力用テキストボックス


#Region "コンストラクタ"

  Public Sub New()
    ' 数値8桁のみ入力可
    MyBase.New(8)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先FAX番号を入力してください。")
  End Sub
#End Region




End Class
