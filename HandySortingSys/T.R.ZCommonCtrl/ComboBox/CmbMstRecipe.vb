Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstRecipe
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "00000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    MyBase.MaxLength = 5
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("配合コードを選択して下さい。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then
      sql &= " SELECT RECIPE_CODE as ItemCode "
      sql &= "      , CONCAT(FORMAT(RECIPE_CODE,'" & CODE_FORMAT & "') , ':' , RECIPE_NAME) as ItemName "
      sql &= " FROM MST_RECIPE_HEADER "
      If prmCode <> "" Then
        sql &= "  WHERE RECIPE_CODE = " & prmCode
      End If
      sql &= " ORDER BY RECIPE_CODE "
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
