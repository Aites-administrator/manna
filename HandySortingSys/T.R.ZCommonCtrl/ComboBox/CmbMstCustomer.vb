Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstCustomer
  Inherits CmbMstBase

  '----------------------------------------------
  '          得意先選択コンボボックス
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

    MyBase.New(CUSTOMER_ZERO_PADDING)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先名を選択入力して下さい。")
    MyBase.DropDownWidth = 360
    MyBase.SkipChkCode = True

  End Sub

  Public Sub New(Optional prmStopFlg As Boolean = False)

    MyBase.New("")
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先名を選択入力して下さい。")
    MyBase.DropDownWidth = 360
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

      sql = "SELECT "
      sql &= "        FORMAT(CONVERT(int,CUSTMST.TKCODE), '" & CUSTOMER_ZERO_PADDING & "') AS ItemCode "
      sql &= "      , CUSTMST.TKNAME AS ItemName "
      sql &= " FROM( "
      sql &= " SELECT MST_CUSTOMER.KUBUN "
      sql &= "      , MST_CUSTOMER.CUSTOMER_CODE AS TKCODE "
      sql &= "      , TOKUISAKI.TNAME AS TKNAME "
      sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE01 AS DELIVERYCD "
      sql &= "      , MST_TANTO.TANTO_NAME AS TANTONAME "
      sql &= "      , MST_TANTO.TANTO_CODE AS TANTOCD "
      sql &= "      , MST_CUSTOMERTYPE01.CUSTOMER_TYPE01_NAME AS DELIVERYNAME "
      sql &= " FROM MST_CUSTOMER "
      sql &= "      INNER JOIN TOKUISAKI ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = TOKUISAKI.TKCODE "
      sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
      sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "

      sql &= " UNION "

      sql &= " SELECT MST_CUSTOMER.KUBUN "
      sql &= "      , MST_CUSTOMER.CUSTOMER_CODE AS TKCODE "
      sql &= "      , TOKUISAKI.TNAME AS TKNAME "
      sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE01 AS DELIVERYCD "
      sql &= "      , MST_TANTO.TANTO_NAME AS TANTONAME "
      sql &= "      , MST_TANTO.TANTO_CODE AS TANTOCD "
      sql &= "      , MST_CUSTOMERTYPE01.CUSTOMER_TYPE01_NAME AS DELIVERYNAME "
      sql &= " FROM MST_CUSTOMER "
      sql &= "      INNER JOIN THENKAN ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = THENKAN.TKCODE "
      sql &= "      INNER JOIN TOKUISAKI ON THENKAN.TKCODE = TOKUISAKI.TKCODE "
      sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
      sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "
      sql &= "  ) AS CUSTMST "
      sql &= " WHERE 1 = 1 "
      If (_StopFlg) Then
        sql &= "AND CUSTMST.KUBUN = 0 "
      End If

      If prmCode <> "" Then
        sql &= " AND CUSTMST.TKCODE = '" & prmCode & "'"
      End If

      sql &= " ORDER BY CUSTMST.TKCODE "
    End If

    Return sql
  End Function

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

  ''' <summary>
  ''' 数値とバックスペースのみ入力可
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
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
