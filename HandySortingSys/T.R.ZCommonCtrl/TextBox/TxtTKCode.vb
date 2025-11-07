Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtTKCode
  Inherits TxtCodeBase

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 得意先名
  ''' </summary>
  Private _tkName As String

  ''' <summary>
  ''' 住所１
  ''' </summary>
  Private _tkAddress01 As String

  ''' <summary>
  ''' 住所２
  ''' </summary>
  Private _tkAddress02 As String

  ''' <summary>
  ''' 電話番号
  ''' </summary>
  Private _tkPhoneNumber As String

  ''' <summary>
  ''' Fax番号
  ''' </summary>
  Private _tkFaxNumber As String
#End Region
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("得意先コードを入力してください。")
  End Sub

  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub
#End Region

#Region "パブリック"
  ''' <summary>
  ''' 得意先名の取得
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>デフォルト False</remarks>
  Public ReadOnly Property TKName As String
    Get
      Return _tkName
    End Get
  End Property

  Public ReadOnly Property TKAddress01 As String
    Get
      Return _tkAddress01
    End Get
  End Property

  Public ReadOnly Property TKAddress02 As String
    Get
      Return _tkAddress02
    End Get
  End Property

  Public ReadOnly Property TKPhoneNumber As String
    Get
      Return _tkPhoneNumber
    End Get
  End Property

  Public ReadOnly Property TKFaxNumber As String
    Get
      Return _tkFaxNumber
    End Get
  End Property
#End Region

#Region "メソッド"
#Region "パブリック"

  ''' <summary>
  ''' 得意先コードの取得
  ''' </summary>
  ''' <param name="prmCustomerCode">得意先コード</param>
  Public Sub GetCustomerData(prmCustomerCode As String)

    If (String.IsNullOrEmpty(prmCustomerCode)) Then
      _tkName = ""
      Return
    End If
    ' 得意先コード
    prmCustomerCode = StringToInt(prmCustomerCode).ToString("000000")

    '得意先コードの検索
    Dim tmpDic As Dictionary(Of String, String) = GetPcaItemCode(prmCustomerCode)
    ' 得意先コード
    If tmpDic.ContainsKey(CTRL_CUST_CODE) Then
      Me.Text = tmpDic(CTRL_CUST_CODE)
    Else
      Me.Text = ""
    End If

    ' 得意先名
    If tmpDic.ContainsKey(CTRL_CUST_NAME) Then
      _tkName = tmpDic(CTRL_CUST_NAME)
    Else
      _tkName = ""
    End If

    ' 住所０１
    If tmpDic.ContainsKey(CTRL_CUST_ADDRESS1) Then
      _tkAddress01 = tmpDic(CTRL_CUST_ADDRESS1)
    Else
      _tkAddress01 = ""
    End If

    ' 住所０２
    If tmpDic.ContainsKey(CTRL_CUST_ADDRESS2) Then
      _tkAddress02 = tmpDic(CTRL_CUST_ADDRESS2)
    Else
      _tkAddress02 = ""
    End If

    ' 電話番号
    If tmpDic.ContainsKey(CTRL_CUST_TEL) Then
      _tkPhoneNumber = tmpDic(CTRL_CUST_TEL)
    Else
      _tkPhoneNumber = ""
    End If

    ' FAX番号
    If tmpDic.ContainsKey(CTRL_CUST_FAX) Then
      _tkFaxNumber = tmpDic(CTRL_CUST_FAX)
    Else
      _tkFaxNumber = ""
    End If

  End Sub
#End Region

#Region "プライベート"
  ''' <summary>
  ''' 得意先一覧一覧表示データ抽出SQL文作成
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Private Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    'sql = "SELECT * FROM ( "
    'sql &= " SELECT MST_CUSTOMER.CUSTOMER_CODE AS " & CTRL_CUST_CODE                   ' 得意先コード
    'sql &= "      , TOKUISAKI.TNAME AS " & CTRL_CUST_NAME                              ' 得意先名
    'sql &= "       ,MST_CUSTOMER.KUBUN "
    'sql &= " FROM MST_CUSTOMER "
    'sql &= "      INNER JOIN TOKUISAKI ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = TOKUISAKI.TKCODE "
    'sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
    'sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "
    'sql &= "      WHERE MST_CUSTOMER.KUBUN = 0 AND "
    'sql &= "      MST_CUSTOMER.CUSTOMER_CODE = " & prmCode

    'sql &= " UNION "

    'sql &= " SELECT MST_CUSTOMER.CUSTOMER_CODE AS " & CTRL_CUST_CODE                    ' 得意先コード
    'sql &= "      , TOKUISAKI.TNAME AS " & CTRL_CUST_NAME                               ' 得意先名
    'sql &= "       ,MST_CUSTOMER.KUBUN "
    'sql &= " FROM MST_CUSTOMER "
    'sql &= "      INNER JOIN THENKAN ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = THENKAN.TKCODE "
    'sql &= "      INNER JOIN TOKUISAKI ON THENKAN.TKCODE = TOKUISAKI.TKCODE "
    'sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
    'sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "
    'sql &= "      WHERE MST_CUSTOMER.KUBUN = 0 AND "
    'sql &= "      MST_CUSTOMER.CUSTOMER_CODE = " & prmCode
    'sql &= "  ) AS CUSTMST "

    sql = "SELECT * FROM ( "
    sql &= " SELECT MST_CUSTOMER.OFFICE_CODE AS " & CTRL_CUST_OFFICECODE               ' 事業所コード
    sql &= "      , MST_CUSTOMER.CUSTOMER_CODE AS " & CTRL_CUST_CODE                   ' 得意先コード
    sql &= "      , TOKUISAKI.TNAME AS " & CTRL_CUST_NAME                              ' 得意先名
    sql &= "      , MST_CUSTOMER.FURIGANA AS " & CTRL_CUST_KANA                        ' フリガナ
    sql &= "      , MST_CUSTOMER.ADDRESS01  AS " & CTRL_CUST_ADDRESS1                  ' 住所１
    sql &= "      , MST_CUSTOMER.ADDRESS02  AS " & CTRL_CUST_ADDRESS2                  ' 住所２
    sql &= "      , TOKUISAKI.TELA AS " & CTRL_CUST_TEL                                ' 電話番号
    sql &= "      , TOKUISAKI.TELF AS " & CTRL_CUST_FAX                                ' FAX番号
    sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE01 AS " & CTRL_CUST_TYPE1                ' 分類コード１
    sql &= "      , MST_CUSTOMERTYPE01.CUSTOMER_TYPE01_NAME AS " & CTRL_CUST_TYPE1NAME ' 分類コード１名称名
    sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE02 AS " & CTRL_CUST_TYPE2                ' 分類コード２
    sql &= "      , MST_TANTO.TANTO_NAME AS " & CTRL_CUST_TANTONAME                    ' 担当者名
    sql &= "      , MST_TANTO.TANTO_CODE AS " & CTRL_CUST_TANTOCODE                    ' 担当者コード
    sql &= "       ,MST_CUSTOMER.KUBUN "
    sql &= "       ,MST_CUSTOMER.PRINTDELIVERY AS " & CTRL_CUST_DELIVERYFLG            ' 加工印刷FLG
    sql &= "       ,MST_CUSTOMER.PRINTPROCESSING AS " & CTRL_CUST_PROCESSFLG           ' 配送印刷FLG
    sql &= " FROM MST_CUSTOMER "
    sql &= "      INNER JOIN TOKUISAKI ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = TOKUISAKI.TKCODE "
    sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
    sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "

    sql &= " UNION "

    sql &= " SELECT MST_CUSTOMER.OFFICE_CODE AS " & CTRL_CUST_OFFICECODE                ' 事業所コード
    sql &= "      , MST_CUSTOMER.CUSTOMER_CODE AS " & CTRL_CUST_CODE                    ' 得意先コード
    sql &= "      , TOKUISAKI.TNAME AS " & CTRL_CUST_NAME                               ' 得意先名
    sql &= "      , MST_CUSTOMER.FURIGANA AS " & CTRL_CUST_KANA                         ' 得意先名フリガナ
    sql &= "      , MST_CUSTOMER.ADDRESS01  AS " & CTRL_CUST_ADDRESS1                   ' 得意先住所１
    sql &= "      , MST_CUSTOMER.ADDRESS02  AS " & CTRL_CUST_ADDRESS2                   ' 得意先住所２
    sql &= "      , TOKUISAKI.TELA AS " & CTRL_CUST_TEL                                 ' 得意先電話番号
    sql &= "      , TOKUISAKI.TELF AS " & CTRL_CUST_FAX                                 ' 得意先FAX番号
    sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE01 AS " & CTRL_CUST_TYPE1                 ' 得意先分類コード１
    sql &= "      , MST_CUSTOMERTYPE01.CUSTOMER_TYPE01_NAME AS " & CTRL_CUST_TYPE1NAME  ' 得意先分類コード１名称名
    sql &= "      , MST_CUSTOMER.CUSTOMER_TYPE02 AS " & CTRL_CUST_TYPE2                 ' 得意先分類コード２
    sql &= "      , MST_TANTO.TANTO_NAME AS " & CTRL_CUST_TANTONAME                     ' 担当者名
    sql &= "      , MST_TANTO.TANTO_CODE AS " & CTRL_CUST_TANTOCODE                     ' 担当者コード
    sql &= "       ,MST_CUSTOMER.KUBUN "
    sql &= "       ,MST_CUSTOMER.PRINTDELIVERY AS " & CTRL_CUST_DELIVERYFLG             ' 加工印刷FLG
    sql &= "       ,MST_CUSTOMER.PRINTPROCESSING AS " & CTRL_CUST_PROCESSFLG            ' 配送印刷FLG
    sql &= " FROM MST_CUSTOMER "
    sql &= "      INNER JOIN THENKAN ON CAST(MST_CUSTOMER.CUSTOMER_CODE as numeric) = THENKAN.TKCODE "
    sql &= "      INNER JOIN TOKUISAKI ON THENKAN.TKCODE = TOKUISAKI.TKCODE "
    sql &= "      LEFT JOIN MST_TANTO ON MST_CUSTOMER.TANTO_CODE = MST_TANTO.TANTO_CODE "
    sql &= "      LEFT JOIN MST_CUSTOMERTYPE01 ON MST_CUSTOMER.CUSTOMER_TYPE01 = MST_CUSTOMERTYPE01.CUSTOMER_TYPE01 "
    sql &= "  ) AS CUSTMST "
    sql &= " WHERE CUSTMST.KUBUN = 0 "
    sql &= "   AND CUSTMST.CUSTOMER_CODE = " & prmCode

    Return sql
  End Function

  ''' <summary>
  ''' 得意先コードより得意先データを取得する
  ''' </summary>
  ''' <param name="prmMaItemCode"></param>
  ''' <returns></returns>
  Private Function GetPcaItemCode(prmMaItemCode As String) As Dictionary(Of String, String)
    Dim ret As New Dictionary(Of String, String)
    Dim tmpDb As New clsSqlServer()
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelListSrc(prmMaItemCode))
      If tmpDt.Rows.Count > 0 Then
        ret.Add(CTRL_CUST_CODE, tmpDt.Rows(0)(CTRL_CUST_CODE).ToString().PadLeft(6, "0"c))
        ret.Add(CTRL_CUST_NAME, tmpDt.Rows(0)(CTRL_CUST_NAME).ToString())

        ret.Add(CTRL_CUST_ADDRESS1, tmpDt.Rows(0)(CTRL_CUST_ADDRESS1).ToString())
        ret.Add(CTRL_CUST_ADDRESS2, tmpDt.Rows(0)(CTRL_CUST_ADDRESS2).ToString())
        ret.Add(CTRL_CUST_TEL, tmpDt.Rows(0)(CTRL_CUST_TEL).ToString())
        ret.Add(CTRL_CUST_FAX, tmpDt.Rows(0)(CTRL_CUST_FAX).ToString())

      End If
    Catch ex As Exception
      Call ComWriteErrLog(ex)
      Throw New Exception("得意先コードの取得に失敗しました。")
    Finally
      tmpDb.Dispose()
      tmpDt.Dispose()
    End Try

    Return ret
  End Function

  ''' <summary>
  ''' 得意先コードの入力判定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtSch1TKCode_Validated(sender As Object, e As EventArgs) Handles Me.Validated

    Try
      _tkName = String.Empty


      If (String.IsNullOrEmpty(Me.Text) = False) Then
        GetCustomerData(Me.Text)
      End If
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

#End Region
#End Region

End Class

