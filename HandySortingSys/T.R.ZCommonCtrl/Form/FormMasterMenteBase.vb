Imports T.R.ZCommonClass.DgvForm01
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsDGVColumnSetting
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsDataGridSearchControl


Public Class FormMasterMenteBase
  Implements IDgvForm01

#Region "メンバ"

#Region "プライベート"
  ''' <summary>
  ''' 一覧表示用SQL文
  ''' </summary>
  Private _sql As String = String.Empty

  ''' <summary>
  ''' 戻り値
  ''' </summary>
  ''' <remarks>
  ''' 以下の形式で選択されたデータを呼び出し元に返す
  '''   _retval("code","一覧で選択されたコード"
  '''         , "name","一覧で選択された名称")
  ''' </remarks>
  Private _retval As New Dictionary(Of String, String)

  ''' <summary>
  ''' 一覧タイトル名
  ''' </summary>
  Private _CodeName As String

  ''' <summary>
  ''' 一覧項目名
  ''' </summary>
  Private _ValueName As String

  ''' <summary>
  ''' フォームタイトル
  ''' </summary>
  Private _FormTitle As String

#End Region

#End Region



#Region "メソッド"

#Region "パブリック"

  ''' <summary>
  ''' サブフォーム起動処理
  ''' </summary>
  ''' <param name="prmCodeName">一覧タイトル（コード）</param>
  ''' <param name="prmValueName">一覧タイトル（データ）</param>
  ''' <param name="prmSql">一覧抽出用SQL文</param>
  ''' <param name="prmFormTitle">フォームタイトル</param>
  ''' <param name="prmItemCode">アイテムコード</param>
  ''' <returns>選択された値</returns>
  Public Function ShowSubForm(prmCodeName As String _
                              , prmValueName As String _
                              , prmSql As String _
                              , prmFormTitle As String _
                              , Optional prmItemCode As String = "") As Dictionary(Of String, String)

    _CodeName = prmCodeName
    _sql = prmSql
    _ValueName = prmValueName
    Me._FormTitle = prmFormTitle

    'If prmItemCode = "" Then
    '  ' アイテムコード未指定時は一覧表示
    '  Me.ShowDialog()
    'Else
    '  ' アイテムコード指定時は入力されたコードの名称を取得
    '  Call GetItemNameByCode(prmItemCode)
    'End If

    ' 選択された値を返す
    Return _retval

  End Function

#End Region
#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' フォームロード時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub FormMasterMente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Me.MinimizeBox = True  ' 最小化ボタン消去
    Me.MaximizeBox = True  ' 最大化ボタン消去
    Me.ControlBox = True   ' コントロールボックス消去(= 閉じるボタン消去)  
    Me.Text = _FormTitle    ' フォームタイトル

  End Sub

  Public Sub InitForm() Implements IDgvForm01.InitForm
    Throw New NotImplementedException()
  End Sub

  Public Function CreateGridSrc() As String Implements IDgvForm01.CreateGridSrc
    Throw New NotImplementedException()
  End Function

  Public Function CreateGridlayout() As List(Of clsDGVColumnSetting) Implements IDgvForm01.CreateGridlayout
    Throw New NotImplementedException()
  End Function

  Public Function CreateGridEditCol() As List(Of clsDataGridEditTextBox) Implements IDgvForm01.CreateGridEditCol
    Throw New NotImplementedException()
  End Function


#End Region

End Class