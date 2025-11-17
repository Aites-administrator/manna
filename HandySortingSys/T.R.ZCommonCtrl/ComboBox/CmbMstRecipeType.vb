Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstRecipeType
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("配合方式を選択入力して下さい。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc() As String
    Dim sql As String = String.Empty

    sql &= " SELECT '0' as ItemCode "
    sql &= "      , '0:横計量' as ItemName "
    sql &= " UNION "
    sql &= " SELECT '1' as ItemCode "
    sql &= "      , '1:縦計量' as ItemName "

    Return sql
  End Function

#End Region

#End Region


End Class
