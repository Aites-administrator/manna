Public Class BtnEnd_L
  Inherits BtnBase


#Region "コンストラクタ"

  ''' <summary>
  ''' 終了ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("終了します。")

    Me.AccessKey = Keys.Escape
    Me.BtnText = "終了"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = Color.Red
    Me.ForeColor = Color.Black
  End Sub

#End Region

End Class
