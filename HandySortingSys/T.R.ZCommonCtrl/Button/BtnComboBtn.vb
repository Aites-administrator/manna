Imports T.R.ZCommonClass

Public Class BtnComboBtn
  Inherits BtnBase

  '----------------------------------------------
  ' 汎用コンボボックス画面表示用ボタン
  '
  '----------------------------------------------

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    Me.Text = ""

    ' 画像を設定
    Me.Image = My.Resources.CMBBTN

    ' ボタンの背景色の設定
    Me.BackColor = clsGlobalDataOrder.BUTTON_BACKCOLOR

  End Sub
#End Region

End Class