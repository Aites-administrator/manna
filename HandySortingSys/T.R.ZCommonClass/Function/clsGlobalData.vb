Public Class clsGlobalData

  ''' <summary>
  '''  返品買戻し番号
  ''' </summary>
  Public Shared ReadOnly HENPIN_KAIMODOSHI_ID As Integer = 2

  ''' <summary>
  '''  加工賃の部位コードを登録
  ''' </summary>
  Public Shared ReadOnly listWageCode As String() = {"3116", "3128"}

  ''' <summary>
  ''' ＦＴＰサーバーデータディレクトリ
  ''' </summary>
  Public Shared ReadOnly FTPDir As String = "\\nikserver21\FTPDATA"

  ''' <summary>
  ''' バックアップ用Accdbの保存先
  ''' </summary>
  Public Shared ReadOnly BACKUP_FILENAME As String = "TrzBackup.accdb"

  ''' <summary>
  ''' 印刷帳票の保存先
  ''' </summary>
  Public Shared ReadOnly REPORT_FILENAME As String = "TrzReports.accdb"

  ''' <summary>
  ''' 印刷用Access元ファイル
  ''' </summary>
  ''' <remarks>
  '''  実行時は本ファイルを実行ファイルと同じフォルダにコピーして使用する
  ''' </remarks>
  Public Shared ReadOnly REPORT_ORG_FILEPATH As String = "C:\flavor\report\TrzReports_org.accdb"

  ''' <summary>
  '''個数表出力Excel元ファイル
  ''' </summary>
  Public Shared ReadOnly EXCEL_ORG_FILEPATH As String = "D:\TRZdotDX\report\kosu_org.xlsx"

  ''' <summary>
  ''' 定貫区分
  ''' </summary>
  Public Shared ReadOnly PRINT_PREVIEW As Integer = 1     '0：プレビューしない、1：プレビューする
  Public Shared ReadOnly PRINT_NON_PREVIEW As Integer = 0

  ''' <summary>
  ''' 使用停止フラグ
  ''' </summary>
  Public Const TYPE_USE = "0"         ' 使用中
  Public Const TYPE_STOP = "-1"       ' 停止中

  ''' <summary>
  ''' 定貫・不定貫フラグ
  ''' </summary>
  Public Const TYPE_CONSTANT = "0"     ' 定貫
  Public Const TYPE_NONCONSTANT = "1"  ' 不定貫

  ''' <summary>
  ''' 親子関係
  ''' </summary>
  Public Const TYPE_SET_NOT = "0"   ' 未設定
  Public Const TYPE_SET_OYA = "1"   ' 親
  Public Const TYPE_SET_KO = "2"    ' 子

  ''' <summary>
  ''' 集計のSP区分（セット、パーツを区別して実績表を出力　０：区別なし、１：区別有り）
  ''' </summary>
  Public Shared ReadOnly SHUKEI_SP_KUBUN As Integer = 0

  ''' <summary>
  ''' セット処理表（０：横、１：縦、２：縦・種別別）
  ''' </summary>
  Public Shared ReadOnly SHUKEI_TATEYOKO As Integer = 2

  ''' <summary>
  ''' 集計の並び
  ''' </summary>
  Public Shared ReadOnly SHUKEI_NARABI As Integer = 1

  ''' <summary>
  ''' 牛捌き単価
  ''' </summary>
  Public Shared ReadOnly NIPPO_GSABAKI As Integer = 22

  ''' <summary>
  ''' 豚捌き単価
  ''' </summary>
  Public Shared ReadOnly NIPPO_BSABAKI As Integer = 1000

  ''' <summary>
  ''' 動作モード
  ''' </summary>
  Public Shared ReadOnly SEISAN_TYPE As Integer = 1

  ''' <summary>
  ''' 枝肉部位コード
  ''' </summary>
  Public Shared ReadOnly EDANIKU_CODE As Integer = 0

  ''' <summary>
  ''' 左右区分（左）
  ''' </summary>
  Public Shared ReadOnly PARTS_SIDE_LEFT As Integer = 1

  ''' <summary>
  ''' 左右区分（右）
  ''' </summary>
  Public Shared ReadOnly PARTS_SIDE_RIGHT As Integer = 2

  ''' <summary>
  ''' 左右区分（1頭）
  ''' </summary>
  Public Shared ReadOnly PARTS_SIDE_BOTH As Integer = 0

  ''' <summary>
  ''' 枝別精算パスワード
  ''' </summary>
  Public Shared ReadOnly EDASEISAN_PASSWORD As String = "0714"

  ''' <summary>
  ''' 枝番最大値
  ''' </summary>
  Public Shared ReadOnly EDABAN_MAX As Integer = 9999

  ''' <summary>
  ''' 枝番最小値
  ''' </summary>
  Public Shared ReadOnly EDABAN_MIN As Integer = 5000

  ''' <summary>
  ''' 自社電話番号・ＦＡＸ
  ''' </summary>
  Public Shared ReadOnly COMPANY_NAME As String = "（株）フレイバー・プラザ"
  Public Shared ReadOnly FAX_NO As String = "０７５－６６２－２０１７"

  ''' <summary>
  ''' 拠点情報
  ''' </summary>
  Public Shared ReadOnly FOOT_01 As String = "TEL:075-662-2018 FAX:075-662-2017"
  Public Shared ReadOnly FOOT_02 As String = "京都市南区上鳥羽南花名町43番地"
  Public Shared ReadOnly FOOT_03 As String = "０７５－６６２－２０１７"
  Public Shared ReadOnly FOOT_04 As String = ""

  ' 税区分
  Public Shared ReadOnly TAX_NAME00 As String = ""
  Public Shared ReadOnly TAX_NAME01 As String = "1"
  Public Shared ReadOnly TAX_NAME02 As String = "2"
  Public Shared ReadOnly TAX_NAME03 As String = "3"

  ' 得意先コードゼロ詰め
  Public Shared ReadOnly CUSTOMER_ZERO_PADDING As String = "000000"

  ' 担当者コードゼロ詰め
  Public Shared ReadOnly TANTO_ZERO_PADDING As String = "0000"

  ' 配送担当者コードゼロ詰め
  Public Shared ReadOnly CUSTOMER_TYPE01_ZERO_PADDING As String = "000"

  ' 得意先分類コード２ゼロ詰め
  Public Shared ReadOnly CUSTOMER_TYPE02_ZERO_PADDING As String = "000"

  ' 納入先コードゼロ詰め
  Public Shared ReadOnly DELIVERY_ZERO_PADDING As String = "000000"

  ' 商品コードゼロ詰め
  Public Shared ReadOnly ITEM_ZERO_PADDING As String = "00000000"

  ' 商品分類コード１ゼロ詰め
  Public Shared ReadOnly PRODUCTCLS1_ZERO_PADDING As String = "000"

  ' 商品分類コード１ゼロ詰め
  Public Shared ReadOnly PRODUCTCLS2_ZERO_PADDING As String = "000"

  Public Const CTRL_REGISTERED_DATE As String = "REGISTERED_DATE"             ' 登録日時
  Public Const CTRL_UPDATE_DATE As String = "UPDATE_DATE"                     ' 最終更新日時
  Public Const CTRL_STOP_FLG As String = "KUBUN"                              ' 使用停止フラグ
  Public Const CTRL_STOP_FLG_MARK As String = "KUBUN_MARK"                    ' 使用停止フラグ

  ' 受注処理画面
  Public Const CTRL_OD_ORDER_NUMBER As String = "ORDER_NUMBER"                　 ' 伝票番号
  Public Const CTRL_OD_LINE_NUMBER As String = "ORDER_LINE_NUMBER "        　    ' 行番号
  Public Const CTRL_OD_ORDER_SUB_NUMBER As String = "ORDER_SUB_NUMBER"        　 ' 伝票明細番号
  Public Const CTRL_OD_ORDER_DATE As String = "ORDER_DATE"                       ' 受注年月日
  Public Const CTRL_OD_DELIVERY_DATE As String = "DELIVERY_DATE"                 ' 納品日
  Public Const CTRL_OD_SALES_DATE As String = "SALES_DATE"                       ' 売上日
  Public Const CTRL_OD_USE_DATE As String = "USE_DATE"     　　   　             ' 使用日
  Public Const CTRL_OD_CUSTOMER_CODE As String = "CUSTOMER_CODE"                 ' 得意先コード
  Public Const CTRL_OD_CUSTOMER_NAME As String = "CUSTOMER_NAME"                 ' 得意先名称
  Public Const CTRL_OD_CUSTOMER_ADDRESS1 As String = "CUSTOMER_ADDRESS1"         ' 得意先住所１
  Public Const CTRL_OD_CUSTOMER_ADDRESS2 As String = "CUSTOMER_ADDRESS2"         ' 得意先住所２
  Public Const CTRL_OD_CUSTOMER_PHONE As String = "CUSTOMER_PHONE"               ' 得意先電話番号
  Public Const CTRL_OD_CUSTOMER_FAX As String = "CUSTOMER_FAX"                   ' 得意先ＦＡＸ
  Public Const CTRL_OD_TANTO_CODE As String = "TANTO_CODE"                       ' 担当コード
  Public Const CTRL_OD_TANTO_NAME As String = "TANTO_NAME"                       ' 担当名
  Public Const CTRL_OD_ROOT_CODE As String = "ROOT_CODE"                         ' 配送担当者コード
  Public Const CTRL_OD_ROOT_NAME As String = "ROOT_NAME"                         ' 配送担当者名
  Public Const CTRL_OD_DEST_CODE As String = "DEST_CODE"                         ' 納入先コード
  Public Const CTRL_OD_DEST_NAME As String = "DEST_NAME"                         ' 納入先名
  Public Const CTRL_OD_DEST_ADDRESS01 As String = "DEST_ADDRESS01"               ' 納入先住所１
  Public Const CTRL_OD_DEST_ADDRESS02 As String = "DEST_ADDRESS02"               ' 納入先住所２
  Public Const CTRL_OD_DEST_PHONE As String = "DEST_PHONE"                       ' 納入先電話番号
  Public Const CTRL_OD_DEST_FAX As String = "DEST_FAX"                           ' 納入先ＦＡＸ
  Public Const CTRL_OD_PROCESSING_LIST As String = "PROCESSING_LIST"     　      ' 加工印刷ＦＬＧ
  Public Const CTRL_OD_DELIVERY_LIST As String = "DELIVERY_LIST"                 ' 配送印刷ＦＬＧ
  Public Const CTRL_OD_MEMO_TEXT2 As String = "MEMO_TEXT2"                       ' 伝票摘要

  Public Const CTRL_OD_SALES_NUMBER As String = "SALES_NUMBER"                   ' 売上伝票番号
  Public Const CTRL_OD_SALES_SUB_NUMBER As String = "SALES_SUB_NUMBER"           ' 売上伝票明細番号
  Public Const CTRL_OD_ITEM_CODE As String = "ITEM_CODE"                         ' 商品コード
  Public Const CTRL_OD_ITEM_NAME As String = "ITEM_NAME"                         ' 商品名
  Public Const CTRL_OD_KIKAKU As String = "KIKAKU"                               ' 規格
  Public Const CTRL_OD_TAX_TYPE As String = "TAX_TYPE"                           ' 税区分
  Public Const CTRL_OD_ORDER_UNIT As String = "ORDER_UNIT"                       ' 単位
  Public Const CTRL_OD_WEIGHT_TYPE As String = "WEIGHT_TYPE"                     ' 定貫
  Public Const CTRL_OD_DECIMAL_POINT As String = "DECIMAL_POINT"                 ' 小数点
  Public Const CTRL_OD_ORDER_QUANTITY As String = "ORDER_QUANTITY"               ' 数量
  Public Const CTRL_OD_ORDER_WEIGHT As String = "ORDER_WEIGHT"                   ' 重量
  Public Const CTRL_OD_ORDER_PRICE_RETAIL As String = "PRICE_RETAIL"             ' 上代単価
  Public Const CTRL_OD_PRICE_STANDARD As String = "PRICE_STANDARD"               ' 受注単価
  Public Const CTRL_OD_MEMO_TEXT As String = "MEMO_TEXT"                         ' 摘要
  Public Const CTRL_OD_AMOUNT As String = "AMOUNT"                               ' 金額
  Public Const CTRL_OD_PARTS_CODE As String = "PARTS_CODE"                     　' 部位コード
  Public Const CTRL_OD_SHOHINC As String = "SHOHINC"                             ' 食肉標準コード
  Public Const CTRL_OD_INCTAXPRICE As String = "IncTaxPrice"                     ' 税込み金額
  Public Const CTRL_OD_TAX_RATE As String = "TaxRate"                            ' 税率
  Public Const CTRL_OD_TAX_PRICE As String = "TaxPrice"                          ' 消費税
  Public Const CTRL_OD_ENTRY_DATE = "ENTRY_DATE"                                 ' 登録日
  Public Const CTRL_OD_LASTUPDATE = "LASTUPDATE"                                 ' 最終更新日

  Public Const CTRL_OD_LAST_ORDER_NUMBER As String = "LASR_ORDER_NUMBER"         ' INFORMATの［伝票No］
  Public Const CTRL_OD_ID_SYSTEM_NO As String = "ID_SYSTEM_NO"                   ' INFORMATの［伝票明細ID_SYSTEM］
  Public Const CTRL_OD_WRITE_FLG As String = "WRITE_FLG"                         ' 出力有無フラグ
  Public Const CTRL_OD_ROWNO As String = "ROWNO"                                 ' 行番号
  Public Const CTRL_OD_OPERATOR_CODE As String = "OPERATOR_CODE"                 ' オペレータコード
  Public Const CTRL_OD_KUBUNCD As String = "OD_KUBUNCD"                          ' 区分コード
  Public Const CTRL_OD_KUBUN As String = "OD_KUBUN"                              ' 受注区分（0:インフォマート・1:MOS・2:手入力等）」

  Public Const CTRL_OD_SECNO As String = "OD_SECNO"                              ' SQN
  Public Const CTRL_OD_MOSNO As String = "OD_MOSNO"                              ' 受注・発注No.
  Public Const CTRL_OD_TIME_ZONE As String = "OD_TIME_ZONE"                      ' 午前・午後区分
  Public Const CTRL_OD_PROXY_CUSTOMER_CODE As String = "OD_PROXY_CUSTOMER_CODE"  ' 代理発注者コード
  Public Const CTRL_OD_PROXY_CUSTOMER_NAME As String = "OD_PROXY_CUSTOMER_NAME"  ' 代理発注者名
  Public Const CTRL_OD_ITEM_CATEGORY_CODE As String = "OD_ITEM_CATEGORY_CODE"    ' 商品カテゴリコード
  Public Const CTRL_OD_ITEM_CATEGORY_NAME As String = "OD_ITEM_CATEGORY_NAME"    ' 商品カテゴリ名
  Public Const CTRL_OD_RESULT_WEIGHT As String = "OD_RESULT_WEIGHT"              ' 重量実績
  Public Const CTRL_OD_RESULT_UNIT_PRICE As String = "OD_RESULT_UNIT_PRICE"      ' 価格実績
  Public Const CTRL_OD_RESULT_TOTAL As String = "OD_RESULT_TOTAL"                ' 実績小計
  Public Const CTRL_OD_RESULT_WEIGHT_STR As String = "OD_RESULT_WEIGHT_STR"      ' 重量実績(文字列形式)

  'Informart受注データ変換
  Public Const CTRL_IM_KUBUN As String = "IM_KUBUN"
  Public Const CTRL_IM_FORM_DATE As String = "IM_FORM_DATE"
  Public Const CTRL_IM_INFORMART_NO As String = "IM_INFORMART_NO"
  Public Const CTRL_IM_TRADE_STATUS As String = "IM_TRADE_STATUS"
  Public Const CTRL_IM_COMPANY_CODE As String = "IM_COMPANY_CODE"
  Public Const CTRL_IM_COMPANY_NAME As String = "IM_COMPANY_NAME"
  Public Const CTRL_IM_COMPANY_TANTO_NAME As String = "IM_COMPANY_TANTO_NAME"
  Public Const CTRL_IM_CUSTOMER_CODE As String = "IM_CUSTOMER_CODE"
  Public Const CTRL_IM_CUSTOMER_NAME As String = "IM_CUSTOMER_NAME"
  Public Const CTRL_IM_CUSTOMER_TANTO_NAME As String = "IM_CUSTOMER_TANTO_NAME"
  Public Const CTRL_IM_SUBJECT_NAME As String = "IM_SUBJECT_NAME"
  Public Const CTRL_IM_DELIVERY_CODE As String = "IM_DELIVERY_CODE"
  Public Const CTRL_IM_DELIVERY_NAME As String = "IM_DELIVERY_NAME"
  Public Const CTRL_IM_DELIVERY_ADDRESS As String = "IM_DELIVERY_ADDRESS"
  Public Const CTRL_IM_ORDER_SUB_NUMBER As String = "IM_ORDER_SUB_NUMBER"
  Public Const CTRL_IM_CATALOG_ID As String = "IM_CATALOG_ID"
  Public Const CTRL_IM_ITEM_CODE As String = "IM_ITEM_CODE"
  Public Const CTRL_IM_ITEM_NAME As String = "IM_ITEM_NAME"
  Public Const CTRL_IM_KIKAKU As String = "IM_KIKAKU"
  Public Const CTRL_IM_IRISU As String = "IM_IRISU"
  Public Const CTRL_IM_IRISU_UNIT As String = "IM_IRISU_UNIT"
  Public Const CTRL_IM_COST As String = "IM_COST"
  Public Const CTRL_IM_QUANTITY As String = "IM_QUANTITY"
  Public Const CTRL_IM_UNIT As String = "IM_UNIT"
  Public Const CTRL_IM_AMOUNT As String = "IM_AMOUNT"
  Public Const CTRL_IM_TAX As String = "IM_TAX"
  Public Const CTRL_IM_SUB_TOTAL As String = "IM_SUB_TOTAL"
  Public Const CTRL_IM_TAX_LEVY_TYPE As String = "IM_TAX_LEVY_TYPE"
  Public Const CTRL_IM_TAX_TYPE As String = "IM_TAX_TYPE"
  Public Const CTRL_IM_ITEM_TOTAL As String = "IM_ITEM_TOTAL"
  Public Const CTRL_IM_ITEM_TAX_TOTAL As String = "IM_ITEM_TAX_TOTAL"
  Public Const CTRL_IM_SHIPPING_TOTAL As String = "IM_SHIPPING_TOTAL"
  Public Const CTRL_IM_SHIPPING_TAX_TOTAL As String = "IM_SHIPPING_TAX_TOTAL"
  Public Const CTRL_IM_OTHER_TOTAL As String = "IM_OTHER_TOTAL"
  Public Const CTRL_IM_GRAND_TOTAL As String = "IM_GRAND_TOTAL"
  Public Const CTRL_IM_ORDER_DATE As String = "IM_ORDER_DATE"
  Public Const CTRL_IM_SENDING_DATE As String = "IM_SENDING_DATE"
  Public Const CTRL_IM_DELIVERY_DATE As String = "IM_DELIVERY_DATE"
  Public Const CTRL_IM_RECEIVED_DATE As String = "IM_RECEIVED_DATE"
  Public Const CTRL_IM_TAX_CODE As String = "IM_TAX_CODE"
  Public Const CTRL_IM_TAX_NAME As String = "IM_TAX_NAME"
  Public Const CTRL_IM_DECIMAL_CODE As String = "IM_DECIMAL_CODE"
  Public Const CTRL_IM_DECIMAL_NAME As String = "IM_DECIMAL_NAME"
  Public Const CTRL_IM_TRADE_ID As String = "IM_TRADE_ID"
  Public Const CTRL_IM_ORDER_ID As String = "IM_ORDER_ID"
  Public Const CTRL_IM_STATUS As String = "IM_STATUS"
  Public Const CTRL_IM_ORDER_SEND_DATE As String = "IM_ORDER_SEND_DATE"
  Public Const CTRL_IM_ORDER_SEND_TIME As String = "IM_ORDER_SEND_TIME"
  Public Const CTRL_IM_SEND_DATE As String = "IM_SEND_DATE"
  Public Const CTRL_IM_SEND_TIME As String = "IM_SEND_TIME"
  Public Const CTRL_IM_ORDER_NUMBER As String = "IM_ORDER_NUMBER"
  Public Const CTRL_IM_LAST_ORDER_NUMBER As String = "LAST_ORDER_NUMBER"


  ' 受注処理画面明細
  Public Const CTRL_OP_LOAD As String = "Load"                                ' ロード情報
  Public Const CTRL_OP_ROWNO As String = "RowNo"                              ' 受注明細番号
  Public Const CTRL_OP_KUBUNCD As String = "KubunCD"                          ' 区分コード
  Public Const CTRL_OP_KUBUN As String = "Kubun"                              ' 区分 
  Public Const CTRL_OP_ITEMCD As String = "ItemCD"                            ' 商品コード
  Public Const CTRL_OP_ITEMNAME As String = "ItemName"                        ' 商品名
  Public Const CTRL_OP_KIKAKU As String = "Kikaku"                            ' 規格
  Public Const CTRL_OP_TAXTYPE As String = "TaxType"                          ' 税区分
  Public Const CTRL_OP_USEDATE As String = "UseDate"                          ' 使用日
  Public Const CTRL_OP_QUANTITY As String = "Quantity"                        ' 数量
  Public Const CTRL_OP_ORDERUNIT As String = "OrderUnit"                      ' 単位
  Public Const CTRL_OP_WEIGHTTYPE As String = "WeightType"                    ' 定貫区分
  Public Const CTRL_OP_JYOUDAITANKA As String = "JyoudaiTanka"                ' 上代単価
  Public Const CTRL_OP_LASTJYOUDAITANKA As String = "LASTJyoudaiTanka"        ' 上代単価（前回入力値）
  Public Const CTRL_OP_JUCHUTANKA As String = "JuchuuTanka"                   ' 受注単価
  Public Const CTRL_OP_LASTJUCHUTANKA As String = "LASTJuchuuTanka"           ' 受注単価（前回入力値）
  Public Const CTRL_OP_TEKIYOU As String = "Tekiyou"                          ' 摘要
  Public Const CTRL_OP_KINGAKU As String = "Kingaku"                          ' 金額
  Public Const CTRL_OP_DECIMAL_POINT As String = "decimalPiont"               ' HT重量小数桁数
  Public Const CTRL_OP_BUICODE As String = "BuiCode"                          ' 部位コード
  Public Const CTRL_OP_SHOHINC As String = "SHOHINC"                          ' 食肉標準コード
  Public Const CTRL_OP_LASTPRODUCT As String = "LASTPRODUCT"                  ' 商品コード（前回入力値）
  Public Const CTRL_OP_INCTAXPRICE As String = "IncTaxPrice"                  ' 税込み金額
  Public Const CTRL_OP_TAX_RATE As String = "TaxRate"                         ' 税率
  Public Const CTRL_OP_TAX_PRICE As String = "TaxPrice"                       ' 消費税

  ' 売上状況一覧
  Public Const CTRL_SS_SALESNUMBER As String = "SALESNUMBER"                  ' 伝票番号
  Public Const CTRL_SS_SALESDATE As String = "SALESDATE"                      ' 売上日
  Public Const CTRL_SS_DELIVERYDATE As String = "DELIVERYDATE"                ' 納品日
  Public Const CTRL_SS_TKCODE As String = "TKCODE"                            ' 得意先コード
  Public Const CTRL_SS_TKNAME As String = "TKNAME"                            ' 得意先名    
  Public Const CTRL_SS_COMENT As String = "COMENT"                            ' 得意先コード
  Public Const CTRL_SS_REASON As String = "REASON"                            ' 得意先名    

  ' 得意先マスタ検索
  Public Const CTRL_CUST_OFFICECODE As String = "OFFICE_CODE"                 ' 事業所コード
  Public Const CTRL_CUST_CODE As String = "CUSTOMER_CODE"                     ' 得意先コード
  Public Const CTRL_CUST_CODE2 As String = "TKCODE"                           ' 得意先コード
  Public Const CTRL_CUST_NAME As String = "LTKNAME"                           ' 得意先名    
  Public Const CTRL_CUST_NAME2 As String = "TNAME"                            ' 得意先名    
  Public Const CTRL_CUST_KANA As String = "FURIGANA"                          ' フリガナ
  Public Const CTRL_CUST_SHORT_NAME As String = "SHORT_NAME"                  ' 得意先略称
  Public Const CTRL_CUST_POSTCODE As String = "YUBIN"                         ' 郵便番号
  Public Const CTRL_CUST_ADDRESS1 As String = "ADDRESS01"                     ' 住所１
  Public Const CTRL_CUST_ADDRESS2 As String = "ADDRESS02"                     ' 住所２
  Public Const CTRL_CUST_TEL As String = "TELA"                               ' 電話番号
  Public Const CTRL_CUST_FAX As String = "TELF"                               ' FAX番号

  Public Const CTRL_CUST_SHIME1 As String = "SSHIMEBI1"                       ' 締め日１
  Public Const CTRL_CUST_SHIME2 As String = "SSHIMEBI2"                       ' 締め日２
  Public Const CTRL_CUST_SHIME3 As String = "SSHIMEBI3"                       ' 締め日３
  Public Const CTRL_CUST_KAI1 As String = "KAISYUBI1"                         ' 入金予定日１
  Public Const CTRL_CUST_KAI2 As String = "KAISYUBI2"                         ' 入金予定日２
  Public Const CTRL_CUST_KAI3 As String = "KAISYUBI3"                         ' 入金予定日３
  Public Const CTRL_OUTPUT_ORDERDETAIL As String = "OUTPUT_ORDERDETAIL"       ' 出荷明細書出力
  Public Const CTRL_OUTPUT_EXCEL As String = "OUTPUT_EXCEL"                   ' Excel出力
  Public Const CTRL_TRANSACTION_START As String = "TRANSACTION_START"         ' 取引開始日
  Public Const CTRL_SEIKYU_CODE As String = "SSCODE"                          ' 請求先コード
  Public Const CTRL_SEIKYU_NAME As String = "SEIKYU_NAME"                     ' 請求先名
  Public Const CTRL_CUST_PRODUCT_CODE As String = "TKITEM_CODE"               ' 得商参照コード

  Public Const CTRL_CUST_TYPE1 As String = "CUSTOMER_TYPE01"                  ' 分類コード１
  Public Const CTRL_CUST_TYPE1NAME As String = "CUSTOMER_TYPE1NAME"           ' 分類コード１名称名
  Public Const CTRL_CUST_TYPE2 As String = "CUSTOMER_TYPE02"                  ' 分類コード２
  Public Const CTRL_CUST_TYPE2NAME As String = "CUSTOMER_TYPE2NAME"           ' 分類コード２名称名
  Public Const CTRL_CUST_TANTOCODE As String = "TANTO_CODE"                   ' 担当者コード
  Public Const CTRL_CUST_TANTONAME As String = "CUSTOMER_TANTONAME"           ' 担当者名
  Public Const CTRL_CUST_PRODUCTNAME1 As String = "TKNAME1"                   ' ラベル商品名１
  Public Const CTRL_CUST_PRODUCTNAME2 As String = "TKNAME2"                   ' ラベル商品名２
  Public Const CTRL_CUST_INFO As String = "INFORMATION"                     　' 情報
  Public Const CTRL_CUST_EN_USEDATE As String = "ENABLE_USEDATE"              ' 使用日使用フラグ
  Public Const CTRL_CUST_DELIVERYFLG As String = "PRINTDELIVERY"              ' 加工印刷FLG
  Public Const CTRL_CUST_PROCESSFLG As String = "PRINTPROCESSING"             ' 配送印刷FLG

  ' 商品マスタ検索
  Public Const CTRL_PRODUCT_CODE As String = "PRODUCT_CODE"                   ' 商品コード
  Public Const CTRL_PRODUCT_NAME1 As String = "PRODUCT_NAME1"                 ' 商品名１
  Public Const CTRL_PRODUCT_NAME2 As String = "PRODUCT_NAME2"                 ' 商品名２
  Public Const CTRL_PRODUCT_STANDARD As String = "PRODUCT_STANDARD"           ' 規格
  Public Const CTRL_PRODUCT_CLS1 As String = "PRODUCT_CLS1"                   ' 商品分類コード１
  Public Const CTRL_PRODUCT_CLS2 As String = "PRODUCT_CLS2"                   ' 商品分類コード２
  Public Const CTRL_PRODUCT_SUP As String = "PRODUCT_SUP"                     ' 標準売上単価
  Public Const CTRL_PRODUCT_COST As String = "PRODUCT_COST"                   ' 標準原価単価
  Public Const CTRL_PRODUCT_QUANTITY As String = "PRODUCT_QUANTITY"           ' 入数
  Public Const CTRL_PRODUCT_UNIT As String = "PRODUCT_ORDER_UNIT"             ' 受注単位
  Public Const CTRL_JAN_CODE As String = "JAN_CODE"                           ' JANコード（未使用）
  Public Const CTRL_PRODUCT_KANANAME As String = "PRODUCT_KANANAME"           ' 商品名フリガナ
  Public Const CTRL_PCA_CODE1 As String = "PCA_CODE1"                         ' PCAコード
  Public Const CTRL_MEAT_CODE1 As String = "MEAT_CODE1"                       ' 食肉標準コード
  Public Const CTRL_SALES_UNIT As String = "SALES_UNIT"                       ' 売上単位
  Public Const CTRL_PRODUCT_REMARKS As String = "PRODUCT_REMARKS"             ' 備考
  Public Const CTRL_PURCHASE_PRICE As String = "PURCHASE_PRICE"               ' 仕入単価
  Public Const CTRL_STANDARD_PRICE As String = "STANDARD_PRICE"               ' 標準上代単価
  Public Const CTRL_CONSTANT As String = "CONSTANT"                           ' 定貫区分
  Public Const CTRL_CONSTANT_LABEL As String = "CONSTANT_LABEL"               ' 定貫区分ラベル
  Public Const CTRL_HT_PROCESS As String = "HT_PROCESS"                       ' HT加工区分
  Public Const CTRL_DECIMAL_POINT As String = "DECIMAL_POINT"                 ' HT重量小数桁数
  Public Const CTRL_BUICODE As String = "BUICODE"                          　 ' 部位コード
  Public Const CTRL_TEMPCODE As String = "TEMPCODE"                        　 ' 温度コード
  Public Const CTRL_BESTBEFOREDAYS As String = "BESTBEFOREDAYS"            　 ' 賞味期限日数
  Public Const CTRL_FORMATNO As String = "FORMATNO"                        　 ' フォーマット番号
  Public Const CTRL_LABELPRODUCTNAME1 As String = "LABELPRODUCTNAME1"      　 ' ラベル商品名１
  Public Const CTRL_LABELPRODUCTNAME2 As String = "LABELPRODUCTNAME2"      　 ' ラベル商品名２
  Public Const CTRL_FAXOCR As String = "FAXOCR"                               ' FAXOCR区分
  Public Const CTRL_KUBUN As String = "KUBUN"                                 ' 区分

  ' 得意先別　商品選択
  Public Const CTRL_CP_TKCODE As String = "CP_TKCODE"                         ' 得意先コード
  Public Const CTRL_CP_TKNAME As String = "CP_TKNAME"                         ' 得意先名
  Public Const CTRL_CP_SHOHINCODE1 As String = "CP_SHOHINCODE1"               ' 商品コード  
  Public Const CTRL_CP_SHOHINCODE2 As String = "CP_SHOHINCODE2"               ' 客先品番
  Public Const CTRL_CP_SHOHINNAME As String = "CP_SHOHINNAME"                 ' 客先商品名
  Public Const CTRL_CP_COST_STANDARD As String = "CP_COST_STANDARD"        　 ' 売上単価
  Public Const CTRL_CP_PRICE_RETAILT As String = "CP_PRICE_RETAILT"           ' 上代単価
  Public Const CTRL_CP_RESERVE As String = "CP_RESERVE"                       ' 定貫 
  Public Const CTRL_CP_ITEMCOUNT As String = "ITEMCOUNT"                      ' 数量
  Public Const CTRL_CP_UNIT As String = "CP_UNIT"                             ' 単位
  Public Const CTRL_CP_CONSTANT As String = "CP_CONSTANT"                     ' 定貫
  Public Const CTRL_CP_DESCRIPTION As String = "CP_DESCRIPTION"               ' 摘要
  Public Const CTRL_CP_ORDER As String = "CP_ORDER"                           ' 並び順
  Public Const CTRL_CP_KUBUN As String = "CP_KUBUN"                           ' 区分
  Public Const CTRL_CP_KUBUN2 As String = "CP_KUBUN2"                         ' 区分

  ' 受注履歴
  Public Const CTRL_HISTORY_ORDEYMD As String = "HISTORY_ORDEYMD"             ' 受注年月日
  Public Const CTRL_HISTORY_DENNO As String = "HISTORY_DENNO"                 ' 伝票番号
  Public Const CTRL_HISTORY_SEQ As String = "HISTORY_SEQ"                     ' 番号
  Public Const CTRL_HISTORY_KUBBUN As String = "HISTORY_KUBBUN"               ' 区分
  Public Const CTRL_HISTORY_TKCODE As String = "HISTORY_TKCODE"               ' 得意先コード
  Public Const CTRL_HISTORY_TKNAME As String = "HISTORY_TKNAME"               ' 得意先名
  Public Const CTRL_HISTORY_PRODUCTCODE As String = "HISTORY_PRODUCTCODE"     ' 商品コード
  Public Const CTRL_HISTORY_PRODUCTNAME As String = "HISTORY_PRODUCTNAME"     ' 商品名
  Public Const CTRL_HISTORY_COUNT As String = "HISTORY_COUNT"                 ' 数量
  Public Const CTRL_HISTORY_TANKA As String = "HISTORY_TANKA"                 ' 単価
  Public Const CTRL_HISTORY_KINGAKU As String = "HISTORY_KINGAKU"             ' 金額
  Public Const CTRL_HISTORY_TEKIYOU As String = "HISTORY_TEKIYOU"             ' 摘要
  Public Const CTRL_HISTORY_TANTOCODE As String = "HISTORY_TANTOCODE"         ' 担当者コード
  Public Const CTRL_HISTORY_SCODE As String = "HISTORY_SCODE"                 ' 商品コード
  Public Const CTRL_HISTORY_PROCESSNO As String = "HISTORY_PROCESSNO"         ' 処理No
  Public Const CTRL_HISTORY_UNIT As String = "HISTORY_UNIT"                   ' 単位

  ' 受注伝票検索
  'Public Const CTRL_OS_SLIPNUMBER As String = "OS_SLIPNUMBER"                               ' 受注伝票番号
  Public Const CTRL_OS_ESTIMATENUMBER As String = "OS_ESTIMATENUMBER"                       ' 見積NO  
  Public Const CTRL_OS_ORDER_NUMBER As String = "OS_ORDER_NUMBER"                           ' 伝票番号
  Public Const CTRL_OS_SALES_NUMBER As String = "OS_SALES_NUMBER"                           ' 受注番号
  Public Const CTRL_OS_DELIVERYDATE As String = "OS_DELIVERYDATE"                           ' 納品日  
  Public Const CTRL_OS_ORDERDATE As String = "OS_ORDERDATE"                                 ' 受注年月日
  Public Const CTRL_OS_SALESDATE As String = "OS_SALESDATE"                                 ' 売上日
  Public Const CTRL_OS_OFFICECOD As String = "OS_OFFICECOD"                                 ' 事業所コード  
  Public Const CTRL_OS_DELIVERYDESTCODE As String = "OS_DELIVERYDESTCODE"                   ' 納入先コード  
  Public Const CTRL_OS_CUSTOMERCODE As String = "OS_CUSTOMERCODE"                           ' 得意先コード
  Public Const CTRL_OS_DELIVERYDESTNAME As String = "OS_DELIVERYDESTNAME"                   ' 納入先名
  Public Const CTRL_OS_CUSTOMERNAME As String = "OS_CUSTOMERNAME"                           ' 得意先名        
  Public Const CTRL_OS_AMOUNTEXCLUDINGTAX As String = "OS_AMOUNTEXCLUDINGTAX"               ' 税抜金額      
  Public Const CTRL_OS_CUSTOMERSERVICECODE As String = "OS_CUSTOMERSERVICECODE"             ' 担当者コード
  Public Const CTRL_OS_CUSTOMERSERVICENAME As String = "OS_CUSTOMERSERVICENAME"             ' 担当者名
  Public Const CTRL_OS_OPERATORCODE As String = "OS_OPERATORCODE"                           ' オペレータ
  Public Const CTRL_OS_AMOUNTINCLUDINGTAX As String = "OS_AMOUNTINCLUDINGTAX"               ' 税込金額
  Public Const CTRL_OS_UPDDT As String = "UPDDT"                                            ' 入力更新日
  Public Const CTRL_OS_PRODCD As String = "PRODCD"                                          ' 商品コード  
  Public Const CTRL_OS_PRODNM As String = "PRODNM"                                          ' 商品名
  Public Const CTRL_OS_PRICE_RETAIL As String = "PRICE_RETAIL"                              ' 上代単価
  Public Const CTRL_OS_COST_STANDARD As String = "COST_STANDARD"                            ' 受注単価
  Public Const CTRL_OS_ORDER_QUANTITY As String = "ORDER_QUANTITY"                          ' 受注数量
  Public Const CTRL_OS_ORDER_WEIGHT As String = "ORDER_WEIGHT"                              ' 受注重量      
  Public Const CTRL_ORDER_KUBUN As String = "ORDER_KUBUN"                                   ' 受注区分

  ' 仕入変換
  Public Const CTRL_STK_CHECK_BOX As String = "STK_CHECKBOX"                                ' 選択チェックボックス      
  Public Const CTRL_STK_IN_STOCK_DATE As String = "STK_IN_STOCK_DATE"                       ' 仕入日
  Public Const CTRL_STK_SUPPLIER_CODE As String = "STK_SUPPLIER_CODE"                       ' 仕入先コード      
  Public Const CTRL_STK_EDABAN As String = "STK_EDABAN"                                     ' 枝番      
  Public Const CTRL_STK_PROCESSING_DATE As String = "STK_PROCESSING_DATE"                   ' 受注重量      
  Public Const CTRL_STK_ITEM_CODE As String = "STK_ITEM_CODE"                               ' 商品コード      
  Public Const CTRL_STK_KOTAINO As String = "STK_KOTAINO"                                   ' 個体識別番号      
  Public Const CTRL_STK_ITEM_WEIGHT As String = "STK_ITEM_WEIGHT"                           ' 数量      
  Public Const CTRL_STK_ITEM_WEIGHT_DISP As String = "STK_ITEM_WEIGHT_DISP"                 ' 数量（表示用）     
  Public Const CTRL_STK_CARTON_NUMBER As String = "STK_CARTON_NUMBER"                       ' カートン番号      
  Public Const CTRL_STK_SIDE_TYPE As String = "STK_SIDE_TYPE"                               ' 左右      
  Public Const CTRL_STK_ORIGIN_PLACE As String = "STK_ORIGIN_PLACE"                         ' 品種コード      
  Public Const CTRL_STK_KIND_CODE As String = "STK_KIND_CODE"                               ' 産地コード      
  Public Const CTRL_STK_COST_PRICE As String = "STK_COST_PRICE"                             ' 単価      
  Public Const CTRL_STK_HENKAN As String = "STK_HENKAN"                                     ' 商品コード（変換）      
  Public Const CTRL_STK_ITEM_NAME As String = "STK_ITEM_NAME"                               ' 商品名      
  Public Const CTRL_STK_KIKA_NAME As String = "STK_KIKA_NAME"                               ' 規格型番      
  Public Const CTRL_STK_GEN_NAME As String = "STK_GEN_NAME"                                 ' 原産地      
  Public Const CTRL_STK_KINGAKU As String = "STK_KINGAKU"                                   ' 金額      
  Public Const CTRL_STK_CUSTOMER_NAME As String = "STK_CUSTOMER_NAME"                       ' 仕入先名      
  Public Const CTRL_STK_UNIT_SALES As String = "STK_UNIT_SALES"                             ' 単位      

  ' 前回伝票　複写
  Public Const CTRL_LS_SLIPNUMBER As String = "LS_SLIPNUMBER"                                 ' 伝票番号 
  Public Const CTRL_LS_INPUTDATE As String = "LS_INPUTDATE"                                   ' 入力年月日   
  Public Const CTRL_LS_ORDERDATE As String = "LS_ORDERDATE"                                   ' 受注年月日
  Public Const CTRL_LS_OFFICECOD As String = "LS_OFFICECOD"                                   ' 事業所コード
  Public Const CTRL_LS_DELIVERYDESTCODE As String = "LS_DELIVERYDESTCODE"                     ' 納入先コード
  Public Const CTRL_LS_CUSTOMERCODE As String = "LS_CUSTOMERCODE"                             ' 得意先コード
  Public Const CTRL_LS_DELIVERYDESTNAME As String = "LS_DELIVERYDESTNAME"                     ' 納入先名  
  Public Const CTRL_LS_CUSTOMERNAME As String = "LS_CUSTOMERNAME"                             ' 得意先名
  Public Const CTRL_LS_AMOUNTEXCLUDINGTAX As String = "LS_AMOUNTEXCLUDINGTAX"                 ' 税抜金額  
  Public Const CTRL_LS_AMOUNTINCLUDINGTAX As String = "LS_AMOUNTINCLUDINGTAX"                 ' 税込金額  
  Public Const CTRL_LS_CUSTOMERSERVICECODE As String = "LS_CUSTOMERSERVICECODE"               ' 担当者コード
  Public Const CTRL_LS_OPERATORCODE As String = "LS_OPERATORCODE"                             ' オペレータコード
  Public Const CTRL_LS_SALESNUMBER As String = "LS_SALESNUMBER"                               ' 売上伝票番号 

  '請求明細照会
  Public Const CTRL_BD_ORDERDATE As String = "BD_ORDERDATE"                                   ' 日付
  Public Const CTRL_BD_SLIPNUMBER As String = "BD_SLIPNUMBER"                                 ' 伝票番号
  Public Const CTRL_BD_BILLINGCATEGORY As String = "BD_BILLINGCATEGORY"                       ' 区分
  Public Const CTRL_BD_PRODUCTNAME As String = "BD_PRODUCTNAME"                               ' 商品名
  Public Const CTRL_BD_PRODUCTQUANTITY As String = "BD_PRODUCTQUANTITY"                       ' 数量
  Public Const CTRL_BD_UNITPRICE As String = "BD_UNITPRICE"                                   ' 単価
  Public Const CTRL_BD_AMOUNT As String = "BD_AMOUNT"                                         ' 金額
  Public Const CTRL_BD_REMARK As String = "BD_REMARK"                                         ' 備考
  Public Const CTRL_BD_DELIVERYDESTINATION As String = "BD_DELIVERYDESTINATION"               ' 納入先
  Public Const CTRL_BD_BDL As String = "BD_BDL"                                               ' 締切日
  Public Const CTRL_BD_CSTCD As String = "BD_CSTCD"                                           ' 得意先コード

  ' 納入先マスタ検索
  Public Const CTRL_DELIVERY_CUSTOMERCODE As String = "DELIVERY_CUSTOMERCODE"                 ' 得意先コード
  Public Const CTRL_DELIVERY_CUSTOMERNAME As String = "DELIVERY_CUSTOMERNAME"                 ' 得意先名
  Public Const CTRL_DELIVERY_CODE As String = "DELIVERY_CODE"                                 ' 納入先コード
  Public Const CTRL_DELIVERY_NAME As String = "DELIVERY_NAME"                                 ' 納入先名
  Public Const CTRL_DELIVERY_KANA As String = "DELIVERY_KANA"                                 ' 納入先名フリガナ
  Public Const CTRL_DELIVERY_ADDRESS As String = "DELIVERY_ADDRESS"                           ' 納入先住所１＆２
  Public Const CTRL_DELIVERY_PHONE As String = "DELIVERY_PHONE"                               ' 納入先電話番号
  Public Const CTRL_DELIVERY_FAX As String = "DELIVERY_FAX" 　　                              ' 納入先ＦＡＸ番号
  Public Const CTRL_DELIVERY_POSTCODE As String = "DELIVERY_POSTCODE"                         ' 納入先郵便番号
  Public Const CTRL_DELIVERY_ADDRESS1 As String = "DELIVERY_ADDRESS1"                         ' 納入先住所１
  Public Const CTRL_DELIVERY_ADDRESS2 As String = "DELIVERY_ADDRESS2"                         ' 納入先住所２
  Public Const CTRL_DELIVERY_COMPANYCODE As String = "DELIVERY_COMPANYCODE"                   ' 納入先運送会社コード
  ' 取引区分検索
  Public Const CTRL_TRNCLS_CODE As String = "TRNCLS_CODE"                     ' 取引区分コード
  Public Const CTRL_TRNCLS_NAME As String = "TRNCLS_NAME"                     ' 取引区分名
  Public Const CTRL_TRNCLS_REMARK As String = "TRNCLS_REMARK"                 ' 取引区分備考

  ' 得意先分類コード１検索
  Public Const CTRL_CUSTCLS1_NAMECODE As String = "CUSTCLS1_NAMECODE"         ' 得意先分類コード１名称コード
  Public Const CTRL_CUSTCLS1_NAME As String = "CUSTCLS1_NAME"                 ' 得意先分類コード１名称名
  Public Const CTRL_CUSTCLS1_KANA As String = "CUSTCLS1_KANA"                 ' 得意先分類コード１フリガナ
  Public Const CTRL_CUSTCLS1_REMARKS As String = "CUSTCLS1_REMARKS"           ' 得意先分類コード１備考
  Public Const CTRL_CUSTCLS1_INDEX As String = "CUSTCLS1_INDEX"             　' 得意先分類コード１連番

  ' 得意先分類コード２検索
  Public Const CTRL_CUSTCLS2_NAMECODE As String = "CUSTCLS2_NAMECODE"         ' 得意先分類コード２名称コード
  Public Const CTRL_CUSTCLS2_NAME As String = "CUSTCLS2_NAME"                 ' 得意先分類コード２名称名
  Public Const CTRL_CUSTCLS2_KANA As String = "CUSTCLS2_KANA"                 ' 得意先分類コード２フリガナ
  Public Const CTRL_CUSTCLS2_REMARKS As String = "CUSTCLS2_REMARKS"           ' 得意先分類コード２備考

  ' 事業所検索
  Public Const CTRL_OFFICE_CODE As String = "OFFICE_CODE"                     ' 事業所コード
  Public Const CTRL_OFFICE_NAME As String = "OFFICE_NAME"                     ' 事業所名
  Public Const CTRL_OFFICE_POCODE As String = "OFFICE_POCODE"                 ' 事業所郵便番号
  Public Const CTRL_OFFICE_ADDRESS As String = "OFFICE_ADDRESS"               ' 事業所住所
  Public Const CTRL_OFFICE_PHONE As String = "OFFICE_PHONE"                   ' 事業所電話番号

  ' 運送会社検索
  Public Const CTRL_COMPANY_CODE As String = "CODE"                           ' コード
  Public Const CTRL_COMPANY_NAME As String = "NAME"                           ' 運送会社名

  ' オペレータ検索
  Public Const CTRL_OPERATOR_CODE As String = "OPERATOR_CODE"                 ' オペレータコード
  Public Const CTRL_OPERATOR_NAME As String = "OPERATOR_NAME"                 ' オペレータ名
  Public Const CTRL_OPERATOR_SECURITY As String = "OPERATOR_SECURITY"         ' セキュリティ

  ' 商品分類コード１検索
  Public Const CTRL_PRODUCTCLS1_NAMECODE As String = "PRODUCTCLS1_NAMECODE"   ' 商品分類コード１
  Public Const CTRL_PRODUCTCLS1_NAME As String = "PRODUCTCLS1_NAME"           ' 商品分類コード１名称
  Public Const CTRL_PRODUCTCLS1_KANA As String = "PRODUCTCLS1_KANA"           ' 商品分類コード１名称フリガナ
  Public Const CTRL_PRODUCTCLS1_REMARKS As String = "PRODUCTCLS1_REMARKS"     ' 商品分類コード１備考

  ' 商品分類コード２検索
  Public Const CTRL_PRODUCTCLS2_NAMECODE As String = "PRODUCTCLS2_NAMECODE"   ' 商品分類コード１
  Public Const CTRL_PRODUCTCLS2_NAME As String = "PRODUCTCLS2_NAME"           ' 商品分類コード１名称
  Public Const CTRL_PRODUCTCLS2_KANA As String = "PRODUCTCLS2_KANA"           ' 商品分類コード１名称フリガナ
  Public Const CTRL_PRODUCTCLS2_REMARKS As String = "PRODUCTCLS2_REMARKS"     ' 商品分類コード１備考

  ' 担当者検索
  Public Const CTRL_SERV_CODE As String = "SERV_CODE"                         ' 担当者コード
  Public Const CTRL_SERV_SUB_CODE As String = "SERV_SUB_CODE"                 ' 担当者サブコード
  Public Const CTRL_SERV_NAME As String = "SERV_NAME"                         ' 担当者名
  Public Const CTRL_SERV_KANA As String = "SERV_KANA"                         ' 担当者フリガナ
  Public Const CTRL_SERV_REMARKS As String = "SERV_REMARKS"                   ' 担当者備考

  ' 単位マスタ検索
  Public Const CTRL_UNIT_CODE As String = "ID"                                ' 単位コード
  Public Const CTRL_UNIT_NAME As String = "NAME"                              ' 単位名

  ' 汎用コンボボックス
  Public Const CTRL_COMMON_CODE As String = "COMMON_CODE"                     ' コード
  Public Const CTRL_COMMON_NAME As String = "COMMON_NAME"                     ' コード名称


#Region "売上処理"
  Public Const CTRL_SP_CUSTOMER_CODE As String = "SP_CUSTOMER_CODE"               ' 得意先コード
  Public Const CTRL_SP_ORDER_NUMBER As String = "SP_ORDER_NUMBER"                 ' 受注伝票番号
  Public Const CTRL_SP_ORDER_SUB_NUMBER As String = "SP_ORDER_SUB_NUMBER"         ' 受注行番号
  Public Const CTRL_SP_ORDER_DATE As String = "SP_ORDER_DATE"                     ' 受注日
  Public Const CTRL_SP_DELIVERY_DATE As String = "SP_DELIVERY_DATE"               ' 納品日
  Public Const CTRL_SP_SALES_DATE As String = "SP_SALES_DATE"                     ' 売上日
  Public Const CTRL_SP_CUSTOMER_NAME As String = "SP_CUSTOMER_NAME"               ' 得意先名称
  Public Const CTRL_SP_TANTO_CODE As String = "SP_TANTO_CODE"                     ' 担当コード
  Public Const CTRL_SP_TANTO_NAME As String = "SP_TANTO_NAME"                     ' 担当名
  Public Const CTRL_SP_ROOT_CODE As String = "SP_ROOT_CODE"                       ' 配送担当者コード
  Public Const CTRL_SP_ROOT_NAME As String = "SP_ROOT_NAME"                       ' 配送担当者名
  Public Const CTRL_SP_MEMO_TEXT2 As String = "MEMO_TEXT2"                        ' 伝票摘要
  Public Const CTRL_SP_DELIVERY_CUSTCODE As String = "SP_DELIVERY_CUSTOMERCODE"   ' 納入先コード
  Public Const CTRL_SP_COMMENT As String = "COMMENT_TEXT" 　                      ' 理由
  Public Const CTRL_SP_REASON As String = "REASON_TEXT"                           ' コメント


  Public Const CTRL_SP_ROW_NUM As String = "SP_ROW_NUMBER"                        ' 行番号
  Public Const CTRL_SP_KUBUN_CODE As String = "SP_KUBUN_CODE"                     ' 区分コード
  Public Const CTRL_SP_KUBUN_NAME As String = "SP_KUBUN_NAME"                     ' 区分名称
  Public Const CTRL_SP_ITEM_CODE As String = "SP_ITEM_CODE"                       ' 商品コード
  Public Const CTRL_SP_LASTITEM_CODE As String = "SP_LASTITEM_CODE"               ' 商品コード（前回入力値）
  Public Const CTRL_SP_ITEM_NAME As String = "SP_ITEM_NAME"                       ' 商品名
  Public Const CTRL_SP_KIKAKU As String = "SP_KIKAKU"                             ' 規格

  ''' <summary>
  ''' セット（親 or 子）
  ''' </summary>
  Public Const CTRL_SP_DETAIL_TYPE As String = "SP_DETAIL_TYPE"
  Public Const CTRL_SP_ORDER_UNIT As String = "SP_ORDER_UNIT"                     ' 受注単位
  Public Const CTRL_SP_ORDER_COUNT As String = "SP_ORDER_COUNT"                   ' 受注数量

  ''' <summary>
  ''' 上代単価
  ''' </summary>
  Public Const CTRL_SP_ORDER_PRICE_RETAIL As String = "SP_PRICE_RETAIL"           ' 上代単価
  Public Const CTRL_SP_LASTORDER_PRICE_RETAIL As String = "SP_LASTPRICE_RETAIL"   ' 上代単価（前回入力値）
  Public Const CTRL_SP_MEMO_TEXT As String = "SP_MEMO_TEXT"                       ' 摘要
  Public Const CTRL_SP_TAX_TYPE As String = "SP_TAX_TYPE"                         ' 税区分

  ''' <summary>
  ''' 売上数量
  ''' </summary>
  Public Const CTRL_SP_SALES_COUNT As String = "SP_SALES_COUNT"

  ''' <summary>
  ''' 売上単位
  ''' </summary>
  Public Const CTRL_SP_SALES_UNIT As String = "SP_SALES_UNIT"

  ''' <summary>
  ''' 売上単価
  ''' </summary>
  Public Const CTRL_SP_SALES_UNIT_PRICE As String = "SP_SALES_UNIT_PRICE"         ' 売上単価
  Public Const CTRL_SP_LASTSALES_UNIT_PRICE As String = "SP_LASTSALES_UNIT_PRICE" ' 売上単価（前回入力値）
  Public Const CTRL_SP_KOTAI_NO As String = "SP_KOTAI_NO"                         ' 個体識別番号
  Public Const CTRL_SP_EDABAN As String = "SP_EDABAN"                             ' 枝番
  Public Const CTRL_SP_SIDE_TYPE As String = "SP_SIDE_TYPE"                       ' 左右
  Public Const CTRL_SP_ORIGIN_PLACE As String = "SP_ORIGIN_PLACE"                 ' 原産地
  Public Const CTRL_SP_DECIMAL_POINT As String = "SP_DECIMAL_POINT"               ' HT重量小数桁数
  Public Const CTRL_SP_KIND_CODE As String = "SP_KIND_CODE"                       ' 品種
  Public Const CTRL_SP_TAX_RATE As String = "SP_TAX_RATE"                         ' 税率
  Public Const CTRL_SP_INCTAXPRICE As String = "SP_INCTAXPRICE"                   ' 税込み金額
  Public Const CTRL_SP_TAX_PRICE As String = "SP_TAX_PRICE"                       ' 消費税

  ''' <summary>
  ''' 金額
  ''' </summary>
  Public Const CTRL_SP_KINGAKU As String = "SP_KINGAKU"                           ' 金額
  Public Const CTRL_SP_WEIGHT_TYPE As String = "SP_WEIGHT_TYPE"                   ' 重量種別（定貫/不定貫）
  Public Const CTRL_SP_WEIGHT_TYPE_TEXT As String = "SP_WEIGHT_TYPE_TEXT"         ' 重量種別（定貫/不定貫）テキスト表示

  ''' <summary>
  ''' 使用日
  ''' </summary>
  Public Const CTRL_SP_USEDATE As String = "SP_USEDATE"

  ''' <summary>
  ''' ' 売上番号
  ''' </summary>
  Public Const CTRL_SP_SALES_NUMBER = "SALES_NUMBER"

  ''' <summary>
  ''' ' 売上明細番号
  ''' </summary>
  Public Const CTRL_SP_SALES_SUB_NUMBER = "SALES_SUB_NUMBER"

  ''' <summary>
  ''' ' PCA売上伝票番号
  ''' </summary>
  Public Const CTRL_SP_SALES_NUMBER_PCA = "SALES_NUMBER_PCA"

  ''' <summary>
  '''  ' PCA売上伝票明細番号
  ''' </summary>
  Public Const CTRL_SP_SALES_SUB_NUMBER_PCA = "SALES_SUB_NUMBER_PCA"

  ''' <summary>
  ''' ' ロット番号（受注番号＋受注明細番号）
  ''' </summary>
  Public Const CTRL_SP_LOT_NUMBER = "LOT_NUMBER"

  ''' <summary>
  ''' ' カートン番号
  ''' </summary>
  Public Const CTRL_SP_CARTON_NUMBER = "CARTON_NUMBER"

  ''' <summary>
  ''' ' 部位コード
  ''' </summary>
  Public Const CTRL_SP_PARTS_CODE = "PARTS_CODE"

  ''' <summary>
  ''' ' 計量重量
  ''' </summary>
  Public Const CTRL_SP_WEIGHING_VALUE = "WEIGHING_VALUE"

  ''' <summary>
  ''' ' 登録日
  ''' </summary>
  Public Const CTRL_SP_ENTRY_DATE = "ENTRY_DATE"

  ''' <summary>
  ''' ' 最終更新日
  ''' </summary>
  Public Const CTRL_SP_LASTUPDATE = "LASTUPDATE"

  ''' <summary>
  ''' ' 受注データ最終取込時刻
  ''' </summary>
  Public Const CTRL_SP_LASTUPDATE_ORDER = "LASTUPDATE_ORDER"

  ''' <summary>
  ''' ' 計量データ最終取込時刻
  ''' </summary>
  Public Const CTRL_SP_LASTUPDATE_SCALE = "LASTUPDATE_SCALE"

  ''' <summary>
  ''' ' 計量器番号
  ''' </summary>
  Public Const CTRL_SP_MACHINE_NUMBER = "MACHINE_NUMBER"

  ''' <summary>
  ''' ' 計量時刻
  ''' </summary>
  Public Const CTRL_SP_WEIGHING_DATE = "WEIGHING_DATE"

  ''' <summary>
  ''' 部位コード
  ''' </summary>
  Public Const CTRL_SP_BUI_CODE As String = "SP_BUI_CODE"

  ''' <summary>
  ''' 食肉標準コード
  ''' </summary>
  Public Const CTRL_SP_SHOHIN_CODE As String = "SP_SHOHIN_CODE"

#If 1 Then
  '''' <summary>
  '''' SQL SERVER接続先
  '''' </summary>
  'Public Shared ReadOnly DB_DATASOURCE As String = "pserver2022\trasa"
  ''Public Shared ReadOnly DB_DATASOURCE As String = "pserver2022\trasa"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "495344"

  '''' <summary>
  '''' PCA SERVER接続先
  '''' </summary>
  'Public Shared ReadOnly PCA_DATASOURCE As String = "pserver2022\PCADB"
  ''Public Shared ReadOnly PCA_DATASOURCE As String = "pserver2022\PCADB"
  'Public Shared ReadOnly PCA_DEFAULTDATABASE As String = "P20V01C001KON0001"
  ''Public Shared ReadOnly PCA_DEFAULTDATABASE As String = "P20V01C001KON0018"
  'Public Shared ReadOnly PCA_USERID As String = "sa"
  'Public Shared ReadOnly PCA_PASSWORD As String = "495344"

  '''' <summary>
  '''' PCA API接続先
  '''' </summary>
  'Public Shared ReadOnly PCAAPI_USERID As String = "aites"
  'Public Shared ReadOnly PCAAPI_PASSWORD As String = "495344"
  ''Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0018"
  'Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0001"
#Else

  ''' <summary>
  ''' SQL SERVER接続先
  ''' </summary>
  Public Shared ReadOnly DB_DATASOURCE As String = "pserver2022\trasa"
  Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  Public Shared ReadOnly DB_USERID As String = "sa"
  Public Shared ReadOnly DB_PASSWORD As String = "495344"

  ''' <summary>
  ''' PCA SERVER接続先
  ''' </summary>
  Public Shared ReadOnly PCA_DATASOURCE As String = "pserver2022\PCADB"
  Public Shared ReadOnly PCA_DEFAULTDATABASE As String = "P20V01C001KON0001"
  Public Shared ReadOnly PCA_USERID As String = "sa"
  Public Shared ReadOnly PCA_PASSWORD As String = "495344"

  ''' <summary>
  ''' PCA API接続先
  ''' </summary>
  Public Shared ReadOnly PCAAPI_USERID As String = "aites"
  Public Shared ReadOnly PCAAPI_PASSWORD As String = "495344"
  Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0001"
#End If

#If 0 Then
  ''' <summary>
  ''' SQL SERVER接続先
  ''' </summary>
  Public Shared ReadOnly DB_DATASOURCE As String = "pserver-test\trasa"
>>>>>>> af8bb292c88aa79b5d526158874cf6b7ed632516
  Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  Public Shared ReadOnly DB_USERID As String = "sa"
  Public Shared ReadOnly DB_PASSWORD As String = "495344"

  ''' <summary>
  ''' PCA SERVER接続先
  ''' </summary>
  Public Shared ReadOnly PCA_DATASOURCE As String = "pserver2022\PCADB"
#If DEBUG Then
  Public Shared ReadOnly PCA_DEFAULTDATABASE As String = "P20V01C001KON0001"
#Else
  Public Shared ReadOnly PCA_DEFAULTDATABASE As String = "P20V01C001KON0001"
#End If
  Public Shared ReadOnly PCA_USERID As String = "sa"
  Public Shared ReadOnly PCA_PASSWORD As String = "495344"

  ''' <summary>
  ''' PCA API接続先
  ''' </summary>
  Public Shared ReadOnly PCAAPI_USERID As String = "aites"
  Public Shared ReadOnly PCAAPI_PASSWORD As String = "495344"
#If DEBUG Then
  Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0001"
#Else
  Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0001"
#End If
#End If
  ''' <summary>
  ''' メインメニューiniファイル名
  ''' </summary>
  Public Shared ReadOnly PRG_FILENAME As String = "MainMenu.ini"

#End Region

End Class
