Public Class BtnDetail
  Inherits BtnBase

  ' 詳細ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 詳細ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("詳細データを表示します。")
    Me.AccessKey = Keys.F6
    Me.BtnText = "詳細"

  End Sub

#End Region
End Class
