Public Class ButtonReflesh
  Inherits BtnBase

  ' 再表示ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 再表示ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("ボタン押下で最新データを取得します。")
    Me.Image = My.Resources.ButtonReflesh

  End Sub

#End Region


End Class
