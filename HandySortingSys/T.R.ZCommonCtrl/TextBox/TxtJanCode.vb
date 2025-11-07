Public Class TxtJanCode
  Inherits TxtNumericBase

  ' JANコード入力用テキストボックス
#Region "コンストラクタ"

  Public Sub New()
    ' 数値13桁のみ入力可
    MyBase.New(13)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("ＪＡＮコードを入力してください。")
  End Sub
#End Region

End Class