Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData

Public Class CmbUseFlg
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("使用可/不可を選択して下さい")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then
      sql &= " SELECT * "
      sql &= " FROM ("
      sql &= " SELECT '-1' as ItemCode "
      sql &= "      , '1:使用可'  as ItemName"
      sql &= " UNION "
      sql &= " SELECT '0'  as ItemCode "
      sql &= "      , '0:使用不可'  as ItemName"
      sql &= " ) AS SRC "
      If prmCode <> "" Then
        sql &= "  WHERE ItemCode = " & prmCode
      End If

      sql &= " ORDER BY ItemCode "
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
