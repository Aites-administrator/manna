Imports T.R.ZCommonClass

Public Class TxtDrTaxType
  Inherits TxtNumericBase

  ' データーリピータ用の税区分テキストボックス

#Region "定数定義"
  Private Const CODE_FORMAT As String = "0"
  Private Const COMBO_CODE As String = "税区分コーﾄﾞ"
  Private Const COMBO_NAME As String = "税区分名"
  Private Const COMBO_TITLE As String = "税区分マスタ"
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("税区分を入力してください。")
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
      ' 税区分コード
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
    retVal("0") = ""
    retVal("1") = clsGlobalData.TAX_NAME01
    retVal("2") = clsGlobalData.TAX_NAME02
    retVal("3") = clsGlobalData.TAX_NAME03


    Return retVal

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