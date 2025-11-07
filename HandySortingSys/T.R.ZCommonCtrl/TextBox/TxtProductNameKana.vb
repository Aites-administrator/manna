Public Class TxtProductNameKana
  Inherits TxtKatakanaHalfBase

#Region "コンストラクタ"
  Public Sub New()
    MyBase.New(20)
    MyBase.SetMsgLabelText("20文字まで入力できます。")
  End Sub
#End Region
End Class
