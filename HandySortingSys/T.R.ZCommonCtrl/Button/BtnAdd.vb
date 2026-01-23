Public Class BtnAdd
  Inherits BtnBase

  ' 新規ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 新規ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを新規追加します。")
    Me.AccessKey = Keys.F5
    Me.BtnText = "新規"

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = ColorTranslator.FromHtml("#4CAF50")
    Me.ForeColor = Color.Black
    Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0


    MakeRoundedButton(Me, 20)
  End Sub


#End Region

End Class
