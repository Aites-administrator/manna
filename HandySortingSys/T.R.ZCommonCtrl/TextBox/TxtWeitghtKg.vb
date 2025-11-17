Public Class TxtWeitghtKg
  Inherits TxtNumericBase

  '----------------------------------------------
  '          重量(Kg)入力テキストボックス
  '
  '
  '----------------------------------------------

  Private _DecimalPoint As Integer = 3

  ''' <summary>
  ''' 小数点以下有効桁数
  ''' </summary>
  ''' <returns></returns>
  Public Property DecimalPoint As Integer
    Get
      Return _DecimalPoint
    End Get
    Set(value As Integer)
      _DecimalPoint = value
    End Set
  End Property
#Region "コンストラクタ"
  Public Sub New()
    ' 数値8桁(小数点可)のみ入力可
    MyBase.New(8, True)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("重量をKg単位で入力します。")
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

  Private Sub TxtWeitghtKg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
    Dim tmpTxtBox As TextBox = DirectCast(sender, TextBox)
    Dim tmpKg As Decimal

    If tmpTxtBox.Text <> "" Then
      If Decimal.TryParse(tmpTxtBox.Text, tmpKg) Then
        ' 小数点第四位で四捨五入し、小数点第三位まで出力
        tmpTxtBox.Text = Math.Round(tmpKg, _DecimalPoint, MidpointRounding.AwayFromZero)
      Else
        e.Cancel = True
      End If
    End If

  End Sub

#End Region


End Class
