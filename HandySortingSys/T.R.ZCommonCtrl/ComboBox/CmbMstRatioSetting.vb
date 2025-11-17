Public Class CmbMstRatioSetting
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("倍率設定を選択入力して下さい。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc() As String
    Dim sql As String = String.Empty

    sql &= " SELECT '0' as ItemCode "
    sql &= "      , '0:しない' as ItemName "
    sql &= " UNION "
    sql &= " SELECT '1' as ItemCode "
    sql &= "      , '1:する' as ItemName "

    Return sql
  End Function

#End Region

#End Region

End Class
