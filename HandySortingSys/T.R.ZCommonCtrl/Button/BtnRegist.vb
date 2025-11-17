Public Class BtnRegist
  Inherits BtnBase

  ' 登録ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 登録ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを登録します。")
    Me.AccessKey = Keys.F5
    Me.BtnText = "登録"

  End Sub


#End Region

End Class
