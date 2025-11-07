Public Class TxtDrCount
  Inherits TxtNumericBase

  ' 数量入力テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値6桁(小数点可)のみ入力可
    MyBase.New(6, True)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("数量を入力してください。")
  End Sub

  Private Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'TxtWeitghtKg
    '
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "イベントプロシージャー"

  Private Sub TxtDrCount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

    Dim tmpTxtBox As TextBox = DirectCast(sender, TextBox)
    Dim tmpCount As Decimal

    If tmpTxtBox.Text <> "" Then
      If Decimal.TryParse(tmpTxtBox.Text, tmpCount) Then
        ' 小数点第三位で四捨五入し、小数点第二位まで出力
        tmpTxtBox.Text = Math.Round(tmpCount, 2, MidpointRounding.AwayFromZero)
      Else
        e.Cancel = True
      End If
    End If

  End Sub

#End Region


End Class
