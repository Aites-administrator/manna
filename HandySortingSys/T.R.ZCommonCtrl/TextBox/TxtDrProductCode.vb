Imports T.R.ZCommonClass

Public Class TxtDrProductCode
  Inherits TxtNumericBase

  ' データーリピータ用の商品コードテキストボックス

#Region "定数定義"
  Private Const CODE_FORMAT As String = "00000000"
  Private Const COMBO_CODE As String = "商品コーﾄﾞ"
  Private Const COMBO_NAME As String = "商品名"
  Private Const COMBO_TITLE As String = "商品マスタ"
#End Region

#Region "コンストラクタ"

  Public Sub New()
    ' 数値8桁のみ入力可
    MyBase.New(8)
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("商品コードを入力してください。")
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
    Else
      cForm.ShowSubForm(COMBO_CODE, COMBO_NAME, SqlSelListSrc(prmCode), COMBO_TITLE, SetCodeFormat(prmCode))
    End If

    ' サブフォームで選択された値をテキストボックスに設定する
    If (cForm._ReturnVal.Count <> 0) Then
      ' 商品コード
      retVal = cForm._ReturnVal(0).Item("ItemCode")
    End If

    Return retVal

  End Function

#End Region

#Region "汎用コンボボックスボタン"

  ''' <summary>
  ''' 商品コードコンボボックスソース抽出用
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT FORMAT(ITEM_CODE,'" & CODE_FORMAT & "') AS ItemCode "
    sql &= "      , ITEM_NAME01 AS ItemName "
    sql &= " FROM MST_ITEM "
    If prmCode <> "" Then
      sql &= "  WHERE ITEM_CODE = " & prmCode
    End If


    Return sql
  End Function

  ''' <summary>
  ''' コードフォーマット変換
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>変換したコード</returns>
  Public Function SetCodeFormat(prmCode As String) As String

    prmCode = clsCommonFnc.StringToInt(prmCode).ToString(CODE_FORMAT)

    Return prmCode

  End Function

#End Region


End Class
