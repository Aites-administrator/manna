Public Class BtnDel
  Inherits BtnBase

  ' 削除ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 削除ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを削除します。")
    Me.AccessKey = Keys.F7
    Me.BtnText = "削除"

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = ColorTranslator.FromHtml("#D32F2F")
    Me.ForeColor = Color.Black
    Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0


    MakeRoundedButton(Me, 20)
  End Sub

#End Region

End Class
