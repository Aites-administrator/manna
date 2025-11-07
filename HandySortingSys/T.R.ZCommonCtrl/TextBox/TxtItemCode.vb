Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData

Public Class TxtItemCode
  Inherits TxtNumericBase

  ' 商品コード入力用テキストボックス

#Region "コンストラクタ"

  Public Sub New()
    ' 数値8桁のみ入力可
    MyBase.New(8)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("商品コードは、8文字まで入力できます。")
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

      ' 商品コードが空白の場合
      If String.IsNullOrWhiteSpace(.Text) Then
        Return
      End If

      .Text = StringToInt(.Text).ToString(ITEM_ZERO_PADDING)

    End With

  End Sub

  Private Sub TxtSchTKCode_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    Dim tmpDateText As String = String.Empty
    With Me

      ' 商品コードが空白の場合
      If String.IsNullOrWhiteSpace(.Text) Then
        Return
      End If

      .Text = StringToInt(.Text).ToString(ITEM_ZERO_PADDING)

    End With
  End Sub

#End Region

End Class
