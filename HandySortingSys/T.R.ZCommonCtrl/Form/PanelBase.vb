Public Class PanelBase
  Inherits Panel

#Region "コンストラクタ"
  Public Sub New()
    ' 共通の色やスタイルをここで指定
    Me.BackColor = SystemColors.ActiveCaption
    Me.BorderStyle = BorderStyle.FixedSingle
  End Sub

#End Region

End Class