Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
'----------------------------------------------
' 検索タイトル名ラベル
' ＜仮作成＞
'----------------------------------------------
Public Class LabelSearchNameBase
  Inherits LabelBase

  ''' <summary>
  ''' コントロール配置
  ''' </summary>
  Protected Overrides Sub InitLayout()

    ' フォント設定
    Me.Font = New Font("MS UI Gothic", 14, FontStyle.Bold)

    ' 背景色の設定
    Me.BackColor = clsGlobalDataOrder.SERCHLABEL_BACKCOLOR

    ' 文字色の設定
    Me.ForeColor = clsGlobalDataOrder.SERCHLABEL_FORECOLOR

    ' ラベルの線の太さ設定
    Me.BorderThickness = 0

  End Sub

End Class

