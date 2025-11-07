Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の商品名コンボボックス
''' </summary>
Public Class CmbDrMstItem
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "00000000"

#Region "コンストラクタ"

  Public Sub New()

    ' データソースをクリア  
    DataSource = Nothing

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5
    CodeFormat = CODE_FORMAT

    lcCallBackCreateSql = AddressOf SqlSelListSrc

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("商品名を選択してください。")

    MyBase.DropDownWidth = 480

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then

      sql &= " SELECT ITEM_CODE AS ItemCode "
      sql &= "      , CONCAT(FORMAT(ITEM_CODE,'" & CODE_FORMAT & "') , ':', ITEM_NAME01) as ItemName "
      sql &= " FROM MST_ITEM "
      If prmCode <> "" Then
        sql &= "  WHERE ITEM_CODE = " & prmCode
      End If
      sql &= " ORDER BY ITEM_CODE "

    End If

    Return sql
  End Function

#End Region

#End Region

End Class
