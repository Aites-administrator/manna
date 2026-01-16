Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc

Public Class FormComMasterMente
  Inherits FormBase

  Private Const ENTRY_TITLE As String = "登録"
  Private Const UPDATE_TITLE As String = "更新"
  Private Const DELETE_TITLE As String = "削除"
  Private ReadOnly _definition As IMasterMentenance
  Private _dt As DataTable

  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents btnSave As Button
  Friend WithEvents btnDelete As Button
  Friend WithEvents btnAdd As Button
  Friend WithEvents btnImport As Button
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L

  Public Sub New(definition As IMasterMentenance)
    InitializeComponent()
    _definition = definition
  End Sub

  Private Sub FormComMasterMente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Me.LblBase1.Text = _definition.Title
    ' データ取得
    _dt = _definition.LoadData()

    _dt.AcceptChanges()

    DgvList1.SetData(_dt)

    ' 列設定
    SetupColumns()

    btnAdd.Enabled = _definition.AllowAdd
    btnImport.Visible = _definition.AllowImport
  End Sub

  Private Sub SetupColumns()
    For Each col In _definition.Columns
      Dim dgvCol = DgvList1.Columns(col.Name)

      If dgvCol IsNot Nothing Then
        dgvCol.HeaderText = col.DisplayName
        dgvCol.ReadOnly = Not col.IsEditable
      End If
    Next
  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

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
      DgvList1.SetData(_dt)
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
    _dt.AcceptChanges()
    DgvList1.SetData(_dt)
    SetupColumns()
  End Sub

  Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    Dim row = GetSelectedRow()
    If row Is Nothing Then Return

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

  End Sub

  Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Dim newRow = _definition.CreateNewRow(_dt)
    _dt.Rows.Add(newRow)
  End Sub

  Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
    _definition.Import()

    ' 再読み込み
    _dt = _definition.LoadData()
    _dt.AcceptChanges()
    DgvList1.SetData(_dt)
  End Sub

  Private Function GetSelectedRow() As DataRow
    If DgvList1.CurrentRow Is Nothing Then Return Nothing
    Dim drv = TryCast(DgvList1.CurrentRow.DataBoundItem, DataRowView)
    If drv Is Nothing Then Return Nothing
    Return drv.Row
  End Function

  '===============================
  ' InitializeComponent（UI定義）
  '===============================
  Protected Overrides Sub InitializeComponent()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.btnSave = New System.Windows.Forms.Button()
    Me.btnDelete = New System.Windows.Forms.Button()
    Me.btnAdd = New System.Windows.Forms.Button()
    Me.btnImport = New System.Windows.Forms.Button()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(13, 174)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1359, 675)
    Me.DgvList1.TabIndex = 4
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(1048, 109)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(159, 50)
    Me.btnSave.TabIndex = 5
    Me.btnSave.Text = "保存"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'btnDelete
    '
    Me.btnDelete.Location = New System.Drawing.Point(1213, 109)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.Size = New System.Drawing.Size(159, 50)
    Me.btnDelete.TabIndex = 6
    Me.btnDelete.Text = "削除"
    Me.btnDelete.UseVisualStyleBackColor = True
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(883, 109)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(159, 50)
    Me.btnAdd.TabIndex = 7
    Me.btnAdd.Text = "追加"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'btnImport
    '
    Me.btnImport.Location = New System.Drawing.Point(718, 109)
    Me.btnImport.Name = "btnImport"
    Me.btnImport.Size = New System.Drawing.Size(159, 50)
    Me.btnImport.TabIndex = 8
    Me.btnImport.Text = "取込"
    Me.btnImport.UseVisualStyleBackColor = True
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 12)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 22
    Me.BtnEnd_L1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
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
    'FormComMasterMente
    '
    Me.ClientSize = New System.Drawing.Size(1384, 861)
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
