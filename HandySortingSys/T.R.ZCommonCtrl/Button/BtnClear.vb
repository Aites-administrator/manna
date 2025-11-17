Public Class BtnClear
  Inherits BtnBase

  ' クリアボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' クリアボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データをクリアします。")
    Me.AccessKey = Keys.F6
    Me.BtnText = "クリア"

  End Sub

#End Region
End Class
