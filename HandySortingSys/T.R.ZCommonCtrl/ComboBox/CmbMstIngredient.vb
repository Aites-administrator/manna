Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstIngredient
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "00000000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("原料コードを選択して下さい。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode) OrElse prmCode = "") Then
      sql &= " SELECT INGREDIENT_CODE as ItemCode "
      sql &= "      , CONCAT(FORMAT(INGREDIENT_CODE,'" & CODE_FORMAT & "') , ':' , INGREDIENT_NAME) as ItemName "
      sql &= " FROM MST_INGREDIENT "
      If prmCode <> "" Then
        sql &= "  WHERE INGREDIENT_CODE = " & prmCode
      End If
      sql &= " ORDER BY INGREDIENT_CODE "
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
