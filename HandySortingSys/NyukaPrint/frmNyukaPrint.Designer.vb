Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass.clsCommonFnc

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNyukaPrint
  Inherits FormBase

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Windows フォーム デザイナーで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
  'Windows フォーム デザイナーを使用して変更できます。  
  'コード エディターを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()>
  Protected Overloads Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNyukaPrint))
    Me.BtnDataListChk = New Button
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    Me.BtnOutput1 = New T.R.ZCommonCtrl.BtnOutput()
    Me.CmbDateSagyoBi1 = New T.R.ZCommonCtrl.CmbDateSagyoBiZumi()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(452, 48)
    Me.LblBase1.TabIndex = 1
    Me.LblBase1.Text = "入荷検品報告書出力"
    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(12, 91)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(111, 33)
    Me.LblBase2.TabIndex = 2
    Me.LblBase2.Text = "入荷日"
    '
    'BtnOutput1
    '
    Me.BtnOutput1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnOutput1.ForeColor = System.Drawing.Color.Black
    Me.BtnOutput1.Location = New System.Drawing.Point(1052, 80)
    Me.BtnOutput1.Name = "BtnOutput1"
    Me.BtnOutput1.Size = New System.Drawing.Size(320, 60)
    Me.BtnOutput1.TabIndex = 3
    Me.BtnOutput1.TargetDataGridView = Nothing
    Me.BtnOutput1.TargetFormatFile = Nothing
    Me.BtnOutput1.TargetKbn = 0
    Me.BtnOutput1.Text = "報告書出力(F5)"
    Me.BtnOutput1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnOutput1.UseVisualStyleBackColor = False
    '
    'CmbDateSagyoBi1
    '
    Me.CmbDateSagyoBi1.AvailableBlank = False
    Me.CmbDateSagyoBi1.DisplayMember = "ItemCode"
    Me.CmbDateSagyoBi1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.CmbDateSagyoBi1.FormattingEnabled = True
    Me.CmbDateSagyoBi1.Location = New System.Drawing.Point(157, 88)
    Me.CmbDateSagyoBi1.Name = "CmbDateSagyoBi1"
    Me.CmbDateSagyoBi1.Size = New System.Drawing.Size(226, 41)
    Me.CmbDateSagyoBi1.TabIndex = 4
    Me.CmbDateSagyoBi1.ValueMember = "ItemCode"
    '
    'BtnDataListChk
    '
    Me.BtnDataListChk.Location = New System.Drawing.Point(385, 88)
    Me.BtnDataListChk.Size = New System.Drawing.Size(100, 41)
    Me.BtnDataListChk.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.BtnDataListChk.BackColor = Color.SteelBlue
    Me.BtnDataListChk.Text = "設定"

    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 146)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 5
    Me.DgvList1.TargetColumnName = ""
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 7)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 6
    Me.BtnEnd_L1.Text = "閉じる(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'frmNyukaPrint
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.BtnDataListChk)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.CmbDateSagyoBi1)
    Me.Controls.Add(Me.BtnOutput1)
    Me.Controls.Add(Me.LblBase2)
    Me.Controls.Add(Me.LblBase1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmNyukaPrint"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnDataListChk As Button
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents LblBase2 As LblBase
  Friend WithEvents BtnOutput1 As BtnOutput
  Friend WithEvents CmbDateSagyoBi1 As CmbDateSagyoBiZumi
  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
End Class
