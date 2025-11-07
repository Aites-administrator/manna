Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 印刷区分コンボボックス
''' </summary>
Public Class CmbPrintKubun
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
    MyBase.SetMsgLabelText("印刷区分を選択してください。")

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

    Select Case InitType
      Case 1
        tmpkeyval("9") = "全て"
        tmpkeyval("1") = "受注残有り"
      Case 2
        tmpkeyval("9") = "全て"
        tmpkeyval("1") = "明細金額0円のみ印刷"
    End Select

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval, True)

  End Sub

#End Region
#End Region

End Class
