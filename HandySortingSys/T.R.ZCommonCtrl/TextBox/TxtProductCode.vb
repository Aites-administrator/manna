Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtProductCode
  Inherits TxtCodeBase

  ' 商品マスタ入力用テキストボックス

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 商品名１
  ''' </summary>
  Private _productName1 As String

  ''' <summary>
  ''' 商品名２
  ''' </summary>
  Private _productName2 As String

#End Region
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("商品名コードを入力してください。")
  End Sub

  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub
#End Region

#Region "パブリック"
  ''' <summary>
  ''' 商品名の取得
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>デフォルト False</remarks>
  Public ReadOnly Property ProductName1 As String
    Get
      Return _productName1
    End Get
  End Property

#End Region

#Region "メソッド"
#Region "パブリック"

  ''' <summary>
  ''' 商品名コードの取得
  ''' </summary>
  ''' <param name="prmProductCode">商品名コード</param>
  Public Sub GetProductData(prmProductCode As String)

    If (String.IsNullOrEmpty(prmProductCode)) Then
      _productName1 = ""
      _productName2 = ""
      Return
    End If

    '商品名コードの検索
    Dim tmpDic As Dictionary(Of String, String) = GetProductItemCode(prmProductCode)
    ' 商品名コード
    If tmpDic.ContainsKey(CTRL_PRODUCT_CODE) Then
      Me.Text = tmpDic(CTRL_PRODUCT_CODE)
    End If

    ' 商品名１
    If tmpDic.ContainsKey(CTRL_PRODUCT_NAME1) Then
      _productName1 = tmpDic(CTRL_PRODUCT_NAME1)
    Else
      _productName1 = ""
    End If

    ' 商品名２
    If tmpDic.ContainsKey(CTRL_PRODUCT_NAME2) Then
      _productName2 = tmpDic(CTRL_PRODUCT_NAME2)
    Else
      _productName2 = ""
    End If

  End Sub
#End Region

#Region "プライベート"
  ''' <summary>
  ''' 商品名一覧表示データ抽出SQL文作成
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Private Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT FORMAT(CONVERT(int,ITEM_CODE), '00000000')  AS " & CTRL_PRODUCT_CODE    ' 商品コード
    sql &= "       ,ITEM_NAME01 AS " & CTRL_PRODUCT_NAME1              ' 商品名１
    sql &= "       ,ITEM_NAME02 AS " & CTRL_PRODUCT_NAME2              ' 商品名２
    sql &= "       ,ITEM_FURIGANA AS " & CTRL_PRODUCT_KANANAME         ' 商品名フリガナ
    sql &= "       ,BICODE AS " & CTRL_PCA_CODE1                       ' PCAコード
    sql &= "       ,SHOHINC AS " & CTRL_MEAT_CODE1                     ' 食肉標準コード
    sql &= "       ,KIKAKU AS " & CTRL_PRODUCT_STANDARD                ' 規格
    sql &= "       ,UNIT_ORDER AS " & CTRL_PRODUCT_UNIT                ' 受注単位
    sql &= "       ,UNIT_SALES AS " & CTRL_SALES_UNIT                  ' 売上単位
    sql &= "       ,IRISU AS " & CTRL_PRODUCT_QUANTITY                 ' 入数
    sql &= "       ,BIKOU AS " & CTRL_PRODUCT_REMARKS                  ' 備考
    sql &= "       ,ITEM_TYPE01 AS " & CTRL_PRODUCT_CLS1               ' 商品分類コード１
    sql &= "       ,ITEM_TYPE02 AS " & CTRL_PRODUCT_CLS2               ' 商品分類コード２
    sql &= "       ,COST_UNIT AS " & CTRL_PURCHASE_PRICE               ' 仕入単価
    sql &= "       ,COST_STANDARD AS " & CTRL_PRODUCT_COST             ' 標準原価単価
    sql &= "       ,PRICE_STANDARD AS " & CTRL_PRODUCT_SUP             ' 標準売上単価
    sql &= "       ,PRICE_RETAIL AS " & CTRL_STANDARD_PRICE            ' 標準上代単価
    sql &= "       ,WEIGHT_TYPE  AS " & CTRL_CONSTANT                  ' 定貫区分
    sql &= "       ,PROCESS_TYPE AS " & CTRL_HT_PROCESS                ' HT加工区分
    sql &= "       ,DECIMAL_POINT AS " & CTRL_DECIMAL_POINT            ' HT重量小数桁数
    sql &= "       ,KUBUN AS  " & CTRL_STOP_FLG                        ' 使用停止フラグ
    sql &= "       ,TDATE AS " & CTRL_REGISTERED_DATE                  ' 登録日時
    sql &= "       ,KDATE AS " & CTRL_UPDATE_DATE                      ' 最終更新日時
    sql &= "       ,0 AS " & CTRL_JAN_CODE
    sql &= "       ,FORMAT(CONVERT(int,BICODE), '0000') AS  " & CTRL_BUICODE  ' 部位コード
    sql &= " FROM  MST_ITEM   "
    sql &= " WHERE KUBUN = 0     "
    sql &= " AND   ITEM_CODE = " & prmCode

    Return sql
  End Function

  ''' <summary>
  ''' 商品名コードより商品名データを取得する
  ''' </summary>
  ''' <param name="prmProductItemCode"></param>
  ''' <returns></returns>
  Private Function GetProductItemCode(prmProductItemCode As String) As Dictionary(Of String, String)
    Dim ret As New Dictionary(Of String, String)
    Dim tmpDb As New clsSqlServer()
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelListSrc(prmProductItemCode))
      If tmpDt.Rows.Count > 0 Then
        ret.Add(CTRL_PRODUCT_CODE, tmpDt.Rows(0)(CTRL_PRODUCT_CODE).ToString())
        ret.Add(CTRL_PRODUCT_NAME1, tmpDt.Rows(0)(CTRL_PRODUCT_NAME1).ToString())
        ret.Add(CTRL_PRODUCT_NAME2, tmpDt.Rows(0)(CTRL_PRODUCT_NAME2).ToString())
      End If
    Catch ex As Exception
      Call ComWriteErrLog(ex)
      Throw New Exception("商品名コードの取得に失敗しました。")
    Finally
      tmpDb.Dispose()
      tmpDt.Dispose()
    End Try

    Return ret
  End Function

  ''' <summary>
  ''' 商品名コードの入力判定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtProductCode_Validated(sender As Object, e As EventArgs) Handles Me.Validated

    Try
      _productName1 = String.Empty


      If (String.IsNullOrEmpty(Me.Text) = False) Then
        GetProductData(Me.Text)
      End If
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

#End Region
#End Region

End Class
