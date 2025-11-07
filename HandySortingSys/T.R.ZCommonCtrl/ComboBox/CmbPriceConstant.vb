Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 定貫コンボボックス
''' </summary>
Public Class CmbPriceConstant
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
    MyBase.SetMsgLabelText("定貫を選択してください。")

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
    tmpkeyval("0") = "0:定貫"
    tmpkeyval("1") = "1:不定貫"

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval)

  End Sub

#End Region
#End Region

End Class
