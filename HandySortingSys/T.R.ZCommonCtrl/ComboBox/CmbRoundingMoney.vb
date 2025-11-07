Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' 金額丸め区分コンボボックス
''' </summary>
Public Class CmbRoundingMoney
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
    MyBase.SetMsgLabelText("金額丸め区分を選択してください。")

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
    tmpkeyval("1") = "1 :四捨五入"
    tmpkeyval("2") = "2 :切り上げ"
    tmpkeyval("3") = "3 :切り捨て"
    tmpkeyval("99") = "99:システム区分"

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval)

  End Sub

#End Region
#End Region

End Class
