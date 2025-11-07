Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
'----------------------------------------------
' 検索タイトル名ラベル
' ＜仮作成＞
'----------------------------------------------

Public Class LabelGridTitleBase
  Inherits LabelBase

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    Me.BackColor = clsGlobalDataOrder.GRIDLABEL_BACKCOLOR

    Me.ForeColor = clsGlobalDataOrder.GRIDLABEL_FORECOLOR

    ' ラベルの線の太さ設定
    Me.BorderThickness = 2

    Me.BorderColor = clsGlobalDataOrder.GRIDLABEL_BORDERCOLOR


  End Sub
#End Region


End Class

