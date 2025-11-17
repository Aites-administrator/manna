Public Class BtnAddNew
  Inherits BtnBase

  ' 新規ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 新規ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを新規追加します。")
    Me.AccessKey = Keys.F5
    Me.BtnText = "新規"

  End Sub


#End Region

End Class
