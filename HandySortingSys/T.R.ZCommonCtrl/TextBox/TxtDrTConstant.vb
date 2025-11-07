Imports T.R.ZCommonClass

Public Class TxtDrConstant
  Inherits TxtNumericBase

  ' データーリピータ用の定貫テキストボックス

#Region "定数定義"
  Private Const CODE_FORMAT As String = "0"
  Private Const COMBO_CODE As String = "定貫コーﾄﾞ"
  Private Const COMBO_NAME As String = "定貫名"
  Private Const COMBO_TITLE As String = "定貫マスタ"
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("定貫を入力してください。")
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
      cForm.ShowSubForm(COMBO_CODE, COMBO_NAME, SetCmbAdd(), COMBO_TITLE)
    Else
      cForm.ShowSubForm(COMBO_CODE, COMBO_NAME, SetCmbAdd(), COMBO_TITLE, SetCodeFormat(prmCode))
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
  ''' データーリピータ上のコンボボックスコントロールの設定
  ''' </summary>
  Public Function SetCmbAdd() As Dictionary(Of String, String)

    ' Dictionaryにデータを追加
    Dim retVal As New Dictionary(Of String, String)
    retVal("0") = "定貫"
    retVal("1") = "不定貫"

    Return retVal

  End Function

  ''' <summary>
  ''' 単位コードフォーマット変換
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>変換した単位コード</returns>
  Public Function SetCodeFormat(prmCode As String) As String

    prmCode = clsCommonFnc.StringToInt(prmCode).ToString(CODE_FORMAT)

    Return prmCode

  End Function

#End Region


End Class