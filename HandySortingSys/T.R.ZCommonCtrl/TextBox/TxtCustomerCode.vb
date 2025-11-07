Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData

Public Class TxtCustomerCode
  Inherits TxtNumericBase

  ' 得意先コード入力用テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値6桁のみ入力可
    MyBase.New(6)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先コードを入力してください。")
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()
    Me.TextAlign = HorizontalAlignment.Left
  End Sub
#End Region

#Region "イベントプロシージャー"
  Private Sub TxtDateBase_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
    Dim tmpDateText As String = String.Empty
    With Me

      ' 得意先コードが空白の場合
      If String.IsNullOrWhiteSpace(.Text) Then
        Return
      End If

      .Text = StringToInt(.Text).ToString(CUSTOMER_ZERO_PADDING)

    End With

  End Sub

  Private Sub TxtDateBase_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    Dim tmpDateText As String = String.Empty
    With Me

      ' 得意先コードが空白の場合
      If String.IsNullOrWhiteSpace(.Text) Then
        Return
      End If

      .Text = StringToInt(.Text).ToString(CUSTOMER_ZERO_PADDING)

    End With
  End Sub

#End Region

End Class
