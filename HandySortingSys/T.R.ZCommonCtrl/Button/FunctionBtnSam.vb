Public Class FunctionBtnSam
  Inherits BtnBase

  ' 終了ボタン

#Region "コンストラクタ"

  ''' <summary>
  ''' 終了ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("Escボタンに反応するサンプルです")
    Me.AccessKey = Keys.Escape
    Me.BtnText = "エスケープボタンで反応します"

  End Sub

  Private Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'BtnEnd
    '
    Me.BackColor = System.Drawing.Color.White
    Me.UseVisualStyleBackColor = False
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class

