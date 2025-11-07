Public Class TxtLabel
  Inherits TxtWideCharBase

  ' 書き込み不可テキストボックス
#Region "コンストラクタ"

  Public Sub New()

    Me.ReadOnly = True
    Me.BackColor = Color.White

  End Sub

#End Region

End Class
