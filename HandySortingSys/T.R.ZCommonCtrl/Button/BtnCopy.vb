Public Class BtnCopy
  Inherits BtnBase

  ' 複写ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 複写ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("データを複写します。")
    Me.AccessKey = Keys.F2
    Me.BtnText = "複写"

  End Sub

#End Region

End Class
