Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstRoot
  Inherits CmbMstBase

  '----------------------------------------------
  '          配送ルート選択コンボボックス
  '
  '
  '----------------------------------------------
#Region "メンバ"

#Region "プライベート"

#Region "SQL関連"
  Private _StopFlg As Boolean
#End Region
#End Region
#End Region

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CUSTOMER_TYPE01_ZERO_PADDING)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("配送ルートを選択入力して下さい。")
    MyBase.DropDownWidth = 480
    MyBase.SkipChkCode = True

  End Sub

  Public Sub New(Optional prmStopFlg As Boolean = False)

    MyBase.New(CUSTOMER_TYPE01_ZERO_PADDING)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("配送ルートを選択入力して下さい。")
    MyBase.DropDownWidth = 480
    MyBase.SkipChkCode = True
    _StopFlg = prmStopFlg

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then

      sql &= " SELECT FORMAT(CONVERT(int,CUSTOMER_TYPE01), '" & CUSTOMER_TYPE01_ZERO_PADDING & "') AS ItemCode "
      sql &= "       ,CUSTOMER_TYPE01_NAME AS ItemName "
      sql &= " FROM MST_CUSTOMERTYPE01 "
      sql &= " WHERE 1 = 1 "
      If (_StopFlg) Then
        sql &= " AND KUBUN <> -1 "
      End If
      If prmCode <> "" Then
        sql &= " AND CUSTOMER_TYPE01 = '" & prmCode & "'"
      End If
      sql &= " ORDER BY CUSTOMER_TYPE01"

    End If

    Return sql
  End Function

#End Region

#Region "イベントプロシージャー"
  Private Sub TxtDateBase_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
    Dim tmpDateText As String = String.Empty
    With Me

      ' 得意先分類コード１が空白の場合
      If String.IsNullOrWhiteSpace(.Text) Then
        Return
      End If

      .Text = StringToInt(.Text).ToString(CUSTOMER_TYPE01_ZERO_PADDING)

    End With

  End Sub

  '' <summary>
  '' 数値とバックスペースのみ入力可
  '' </summary>
  '' <param name="sender"></param>
  '' <param name="e"></param>
  Private Sub TTxtDateBase_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    ' 数値とバックスペースのみ入力可
    If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
      '押されたキーが 0～9でない場合は、イベントをキャンセルする
      e.Handled = True
    End If

  End Sub

#End Region

#End Region

End Class
