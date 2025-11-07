Public Class TxtDrTanka
  Inherits TxtNumericBase

  ' 受注単価入力テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値6桁のみ入力可
    MyBase.New(6, True)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("受注単価を入力してください。")
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
    Dim tmpKg As Decimal

    If tmpTxtBox.Text <> "" Then
      If Decimal.TryParse(tmpTxtBox.Text, tmpKg) Then
        ' 小数点第三位で四捨五入し、小数点第二位まで出力
        tmpTxtBox.Text = Math.Round(tmpKg, 2, MidpointRounding.AwayFromZero)
      Else
        e.Cancel = True
      End If
    End If

  End Sub

#End Region

End Class
