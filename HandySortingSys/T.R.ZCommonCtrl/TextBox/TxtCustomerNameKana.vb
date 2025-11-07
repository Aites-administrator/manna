Public Class TxtCustomerNameKana
  Inherits TxtKatakanaHalfBase

#Region "コンストラクタ"
  Public Sub New()
    MyBase.New(10)
    MyBase.SetMsgLabelText("10文字まで入力できます。")
  End Sub
#End Region
End Class
