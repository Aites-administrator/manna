Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtMeatStandardCode
  Inherits TxtNumericBase

  ' 食肉標準コード入力用テキストボックス


#Region "メンバ"

#Region "パブリック"
  ' 食肉標準コードエラー時処理コールバック
  Delegate Sub CallBackEnterInvalidMeatStandardCode(MeatStandardCode As String)
  Public lcCallBackEnterInvalidMeatStandardCode As CallBackEnterInvalidMeatStandardCode

  ' 食肉標準コード有効時処理コールバック
  Delegate Sub CallBackEnterEnableMeatStandardCode(MeatStandardCode As String)
  Public lcCallBackEnterEnableMeatStandardCode As CallBackEnterEnableMeatStandardCode

#End Region

#End Region

#Region "コンストラクタ"

  Public Sub New()
    ' 数値8桁のみ入力可
    MyBase.New(8)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("食肉標準コードを入力してください。")

  End Sub

  Private Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'TxtMeatStandardCode
    '
    Me.ResumeLayout(False)

  End Sub


#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' チェック時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtProductCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
    Dim tmpTxt As TextBox = DirectCast(sender, TextBox)

    'If tmpTxt.Text <> "" Then
    '  ' 商品コードとして正しいか？
    '  If ComChkOfficeCode(tmpTxt.Text) Then
    '    ' 商品コード有効
    '    If lcCallBackEnterEnableProductCode IsNot Nothing Then
    '      Call lcCallBackEnterEnableProductCode(tmpTxt.Text)
    '    End If
    '  Else
    '    '商品コード無効

    '    If lcCallBackEnterInvalidProductCode Is Nothing Then
    '      ' コールバック未設定ならキャンセル
    '      e.Cancel = True
    '    Else
    '      'コールバック実行
    '      Call lcCallBackEnterInvalidProductCode(tmpTxt.Text)
    '    End If
    '  End If
    'End If
  End Sub

#End Region

End Class
