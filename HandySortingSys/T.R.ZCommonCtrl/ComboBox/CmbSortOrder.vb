Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 並び順コンボボックス
''' </summary>
Public Class CmbSortOrder
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
    MyBase.SetMsgLabelText("並び順を選択してください。")

    MyBase.DropDownWidth = 360

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

    Dim tmpkeyval As New Dictionary(Of String, String)

    ' Dictionaryにデータを追加
    Select Case InitType
      Case 1
        tmpkeyval("1") = "納期, 商品, 得意先"
        tmpkeyval("2") = "商品, 納期, 得意先"
        tmpkeyval("3") = "得意先, 商品, 納期"
        tmpkeyval("4") = "担当, 得意先, 商品, 納期"
        tmpkeyval("5") = "伝票番号"
        tmpkeyval("6") = "分類, 得意先, 商品, 納期"
      Case 2
        tmpkeyval("1") = "日付"
        tmpkeyval("2") = "取引先コード"
        tmpkeyval("3") = "伝票番号"

    End Select

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval, True)

  End Sub

#End Region
#End Region

End Class
