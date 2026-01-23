Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTanemakiSendCommunication
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
  Protected Overrides Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTanemakiSendCommunication))
    Me.BtnSendHandy1 = New T.R.ZCommonCtrl.BtnSendHandy()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.CmbDateNohinBi1 = New T.R.ZCommonCtrl.CmbDateNohinBiZumi()
    Me.LblBase2 = New T.R.ZCommonCtrl.LblBase()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkReizoJouon = New System.Windows.Forms.CheckBox()
    Me.ChkReito = New System.Windows.Forms.CheckBox()
    Me.ChkJouon = New System.Windows.Forms.CheckBox()
    Me.ChkReizo = New System.Windows.Forms.CheckBox()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnSendHandy1
    '
    Me.BtnSendHandy1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnSendHandy1.FlatAppearance.BorderSize = 0
    Me.BtnSendHandy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnSendHandy1.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnSendHandy1.ForeColor = System.Drawing.Color.Black
    Me.BtnSendHandy1.Location = New System.Drawing.Point(1052, 80)
    Me.BtnSendHandy1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
    Me.BtnSendHandy1.Name = "BtnSendHandy1"
    Me.BtnSendHandy1.Size = New System.Drawing.Size(320, 60)
    Me.BtnSendHandy1.TabIndex = 24
    Me.BtnSendHandy1.TargetCancelParentClick = False
    Me.BtnSendHandy1.TargetCommunicationDate = CType(resources.GetObject("BtnSendHandy1.TargetCommunicationDate"), System.Collections.Generic.Dictionary(Of String, String))
    Me.BtnSendHandy1.TargetFileName = Nothing
    Me.BtnSendHandy1.TargetLenClumn = Nothing
    Me.BtnSendHandy1.TargetTableName = Nothing
    Me.BtnSendHandy1.TargetUpdColumn = Nothing
    Me.BtnSendHandy1.TargetUpdStatus = Nothing
    Me.BtnSendHandy1.TargetWhere = Nothing
    Me.BtnSendHandy1.Text = "F5：送信"
    Me.BtnSendHandy1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnSendHandy1.UseVisualStyleBackColor = False
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 146)
    Me.DgvList1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 23
    Me.DgvList1.TargetColumnName = ""
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(586, 48)
    Me.LblBase1.TabIndex = 22
    Me.LblBase1.Text = "ハンディ種まき作業データ送信"
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 12)
    Me.BtnEnd_L1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 21
    Me.BtnEnd_L1.Text = "終了(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'CmbDateNohinBi1
    '
    Me.CmbDateNohinBi1.AvailableBlank = False
    Me.CmbDateNohinBi1.DisplayMember = "ItemCode"
    Me.CmbDateNohinBi1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.CmbDateNohinBi1.FormattingEnabled = True
    Me.CmbDateNohinBi1.Location = New System.Drawing.Point(157, 93)
    Me.CmbDateNohinBi1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
    Me.CmbDateNohinBi1.Name = "CmbDateNohinBi1"
    Me.CmbDateNohinBi1.Size = New System.Drawing.Size(226, 41)
    Me.CmbDateNohinBi1.TabIndex = 20
    Me.CmbDateNohinBi1.ValueMember = "ItemCode"
    '
    'LblBase2
    '
    Me.LblBase2.AutoSize = True
    Me.LblBase2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.LblBase2.Location = New System.Drawing.Point(12, 96)
    Me.LblBase2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
    Me.LblBase2.Name = "LblBase2"
    Me.LblBase2.Size = New System.Drawing.Size(111, 33)
    Me.LblBase2.TabIndex = 19
    Me.LblBase2.Text = "納品日"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkReizoJouon)
    Me.GroupBox1.Controls.Add(Me.ChkReito)
    Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
    Me.GroupBox1.Location = New System.Drawing.Point(606, 55)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(319, 85)
    Me.GroupBox1.TabIndex = 26
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "温度帯"
    '
    'ChkReizoJouon
    '
    Me.ChkReizoJouon.AutoSize = True
    Me.ChkReizoJouon.Location = New System.Drawing.Point(110, 38)
    Me.ChkReizoJouon.Name = "ChkReizoJouon"
    Me.ChkReizoJouon.Size = New System.Drawing.Size(178, 37)
    Me.ChkReizoJouon.TabIndex = 2
    Me.ChkReizoJouon.Text = "冷蔵・常温"
    Me.ChkReizoJouon.UseVisualStyleBackColor = True
    '
    'ChkReito
    '
    Me.ChkReito.AutoSize = True
    Me.ChkReito.Location = New System.Drawing.Point(6, 38)
    Me.ChkReito.Name = "ChkReito"
    Me.ChkReito.Size = New System.Drawing.Size(98, 37)
    Me.ChkReito.TabIndex = 1
    Me.ChkReito.Text = "冷凍"
    Me.ChkReito.UseVisualStyleBackColor = True
    '
    'ChkJouon
    '
    Me.ChkJouon.AutoSize = True
    Me.ChkJouon.Location = New System.Drawing.Point(821, 19)
    Me.ChkJouon.Name = "ChkJouon"
    Me.ChkJouon.Size = New System.Drawing.Size(48, 16)
    Me.ChkJouon.TabIndex = 2
    Me.ChkJouon.Text = "常温"
    Me.ChkJouon.UseVisualStyleBackColor = True
    Me.ChkJouon.Visible = False
    '
    'ChkReizo
    '
    Me.ChkReizo.AutoSize = True
    Me.ChkReizo.Location = New System.Drawing.Point(717, 19)
    Me.ChkReizo.Name = "ChkReizo"
    Me.ChkReizo.Size = New System.Drawing.Size(48, 16)
    Me.ChkReizo.TabIndex = 0
    Me.ChkReizo.Text = "冷蔵"
    Me.ChkReizo.UseVisualStyleBackColor = True
    Me.ChkReizo.Visible = False
    '
    'frmTanemakiSendCommunication
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.ChkJouon)
    Me.Controls.Add(Me.ChkReizo)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.BtnSendHandy1)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.LblBase1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.CmbDateNohinBi1)
    Me.Controls.Add(Me.LblBase2)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
    Me.MaximizeBox = False
    Me.Name = "frmTanemakiSendCommunication"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnSendHandy1 As BtnSendHandy
  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents LblBase1 As LblBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents CmbDateNohinBi1 As CmbDateNohinBiZumi
  Friend WithEvents LblBase2 As LblBase
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents ChkJouon As CheckBox
  Friend WithEvents ChkReito As CheckBox
  Friend WithEvents ChkReizo As CheckBox
  Friend WithEvents ChkReizoJouon As CheckBox
End Class
