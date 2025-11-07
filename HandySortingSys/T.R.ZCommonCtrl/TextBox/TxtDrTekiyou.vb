Imports T.R.ZCommonClass

Public Class TxtDrTekiyou
  Inherits TxtWideCharBase

  ' データーリピータ用の摘要テキストボックス

#Region "定数定義"
  Private Const COMBO_CODE As String = "摘要コーﾄﾞ"
  Private Const COMBO_NAME As String = "摘要名"
  Private Const COMBO_TITLE As String = "摘要マスタ"
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("摘要を入力してください。")
  End Sub

  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub

  ''' <summary>
  ''' サブフォーム表示
  ''' </summary>
  ''' <returns></returns>
  Public Function ShowSubForm(Optional prmCode As String = "") As String

    Dim cForm As New FormComboBox
    Dim retVal As String = String.Empty
    '汎用コンボボックス画面表示
    If String.IsNullOrWhiteSpace(prmCode) Then
      cForm.ShowSubForm(COMBO_CODE, COMBO_NAME, SqlSelListSrc(""), COMBO_TITLE)
    End If

    ' サブフォームで選択された値をテキストボックスに設定する
    If (cForm._ReturnVal.Count <> 0) Then
      ' 商品コード
      retVal = cForm._ReturnVal(0).Item("ItemName")
    End If

    Return retVal

  End Function

#End Region

#Region "汎用コンボボックスボタン"

  ''' <summary>
  ''' 摘要コードコンボボックスソース抽出用
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT NO AS ItemCode "
    sql &= "      , NAME AS ItemName "
    sql &= " FROM INFO "
    If prmCode <> "" Then
      sql &= "  WHERE NO = " & prmCode & " AND KUBUN = 1 "
    Else
      sql &= "  WHERE KUBUN = 1"
    End If

    Return sql
  End Function

#End Region


End Class

