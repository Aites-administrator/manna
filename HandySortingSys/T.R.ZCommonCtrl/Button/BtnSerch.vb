Public Class BtnSerch
  Inherits BtnBase

  ' 集計検索ボタン

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    Me.Size = New Size(180, 48)

    ' 画像を設定
    Me.Image = My.Resources.ButtonFuncBig

    SetText2("集計検索")

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("ボタン押下で集計検索を行います。")
  End Sub

#End Region

End Class