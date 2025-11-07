Public Class TxtPhone
  Inherits TxtNumericBase

  ' 得意先電話番号入力用テキストボックス
#Region "コンストラクタ"

  Public Sub New()
    ' 数値12桁のみ入力可
    MyBase.New(12)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先電話番号を入力してください。")
  End Sub
#End Region

End Class
