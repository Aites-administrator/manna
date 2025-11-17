Public Class BtnEnabled
  Inherits BtnBase

  ' 使用可/不可ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 使用可/不可ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("使用可/不可を切替ます。")
    Me.AccessKey = Keys.F7
    Me.BtnText = "使用可/不可"
  End Sub

#End Region

End Class
