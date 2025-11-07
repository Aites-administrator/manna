Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の商品コードコンボボックス
''' </summary>
Public Class CmbDrMstItemCode
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "00000000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5

    '   lcCallBackCreateSql = AddressOf SqlSelListSrc
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("商品コードを選択してください。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then
      If (ComChkNumeric(prmCode)) Then

        sql &= " SELECT ITEM_CODE AS ItemCode "
        sql &= "      , FORMAT(ITEM_CODE,'" & CODE_FORMAT & "') as ItemName "
        sql &= " FROM MST_ITEM "
        If prmCode <> "" Then
          sql &= "  WHERE ITEM_CODE = " & prmCode
        End If
        sql &= " ORDER BY ITEM_CODE "
      End If
    End If

    Return sql
  End Function

#End Region

#End Region

End Class
