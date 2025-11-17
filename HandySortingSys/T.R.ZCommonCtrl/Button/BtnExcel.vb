Public Class BtnExcel
  Inherits BtnBase

  ' 詳細ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 詳細ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("Excel入力画面を表示します。")
    Me.AccessKey = Keys.F6
    Me.BtnText = "Excel"

  End Sub

#End Region

End Class
