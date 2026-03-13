Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System.ComponentModel

Public Class FormComMasterMente
  Inherits FormBase

  Private Const ENTRY_TITLE As String = "登録"
  Private Const UPDATE_TITLE As String = "更新"
  Private Const DELETE_TITLE As String = "削除"
  Private ReadOnly _definition As IMasterMentenance
  Private _dt As DataTable

  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents btnSave As BtnSave
  Friend WithEvents btnDelete As BtnDel
  Friend WithEvents btnAdd As BtnAdd
  Friend WithEvents btnImport As BtnMstInput
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents LblBase2 As LblBase
  Friend WithEvents TxtCode As TxtNumericBase
  Friend WithEvents TxtName As TxtBase
  Friend WithEvents LblBase3 As LblBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L

  Public Sub New(definition As IMasterMentenance)
    InitializeComponent()
    _definition = definition
  End Sub

  Private Sub FormComMasterMente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      Me.LblBase1.Text = _definition.Title
      ' データ取得
      _dt = _definition.LoadData()

      DgvList1.TrimDataTable(_dt)

      DgvList1.SetData(_dt)

      ' 列設定
      SetupColumns()

      btnAdd.Visible = Not _definition.AllowImport
      btnImport.Visible = _definition.AllowImport
      LblBase2.Visible = _definition.AllowImport
      TxtCode.Visible = _definition.AllowImport
      LblBase3.Visible = _definition.AllowImport
      TxtName.Visible = _definition.AllowImport
    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub

  Private Sub DgvList1_EditingControlShowing(
    sender As Object,
    e As DataGridViewEditingControlShowingEventArgs
) Handles DgvList1.EditingControlShowing

    Dim txt = TryCast(e.Control, TextBox)
    If txt Is Nothing Then Return

    RemoveHandler txt.KeyPress, AddressOf NumericOnly_KeyPress
    RemoveHandler txt.KeyPress, AddressOf NumericDecimal_KeyPress

    Dim colName = DgvList1.Columns(DgvList1.CurrentCell.ColumnIndex).Name

    ' ★ definition の設定を参照
    Dim colDef = _definition.Columns.FirstOrDefault(Function(c) c.Name = colName)

    If colDef IsNot Nothing AndAlso colDef.IsNumeric AndAlso colDef.IsDecimal Then
      AddHandler txt.KeyPress, AddressOf NumericDecimal_KeyPress
    ElseIf colDef IsNot Nothing AndAlso colDef.IsNumeric Then
      AddHandler txt.KeyPress, AddressOf NumericOnly_KeyPress
    End If
  End Sub

  Private Sub NumericOnly_KeyPress(sender As Object, e As KeyPressEventArgs)
    If Not ("0"c <= e.KeyChar AndAlso e.KeyChar <= "9"c) _
       AndAlso e.KeyChar <> ControlChars.Back Then
      e.Handled = True
    End If

  End Sub

  Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
    Dim txt = DirectCast(sender, TextBox)

    ' バックスペースは許可
    If e.KeyChar = ControlChars.Back Then
      Return
    End If

    ' 半角数字は許可
    If "0"c <= e.KeyChar AndAlso e.KeyChar <= "9"c Then
      Return
    End If

    ' 小数点は 1 回だけ許可
    If e.KeyChar = "."c AndAlso Not txt.Text.Contains("."c) Then
      Return
    End If

    ' 上記以外は拒否
    e.Handled = True
  End Sub

  Private Sub SetupColumns()
    Try
      For Each col In _definition.Columns
        Dim dgvCol = DgvList1.Columns(col.Name)

        If dgvCol IsNot Nothing Then
          dgvCol.HeaderText = col.DisplayName
          dgvCol.Visible = col.IsVisible
          dgvCol.ReadOnly = Not col.IsEditable
        End If
      Next
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub
  'Private Sub ExecuteSearch()
  '  Try
  '    Dim keyword = TxtBase1.Text.Trim().Replace("'", "''")

  '    If keyword = "" Then
  '      DgvList1.SetData(_dt)
  '      Return
  '    End If

  '    Dim dv As New DataView(_dt)
  '    Dim filters As New List(Of String)

  '    For Each col In _definition.Columns.Where(Function(c) c.IsSearchTarget)
  '      If _dt.Columns.Contains(col.Name) AndAlso
  '             _dt.Columns(col.Name).DataType Is GetType(String) Then

  '        filters.Add($"{col.Name} LIKE '%{keyword}%'")
  '      End If
  '    Next

  '    dv.RowFilter = String.Join(" OR ", filters)
  '    DgvList1.DataSource = dv
  '    ' 列設定
  '    SetupColumns()
  '  Catch ex As Exception
  '    Throw New Exception(ex.Message)
  '  End Try
  'End Sub

  Private Sub ExecuteSearch()
    Try
      Dim filters As New List(Of String)

      ' --- コード検索項目の Caption と検索条件 ---
      If TxtCode.Text.Trim() <> "" Then
        Dim code = TxtCode.Text.Trim().Replace("'", "''")

        For Each col In _definition.Columns.Where(Function(c) c.IsSearchTarget AndAlso c.SearchType = "Code")
          If _dt.Columns.Contains(col.Name) Then

            ' Caption 取得（改行など制御文字除去）
            Dim cap = _dt.Columns(col.Name).Caption
            cap = New String(cap.Where(Function(ch) Not Char.IsControl(ch)).ToArray())

            ' 数値列でも検索できるように CONVERT を使用
            filters.Add($"CONVERT([{col.Name}], 'System.String') LIKE '%{code}%'")
          End If
        Next
      End If

      ' --- 名称検索項目の Caption と検索条件 ---
      If TxtName.Text.Trim() <> "" Then
        Dim name = TxtName.Text.Trim().Replace("'", "''")

        For Each col In _definition.Columns.Where(Function(c) c.IsSearchTarget AndAlso c.SearchType = "Name")
          If _dt.Columns.Contains(col.Name) Then

            ' Caption 取得（改行など制御文字除去）
            Dim cap = _dt.Columns(col.Name).Caption
            cap = New String(cap.Where(Function(ch) Not Char.IsControl(ch)).ToArray())

            filters.Add($"[{col.Name}] LIKE '%{name}%'")
          End If
        Next
      End If

      ' --- フィルタなし → 全件表示 ---
      If filters.Count = 0 Then
        DgvList1.SetData(_dt)
        Return
      End If

      ' --- DataView にフィルタ適用 ---
      Dim dv As New DataView(_dt)
      dv.RowFilter = String.Join(" AND ", filters)

      DgvList1.DataSource = dv

      ' 列設定
      SetupColumns()

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub


  Private Sub TxtNumericBase1_Validated(sender As Object, e As EventArgs) Handles TxtCode.Validated, TxtName.Validated
    Try
      ExecuteSearch()

    Catch ex As Exception
      ComWriteErrLog(ex, False)

    End Try
  End Sub

  Private Sub DgvList1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DgvList1.CellEndEdit

    DgvList1.EndEdit()
    DgvList1.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub


  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    Try
      DgvList1.EndEdit()
      DgvList1.CommitEdit(DataGridViewDataErrorContexts.Commit)
      DgvList1.CurrentCell = Nothing

      Dim changed As DataTable = _dt.GetChanges(DataRowState.Modified Or DataRowState.Added)

      If changed Is Nothing OrElse changed.Rows.Count = 0 Then
        ComMessageBox("変更された行はありません。", ENTRY_TITLE, typMsgBox.MSG_NORMAL)
        Return
      End If

      DgvList1.SetData(changed)

      Dim result = ComMessageBox("変更された行だけを表示しています。" & vbCrLf &
                                   "この内容で保存しますか？",
                                   ENTRY_TITLE,
                                    typMsgBox.MSG_NORMAL,
                                   MessageBoxButtons.YesNo)

      If result = DialogResult.No Then
        ' 元の全件に戻す
        ExecuteSearch()
        SetupColumns()

        Return
      End If

      For Each row As DataRow In changed.Rows

        Dim errors = _definition.ValidateRow(row)
        If errors.Any() Then
          ComMessageBox(String.Join(vbCrLf, errors), ENTRY_TITLE, typMsgBox.MSG_ERROR)
          Return
        End If

        _definition.Save(row)
      Next

      ComMessageBox("保存しました。", ENTRY_TITLE, typMsgBox.MSG_NORMAL)

      ' 保存後は全件再読み込み
      _dt = _definition.LoadData()
      DgvList1.TrimDataTable(_dt)
      DgvList1.SetData(_dt)
      SetupColumns()
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try


  End Sub

  Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    Try
      Dim row = GetSelectedRow()
      If row Is Nothing Then Return

      If row.RowState = DataRowState.Added Then
        row.Delete()
        Return
      End If

      Dim result = ComMessageBox(
        "選択された行を削除しますか？" & vbCrLf &
        "（この操作は元に戻せません）",
        DELETE_TITLE,
        typMsgBox.MSG_NORMAL,
        MessageBoxButtons.YesNo
    )

      If result = DialogResult.No Then
        Return
      End If

      ComMessageBox("削除しました。", ENTRY_TITLE, typMsgBox.MSG_NORMAL)

      _definition.Delete(row)
      row.Delete()

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

  Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Try
      Dim newRow = _definition.CreateNewRow(_dt)
      _dt.Rows.Add(newRow)

      ScrollToBottom(DgvList1)



    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

  Private Sub ScrollToBottom(dgv As DataGridView)
    If dgv.Rows.Count = 0 Then Exit Sub

    ' 新規行を除いた最後の行
    Dim last As Integer = dgv.Rows.Count - 1
    If dgv.AllowUserToAddRows Then last -= 1
    If last < 0 Then Exit Sub

    ' 最後の行を表示＆フォーカス
    dgv.FirstDisplayedScrollingRowIndex = last
    If dgv.Rows(last).Cells(0).Visible Then
      dgv.CurrentCell = dgv.Rows(last).Cells(0)
    Else
      dgv.CurrentCell = dgv.Rows(last).Cells(1)
    End If
  End Sub


  Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
    Try
      _definition.Import()

      ' 再読み込み
      _dt = _definition.LoadData()
      _dt.AcceptChanges()
      DgvList1.SetData(_dt)
      ' 列設定
      SetupColumns()
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

  Private Sub FormComMasterMente_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    DgvList1.EndEdit()
    DgvList1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    DgvList1.CurrentCell = Nothing

    Dim changed As DataTable = _dt.GetChanges(DataRowState.Modified Or DataRowState.Added)
    If changed IsNot Nothing Then
      If changed.Rows.Count <> 0 Then
        DgvList1.SetData(changed)
        ' 列設定
        SetupColumns()

        Dim result = ComMessageBox("保存されていない行があります。" & vbCrLf &
                                   "本当に終了しますか？",
                                   ENTRY_TITLE,
                                    typMsgBox.MSG_NORMAL,
                                   MessageBoxButtons.YesNo)

        If result = DialogResult.No Then
          e.Cancel = True
        End If
        Return
      End If

    End If

  End Sub

  Private Function GetSelectedRow() As DataRow
    Dim drv = TryCast(DgvList1.CurrentRow.DataBoundItem, DataRowView)

    Try
      If DgvList1.CurrentRow Is Nothing Then Return Nothing
      If drv Is Nothing Then Return Nothing
      Return drv.Row

    Catch ex As Exception
      ComWriteErrLog(ex, False)
      Return drv.Row
    End Try
  End Function

  '===============================
  ' InitializeComponent（UI定義）
  '===============================
  Protected Overrides Sub InitializeComponent()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.btnSave = New T.R.ZCommonCtrl.BtnSave()
    Me.btnDelete = New T.R.ZCommonCtrl.BtnDel()
    Me.btnAdd = New T.R.ZCommonCtrl.BtnAdd()
    Me.btnImport = New T.R.ZCommonCtrl.BtnMstInput()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    Me.TxtCode = New T.R.ZCommonCtrl.TxtNumericBase()
    Me.TxtName = New T.R.ZCommonCtrl.TxtBase()
    Me.LblBase3 = New T.R.ZCommonCtrl.LblBase()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.CustomAutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.DgvList1.CustomAutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
    Me.DgvList1.GridFontSize = 20
    Me.DgvList1.HeaderFontSize = 20
    Me.DgvList1.Location = New System.Drawing.Point(13, 174)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1659, 675)
    Me.DgvList1.TabIndex = 4
    Me.DgvList1.TargetColumnName = ""
    Me.DgvList1.UseCustomSize = False
    '
    'btnSave
    '
    Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.btnSave.FlatAppearance.BorderSize = 0
    Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnSave.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.btnSave.Location = New System.Drawing.Point(1026, 99)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(320, 60)
    Me.btnSave.TabIndex = 5
    Me.btnSave.Text = "保存(F9)"
    Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnSave.UseVisualStyleBackColor = False
    '
    'btnDelete
    '
    Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
    Me.btnDelete.FlatAppearance.BorderSize = 0
    Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnDelete.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.btnDelete.ForeColor = System.Drawing.Color.Black
    Me.btnDelete.Location = New System.Drawing.Point(1352, 99)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.Size = New System.Drawing.Size(320, 60)
    Me.btnDelete.TabIndex = 6
    Me.btnDelete.Text = "削除(F8)"
    Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnDelete.UseVisualStyleBackColor = False
    '
    'btnAdd
    '
    Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
    Me.btnAdd.FlatAppearance.BorderSize = 0
    Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnAdd.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.btnAdd.ForeColor = System.Drawing.Color.Black
    Me.btnAdd.Location = New System.Drawing.Point(700, 99)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(320, 60)
    Me.btnAdd.TabIndex = 7
    Me.btnAdd.Text = "追加(F4)"
    Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnAdd.UseVisualStyleBackColor = False
    '
    'btnImport
    '
    Me.btnImport.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.btnImport.FlatAppearance.BorderSize = 0
    Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnImport.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.btnImport.ForeColor = System.Drawing.Color.Black
    Me.btnImport.Location = New System.Drawing.Point(700, 99)
    Me.btnImport.Name = "btnImport"
    Me.btnImport.Size = New System.Drawing.Size(320, 60)
    Me.btnImport.TabIndex = 8
    Me.btnImport.Text = "取込(F1)"
    Me.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnImport.UseVisualStyleBackColor = False
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.Font = New System.Drawing.Font("メイリオ", 16.0!, System.Drawing.FontStyle.Bold)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1352, 12)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 22
    Me.BtnEnd_L1.Text = "閉じる(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(161, 48)
    Me.LblBase1.TabIndex = 23
    Me.LblBase1.Text = "タイトル"
    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(344, 111)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(79, 33)
    Me.LblBase2.TabIndex = 24
    Me.LblBase2.Text = "名称"
    '
    'TxtCode
    '
    Me.TxtCode.DisableAllSelect = False
    Me.TxtCode.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.TxtCode.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.TxtCode.Location = New System.Drawing.Point(106, 111)
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(201, 39)
    Me.TxtCode.TabIndex = 25
    Me.TxtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtName
    '
    Me.TxtName.DisableAllSelect = False
    Me.TxtName.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.TxtName.ImeMode = System.Windows.Forms.ImeMode.[On]
    Me.TxtName.Location = New System.Drawing.Point(429, 111)
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(201, 39)
    Me.TxtName.TabIndex = 25
    Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
    '
    'LblBase3
    '
    Me.LblBase3.AutoSize = True
    Me.LblBase3.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase3.Location = New System.Drawing.Point(14, 111)
    Me.LblBase3.Name = "LblBase3"
    Me.LblBase3.Size = New System.Drawing.Size(86, 33)
    Me.LblBase3.TabIndex = 26
    Me.LblBase3.Text = "コード"
    '
    'FormComMasterMente
    '
    Me.ClientSize = New System.Drawing.Size(1684, 861)
    Me.Controls.Add(Me.LblBase3)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.LblBase2)
    Me.Controls.Add(Me.LblBase1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.btnImport)
    Me.Controls.Add(Me.btnAdd)
    Me.Controls.Add(Me.btnDelete)
    Me.Controls.Add(Me.btnSave)
    Me.Controls.Add(Me.DgvList1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FormComMasterMente"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub


End Class
