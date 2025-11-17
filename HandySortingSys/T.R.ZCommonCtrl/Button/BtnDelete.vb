Public Class BtnDelete
  Inherits BtnBase

  ' 削除ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 削除ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを削除します。")
    Me.AccessKey = Keys.F7
    Me.BtnText = "削除"

  End Sub

#End Region

End Class
