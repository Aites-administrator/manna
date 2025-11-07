Imports T.R.ZCommonClass.clsCommonFnc

''' <summary>
''' データーリピータ用の摘要コンボボックス
''' </summary>
Public Class CmbDrMstDescription
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "0000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)

    MyBase.DrawMode = DrawMode.Normal
    '表示スタイル指定
    MyBase.DropDownStyle = ComboBoxStyle.DropDown

    ' コンボボックスの項目の表示数設定
    IntegralHeight = False
    MaxDropDownItems = 5
    CodeFormat = CODE_FORMAT

    InitCmbNonSql()

    ' コンボボックスのコードチェックをスキップする
    SkipChkCode = True

    lcCallBackCreateSql = AddressOf SqlSelListSrc
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("摘要を選択してください。")


  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then

      sql &= " SELECT NO AS ItemCode "
      sql &= "      , NAME AS ItemName "
      sql &= " FROM INFO "
      If prmCode <> "" Then
        sql &= "  WHERE NO = " & prmCode & " AND KUBUN = 1 "
      Else
        sql &= "  WHERE KUBUN = 1"
      End If
      sql &= " ORDER BY NO "

    End If

    Return sql
  End Function

#End Region

#End Region

End Class
