Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNyukaSendCommunication
  Inherits FormCommunication

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
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNyukaSendCommunication))
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.CmbDateSagyoBi1 = New T.R.ZCommonCtrl.CmbDateSagyoBi()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.BtnSendHandy1 = New T.R.ZCommonCtrl.BtnSendHandy()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.Red
    Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.Black
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 12)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 9
    Me.BtnEnd_L1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'CmbDateSagyoBi1
    '
    Me.CmbDateSagyoBi1.AvailableBlank = False
    Me.CmbDateSagyoBi1.DisplayMember = "ItemCode"
    Me.CmbDateSagyoBi1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.CmbDateSagyoBi1.FormattingEnabled = True
    Me.CmbDateSagyoBi1.Location = New System.Drawing.Point(157, 93)
    Me.CmbDateSagyoBi1.Name = "CmbDateSagyoBi1"
    Me.CmbDateSagyoBi1.Size = New System.Drawing.Size(226, 41)
    Me.CmbDateSagyoBi1.TabIndex = 8
    Me.CmbDateSagyoBi1.ValueMember = "ItemCode"
    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(12, 96)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(111, 33)
    Me.LblBase2.TabIndex = 7
    Me.LblBase2.Text = "作業日"
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(562, 48)
    Me.LblBase1.TabIndex = 10
    Me.LblBase1.Text = "ハンディ入荷検品データ送信"
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 146)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 11
    '
    'BtnSendHandy1
    '
    Me.BtnSendHandy1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnSendHandy1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnSendHandy1.ForeColor = System.Drawing.Color.Black
    Me.BtnSendHandy1.Location = New System.Drawing.Point(1052, 80)
    Me.BtnSendHandy1.Name = "BtnSendHandy1"
    Me.BtnSendHandy1.Size = New System.Drawing.Size(320, 60)
    Me.BtnSendHandy1.TabIndex = 12
    Me.BtnSendHandy1.TargetFileName = Nothing
    Me.BtnSendHandy1.Text = "BtnSendHandy1"
    Me.BtnSendHandy1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnSendHandy1.UseVisualStyleBackColor = False
    '
    'frmNyukaSendCommunication
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.BtnSendHandy1)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.LblBase1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.CmbDateSagyoBi1)
    Me.Controls.Add(Me.LblBase2)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmNyukaSendCommunication"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents CmbDateSagyoBi1 As CmbDateSagyoBi
  Friend WithEvents LblBase2 As LblBase
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents DgvList1 As DgvList
    Friend WithEvents BtnSendHandy1 As BtnSendHandy
End Class
