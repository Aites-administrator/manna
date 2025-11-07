Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 印刷再発行フラグコンボボックス
''' </summary>
Public Class CmbRePrintFlg
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
    MyBase.SetMsgLabelText("発行／再発行を選択してください。")

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
    tmpkeyval("0") = "発行"
    tmpkeyval("1") = "再発行"

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval, True)

  End Sub

#End Region
#End Region

End Class
