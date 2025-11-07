Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の単位コンボボックス
''' </summary>
Public Class CmbDrMstUnit
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("単位を選択してください。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  Public Sub InitCmbData()
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
  End Sub

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmUnitCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmUnitCode)) Then

      sql &= " SELECT ID AS ItemCode, "     ' 単位コード
      sql &= "        NAME AS ItemName "    ' 単位名
      sql &= " FROM MST_UNIT "
      If prmUnitCode <> "" Then
        sql &= "  WHERE ID = '" & prmUnitCode & "'"
      End If
      sql &= " ORDER BY ID "

    End If

    Return sql
  End Function

#End Region

#End Region

End Class
