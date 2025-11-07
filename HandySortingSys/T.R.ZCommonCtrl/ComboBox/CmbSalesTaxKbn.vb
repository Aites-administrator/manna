Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 売上税方式コンボボックス
''' </summary>
Public Class CmbCMSalesTaxKbn
  Inherits CmbMstBase

#Region "コンストラクタ"

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()

    ' データソースをクリア  
    DataSource = Nothing

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("売上税区分を選択してください。")

    MyBase.DropDownWidth = 280

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
    tmpkeyval("1") = "1 :外税"
    tmpkeyval("2") = "2 :内税"
    tmpkeyval("3") = "3 :非課税"
    tmpkeyval("99") = "99:商品売税"

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval)

  End Sub

#End Region
#End Region

End Class
