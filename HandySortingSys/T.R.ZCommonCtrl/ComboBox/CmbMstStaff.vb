Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstStaff
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("担当者名を選択してください。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then
      sql &= " SELECT OPERATOR_CODE  as ItemCode "
      sql &= "      , FORMAT(OPERATOR_CODE,'" & CODE_FORMAT & "') + ':' + OPERATOR_NAME  as ItemName"
      sql &= " FROM T_OPERATOR "
      'sql &= " WHERE ENABLED <> 0 "

      If prmCode <> "" Then
        sql &= "  WHERE OPERATOR_CODE = " & prmCode
      End If

      sql &= " ORDER BY OPERATOR_CODE "
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
