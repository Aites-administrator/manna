Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の定貫コンボボックス
''' </summary>
Public Class CmbHTProcessDivision
  Inherits CmbMstBase

#Region "コンストラクタ"

  Public Sub New()

    ' データソースをクリア  
    DataSource = Nothing

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("HT加工区分を選択してください。")

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
    tmpkeyval("000") = "0:加工指示あり"
    tmpkeyval("001") = "1:加工指示なし"

    ' コンボボックスにデータテーブルをセット
    InitCmbNonSql(tmpkeyval)

  End Sub

#End Region
#End Region

End Class






