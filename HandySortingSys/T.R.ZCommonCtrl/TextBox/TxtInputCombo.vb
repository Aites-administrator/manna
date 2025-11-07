Public Class TxtInputCombo
  Inherits TxtBase

  ' 印刷ＦＬＧ入力用テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("印刷ＦＬＧを入力してください。")
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()
    Me.TextAlign = HorizontalAlignment.Left
  End Sub
#End Region

End Class
