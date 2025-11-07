Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の部位コードコンボボックス
''' </summary>
Public Class CmbPriceMstBui
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0000"

#Region "コンストラクタ"

  Public Sub New()

    ' データソースをクリア  
    DataSource = Nothing

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5
    CodeFormat = CODE_FORMAT

    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("部位名を選択してください。")

    MyBase.DropDownWidth = 480

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc() As String
    Dim sql As String = String.Empty

    sql &= " SELECT FORMAT(CONVERT(int,CAST(SRC.BICODE As varchar)), '0000') AS  ItemCode "
    sql &= "      , CONCAT(FORMAT(SRC.BICODE,'" & CODE_FORMAT & "') , ':', SRC.BINAME) AS ItemName "
    sql &= " FROM(SELECT BICODE, BINAME, KUBUN FROM BUIM_P WHERE KUBUN = 1  GROUP BY BICODE, BINAME, KUBUN) AS SRC "
    sql &= " ORDER BY SRC.BICODE "

    Return sql
  End Function

#End Region

#End Region

End Class
