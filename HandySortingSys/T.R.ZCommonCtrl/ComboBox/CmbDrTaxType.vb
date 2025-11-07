Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の税区分コンボボックス
''' </summary>
Public Class CmbDrTaxType
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0"

#Region "コンストラクタ"

  Public Sub New()

    ' データソースをクリア  
    DataSource = Nothing

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5
    CodeFormat = CODE_FORMAT

    ' コンボボックスのコードチェックをスキップする
    SkipChkCode = True

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("税区分を選択してください。")

  End Sub

#End Region

#Region "デストラクタ"

  ''' <summary>
  ''' デストラクタ
  ''' </summary>
  Protected Overrides Sub Finalize()

    ClearDataSorce()

  End Sub

#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    SetCmbAdd()

  End Sub
#End Region

#Region "メソッド"
#Region "パブリック"

  ''' <summary>
  ''' データーリピータ上のコンボボックスコントロールの設定
  ''' </summary>
  Public Sub SetCmbAdd()

    ' データソースをクリア  
    DataSource = Nothing

    ' Dictionaryにデータを追加
    Dim tmpkeyval As New Dictionary(Of String, String)
    tmpkeyval("0") = clsGlobalData.TAX_NAME00
    tmpkeyval("1") = clsGlobalData.TAX_NAME01
    tmpkeyval("2") = clsGlobalData.TAX_NAME02
    tmpkeyval("3") = clsGlobalData.TAX_NAME03

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval)

  End Sub

#End Region
#End Region


End Class

