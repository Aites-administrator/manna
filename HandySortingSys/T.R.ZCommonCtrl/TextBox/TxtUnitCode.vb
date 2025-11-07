Public Class TxtUnitCode
  Inherits TxtNumericBase

  ' 単位コード入力用テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値3桁のみ入力可
    MyBase.New(3)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("単位コードを入力してください。")
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()
    Me.TextAlign = HorizontalAlignment.Left
  End Sub
#End Region

End Class
