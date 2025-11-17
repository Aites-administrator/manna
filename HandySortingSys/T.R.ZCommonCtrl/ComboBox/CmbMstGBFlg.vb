Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstGBFlg
  Inherits CmbMstBase

  '----------------------------------------------
  '          牛豚鶏区分コンボボックス
  '
  '
  '----------------------------------------------

  Private Const CODE_FORMAT As String = "0"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("牛豚鶏を選択入力して下さい。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then
      sql &= " SELECT GBCODE as ItemCode "
      sql &= "      , CONCAT(FORMAT(GBCODE,'" & CODE_FORMAT & "') , ':' , GBNAME) as ItemName "
      sql &= " FROM GBFLG_Tbl "

      sql &= " WHERE  1 = 1 "
      If prmCode <> "" Then
        sql &= " AND GBCODE = " & prmCode
      End If

      sql &= " ORDER BY GBCODE"
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
