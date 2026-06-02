Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTanaoroshiPrint
  Inherits FormBase

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()> _
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTanaoroshiPrint))
    Me.BtnDataListChk = New Button
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.CmbDateSagyoBi1 = New T.R.ZCommonCtrl.CmbDateTanaoroshiBiZumi()
    Me.BtnOutput1 = New T.R.ZCommonCtrl.BtnOutput()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.Font = New System.Drawing.Font("メイリオ", 16.0!, System.Drawing.FontStyle.Bold)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 9)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 12
    Me.BtnEnd_L1.Text = "閉じる(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 148)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 11
    Me.DgvList1.TargetColumnName = ""
    '
    'CmbDateSagyoBi1
    '
    Me.CmbDateSagyoBi1.AvailableBlank = False
    Me.CmbDateSagyoBi1.DisplayMember = "ItemCode"
    Me.CmbDateSagyoBi1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.CmbDateSagyoBi1.FormattingEnabled = True
    Me.CmbDateSagyoBi1.Location = New System.Drawing.Point(157, 90)
    Me.CmbDateSagyoBi1.Name = "CmbDateSagyoBi1"
    Me.CmbDateSagyoBi1.Size = New System.Drawing.Size(226, 41)
    Me.CmbDateSagyoBi1.TabIndex = 10
    Me.CmbDateSagyoBi1.ValueMember = "ItemCode"
    '
    'BtnDataListChk
    '
    Me.BtnDataListChk.Location = New System.Drawing.Point(385, 90)
    Me.BtnDataListChk.Size = New System.Drawing.Size(100, 41)
    Me.BtnDataListChk.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.BtnDataListChk.BackColor = Color.SteelBlue
    Me.BtnDataListChk.Text = "設定"

    '
    'BtnOutput1
    '
    Me.BtnOutput1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnOutput1.FlatAppearance.BorderSize = 0
    Me.BtnOutput1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnOutput1.Font = New System.Drawing.Font("メイリオ", 16.0!, System.Drawing.FontStyle.Bold)
    Me.BtnOutput1.ForeColor = System.Drawing.Color.Black
    Me.BtnOutput1.Location = New System.Drawing.Point(1052, 82)
    Me.BtnOutput1.Name = "BtnOutput1"
    Me.BtnOutput1.Size = New System.Drawing.Size(320, 60)
    Me.BtnOutput1.TabIndex = 9
    Me.BtnOutput1.TargetDataGridView = Nothing
    Me.BtnOutput1.TargetFormatFile = Nothing
    Me.BtnOutput1.TargetKbn = 1
    Me.BtnOutput1.Text = "報告書出力(F5)"
    Me.BtnOutput1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnOutput1.UseVisualStyleBackColor = False
    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(12, 93)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(111, 33)
    Me.LblBase2.TabIndex = 8
    Me.LblBase2.Text = "棚卸日"
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 21)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(356, 48)
    Me.LblBase1.TabIndex = 7
    Me.LblBase1.Text = "棚卸報告書出力"
    '
    'frmTanaoroshiPrint
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
    Me.Name = "frmTanaoroshiPrint"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnDataListChk As Button
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents CmbDateSagyoBi1 As CmbDateTanaoroshiBiZumi
  Friend WithEvents BtnOutput1 As BtnOutput
  Friend WithEvents LblBase2 As LblBase
  Friend WithEvents LblBase1 As LblBase
End Class
