Imports T.R.ZCommonClass.clsDataGridSearchControl
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalDataOrder
Imports T.R.ZCommonClass.clsGlobalData
Imports GrapeCity.Win.MultiRow
Imports GrapeCity.Win.MultiRow.InputMan

''' <summary>
''' MultiRow操作クラス
''' </summary>
Public Class clsMultiRow

#Region "列挙体"

  ''' <summary>
  ''' MultiRowの型
  ''' </summary>
  Public Enum typDataTable
    TYPE_STRING
    TYPE_INTEGER
    TYPE_LONG
    TYPE_DATETIME
  End Enum

#End Region

#Region "定数定義"
#Region "プライベート"
  Private Const PROPERTY_TEXT As String = "Text"
  Private Const PROPERTY_VALUE As String = "Value"
#End Region

#End Region

#Region "メンバ"

#Region "プライベート"

#Region "MultiRow関連"
  Private WithEvents _GcMultiRow As GcMultiRow

  ''' <summary>
  ''' 編集前データテーブル
  ''' </summary>
  Private _OrgDt As DataTable = New DataTable

  ''' <summary>
  ''' 編集用データテーブル
  ''' </summary>
  Private _EditableDt As DataTable = New DataTable

  ''' <summary>
  ''' バインディングソース
  ''' </summary>
  Private _BdSrc As BindingSource = New BindingSource

  ''' <summary>
  ''' MultiRowコントロール配列
  ''' </summary>
  Private _DicDRCtrl As New Dictionary(Of String, clsMultiRowCtrl)

  ''' <summary>
  ''' MultiRow項番
  ''' </summary>
  Private _DRTabIndex As Integer = 0

  ''' <summary>
  ''' 最終セルインデックス
  ''' </summary>
  Private _LastCellIdx As Integer = 0

  ''' <summary>
  ''' セル全選択
  ''' </summary>
  Private _SelectAllFocus As Boolean = True

#End Region

#Region "データベース関連"
  ''' <summary>
  ''' データベース接続オブジェクト
  ''' </summary>
  Private _SqlCon As clsComDatabase

  ''' <summary>
  ''' 一覧表示用SQL文
  ''' </summary>
  Private _SrcSql As String

  ''' <summary>
  ''' 一覧表示用SQL文(修正元)
  ''' </summary>
  Private _BeforeSrcSql As String

#End Region

#Region "動作設定関連"
  ''' <summary>
  ''' 一覧抽出コントロールリスト
  ''' </summary>
  Private _SearchConditionz As New List(Of clsDataGridSearchControl)

  ''' <summary>
  ''' 自動検索実行フラグ
  ''' </summary>
  ''' <remarks>
  '''  Trueにすると、検索条件コントロールが更新される度に自動で一覧表示を更新する
  ''' </remarks>
  Private _AutoSearch As Boolean = False

  ''' <summary>
  ''' メッセージ出力ラベル
  ''' </summary>
  Private _msgLabel As Label = Nothing

  ''' <summary>
  ''' 出力メッセージ
  ''' </summary>
  Private _msgLabelText As String = String.Empty

  ''' <summary>
  ''' 検索項目更新時に検索実行有無設定
  ''' </summary>
  Private _SerchControl As Boolean = False

#End Region

#Region "更新処理関連"
  ''' <summary>
  ''' 最終データ取得日時
  ''' </summary>
  Private _lastUpdate As Date = Now

#End Region

#Region "ダブルクリック処理関連"
  ''' <summary>
  ''' 最終クリックセル
  ''' </summary>
  Private _LastMrCtrl As Control = Nothing

  ''' <summary>
  ''' 最終セルクリック時刻
  ''' </summary>
  Private _LastClickTime As DateTime = Date.MinValue

  ''' <summary>
  ''' ダブルクリック有効セル名称一覧
  ''' </summary>
  Private _DoubleClickCellz As New List(Of String)

  ''' <summary>
  ''' ダブルクリックと判断するクリック間隔
  ''' </summary>
  Private _DoubleClickCycle As Double = Double.MinValue

#End Region

#End Region

#Region "イベントハンドラ"

  ' データ表示イベント
  Delegate Sub CallBackReLoadData(sender As Object, LastUpdate As String, DataCount As Long)
  Public lcCallBackReLoadData As CallBackReLoadData

  ' セルダブルクリックイベント
  Delegate Sub CallbackCellDoubleClick(sender As Object, e As MouseEventArgs)
  Public lcCallbackCellDoubleClick As CallbackCellDoubleClick
#End Region

#End Region

#Region "プロパティー"

#Region "プライベート"

  ''' <summary>
  ''' 初期化済確認
  ''' </summary>
  ''' <returns></returns>
  Private ReadOnly Property IsInitialized As Boolean
    Get
      Return Not _SrcSql.Equals(String.Empty) AndAlso _SqlCon IsNot Nothing
    End Get
  End Property

#End Region

#Region "パブリック"

  ''' <summary>
  ''' カレント行取得
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property CurrentRow As DataRow
    Get
      Return DirectCast(_BdSrc.Current, DataRowView).Row
    End Get
  End Property

  ''' <summary>
  ''' 編集前データテーブル
  ''' </summary>
  ''' <returns></returns>
  Public Property OriginalDT As DataTable
    Get
      Return _OrgDt
    End Get
    Set(value As DataTable)
      _OrgDt = value
    End Set
  End Property

  ''' <summary>
  ''' 編集用データテーブル
  ''' </summary>
  ''' <returns></returns>
  Public Property EditDT As DataTable
    Get
      Return _EditableDt
    End Get
    Set(value As DataTable)
      _EditableDt = value
    End Set
  End Property

  ''' <summary>
  ''' バインディングソース
  ''' </summary>
  ''' <returns></returns>
  Public Property BindSrc As BindingSource
    Get
      Return _BdSrc
    End Get
    Set(value As BindingSource)
      _BdSrc = value
    End Set
  End Property

  ''' <summary>
  ''' 一覧表示用SQL
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>一覧表示用のSQL文を直接編集</remarks>
  Public Property SrcSql As String
    Get
      Return _SrcSql
    End Get
    Set(value As String)
      _SrcSql = value
      _BeforeSrcSql = value
      If IsInitialized AndAlso _AutoSearch Then
        ShowList()
      End If
    End Set
  End Property

  ''' <summary>
  ''' 検索処理自動実行フラグ
  ''' </summary>
  ''' <returns>フラグ</returns>
  ''' <remarks>
  '''   True  : SQL文が設定変更されたら即時Gridに反映する
  '''   False : SQL文が設定変更されてもGridに反映しない
  ''' </remarks>
  Public Property AutoSearch As Boolean
    Get
      Return _AutoSearch
    End Get
    Set(value As Boolean)
      _AutoSearch = value
      ' フラグ設定時に初期化済かつ設定された値がTrueなら検索処理実行
      If IsInitialized AndAlso _AutoSearch Then
        ShowList()
      End If
    End Set
  End Property

  ''' <summary>
  ''' 指定されたSQLで検索し、MultiRowに一覧表示する
  ''' </summary>
  Public WriteOnly Property SqlCon As clsComDatabase
    Set(value As clsComDatabase)
      _SqlCon = value
      If IsInitialized AndAlso _AutoSearch Then
        ShowList()
      End If
    End Set
  End Property

  ''' <summary>
  ''' 検索項目更新時に検索実行有無設定（デフォルトは検索項目更新時に検索しない）
  ''' </summary>
  Public Property SearchCtl As Boolean

    Set(value As Boolean)
      _SerchControl = value
    End Set
    Get
      Return _SerchControl
    End Get

  End Property

  ''' <summary>
  ''' 最終更新日時取得
  ''' </summary>
  ''' <returns>最終更新日時</returns>
  Public ReadOnly Property LastUpdate As Date
    Get
      Return Now
    End Get
  End Property

  ''' <summary>
  ''' 最終セルインデックス
  ''' </summary>
  ''' <returns></returns>
  Public Property LastCellIdx As Integer

    Set(value As Integer)
      _LastCellIdx = value
    End Set
    Get
      Return _LastCellIdx
    End Get

  End Property

  ''' <summary>
  ''' セル全選択
  ''' </summary>
  ''' <returns></returns>
  Public Property SelectAllFocus As Boolean

    Set(value As Boolean)
      _SelectAllFocus = value
    End Set
    Get
      Return _SelectAllFocus
    End Get

  End Property


#End Region

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 初期処理
  ''' </summary>
  Public Sub New(prmGcMultiRow As GcMultiRow,
                 prmLastCellIdx As Integer)

    ' DataGridViewを保持
    _GcMultiRow = prmGcMultiRow

    LastCellIdx = prmLastCellIdx

    ' 表示用SQL文を保持
    _SrcSql = String.Empty
    ' 表示用SQL文(修正元)を保持
    _BeforeSrcSql = String.Empty

    ' MultiRow初期化
    Call InitMultiRow()

  End Sub

  ''' <summary>
  ''' 初期処理
  ''' </summary>
  ''' <param name="prmGridSrcSql"></param>
  Public Sub New(prmGcMultiRow As GcMultiRow,
                 prmLastCellIdx As Integer,
                 prmGridSrcSql As String)

    ' DataGridViewを保持
    _GcMultiRow = prmGcMultiRow

    LastCellIdx = prmLastCellIdx

    ' 表示用SQL文を保持
    _SrcSql = prmGridSrcSql
    ' 表示用SQL文(修正元)を保持
    _BeforeSrcSql = prmGridSrcSql

    ' MultiRow初期化
    Call InitMultiRow()

  End Sub
#End Region

#Region "メソッド"

#Region "プライベート"

  ''' <summary>
  ''' MultiRow初期化
  ''' </summary>
  Private Sub InitMultiRow()

    EditDT = OriginalDT.Clone
    BindSrc.DataSource = EditDT

    With _GcMultiRow

      .DataSource = BindSrc

      ' [Ctrl]+[C]キーの操作を行うと、行全体のデータがコピーを解除
      .ShortcutKeyManager.Unregister(ViewMode.Row, EditingActions.Copy)

      ' Tabキーの既定のショートカットキーを解除する。
      .ShortcutKeyManager.Unregister(Keys.Tab)
      ' Tabキーのショートカットキーにユーザー定義のショートカットキーを割り当てる。
      .ShortcutKeyManager.Register(New CustomMoveToNextControl(LastCellIdx), Keys.Tab)

      ' ショートカットキーの登録解除
      .ShortcutKeyManager.Unregister(Keys.Down)
      .ShortcutKeyManager.Unregister(Keys.Right)
      .ShortcutKeyManager.Unregister(Keys.Left)
      .ShortcutKeyManager.Unregister(Keys.Up)

      ' 自動調整の無効
      .AllowUserToAutoFitColumns = False

    End With

  End Sub

  ''' <summary>
  ''' 検索条件文字列の作成
  ''' </summary>
  ''' <returns></returns>
  Private Function CreateConditionText() As String

    Dim sqlWhere As String = String.Empty

    For Each tmpSc As clsDataGridSearchControl In _SearchConditionz
      With tmpSc
        If Not .Value.Equals(String.Empty) Then
          sqlWhere &= .SearchItemName
          sqlWhere &= ComSearchType2Text(.SearchType)
          sqlWhere &= ComGetLiteralChar(.DataType, _SqlCon.Provider)
          Select Case .SearchType
            Case typExtraction.EX_LIK
              sqlWhere &= "%" & .Value.Trim & "%"
            Case typExtraction.EX_LIKB
              sqlWhere &= "%" & .Value.Trim
            Case typExtraction.EX_LIKF
              sqlWhere &= .Value.Trim & "%"
            Case Else
              sqlWhere &= .Value.Trim
          End Select
          sqlWhere &= ComGetLiteralChar(.DataType, _SqlCon.Provider)
          sqlWhere &= " AND "
        End If
      End With
    Next

    ' 最終の "AND" を削除
    If Not sqlWhere.Equals(String.Empty) Then
      sqlWhere = Mid(sqlWhere, 1, Len(sqlWhere) - Len("AND "))
    End If

    Return sqlWhere

  End Function

#End Region

#Region "パブリック"

  ''' <summary>
  ''' ダブルクリックを有効にするセルを設定
  ''' </summary>
  ''' <param name="prmCellz">ダブルクリックを有効にするセル名称</param>
  Public Sub AddDoubleClickSetting(prmCellz As List(Of String) _
                                  , Optional prmDoubleClickCycle As Double = 0)

    ' ダブルクリック有効セル名設定
    _DoubleClickCellz = prmCellz

    ' ダブルクリック間隔設定
    If prmDoubleClickCycle = 0 Then
      _DoubleClickCycle = MULTIROW_DOUBLE_CLICK_CYCLE
    Else
      _DoubleClickCycle = prmDoubleClickCycle
    End If

    ' ダブルクリック有効セル背景色設定
    Dim template1 As Template = _GcMultiRow.Template
    Dim curFont As Font
    For Each tmpCell As String In _DoubleClickCellz
      ' 指定したセルをダブルクリック有効色に変更
      template1.Row.Cells(tmpCell).Style.ForeColor = MULTIROW_DOUBLUCLICK_COLOR
      curFont = template1.Row.Cells(tmpCell).Style.Font
      ' 指定したセルの文字を太字に変更
      Dim boldFont As Font = New Font(curFont, FontStyle.Bold)
      template1.Row.Cells(tmpCell).Style.Font = boldFont
    Next
    _GcMultiRow.Template = template1

  End Sub

  ''' <summary>
  ''' MultiRow上のコントロールとデータ連結
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmType">型</param>
  Public Sub LinkControl(prmCtrl As Control,
                         Optional prmType As typDataTable = typDataTable.TYPE_STRING)

    ' MultiRowコントロールクラスに要素を追加
    _DicDRCtrl(prmCtrl.Name) = New clsMultiRowCtrl(prmType, "", prmCtrl.Name, False, _DRTabIndex)
    _DRTabIndex = _DRTabIndex + 1

    ' コントロールとデータ連結
    prmCtrl.DataBindings.Add(PROPERTY_TEXT, EditDT, prmCtrl.Name)

  End Sub

  ''' <summary>
  ''' MultiRowのデータテーブルとデータ連結
  ''' </summary>
  ''' <param name="prmName">テキストボックスコントロール</param>
  Public Sub LinkControlName(prmName As String,
                             Optional prmType As String = "System.String")

    ' データテーブルに列名を追加
    EditDT.Columns.Add(prmName, System.Type.GetType("System.String"))

  End Sub

  ''' <summary>
  ''' MultiRow上のコントロールとデータ連結
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmType">型</param>
  Public Sub LinkControlAdd(prmCtrl As Control,
                         Optional prmType As String = "System.String")

    '' 自コントロールにフォーカスが移る時に他コントロールのValidation(検査)イベントの発生を抑制する
    'prmCtrl.CausesValidation = True

    ' データテーブルに列名を追加
    EditDT.Columns.Add(prmCtrl.Name, System.Type.GetType(prmType))

    ' MultiRowコントロールクラスに要素を追加
    _DicDRCtrl(prmCtrl.Name) = New clsMultiRowCtrl(typDataTable.TYPE_STRING, "", prmCtrl.Name, False, _DRTabIndex)
    _DRTabIndex = _DRTabIndex + 1

    ' コントロールとデータ連結
    prmCtrl.DataBindings.Add(PROPERTY_TEXT, EditDT, prmCtrl.Name)

  End Sub

  ''' <summary>
  ''' MultiRow上のコントロールの下部メッセージ設定
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmLabel">下部メッセージ</param>
  Public Sub AddLabelMsg(prmCtrl As Control, prmLabel As String)

    ' 表示メッセージ設定
    _DicDRCtrl(prmCtrl.Name).MsgLabel = prmLabel

  End Sub

  ''' <summary>
  ''' MultiRow上のコンボボックスコントロールのＳＱＬ文設定
  ''' </summary>
  ''' <param name="prmCtrl"></param>
  ''' <param name="prmSql"></param>
  Public Sub SetCmbSql(prmCtrl As Control, prmSql As String)

    ' コンボボックス有無フラグ設定
    _DicDRCtrl(prmCtrl.Name).cmbControl = True

    ' コンボボックスＳＱＬ文設定
    _DicDRCtrl(prmCtrl.Name).sql = prmSql

  End Sub

  ''' <summary>
  '''  'データーソース経由で MultiRow を表示
  ''' </summary>
  Public Sub BindDataSrc()

    'データーソース経由で MultiRow を表示
    BindSrc.DataSource = EditDT

  End Sub

  ''' <summary>
  ''' メッセージラベルの定義
  ''' </summary>
  ''' <param name="msgLabel">メッセージを表示するラベル情報</param>
  Public Sub SetMsgLabel(msgLabel As Label)

    _msgLabel = msgLabel

  End Sub

  ''' <summary>
  ''' メッセージラベルへのメッセージ表示
  ''' </summary>
  ''' <param name="msg">メッセージ</param>
  Public Sub F(msg As String)

    _msgLabelText = msg

  End Sub

  ''' <summary>
  ''' MultiRow上のコンボボックス初期設定
  ''' </summary>
  ''' <param name="sql"></param>
  ''' <param name="Cmb"></param>
  Public Sub setDRCombo(sql As String, Cmb As ComboBox)

    Dim tmpDb = New clsSqlServer

    With tmpDb
      Try

        Dim tmpDt As New DataTable
        Call tmpDb.GetResult(tmpDt, sql)

        For Each tmpDr As DataRow In tmpDt.Rows
          Cmb.Items.Add(tmpDr("ItemName"))
        Next

      Catch ex As Exception
        ' Error
        Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
      End Try

    End With

  End Sub

  ''' <summary>
  ''' 検索処理実行
  ''' </summary>
  ''' <remarks>
  ''' 自動検索フラグに影響をウケます
  ''' 抽出コントロール変更時コールバックに使用
  ''' </remarks>
  Public Sub ExecSearch()

    If AutoSearch Then
      ShowList()
    End If

  End Sub

  ''' <summary>
  ''' 一覧表示（パラメータ変更）
  ''' </summary>
  ''' <param name="prmKbn">置き換える区分名</param>
  ''' <param name="prmData">置き換える文字</param>
  Public Sub ChgShowList(prmKbn As String, prmData As String)

    ' 表示用SQL文(修正元)から、指定した区分を置き換える
    _SrcSql = Replace(_BeforeSrcSql, prmKbn, prmData, 1, 1, CompareMethod.Binary)

  End Sub

  ''' <summary>
  ''' 一覧表示
  ''' </summary>
  Public Sub ShowList()

    ' 一覧表示更新
    _SqlCon.GetResult(EditDT, ComAddSqlSearchCondition(_SrcSql, CreateConditionText()))

    OriginalDT = EditDT.Clone

    ' 最終更新日時更新
    _lastUpdate = CDate(ComGetProcTime())

    If lcCallBackReLoadData IsNot Nothing Then
      Call lcCallBackReLoadData(_GcMultiRow, LastUpdate, BindSrc.Count)
    End If

  End Sub

  ''' <summary>
  ''' MultiRowを新規行追加不可に設定
  ''' </summary>
  Public Sub SetDisplayMode()

    ' 新規行
    _GcMultiRow.AllowUserToAddRows = False

    ' クリックされたセルが属する行を選択し、クリックされたセルをアクティブにするモードを指定
     _GcMultiRow.ViewMode = GrapeCity.Win.MultiRow.ViewMode.Row

    ' 行選択状態のときの色設定
    _GcMultiRow.DefaultCellStyle.SelectionBackColor = Color.Transparent
    _GcMultiRow.DefaultCellStyle.SelectionForeColor = Color.Black

  End Sub

  ''' <summary>
  ''' 指定したセルのデータソースフィールドを設定
  ''' </summary>
  ''' <param name="prmCtrlName">指定するセル名</param>
  ''' <param name="prmDataFiled">データソースフィールド</param>
  ''' <param name="prmIndex"></param>
  Public Sub SetDataFiled(prmCtrlName As String,
                          prmDataFiled As String,
                          prmIndex As Integer)

    Dim temp As Template = _GcMultiRow.Template

    temp.Row.Cells(prmCtrlName).DataField = prmDataFiled
    temp.Row.Cells(prmCtrlName).CellIndex = prmIndex

    _GcMultiRow.Template = temp

  End Sub

  ''' <summary>
  ''' 指定したセルのデータソースフィールドを設定
  ''' </summary>
  ''' <param name="prmCtrlName">指定するセル名</param>
  ''' <param name="prmDataFiled">データソースフィールド</param>
  ''' <param name="prmIndex"></param>
  ''' <param name="prmVisible"></param>
  Public Sub SetDataFiled(prmCtrlName As String,
                          prmDataFiled As String,
                          prmIndex As Integer,
                          prmVisible As Boolean)

    Dim temp As Template = _GcMultiRow.Template

    temp.Row.Cells(prmCtrlName).DataField = prmDataFiled
    temp.Row.Cells(prmCtrlName).CellIndex = prmIndex
    temp.Row.Cells(prmCtrlName).Visible = prmVisible

    _GcMultiRow.Template = temp

  End Sub


  ''' <summary>
  ''' 指定したヘッダ名称を設定
  ''' </summary>
  ''' <param name="prmCtrlName">指定するセル名</param>
  ''' <param name="prmName">ヘッダ名称</param>
  Public Sub SetLabelFiled(prmCtrlName As String,
                          prmName As String)

    Dim temp As Template = _GcMultiRow.Template

    temp.ColumnHeaders(0).Cells(prmCtrlName).Value = prmName

    _GcMultiRow.Template = temp

  End Sub

  ''' <summary>
  ''' 検索条件コントロール追加
  ''' </summary>
  ''' <param name="prmCtrl"></param>
  ''' <param name="prmSearchItemName"></param>
  ''' <param name="prmSearchType"></param>
  ''' <param name="prmDataType"></param>
  Public Sub AddSearchControl(prmCtrl As Control _
                              , prmSearchItemName As String _
                              , prmSearchType As typExtraction _
                              , prmDataType As typColumnKind _
                              , Optional prmSerch As Boolean = False)

    Dim tmpSc As clsDataGridSearchControl

    If IsComboBox(prmCtrl) Then
      tmpSc = New clsDataGridSearchCmb
    ElseIf IsTextBox(prmCtrl) Then
      tmpSc = New clsDataGridSearchTextBox
    Else
      Throw New Exception("")
    End If

    With tmpSc
      .DataType = prmDataType
      .SearchItemName = prmSearchItemName
      .SearchType = prmSearchType
      .TargetControl = prmCtrl
      If (SearchCtl()) Then
        .mCallBack = Sub() ExecSearch()
      End If
    End With

    Call _SearchConditionz.Add(tmpSc)

  End Sub

  ''' <summary>
  ''' 検索コントロール追加
  ''' </summary>
  ''' <param name="prmCtrl"></param>
  ''' <param name="prmSearchType"></param>
  ''' <param name="prmDataType"></param>
  ''' <param name="prmSerch"></param>
  ''' <remarks>
  ''' 抽出項目名省略バージョン（抽出項目名=コントロール名）
  ''' </remarks>
  Public Sub AddSearchControl(prmCtrl As Control _
                              , prmSearchType As typExtraction _
                              , prmDataType As typColumnKind _
                              , Optional prmSerch As Boolean = False)

    Call AddSearchControl(prmCtrl, prmCtrl.Name, prmSearchType, prmDataType)
  End Sub

  ''' <summary>
  ''' 指定した項目でのデータテーブルの検索
  ''' </summary>
  ''' <param name="prmCtrl">検索する項目名</param>
  ''' <param name="prmNo">検索する値</param>
  ''' <param name="retVal">検索した結果</param>
  ''' <returns>True:検索結果あり、False:検索結果なし</returns>
  Public Function SelectDataRow(prmCtrl As String,
                                prmNo As String,
                                ByRef retVal As DataRow) As Boolean

    Dim ret As Boolean = False
    Dim rows As DataRow() = EditDT.Select(prmCtrl & " = '" & prmNo & "'")


    Try
      If (rows.Count = 1) Then
        retVal = rows(0)
        ret = True
      ElseIf (rows.Count > 1) Then
        ' Error
        Throw New Exception("検索結果が１件以上存在します")
      End If
    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

    Return ret

  End Function

  ''' <summary>
  ''' 税区分コンボボックスの設定
  ''' </summary>
  ''' <param name="template1"></param>
  Public Shared Sub SetTaxCombo(ByRef template1 As Template _
                              , Optional prmCellName As String = "CmbTaxType")

    ' コンボボックス型セル用データの作成
    Dim dl As New DataTable
    dl.Columns.Add("ItemCode", GetType([String]))
    dl.Columns.Add("ItemName", GetType([String]))
    dl.Rows.Add("1", "外税")
    dl.Rows.Add("2", "内税")
    dl.Rows.Add("3", "非")
    dl.AcceptChanges()

    Dim tmpCmb As GcComboBoxCell = CType(template1.Row.Cells(prmCellName), GcComboBoxCell)
    ' ヘッダを非表示にします。
    tmpCmb.ListHeaderPane.Visible = False
    ' サイズ変更グリップの非表示
    tmpCmb.DropDown.AllowResize = False
    tmpCmb.ListColumns.Clear()
    tmpCmb.ListColumns.Add("ItemCode")
    tmpCmb.ListColumns.Add("ItemName")
    tmpCmb.ListColumns(0).AutoWidth = False
    tmpCmb.ListColumns(1).AutoWidth = False
    tmpCmb.ListColumns(0).DataPropertyName = "ItemCode"
    tmpCmb.ListColumns(1).DataPropertyName = "ItemName"

    tmpCmb.ListColumns(0).Width = 40
    tmpCmb.ListColumns(1).Width = 100
    tmpCmb.DropDown.Width = 140
    tmpCmb.ValueSubItemIndex = 0
    tmpCmb.TextSubItemIndex = 0       ' 税区分コードを表示する

    tmpCmb.DataSource = dl

  End Sub

  ''' <summary>
  ''' 定貫コンボボックスの設定
  ''' </summary>
  ''' <param name="template1"></param>
  Public Shared Sub SetWeightTypeCombo(ByRef template1 As Template)

    ' コンボボックス型セル用データの作成
    Dim dl As New DataTable
    dl.Columns.Add("ItemCode", GetType([String]))
    dl.Columns.Add("ItemName", GetType([String]))
    dl.Rows.Add("0", "定貫")
    dl.Rows.Add("1", "不定貫")
    dl.AcceptChanges()

    Dim tmpCmb As GcComboBoxCell = CType(template1.Row.Cells("CmbWeightType"), GcComboBoxCell)
    ' ヘッダを非表示にします。
    tmpCmb.ListHeaderPane.Visible = False
    ' サイズ変更グリップの非表示
    tmpCmb.DropDown.AllowResize = False
    tmpCmb.ListColumns.Clear()
    tmpCmb.ListColumns.Add("ItemCode")
    tmpCmb.ListColumns.Add("ItemName")
    tmpCmb.ListColumns(0).AutoWidth = False
    tmpCmb.ListColumns(1).AutoWidth = False
    tmpCmb.ListColumns(0).DataPropertyName = "ItemCode"
    tmpCmb.ListColumns(1).DataPropertyName = "ItemName"
    tmpCmb.ListColumns(0).Width = 40
    tmpCmb.ListColumns(1).Width = 100
    tmpCmb.DropDown.Width = 140
    tmpCmb.ValueSubItemIndex = 0
    tmpCmb.TextSubItemIndex = 0       ' 定貫コードを表示する

    tmpCmb.DataSource = dl

  End Sub

  ''' <summary>
  ''' ラベル発行状態コンボボックスの設定
  ''' </summary>
  ''' <param name="template1"></param>
  Public Shared Sub SetLabelPrintCombo(ByRef template1 As Template)

    ' コンボボックス型セル用データの作成
    Dim dl As New DataTable
    dl.Columns.Add("ItemCode", GetType([String]))
    dl.Columns.Add("ItemName", GetType([String]))
    dl.Rows.Add("0", "未発行")
    dl.Rows.Add("1", "発行済み")
    dl.AcceptChanges()

    Dim tmpCmb As GcComboBoxCell = CType(template1.Row.Cells("cmbLabelPrint"), GcComboBoxCell)
    ' ヘッダを非表示にします。
    tmpCmb.ListHeaderPane.Visible = False
    ' サイズ変更グリップの非表示
    tmpCmb.DropDown.AllowResize = False
    tmpCmb.ListColumns.Clear()
    tmpCmb.ListColumns.Add("ItemCode")
    tmpCmb.ListColumns.Add("ItemName")
    tmpCmb.ListColumns(0).AutoWidth = False
    tmpCmb.ListColumns(1).AutoWidth = False
    tmpCmb.ListColumns(0).DataPropertyName = "ItemCode"
    tmpCmb.ListColumns(1).DataPropertyName = "ItemName"
    tmpCmb.ListColumns(0).Width = 40
    tmpCmb.ListColumns(1).Width = 100
    tmpCmb.DropDown.Width = 140
    tmpCmb.ValueSubItemIndex = 0
    tmpCmb.TextSubItemIndex = 1

    tmpCmb.DataSource = dl

  End Sub

  ''' <summary>
  ''' 単位コンボボックスの設定
  ''' </summary>
  ''' <param name="_unitDic"></param>
  ''' <param name="template1"></param>
  Public Shared Sub SetOrderUnitCombo(_unitDic As Dictionary(Of String, String),
  ByRef template1 As Template _
  , Optional prmCellName As String = "CmbOrderUnit")


    Dim tmpCmb As GcComboBoxCell = CType(template1.Row.Cells(prmCellName), GcComboBoxCell)
    ' ヘッダを非表示にします。
    tmpCmb.ListHeaderPane.Visible = False
    ' サイズ変更グリップの非表示
    tmpCmb.DropDown.AllowResize = False
    tmpCmb.ListColumns.Clear()
    tmpCmb.DropDown.Width = 100

    For Each row In _unitDic
      tmpCmb.Items.Add(row.Value)
    Next

  End Sub

  ''' <summary>
  ''' 摘要コードから摘要名を取得
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <param name="prmName"></param>
  ''' <returns></returns>
  Public Shared Function GetMemoTextCombo(prmCode As String,
                                          ByRef prmName As String) As Boolean

    Dim ret As Boolean = False
    Dim tmpDt As New DataTable

    If (GetMemoText(tmpDt)) Then
      '条件に合うデータの取得
      Dim retDR As DataRow()
      retDR = tmpDt.Select(CTRL_COMMON_CODE & " = '" & prmCode & "'")
      For Each d As DataRow In retDR
        prmName = d(CTRL_COMMON_NAME).ToString
        ret = True
        Exit For
      Next
    End If

    Return ret

  End Function

  ''' <summary>
  ''' 摘要コンボボックスの設定
  ''' </summary>
  ''' <param name="template1"></param>
  Public Shared Sub SetMemoTextCombo(ByRef template1 As Template,
                                     Optional prmReSet As Boolean = False)

    Dim tmpCmb As GcComboBoxCell = CType(template1.Row.Cells("CmbTekiyou"), GcComboBoxCell)
    If (prmReSet = False) Then
      ' ヘッダを非表示にします。
      tmpCmb.ListHeaderPane.Visible = False
      ' サイズ変更グリップの非表示
      tmpCmb.DropDown.AllowResize = False
      tmpCmb.ListColumns.Clear()
      tmpCmb.DropDown.Width = 400

      Dim tmpDt As New DataTable

      If (GetMemoText(tmpDt)) Then
        For Each row As DataRow In tmpDt.Rows
          tmpCmb.Items.Add(row(CTRL_COMMON_NAME).ToString)
        Next
      End If

    End If

  End Sub

  ''' <summary>
  ''' 摘要マスタ検索処理
  ''' </summary>
  ''' <param name="prmDt"></param>
  ''' <returns></returns>
  Private Shared Function GetMemoText(ByRef prmDt As DataTable) As Boolean

    Dim ret As Boolean = True
    Dim tmpDb As New clsSqlServer

    ' 実行
    With tmpDb
      Try

        ' SQL実行結果が指定した件数か？
        Call tmpDb.GetResult(prmDt, SqlGetTekiyou())
        If (prmDt.Rows.Count = 0) Then
          ret = False
        End If

      Catch ex As Exception
        ' Error
        Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
        ret = False
      End Try

    End With

    Return ret

  End Function

  ''' <summary>
  ''' 摘要コードを取得するＳＱＬ文
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Public Shared Function SqlGetTekiyou(Optional prmCode As String = "") As String

    Dim sql As String = String.Empty

    sql &= " SELECT NO AS " & CTRL_COMMON_CODE
    sql &= "      , NAME AS " & CTRL_COMMON_NAME
    sql &= " FROM INFO "
    If prmCode <> "" Then
      sql &= "  WHERE NO = " & prmCode & " AND KUBUN = 1 "
    Else
      sql &= "  WHERE KUBUN = 1"
    End If

    Return sql
  End Function


#End Region

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' リサイズ禁止
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRow1_CellResizeCompleting(sender As Object, e As CellResizeCompletingEventArgs) Handles _GcMultiRow.CellResizeCompleting

    e.Handled = True

  End Sub

  ''' <summary>
  ''' セル全選択設定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRow1_CellEnter(sender As Object, e As CellEventArgs) Handles _GcMultiRow.CellEnter

    If (SelectAllFocus) Then

      With _GcMultiRow
        If e.Scope = CellScope.Row Then
          ' 文字列型セルとコンボボックスセルの場合のみ常時入力モードを有効
          If TypeOf .CurrentCell Is TextBoxCell Or
               TypeOf .CurrentCell Is GcComboBoxCell Then
            .BeginEdit(True)
          End If
        End If
      End With
    End If

  End Sub

  ''' <summary>
  ''' 編集モードへの変更時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRowEditingControlShowing(sender As Object, e As EditingControlShowingEventArgs) Handles _GcMultiRow.EditingControlShowing

    If _GcMultiRow.CurrentCell Is Nothing Then
      Exit Sub
    End If

    Dim tmpCurrentCellName As String = _GcMultiRow.CurrentCell.Name

    If TypeOf e.Control Is TextBoxEditingControl Then
      If _DoubleClickCellz.IndexOf(tmpCurrentCellName) >= 0 Then
        _LastMrCtrl = e.Control ' 編集モードへ移行したコントロールを保持
        _LastClickTime = Now()  ' 編集モードへ移行した時刻を保持

        ' 編集モードへ移行したコントロールのクリックイベントを設定
        RemoveHandler e.Control.MouseClick, AddressOf CellMouseClick
        AddHandler e.Control.MouseClick, AddressOf CellMouseClick
        RemoveHandler e.Control.MouseDoubleClick, AddressOf CellMouseDoubleClick
        AddHandler e.Control.MouseDoubleClick, AddressOf CellMouseDoubleClick

      End If
    End If

    ' 編集用コントロールのKeyDownイベントの検出
    RemoveHandler e.Control.KeyDown, AddressOf editor_KeyDown
    AddHandler e.Control.KeyDown, AddressOf editor_KeyDown

  End Sub

  Private Sub editor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    ' キー操作による動作の実装
    Select Case e.KeyCode
      Case Keys.Home
        e.SuppressKeyPress = False

        If TypeOf sender Is TextBoxCell Then
          Dim editor As TextBoxEditingControl = CType(sender, TextBoxEditingControl)

          editor.SelectionStart = 1

        End If





        '      DirectCast(sender, IEditingControl).GcMultiRow.se



        'If (e.RowIndex >= 0) And (e.CellIndex >= 0) Then
        '  If TypeOf GcMultiRow1(e.RowIndex, e.CellIndex) Is TextBoxCell Or
        '   TypeOf GcMultiRow1(e.RowIndex, e.CellIndex) Is GcComboBoxCell Then

        '    Dim pos As CellPosition = New CellPosition(e.RowIndex, e.CellIndex)
        '    MR1.CurrentCellPosition = pos
        '  End If
        'End If

        Return
    End Select


    If ((DirectCast(sender, IEditingControl).GcMultiRow) Is Nothing) Then
      Return
    End If

    If (DirectCast(sender, IEditingControl).GcMultiRow.CurrentCell.IsInEditMode) Then
      Console.WriteLine("MultiRow入力")
    Else
      'Select Case e.KeyCode
      '  Case Keys.Down
      '    e.SuppressKeyPress = True
      '    SelectionActions.MoveDown.Execute(DirectCast(sender, IEditingControl).GcMultiRow)
      '  Case Keys.Right
      '    e.SuppressKeyPress = True
      '    SelectionActions.MoveDown.Execute(DirectCast(sender, IEditingControl).GcMultiRow)
      '  Case Keys.Left
      '    e.SuppressKeyPress = True
      '    SelectionActions.MoveUp.Execute(DirectCast(sender, IEditingControl).GcMultiRow)
      '  Case Keys.Up
      '    e.SuppressKeyPress = True
      '    SelectionActions.MoveUp.Execute(DirectCast(sender, IEditingControl).GcMultiRow)
      'End Select
    End If

  End Sub

  ''' <summary>
  ''' 編集モード時マウスクリックイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CellMouseClick(sender As Object, e As MouseEventArgs)
    Dim tmpTimeSpan As TimeSpan
    Dim tmpCtrl As Control = DirectCast(sender, Control)

    Try
      If tmpCtrl.Equals(_LastMrCtrl) Then
        tmpTimeSpan = Date.Now() - _LastClickTime

        If tmpTimeSpan.TotalSeconds < _DoubleClickCycle Then
          ' 同一オブジェクトで2回クリックされた
          If lcCallbackCellDoubleClick IsNot Nothing Then
            Call lcCallbackCellDoubleClick(sender, e)
          End If
        End If

      End If
    Catch ex As Exception
      ' 大丈夫、Errorが起きてもダブルクリックに失敗したと思うはず
    Finally
      ' 最終設定情報をクリア
      _LastClickTime = Date.MinValue
      _LastMrCtrl = Nothing
      RemoveHandler tmpCtrl.MouseClick, AddressOf CellMouseClick
    End Try

  End Sub

  ''' <summary>
  ''' セルダブルクリック時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CellMouseDoubleClick(sender As Object, e As MouseEventArgs)
    If lcCallbackCellDoubleClick IsNot Nothing _
      AndAlso _DoubleClickCellz.IndexOf(_GcMultiRow.CurrentCell.Name) >= 0 Then
      Dim tmpCurrentPos As New Point(_GcMultiRow.CurrentCell.CellIndex, _GcMultiRow.CurrentCell.RowIndex)
      _GcMultiRow.CurrentCell = Nothing
      _GcMultiRow.CurrentCellPosition = New CellPosition(tmpCurrentPos.Y, tmpCurrentPos.X)
      Call lcCallbackCellDoubleClick(sender, e)
    End If
  End Sub

  ''' <summary>
  ''' MultiRowダブルクリック時(先頭)
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GcMultiRow1_CellDoubleClick(sender As Object, e As CellEventArgs) Handles _GcMultiRow.CellDoubleClick
    If e.Scope = CellScope.Row Then
      If TypeOf _GcMultiRow(e.RowIndex, e.CellIndex) Is RowHeaderCell Then
        If lcCallbackCellDoubleClick IsNot Nothing Then
          Call lcCallbackCellDoubleClick(sender, Nothing)
        End If
      End If
    End If
  End Sub

#End Region
End Class
