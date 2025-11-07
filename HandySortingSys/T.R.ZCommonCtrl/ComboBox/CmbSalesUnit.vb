Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbSalesUnit
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("４文字まで入力できます。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty


    sql &= " SELECT TKCODE as ItemCode "
    '    sql &= "      , CONCAT(FORMAT(TKCODE,'" & CODE_FORMAT & "') , ':' , LTKNAME) as ItemName "
    sql &= " FROM TOKUISAKI "
    '  sql &= " WHERE KUBUN <> 9 "
    'sql &= " ORDER BY TKCODE"

    Return sql
  End Function

#End Region

#End Region

End Class







