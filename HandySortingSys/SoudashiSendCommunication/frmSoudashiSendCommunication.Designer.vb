Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSoudashiSendCommunication
  Inherits FormSendCommunication

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSoudashiSendCommunication))
    Me.BtnDataListChk = New Button
    Me.BtnSendHandy1 = New T.R.ZCommonCtrl.BtnSendHandy()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.CmbDateNohinBi1 = New T.R.ZCommonCtrl.CmbDateNohinBi()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnSendHandy1
    '
    Me.BtnSendHandy1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnSendHandy1.FlatAppearance.BorderSize = 0
    Me.BtnSendHandy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnSendHandy1.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnSendHandy1.ForeColor = System.Drawing.Color.Black
    Me.BtnSendHandy1.Location = New System.Drawing.Point(1131, 731)
    Me.BtnSendHandy1.Name = "BtnSendHandy1"
    Me.BtnSendHandy1.Size = New System.Drawing.Size(320, 60)
    Me.BtnSendHandy1.TabIndex = 18
    Me.BtnSendHandy1.TargetCancelParentClick = False
    Me.BtnSendHandy1.TargetCommunicationDate = CType(resources.GetObject("BtnSendHandy1.TargetCommunicationDate"), System.Collections.Generic.Dictionary(Of String, String))
    Me.BtnSendHandy1.TargetFileName = Nothing
    Me.BtnSendHandy1.TargetLenClumn = Nothing
    Me.BtnSendHandy1.TargetTableName = Nothing
    Me.BtnSendHandy1.TargetUpdColumn = Nothing
    Me.BtnSendHandy1.TargetUpdStatus = Nothing
    Me.BtnSendHandy1.TargetWhere = Nothing
    Me.BtnSendHandy1.Text = "送信(F5)"
    Me.BtnSendHandy1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnSendHandy1.UseVisualStyleBackColor = False
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 146)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 17
    Me.DgvList1.TargetColumnName = ""
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(597, 48)
    Me.LblBase1.TabIndex = 16
    Me.LblBase1.Text = "ハンディ総出し作業データ送信"
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.Font = New System.Drawing.Font("メイリオ", 16.0!, System.Drawing.FontStyle.Bold)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1131, 794)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 15
    Me.BtnEnd_L1.Text = "閉じる(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'CmbDateNohinBi1
    '
    Me.CmbDateNohinBi1.AvailableBlank = False
    'Me.CmbDateNohinBi1.DisplayMember = "ItemCode"
    Me.CmbDateNohinBi1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.CmbDateNohinBi1.FormattingEnabled = True
    Me.CmbDateNohinBi1.Location = New System.Drawing.Point(157, 93)
    Me.CmbDateNohinBi1.Name = "CmbDateNohinBi1"
    Me.CmbDateNohinBi1.Size = New System.Drawing.Size(256, 41)
    Me.CmbDateNohinBi1.TabIndex = 14
    'Me.CmbDateNohinBi1.ValueMember = "ItemCode"
    '
    'BtnDataListChk
    '
    Me.BtnDataListChk.Location = New System.Drawing.Point(415, 93)
    Me.BtnDataListChk.Size = New System.Drawing.Size(100, 41)
    Me.BtnDataListChk.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.BtnDataListChk.BackColor = Color.SteelBlue
    Me.BtnDataListChk.Text = "設定"

    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(12, 96)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(111, 33)
    Me.LblBase2.TabIndex = 13
    Me.LblBase2.Text = "納品日"
    '
    'frmSoudashiSendCommunication
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.BtnDataListChk)
    Me.Controls.Add(Me.BtnSendHandy1)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.LblBase1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.CmbDateNohinBi1)
    Me.Controls.Add(Me.LblBase2)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmSoudashiSendCommunication"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnDataListChk As Button
  Friend WithEvents BtnSendHandy1 As BtnSendHandy
  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents CmbDateNohinBi1 As CmbDateNohinBi
  Friend WithEvents LblBase2 As LblBase
End Class
