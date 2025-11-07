Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
'----------------------------------------------
' 検索タイトル名ラベル
' ＜仮作成＞
'----------------------------------------------

Public Class LabelTitleBase
  Inherits LabelBase

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    Me.Font = New Font("MS UI Gothic", 22)

    Me.BackColor = clsGlobalDataOrder.TITLE_BACKCOLOR

    Me.ForeColor = clsGlobalDataOrder.TITLE_FORECOLOR

    ' ラベルの線の太さ設
    Me.BorderThickness = 0

  End Sub
#End Region

End Class

