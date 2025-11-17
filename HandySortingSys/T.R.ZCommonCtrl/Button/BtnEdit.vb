Public Class BtnEdit
  Inherits BtnBase

  ' 編集ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 編集ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを編集します。")
    Me.AccessKey = Keys.F3
    Me.BtnText = "編集"

  End Sub

#End Region

End Class
