Public Class TxtOfficeCode
  Inherits TxtNumericBase

  ' 事業所コード入力テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値6桁のみ入力可
    MyBase.New(6)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("事業所コードを入力してください。")
  End Sub
#End Region

End Class
