Public Class TxtWideChar
  Inherits TxtWideCharBase

  ' 汎用二バイト文字入力用入力テキストボックス

#Region "コンストラクタ"
  Public Sub New()

  End Sub

#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()
    Me.TextAlign = HorizontalAlignment.Left
  End Sub
#End Region

End Class
