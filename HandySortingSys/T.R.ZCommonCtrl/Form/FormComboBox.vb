Imports T.R.ZCommonClass.MrForm
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Imports GrapeCity.Win.MultiRow

Public Class FormComboBox

  '------------------------------------
  '       汎用コンボボックス画面
  '------------------------------------

#Region "定数定義"

  ''' <summary>
  ''' 処理モード
  ''' </summary>
  Public Enum typMode
    SQL = 1     ' SQL
    DICTIONARY  ' DICTIONARY
  End Enum

#Region "プライベート"
  Private Const PRG_ID As String = "CustomerClassification1Search"
#End Region
#End Region

#Region "メンバ"

#Region "プライベート"
  ''' <summary>
  ''' 一覧表示値
  ''' </summary>
  Private _prmDicData As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

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
  ''' モード　1:SQL指定,2:Dictionary指定
  ''' </summary>
  Private _Mode As Integer = 0

  ' コードタイトル
  Private _ItemCode = String.Empty
  ' コード名タイトル
  Private _ItemName As String = String.Empty

#End Region

#End Region

#Region "メソッド"

#Region "パブリック"

  ''' <summary>
  ''' サブフォーム起動処理
  ''' </summary>
  ''' <param name="prmCodeName">一覧タイトル（コード）</param>
  ''' <param name="prmValueName">一覧タイトル（データ）</param>
  ''' <param name="prmDicData">一覧表示値</param>
  ''' <param name="prmFormTitle">フォームタイトル</param>
  ''' <param name="prmItemCode">アイテムコード</param>
  Public Overloads Sub ShowSubForm(prmCodeName As String _
                          , prmValueName As String _
                          , prmDicData As Dictionary(Of String, String) _
                          , prmFormTitle As String _
                          , Optional prmItemCode As String = "")

    ' モード：ディクショナリ
    _Mode = typMode.DICTIONARY

    ' コードタイトル
    _ItemCode = prmCodeName
    ' コード名タイトル
    _ItemName = prmValueName

    ' 表題
    Me.Text = prmFormTitle
    lblTitle.Text = prmFormTitle

    ' 選択データ設定
    _prmDicData = prmDicData

    If prmItemCode = "" Then
      ' アイテムコード未指定時は一覧表示
      Me.ShowDialog()
    Else
      ' アイテムコード指定時は入力されたコードの名称を取得
      Call GetItemNameByCode(prmItemCode)
    End If

  End Sub

  ''' <summary>
  ''' サブフォーム起動処理
  ''' </summary>
  ''' <param name="prmCodeName">一覧タイトル（コード）</param>
  ''' <param name="prmValueName">一覧タイトル（データ）</param>
  ''' <param name="prmSql">一覧抽出用SQL</param>
  ''' <param name="prmFormTitle">フォームタイトル</param>
  ''' <param name="prmItemCode">アイテムコード</param>
  Public Overloads Sub ShowSubForm(prmCodeName As String _
                          , prmValueName As String _
                          , prmSql As String _
                          , prmFormTitle As String _
                          , Optional prmItemCode As String = "")

    ' モード：ＳＱＬ
    _Mode = typMode.SQL

    ' コードタイトル
    _ItemCode = prmCodeName
    ' コード名タイトル
    _ItemName = prmValueName

    ' 表題
    Me.Text = prmFormTitle
    lblTitle.Text = prmFormTitle

    'SQL設定
    _sql = prmSql

    If prmItemCode = "" Then
      ' アイテムコード未指定時は一覧表示
      Me.ShowDialog()
    Else
      ' アイテムコード指定時は入力されたコードの名称を取得
      Call GetItemNameByCode(prmItemCode)
    End If

  End Sub

#End Region

#Region "プライベート"

  ''' <summary>
  ''' コードより名称を取得する
  ''' </summary>
  ''' <param name="prmItemCode">検索対象のコード</param>
  Private Sub GetItemNameByCode(prmItemCode As String)
    Dim tmpSql As New clsSqlServer
    Dim tmpDt As New DataTable

    Try
      If (_Mode = typMode.SQL) Then
        Call tmpSql.GetResult(tmpDt, CreateMultiRowSrc)
        If tmpDt.Rows.Count > 0 Then
          _retval.Add(CTRL_COMMON_CODE, prmItemCode)
          _retval.Add(CTRL_COMMON_NAME, tmpDt.Rows(0)(CTRL_COMMON_NAME))
        End If
      Else

        Dim tmpDic As New Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
        tmpDic = _prmDicData

        For Each kvp As KeyValuePair(Of String, String) In _prmDicData
          If (String.Compare(kvp.Key, prmItemCode, True) = 0) Then
            _retval.Add(CTRL_COMMON_CODE, kvp.Key)
            _retval.Add(CTRL_COMMON_NAME, tmpDic.Item(kvp.Key))
          End If
        Next

      End If

      If (_retval.Count <> 0) Then
        Dim ret As New List(Of Dictionary(Of String, String))
        ret.Add(_retval)

        If (ret.Count <> 0) Then
          SetListForReturnsVal(ret)
        End If
      End If

    Catch ex As Exception
      Call ComWriteErrLog(ex)
      Throw New Exception("名称の取得に失敗しました")
    End Try

  End Sub
#End Region

#Region "データリピーター操作関連共通"
  ''' <summary>
  ''' 一覧表示データ抽出SQL文作成
  ''' </summary>
  ''' <returns>作成したSQL文</returns>
  ''' <remarks>
  '''   画面毎の抽出内容をここに記載する
  ''' </remarks>
  Private Function CreateMultiRowSrc() As String
    Dim sql As String = String.Empty

    sql &= " SELECT * "
    sql &= " FROM  (" & _sql & ") as ListSrc"

    Return sql
  End Function

  ''' <summary>
  ''' 初期化処理
  ''' </summary>
  ''' <remarks>
  ''' コントロールの初期化（Form_Loadで実行して下さい）
  ''' </remarks>
  Private Sub InitForm01()

    '１つ目のMultiRowオブジェクトの設定
    MR1 = Me.GcMultiRow1

    If (_Mode = typMode.SQL) Then
      ' MultiRow初期化
      Call InitMultiRow(MR1, 1, CreateMultiRowSrc())
    Else
      ' MultiRow初期化
      Call InitMultiRow(MR1, 1)
    End If

    With MR1

      With Controlr(.Name)

        .SetLabelFiled("lblItemCode", _ItemCode)
        .SetLabelFiled("lblItemName", _ItemName)

        ' 各コントロールとデータテーブルの連結
        .SetDataFiled("ItemCode", CTRL_COMMON_CODE, 0)   ' コード
        .SetDataFiled("ItemName", CTRL_COMMON_NAME, 1)       ' コード名称

        If (_Mode = typMode.SQL) Then
          ' データーソース経由で DataRepeater を表示
          .BindDataSrc()
        Else

          Dim tmpDt As New DataTable
          tmpDt.Columns.Add(CTRL_COMMON_CODE)
          tmpDt.Columns.Add(CTRL_COMMON_NAME)

          Dim row As DataRow
          For Each kvp As KeyValuePair(Of String, String) In _prmDicData
            row = tmpDt.NewRow
            row(CTRL_COMMON_CODE) = kvp.Key
            row(CTRL_COMMON_NAME) = kvp.Value
            tmpDt.Rows.Add(row)
          Next

          MR1.DataSource = tmpDt
        End If

        ' MultiRowを新規行追加不可に設定
        .SetDisplayMode()

      End With
    End With

  End Sub
#End Region
#End Region

#Region "イベントプロシージャ"
#Region "フォーム関連"

  ''' <summary>
  ''' フォームロード時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub FormCustomerClassification1Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    ' 画面初期化
    InitForm01()

    With MR1
      With Controlr(.Name)
        ' MultiRow再表示時処処理追加
        .lcCallBackReLoadData = AddressOf DrReload

        .AutoSearch = True

      End With
    End With

    ' ファンクションキー名設定
    BtnF9End.SetText("終了")
    BtnF12Decision.SetText("決定")

  End Sub

  ''' <summary>
  ''' MultiRow更新時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="LastUpdate">最終更新日時</param>
  ''' <param name="DataCount">データ件数</param>
  Private Sub DrReload(sender As Object, LastUpdate As String, DataCount As Long)

  End Sub

#End Region

#Region "データリピーター関連"

  ''' <summary>
  ''' 終了ボタン(F9)押下時の動き
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BtnF9End_Click(sender As Object, e As EventArgs) Handles BtnF9End.Click
    Close()
  End Sub

  ''' <summary>
  ''' 決定ボタン(F12)押下時の動き
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BtnF12Decision_Click(sender As Object, e As EventArgs) Handles BtnF12Decision.Click

    SetListForReturnVal(sender, e)

  End Sub

  ''' <summary>
  ''' MultiRowダブルクリック時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRow1_CellDoubleClick(sender As Object, e As CellEventArgs) Handles GcMultiRow1.CellDoubleClick

    SetListForReturnVal(sender, e)

  End Sub

  ''' <summary>
  ''' セルの選択を許可し内容の変更だけ禁止
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRow1_EditingControlShowing(sender As Object, e As EditingControlShowingEventArgs) Handles GcMultiRow1.EditingControlShowing

    If TypeOf e.Control Is TextBoxEditingControl Then
      RemoveHandler e.Control.DoubleClick, AddressOf Control_DoubleClick
      AddHandler e.Control.DoubleClick, AddressOf Control_DoubleClick

      ' 編集用コントロールの取得
      Dim editor As TextBoxEditingControl = e.Control

      ' 編集用コントロールのReadOnlyプロパティを設定
      editor.ReadOnly = True
    End If
  End Sub

#End Region

#Region "メソッド"
  ''' <summary>
  ''' MultiRowダブルクリック時(得意先コード、得意先名、商品コード、商品名のセル)
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub Control_DoubleClick(sender As Object, e As EventArgs)

    SetListForReturnVal(sender, e)

  End Sub
#End Region

#End Region

End Class
