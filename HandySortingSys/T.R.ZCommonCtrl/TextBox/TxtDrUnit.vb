Imports T.R.ZCommonClass

Public Class TxtDrUnit
  Inherits TxtWideCharBase

  ' データーリピータ用の単位テキストボックス

#Region "定数定義"
  Private Const CODE_FORMAT As String = "00"
  Private Const COMBO_CODE As String = "単位コーﾄﾞ"
  Private Const COMBO_NAME As String = "単位名"
  Private Const COMBO_TITLE As String = "単位マスタ"
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("単位を入力してください。")
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
      cForm.ShowSubForm(COMBO_CODE, COMBO_NAME, SetCmbAdd(), COMBO_TITLE, prmCode)
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
  ''' データーリピータ上のコンボボックスコントロールの設定
  ''' </summary>
  Public Function SetCmbAdd() As Dictionary(Of String, String)

    ' Dictionaryにデータを追加
    Dim retVal As New Dictionary(Of String, String)
    retVal("000") = ""
    retVal("001") = "c/s"
    retVal("002") = "Kg"
    retVal("003") = "P"
    retVal("004") = "ｾｯﾄ"
    retVal("005") = "ﾄﾚｰ"
    retVal("006") = "ﾊﾟｯｸ"
    retVal("007") = "羽"
    retVal("008") = "回"
    retVal("009") = "巻"
    retVal("010") = "缶"
    retVal("011") = "個"
    retVal("012") = "箱"
    retVal("013") = "式"
    retVal("014") = "切"
    retVal("015") = "袋"
    retVal("016") = "頭"
    retVal("017") = "頭分"
    retVal("018") = "尾"
    retVal("019") = "本"
    retVal("020") = "枚"

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