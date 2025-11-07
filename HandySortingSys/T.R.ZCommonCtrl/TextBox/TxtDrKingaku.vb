Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtDrKingaku
  Inherits TxtNumericBase

  ' 金額入力テキストボックス

#Region "コンストラクタ"

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()
    ' 数値8桁のみ入力可
    MyBase.New(8)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("金額を入力してください。")
  End Sub

  ''' <summary>
  ''' デフォルトコンストラクタ
  ''' </summary>
  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' 金額表示
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtDrCount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

    Dim tmpTxtBox As TextBox = DirectCast(sender, TextBox)
    Dim kingaku As Decimal = StringToDecimal(tmpTxtBox.Text)

    tmpTxtBox.Text = kingaku.ToString("#,###")

  End Sub

#End Region

End Class
