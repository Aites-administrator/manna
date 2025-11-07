Imports Microsoft.VisualBasic.PowerPacks
Imports T.R.ZCommonClass.clsDataGridSearchControl
Imports T.R.ZCommonClass.clsCommonFnc
Imports System.Reflection

''' <summary>
''' DataRepeater操作クラス
''' </summary>
Public Class clsDataRepeater

#Region "列挙体"

  ''' <summary>
  ''' データーリピータの型
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

#Region "データリピータ関連"
  Private WithEvents _DataRepeater As DataRepeater

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
  ''' データリピーターコントロール配列
  ''' </summary>
  Private _DicDRCtrl As New Dictionary(Of String, clsDataRepeaterCtrl)

  ''' <summary>
  ''' データリピーター項番
  ''' </summary>
  Private _DRTabIndex As Integer = 0


  ''' <summary>
  ''' 初期描画フラグ
  ''' </summary>
  Private _InitDraw As Boolean = True

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

  ''' <summary>
  ''' コンボボックスドロップダウン有無 
  ''' </summary>
  Private _ComboDropDown As Boolean = False

#End Region

#Region "更新処理関連"
  ''' <summary>
  ''' 最終データ取得日時
  ''' </summary>
  Private _lastUpdate As Date = Now

#End Region

#End Region

#Region "イベントハンドラ"
  ' ダブルクリックイベント
  Delegate Sub CallBackTextDoubleClick(sender As Object, e As EventArgs)
  Public lcCallBackTextDoubleClick As CallBackTextDoubleClick

  ' コンボボックス変更イベント
  Delegate Sub CallBackComboSelectedIndexChanged(sender As Object, e As EventArgs)
  Public lcCallBackComboSelectedIndexChanged As CallBackComboSelectedIndexChanged

  ' データ表示イベント
  Delegate Sub CallBackReLoadData(sender As DataRepeater, LastUpdate As String, DataCount As Long)
  Public lcCallBackReLoadData As CallBackReLoadData

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
  ''' カレント行の取得
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property DR As DataRepeater
    Get
      Return _DataRepeater
    End Get

  End Property

  ''' <summary>
  ''' カレント行の設定/取得
  ''' </summary>
  ''' <returns></returns>
  Public Property CurrentItemIndex As Integer

    Set(value As Integer)
      If (DataCount > 0) Then
        _DataRepeater.CurrentItemIndex = value
      End If
    End Set
    Get
      Return _DataRepeater.CurrentItemIndex
    End Get

  End Property

  ''' <summary>
  ''' 指定されたSQLで検索し、DataRepeatrに一覧表示する
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
  ''' データ行数取得
  ''' </summary>
  ''' <returns>データ行数</returns>
  Public ReadOnly Property DataCount As Long
    Get
      Return _DataRepeater.ItemCount
    End Get
  End Property

  ''' <summary>
  ''' コンボボックスドロップダウン有無
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>コンボボックスドロップダウン有無</remarks>
  Public Property ComboDropDown As Boolean
    Get
      Return _ComboDropDown
    End Get
    Set(value As Boolean)
      _ComboDropDown = value
    End Set
  End Property

#End Region

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 初期処理
  ''' </summary>
  ''' <param name="prmDataRepeater"></param>
  ''' <param name="prmGridSrcSql"></param>
  Public Sub New(prmDataRepeater As DataRepeater _
               , prmGridSrcSql As String)

    ' DataGridViewを保持
    _DataRepeater = prmDataRepeater

    ' DataRepeaterのインジケータマークを表示する
    _DataRepeater.ItemHeaderVisible = True

    ' ユーザーが新しい行を追加できないようにする
    _DataRepeater.AllowUserToAddItems = False

    ' ユーザーが行を削除できないようにする
    _DataRepeater.AllowUserToDeleteItems = False

    ' 表示用SQL文を保持
    _SrcSql = prmGridSrcSql

    ' DataRepeater初期化
    Call InitDataRepeater()

  End Sub
#End Region

#Region "メソッド"

#Region "プライベート"

  ''' <summary>
  ''' DataRepeater初期化
  ''' </summary>
  Private Sub InitDataRepeater()

    EditDT = OriginalDT.Clone
    BindSrc.DataSource = EditDT
    _DataRepeater.DataSource = BindSrc

    'グリッドに初期を設定する
    With _DataRepeater

      '--------------------------
      '   以下、高速化処理
      '--------------------------

      ' ダブルバッファリング有効
      .GetType().InvokeMember(
      "DoubleBuffered",
      BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty,
      Nothing,
      _DataRepeater,
      New Object() {True})

      '' バーチャルモード有効
      '.VirtualMode = True

    End With
  End Sub

  ''' <summary>
  ''' データリピーター上のコンボボックス変更時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRSelectedIndexChanged(sender As Object, e As EventArgs)

    Try
      Dim ctrlCombo = DirectCast(sender, ComboBox)

      If lcCallBackComboSelectedIndexChanged IsNot Nothing Then
        Call lcCallBackComboSelectedIndexChanged(sender, e)
      End If

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

  End Sub

  ''' <summary>
  ''' ドロップダウンリストを開くと発生するイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRDropDown(sender As Object, e As EventArgs)

    ComboDropDown = True

  End Sub

  ''' <summary>
  ''' ドロップダウンリストを閉じると発生するイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRDropDownClosed(sender As Object, e As EventArgs)

    ComboDropDown = False

  End Sub

  ''' <summary>
  ''' データリピーター上のテキストボックスコントロールのDoubleClick処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_DoubleClick(sender As Object, e As EventArgs)

    Try
      Dim ctrlText = DirectCast(sender, TextBox)

      If (_DicDRCtrl(ctrlText.Name).UseDoubleClick) Then
        DataRepeater_ItemTemplate_DoubleClick(sender, e)
      End If

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

  End Sub

  ''' <summary>
  ''' データリピーター上のテキストボックスコントロールのKeyPress処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_KeyPress(sender As Object, e As KeyPressEventArgs)

    Try
      Dim ctrlText = DirectCast(sender, TextBox)

      Select Case _DicDRCtrl(ctrlText.Name).Type
        Case typDataTable.TYPE_DATETIME
          If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
            AndAlso e.KeyChar <> "/"c _
            AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
          End If
        Case typDataTable.TYPE_LONG
          If sender.Text.Length >= ctrlText.MaxLength Then
            If e.KeyChar <> ControlChars.Back Then
              e.Handled = True
            End If
          End If

        Case typDataTable.TYPE_STRING

          If sender.Text.Length >= ctrlText.MaxLength Then
            If e.KeyChar <> ControlChars.Back Then
              e.Handled = True
            End If
          End If

      End Select

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）

    End Try

  End Sub

  ''' <summary>
  ''' TABキー押下時、SHIFT + TABキー押下時の処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

    'Dim serchIdx As Integer = 0

    'Dim ctrl = DirectCast(sender, Control)

    'If (e.KeyCode = Keys.Tab) Then
    '  If (e.Shift) Then

    '    For Each Item As Control In _DataRepeater.CurrentItem.Controls
    '      If (Item.TabStop) Then
    '        If (Item.TabIndex < ctrl.TabIndex) Then
    '          If (Item.TabIndex > serchIdx) Then
    '            serchIdx = Item.TabIndex
    '          End If
    '        End If
    '      End If
    '    Next

    '    If (serchIdx = 0) Then
    '      If (0 < _DataRepeater.CurrentItemIndex) Then
    '        _DataRepeater.CurrentItemIndex = _DataRepeater.CurrentItemIndex - 1

    '        Dim serchCtrl As Control = Nothing
    '        ' データリピータ上の全コントロール中の一番最後のコントロールを取得する
    '        If (FindLastControl(serchCtrl)) Then
    '          serchCtrl.Select()

    ''          e.IsInputKey = True
    '        End If
    '      End If
    '    End If
    '  Else

    '    '  DRControl_NextMove(ctrl)

    '    '    e.IsInputKey = True

    '  End If
    'End If

  End Sub

  ''' <summary>
  ''' Enterキーを押した時、まるでTabキーを押したかのように、次のコントロールにフォーカスを移す
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_KeyDown(sender As Object, e As KeyEventArgs)

    Dim ctrl = DirectCast(sender, Control)

    If e.KeyCode = Keys.Enter Then

      DRControl_NextMove(ctrl)

    End If

  End Sub

  ''' <summary>
  ''' 上下キー押した時、同一のコントロールにフォーカスを移動する
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_KeyUp(sender As Object, e As KeyEventArgs)

    Dim ctrl = DirectCast(sender, Control)


    If e.KeyCode = Keys.Up Then
      If (CurrentItemIndex > 0) Then
        CurrentItemIndex = CurrentItemIndex - 1
        SetFocus(ctrl)
      End If
    End If

    If e.KeyCode = Keys.Down Then
      ' データリピーターの行が最終行以外の場合
      If (DataCount - 1 > _DataRepeater.CurrentItemIndex) Then
        CurrentItemIndex = CurrentItemIndex + 1
        SetFocus(ctrl)
      End If
    End If

  End Sub

  ''' <summary>
  ''' コントロールの次への移動
  ''' </summary>
  Private Sub DRControl_NextMove(prmCtrl As Control)

    ' 指定したコントロールのタブインデックスの次のタブインデックスの検索
    If (GetSerchNextTabIndex(prmCtrl)) Then
      ' 指定したコントロールのタブインデックスの次のタブインデックスのコントロールに移動する
      _DataRepeater.SelectNextControl(prmCtrl, True, True, True, True)
    Else
      ' データリピーターの行が最終行以外の場合
      If (DataCount - 1 > _DataRepeater.CurrentItemIndex) Then

        ' データリピーターの行を＋１する
        _DataRepeater.CurrentItemIndex = _DataRepeater.CurrentItemIndex + 1

        Dim serchCtrl As Control = Nothing
        ' データリピータ上の全コントロール中の一番最初のコントロールを取得する
        If (FindFirstControl(serchCtrl)) Then
          serchCtrl.Select()
        End If

      End If
    End If

  End Sub

  ''' <summary>
  ''' データリピーター上のテキストボックスコントロールのTextChanged処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_TextChanged(sender As Object, e As EventArgs)

  End Sub

  ''' <summary>
  ''' データリピーター上のテキストボックスコントロールのEnter処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_Enter(sender As Object, e As EventArgs)

    Try
      Dim ctrlText = DirectCast(sender, TextBox)

      If (_DicDRCtrl(ctrlText.Name).MsgLabel Is Nothing) Then
        'メッセージラベルへのメッセージの表示
        _msgLabel.Text = _DicDRCtrl(ctrlText.Name).MsgLabel
      End If

    Catch ex As Exception

    End Try

  End Sub

  ''' <summary>
  ''' データリピーター上のテキストボックスコントロールのValidating処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DRControl_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    'If (CancelValidating) Then
    '  e.Cancel = True
    'End If

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
              sqlWhere &= "%" & .Value & "%"
            Case typExtraction.EX_LIKB
              sqlWhere &= "%" & .Value
            Case typExtraction.EX_LIKF
              sqlWhere &= .Value & "%"
            Case Else
              sqlWhere &= .Value
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

  ''' <summary>
  ''' データリピータの選択行の背景色変更
  ''' </summary>
  Private Sub SetFocusColor()

    If (DataCount > 0) Then
      Static olditem As PowerPacks.DataRepeaterItem

      If olditem Is Nothing Then
        olditem = _DataRepeater.CurrentItem
      Else
        olditem = _DataRepeater.CurrentItem
        _DataRepeater.Refresh()
      End If
      _DataRepeater.CurrentItem.BackColor = Color.LightBlue

    End If

  End Sub

  ''' <summary>
  ''' 指定された行のデーターリピータ上の項目値
  ''' </summary>
  ''' <param name="selectIdx"></param>
  ''' <returns></returns>
  Private Function SelectedRow(selectIdx As Integer) As Dictionary(Of String, String)

    Dim ret As New Dictionary(Of String, String)

    If (selectIdx = -1) Then
      Return ret
    End If

    ' 引数で指定した行番号をカレント行に指定
    Dim oldIdx As Integer = CurrentItemIndex
    CurrentItemIndex = selectIdx

    ' 選択している列の全項目を取得（項目は別名で判断）
    For Each Item As Control In _DataRepeater.CurrentItem.Controls
      ret.Add(_DicDRCtrl(Item.Name).ColumName, Item.Text)
    Next

    ' カレント行を元に戻す
    CurrentItemIndex = oldIdx

    Return ret

  End Function

  ''' <summary>
  ''' 指定された列の、指定された項目値
  ''' </summary>
  ''' <param name="selectIdx"></param>
  ''' <param name="prmKey"></param>
  ''' <returns></returns>
  Private Function SelectedRowByColumn(selectIdx As Integer, prmKey As Control) As String

    Dim ret As String = String.Empty

    '表示している全レコードの内容を表示
    Dim oldIdx As Integer = CurrentItemIndex
    CurrentItemIndex = selectIdx

    'レコード毎にコントロール名から処理を判断
    For Each Item As Control In _DataRepeater.CurrentItem.Controls
      ret = Item.Text
      If Item.Name.Equals(prmKey.Name) Then
        Exit For
      End If
    Next

    CurrentItemIndex = oldIdx

    Return ret

  End Function

#End Region

#Region "パブリック"

  ''' <summary>
  ''' 最後に編集されたデーターリピータ上の項目値
  ''' </summary>
  ''' <returns></returns>
  Public Function SelectedRow() As Dictionary(Of String, String)

    Return SelectedRow(CurrentItemIndex)

  End Function

  ''' <summary>
  ''' 最後に編集された列の、指定されたキーの項目値
  ''' </summary>
  ''' <param name="prmKey"></param>
  ''' <returns></returns>
  Public Function SelectedRowByColumn(prmKey As Control) As String

    Return SelectedRowByColumn(CurrentItemIndex, prmKey)

  End Function

  ''' <summary>
  ''' データリピータ上の全コントロールにイベントハンドラ設定
  ''' </summary>
  ''' <returns></returns>
  Public Function SetCtrlEvent() As Boolean

    Dim ret As Boolean = False
    Dim tabIndex As Integer = 0

    Try

      If (DataCount > 0) Then

        For Each ctl As Control In _DataRepeater.CurrentItem.Controls

          Try
            If IsComboBox(ctl) Then

              Dim comboCtrl As ComboBox = DirectCast(ctl, ComboBox)

              ' コンボボックスイベントハンドラの削除
              RemoveHandler comboCtrl.SelectedIndexChanged, AddressOf DRSelectedIndexChanged
              RemoveHandler comboCtrl.DropDown, AddressOf DRDropDown
              RemoveHandler comboCtrl.DropDownClosed, AddressOf DRDropDownClosed

              ' コンボボックスイベントハンドラの追加
              AddHandler comboCtrl.SelectedIndexChanged, AddressOf DRSelectedIndexChanged
              AddHandler comboCtrl.DropDown, AddressOf DRDropDown
              AddHandler comboCtrl.DropDownClosed, AddressOf DRDropDownClosed

            ElseIf IsTextBox(ctl) Then

              Dim textCtrl As TextBox = DirectCast(ctl, TextBox)

              ' テキストボックスイベントハンドラの削除
              RemoveHandler textCtrl.DoubleClick, AddressOf DRControl_DoubleClick
              RemoveHandler textCtrl.KeyPress, AddressOf DRControl_KeyPress
              RemoveHandler textCtrl.KeyDown, AddressOf DRControl_KeyDown
              RemoveHandler textCtrl.KeyUp, AddressOf DRControl_KeyUp
              RemoveHandler textCtrl.PreviewKeyDown, AddressOf DRControl_PreviewKeyDown
              RemoveHandler textCtrl.Enter, AddressOf DRControl_Enter
              RemoveHandler textCtrl.Validating, AddressOf DRControl_Validating
              RemoveHandler textCtrl.TabIndexChanged, AddressOf DRControl_TextChanged

              ' テキストボックスイベントハンドラの追加
              AddHandler textCtrl.DoubleClick, AddressOf DRControl_DoubleClick
              AddHandler textCtrl.KeyPress, AddressOf DRControl_KeyPress
              AddHandler textCtrl.KeyDown, AddressOf DRControl_KeyDown
              AddHandler textCtrl.KeyUp, AddressOf DRControl_KeyUp
              AddHandler textCtrl.PreviewKeyDown, AddressOf DRControl_PreviewKeyDown
              AddHandler textCtrl.Enter, AddressOf DRControl_Enter
              AddHandler textCtrl.Validating, AddressOf DRControl_Validating
              AddHandler textCtrl.TabIndexChanged, AddressOf DRControl_TextChanged

            Else
              Console.WriteLine(ctl.Name)
            End If
          Catch
          End Try
        Next
      End If
      ret = True

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）

    End Try

    Return ret

  End Function

  ''' <summary>
  ''' データリピータ上の全コントロールにタブオーダー設定
  ''' </summary>
  ''' <returns></returns>
  Private Function SetCtrlTabOrder() As Boolean

    Dim ret As Boolean = False

    ' _DataRepeater.TabStop = False
    _DataRepeater.TabIndex = 99

    Try
      If (DataCount > 0) Then
        Dim tabIndex As Integer = 0
        ' データリピータの全レコードに対してタブオーダーの再設定　※これをしないとタブオーダーが正常に動作しない

        ' レコード毎にコントロール名から処理を判断
        For Each ctl As Control In _DataRepeater.CurrentItem.Controls
          If _DicDRCtrl.ContainsKey(ctl.Name) Then
            tabIndex = _DicDRCtrl(ctl.Name).tabIndex
            If IsComboBox(ctl) Then
              Dim comboCtrl As ComboBox = DirectCast(ctl, ComboBox)
              comboCtrl.TabIndex = tabIndex
            ElseIf IsTextBox(ctl) Then
              Dim textCtrl As TextBox = DirectCast(ctl, TextBox)
              textCtrl.TabIndex = tabIndex
            End If
          End If
        Next
      End If

      ret = True

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

    Return ret

  End Function

  ''' <summary>
  ''' 指定したコントロールのタブインデックスの次のタブインデックスの検索
  ''' </summary>
  ''' <param name="prmCtrl"></param>
  ''' <returns></returns>
  Private Function GetSerchNextTabIndex(ByRef prmCtrl As Control) As Boolean

    Dim ret As Boolean = False
    Dim tabIndex As Integer = 999

    For Each Item As Control In _DataRepeater.CurrentItem.Controls
      If (Item.TabStop) Then
        If (Item.TabIndex > prmCtrl.TabIndex) Then
          If (Item.TabIndex < tabIndex) Then
            tabIndex = Item.TabIndex
            ret = True
          End If
        End If
      End If
    Next

    Return ret

  End Function

  ''' <summary>
  ''' データリピータ上の全コントロール中の一番最初のコントロールを取得する
  ''' </summary>
  ''' <returns>True:コントロールあり、False:コントロールなし</returns>
  Public Function FindFirstControl(ByRef firstCtl As Control) As Boolean

    Dim ret As Boolean = False

    firstCtl = Nothing

    Try
      If (DataCount > 0) Then
        Dim tabIndex As Integer = 0
        ' データリピータの全レコードから先頭のタブオーダーの取得

        ' レコード毎にコントロール名から処理を判断
        For Each ctl As Control In _DataRepeater.CurrentItem.Controls

          If (ctl.TabStop) Then
            If (firstCtl Is Nothing) Then
              firstCtl = ctl
              ret = True
            Else
              If (firstCtl.TabIndex > ctl.TabIndex) Then
                firstCtl = ctl
                ret = True
              End If
            End If
          End If

        Next
      End If

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

    Return ret

  End Function

  ''' <summary>
  ''' データリピータ上の全コントロール中の一番最後のコントロールを取得する
  ''' </summary>
  ''' <returns></returns>
  Public Function FindLastControl(ByRef lastCtl As Control) As Boolean

    Dim ret As Boolean = False

    lastCtl = Nothing

    Try
      If (DataCount > 0) Then
        Dim tabIndex As Integer = 0
        ' データリピータの全レコードから先頭のタブオーダーの取得

        ' レコード毎にコントロール名から処理を判断
        For Each ctl As Control In _DataRepeater.CurrentItem.Controls

          If (ctl.TabStop) Then
            For Each Item As Control In _DataRepeater.CurrentItem.Controls
              If (Item.TabStop) Then
                If (tabIndex < Item.TabIndex) Then
                  tabIndex = Item.TabIndex
                  lastCtl = Item
                End If
              End If
            Next
          End If

        Next
      End If

      ret = True

    Catch ex As Exception
      ' Error
      Call ComWriteErrLog(ex, False)   ' Error出力（＋画面表示）
    End Try

    Return ret

  End Function

  ''' <summary>
  ''' データーリピータ上のコントロールとデータ連結
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmType">型</param>
  Public Sub LinkControl(prmCtrl As Control,
                         Optional prmType As typDataTable = typDataTable.TYPE_STRING)

    ' データリピーターコントロールクラスに要素を追加
    _DicDRCtrl(prmCtrl.Name) = New clsDataRepeaterCtrl(prmType, "", prmCtrl.Name, False, _DRTabIndex)
    _DRTabIndex = _DRTabIndex + 1

    ' コントロールとデータ連結
    prmCtrl.DataBindings.Add(PROPERTY_TEXT, EditDT, prmCtrl.Name)

  End Sub

  ''' <summary>
  ''' データーリピータのデータテーブルとデータ連結
  ''' </summary>
  ''' <param name="prmName">テキストボックスコントロール</param>
  Public Sub LinkControlName(prmName As String,
                             Optional prmType As String = "System.String")

    ' データテーブルに列名を追加
    EditDT.Columns.Add(prmName, System.Type.GetType("System.String"))

  End Sub


  ''' <summary>
  ''' データーリピータ上のコントロールとデータ連結
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmType">型</param>
  Public Sub LinkControlAdd(prmCtrl As Control,
                         Optional prmType As String = "System.String")

    ' 自コントロールにフォーカスが移る時に他コントロールのValidation(検査)イベントの発生を抑制する
    prmCtrl.CausesValidation = False

    ' データテーブルに列名を追加
    EditDT.Columns.Add(prmCtrl.Name, System.Type.GetType(prmType))

    ' データリピーターコントロールクラスに要素を追加
    _DicDRCtrl(prmCtrl.Name) = New clsDataRepeaterCtrl(typDataTable.TYPE_STRING, "", prmCtrl.Name, False, _DRTabIndex)
    _DRTabIndex = _DRTabIndex + 1

    ' コントロールとデータ連結
    prmCtrl.DataBindings.Add(PROPERTY_TEXT, EditDT, prmCtrl.Name)

  End Sub

  ''' <summary>
  ''' データーリピータ上のコントロールの下部メッセージ設定
  ''' </summary>
  ''' <param name="prmCtrl">テキストボックスコントロール</param>
  ''' <param name="prmLabel">下部メッセージ</param>
  Public Sub AddLabelMsg(prmCtrl As Control, prmLabel As String)

    ' 表示メッセージ設定
    _DicDRCtrl(prmCtrl.Name).MsgLabel = prmLabel

  End Sub

  ''' <summary>
  ''' データーリピータ上のコンボボックスコントロールのＳＱＬ文設定
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
  ''' データーリピータ上のコントロールのDoubleClickイベント実行有無設定
  ''' </summary>
  ''' <param name="prmCtrl"></param>
  ''' <param name="prmFlg"></param>
  Public Sub SetEventDoubleClick(prmCtrl As Control, prmFlg As Boolean)

    _DicDRCtrl(prmCtrl.Name).UseDoubleClick = prmFlg

  End Sub

  ''' <summary>
  '''  'データーソース経由で DataRepeater を表示
  ''' </summary>
  Public Sub BindDataSrc()

    'データーソース経由で DataRepeater を表示
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
  ''' データリピータ上のコンボボックス初期設定
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

    ' データリピータの先頭位置フォーカス設定
    CurrentItemIndex = 0

  End Sub

  ''' <summary>
  ''' 一覧表示
  ''' </summary>
  Public Sub ShowList()

    ' 描画停止
    BeginUpdate(_DataRepeater)

    ' 一覧表示更新
    _SqlCon.GetResult(EditDT, ComAddSqlSearchCondition(_SrcSql, CreateConditionText()))

    OriginalDT = EditDT.Clone

    ' 最終更新日時更新
    _lastUpdate = CDate(ComGetProcTime())

    If lcCallBackReLoadData IsNot Nothing Then
      Call lcCallBackReLoadData(_DataRepeater, LastUpdate, DataCount)
    End If

    ' 描画再開
    EndUpdate(_DataRepeater)

  End Sub

  ''' <summary>
  ''' 行追加（末尾に追加）
  ''' </summary>
  ''' <param name="prmRow">追加する行の内容</param>
  Public Sub CurrentAddItem(prmRow As DataRow)

    ' データリピータの列の最大件数＋１
    Dim tmpNo As Long = DataCount + 1

    ''項番を末尾の値を設定する
    'prmRow(DR_NAME01) = tmpNo

    '行追加
    EditDT.Rows.Add(prmRow)

    ' 追加を確定
    EditDT.AcceptChanges()

    ' 追加した位置に移動
    CurrentItemIndex = tmpNo - 1

  End Sub

  ''' <summary>
  ''' 行追加（末尾に追加）
  ''' </summary>
  ''' <param name="prmRow">追加する行の内容</param>
  Public Sub CurrentAddItemImport(prmRow As DataRow)

    ' データリピータの列の最大件数＋１
    Dim tmpNo As Long = DataCount + 1

    ''項番を末尾の値を設定する
    'prmRow(DR_NAME01) = tmpNo

    '行追加
    EditDT.ImportRow(prmRow)

    ' 追加を確定
    EditDT.AcceptChanges()

    ' 追加した位置に移動
    CurrentItemIndex = tmpNo - 1

  End Sub

  ''' <summary>
  ''' 選択行より１つ前の行と交換
  ''' </summary>
  Public Sub CurrentChgFront()

    If (DataCount > 0) Then

      Dim idxChg As Integer = CurrentItemIndex

      ' 選択行が先頭の場合、交換処理を行わない
      If (idxChg <= 0) Then
        Exit Sub
      End If

      ' 選択行が新規行の場合、交換処理を行わない
      If (EditDT.Rows(idxChg).Item("TxtKubun").Equals("0")) Then
        Exit Sub
      End If

      Dim dtSwap As DataTable = New DataTable
      dtSwap = EditDT.Copy

      ' 列の交換
      EditDT.Rows(idxChg - 1).ItemArray = dtSwap.Rows(idxChg).ItemArray
      EditDT.Rows(idxChg).ItemArray = dtSwap.Rows(idxChg - 1).ItemArray
      EditDT.Rows(idxChg - 1).Item(0) = dtSwap.Rows(idxChg).Item(0)
      EditDT.Rows(idxChg).Item(0) = dtSwap.Rows(idxChg - 1).Item(0)

      ' 変更の確定
      EditDT.AcceptChanges()

      ' メモリ解放
      dtSwap.Dispose()
      dtSwap = Nothing

      ' 選択行を１つ上に設定
      CurrentItemIndex = idxChg - 1

    End If

  End Sub

  ''' <summary>
  ''' 選択行より１つ後の行と交換）
  ''' </summary>
  Public Sub CurrentChgBack()

    If (DataCount > 0) Then

      Dim idxChg As Integer = CurrentItemIndex

      ' 選択行が未選択の場合、交換処理を行わない
      If (idxChg < 0) Then
        Exit Sub
      End If

      ' 選択行が末尾の場合、交換処理を行わない
      If (idxChg >= DataCount) Then
        Exit Sub
      End If

      ' 選択行が新規行の場合、交換処理を行わない
      If (EditDT.Rows(idxChg).Item("TxtKubun").Equals("0")) Then
        Exit Sub
      End If

      ' 交換先が新規行の場合、交換処理を行わない
      If (EditDT.Rows(idxChg + 1).Item("TxtKubun").Equals("0")) Then
        Exit Sub
      End If

      Dim dtSwap As DataTable = New DataTable
      dtSwap = EditDT.Copy

      ' 列の交換
      EditDT.Rows(idxChg).ItemArray = dtSwap.Rows(idxChg + 1).ItemArray
      EditDT.Rows(idxChg + 1).ItemArray = dtSwap.Rows(idxChg).ItemArray
      EditDT.Rows(idxChg).Item(0) = dtSwap.Rows(idxChg + 1).Item(0)
      EditDT.Rows(idxChg + 1).Item(0) = dtSwap.Rows(idxChg).Item(0)

      ' 変更の確定
      EditDT.AcceptChanges()

      ' メモリ解放
      dtSwap.Dispose()
      dtSwap = Nothing

      ' 選択行を１つ下に設定
      CurrentItemIndex = idxChg + 1

    End If

  End Sub

  ''' <summary>
  ''' 新規追加
  ''' </summary>
  Public Sub InsertNewData()

    Dim rowNo As Integer = 0
    If (EditDT IsNot Nothing) Then
      rowNo = EditDT.Rows.Count + 1
    Else
      rowNo = 1
    End If

    CurrentAddItemNew(rowNo)

  End Sub

  ''' <summary>
  ''' 行追加（行番号指定）
  ''' </summary>
  Public Sub CurrentAddItemNew(rowNo As Integer)

    Dim dtRow As DataRow = Nothing
    dtRow = EditDT.NewRow

    ' 区分
    dtRow("TxtKubun") = "0"
    ' 行番号
    dtRow("TxtRows") = rowNo.ToString

    EditDT.Rows.Add(dtRow)

    EditDT.AcceptChanges()

  End Sub

  ''' <summary>
  ''' 選択された行の削除
  ''' </summary>
  Public Sub CurrentDeleteItem()

    If (EditDT.Rows.Count <> 0) Then
      If (CurrentItemIndex >= 0) Then
        EditDT.Rows.RemoveAt(CurrentItemIndex)
      End If
    End If

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
  ''' データリピータ上のコントロールのフォーカス設定
  ''' </summary>
  ''' <param name="prmContrl"></param>
  Public Sub SetFocus(prmContrl As Control)

    For Each ctrl As Control In _DataRepeater.CurrentItem.Controls
      If (ctrl.Name.Equals(prmContrl.Name)) Then
        ctrl.Focus()
        Exit For
      End If
    Next

  End Sub

#End Region

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' データリピータ上の行フォーカス移動時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DataRepeater_CurrentItemIndexChanged(sender As Object, e As EventArgs) Handles _DataRepeater.CurrentItemIndexChanged

    ' イベントハンドラの再設定を行う
    SetCtrlEvent()

    ' タブオーダーの再設定
    SetCtrlTabOrder()

    ' 選択行の色変更
    SetFocusColor()

  End Sub

  ''' <summary>
  ''' データリピーターの左右空白設定／背景色変更
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DataRepeater_DrawItem(sender As Object, e As DataRepeaterItemEventArgs) Handles _DataRepeater.DrawItem

    Dim tmpCmbo As ComboBox

    For Each dicCombo In _DicDRCtrl
      If (dicCombo.Value.cmbControl) Then
        tmpCmbo = DirectCast(e.DataRepeaterItem.Controls(dicCombo.Key), ComboBox)
        If tmpCmbo IsNot Nothing Then
          tmpCmbo.SelectionLength = 0
        End If
      End If
    Next

    ' データリピータ内のデータ表示部で左右にマージンを入れる
    For Each ctl In e.DataRepeaterItem.Controls
      ' マージン設定
      SetLeftRightMargin(ctl, (6 And &HFFFF) Or (6 * &H10000))
    Next

    If e.DataRepeaterItem.ItemIndex Mod 2 <> 0 Then
      '奇数行
      e.DataRepeaterItem.BackColor = clsGlobalDataOrder.GRID_ODD_BACKCOLOR

      '奇数行のDataRepeaterに載っかっているコントロールの背景色変更
      For Each ctl In e.DataRepeaterItem.Controls
        If (IsButton(ctl) = False) Then
          ctl.BackColor = e.DataRepeaterItem.BackColor
        End If
      Next
    Else
      '偶数行
      e.DataRepeaterItem.BackColor = clsGlobalDataOrder.GRID_EVEN_BACKCOLOR

      '偶数行のDataRepeaterに載っかっているコントロールの背景色変更
      For Each ctl In e.DataRepeaterItem.Controls
        If (IsButton(ctl) = False) Then
          ctl.BackColor = e.DataRepeaterItem.BackColor
        End If
      Next
    End If

  End Sub

  ''' <summary>
  ''' データリピーターのコンボボックスダブルクリックイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub DataRepeater_ItemTemplate_DoubleClick(sender As Object, e As EventArgs) Handles _DataRepeater.ItemTemplate.DoubleClick

    If lcCallBackTextDoubleClick IsNot Nothing Then
      Call lcCallBackTextDoubleClick(sender, e)
    End If

  End Sub

  Private Sub DataRepeater_ItemTemplate_KeyDown(sender As Object, e As KeyEventArgs) Handles _DataRepeater.ItemTemplate.KeyDown

  End Sub

#End Region

#Region "インナークラス"
  Private Class CustomDGV
    Inherits DataRepeater



  End Class
#End Region
End Class
