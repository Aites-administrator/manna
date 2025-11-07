Public Class TxtIriSu
  Inherits TxtNumericBase

  ' 入数入力用テキストボックス
#Region "コンストラクタ"

  Public Sub New()
    ' 数値9桁のみ入力可
    MyBase.New(9, True)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("入数を入力してください。")
  End Sub
#End Region

End Class