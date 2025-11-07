Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の担当者名コンボボックス
''' </summary>
Public Class CmbDrMstStaff
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5

    lcCallBackCreateSql = AddressOf SqlSelListSrc
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

      sql &= " SELECT TANTOC  as ItemCode "
      sql &= "      , CONCAT(FORMAT(TANTOC,'" & CODE_FORMAT & "') , ':', TANTOMEI)  as ItemName"
      sql &= " FROM TANTO_TBL "
      If prmCode <> "" Then
        sql &= "  WHERE TANTOC = " & prmCode
      End If
      sql &= " ORDER BY TANTOC "

    End If

    Return sql
  End Function

#End Region





#End Region

End Class
