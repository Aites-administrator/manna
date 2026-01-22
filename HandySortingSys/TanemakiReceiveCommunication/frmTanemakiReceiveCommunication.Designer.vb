Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTanemakiReceiveCommunication
  Inherits FormRecieveCommunication

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTanemakiReceiveCommunication))
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    Me.BtnRecieveHandy1 = New T.R.ZCommonCtrl.BtnRecieveHandy()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(20, 146)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1352, 703)
    Me.DgvList1.TabIndex = 22
    '
    'BtnRecieveHandy1
    '
    Me.BtnRecieveHandy1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnRecieveHandy1.FlatAppearance.BorderSize = 0
    Me.BtnRecieveHandy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnRecieveHandy1.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnRecieveHandy1.ForeColor = System.Drawing.Color.Black
    Me.BtnRecieveHandy1.Location = New System.Drawing.Point(1052, 80)
    Me.BtnRecieveHandy1.Name = "BtnRecieveHandy1"
    Me.BtnRecieveHandy1.Size = New System.Drawing.Size(320, 60)
    Me.BtnRecieveHandy1.TabIndex = 21
    Me.BtnRecieveHandy1.TargetCommunicationDate = CType(resources.GetObject("BtnRecieveHandy1.TargetCommunicationDate"), System.Collections.Generic.Dictionary(Of String, String))
    Me.BtnRecieveHandy1.TargetDataGridView = Nothing
    Me.BtnRecieveHandy1.TargetFileName = Nothing
    Me.BtnRecieveHandy1.TargetItemUpdColumn = CType(resources.GetObject("BtnRecieveHandy1.TargetItemUpdColumn"), System.Collections.Generic.List(Of String))
    Me.BtnRecieveHandy1.TargetLenClumn = CType(resources.GetObject("BtnRecieveHandy1.TargetLenClumn"), System.Collections.Generic.List(Of System.Tuple(Of String, Integer)))
    Me.BtnRecieveHandy1.TargetMappingName = Nothing
    Me.BtnRecieveHandy1.TargetOutputFileName = Nothing
    Me.BtnRecieveHandy1.TargetTableName = Nothing
    Me.BtnRecieveHandy1.TargetUpdColumn = CType(resources.GetObject("BtnRecieveHandy1.TargetUpdColumn"), System.Collections.Generic.List(Of String))
    Me.BtnRecieveHandy1.TargetUpdStatus = Nothing
    Me.BtnRecieveHandy1.TargetWhere = CType(resources.GetObject("BtnRecieveHandy1.TargetWhere"), System.Collections.Generic.List(Of String))
    Me.BtnRecieveHandy1.Text = "F6:受信"
    Me.BtnRecieveHandy1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnRecieveHandy1.UseVisualStyleBackColor = False
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
    Me.BtnEnd_L1.TabIndex = 20
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
    Me.LblBase1.Size = New System.Drawing.Size(490, 48)
    Me.LblBase1.TabIndex = 19
    Me.LblBase1.Text = "ハンディ種まきデータ受信"
    '
    'frmTanemakiReceiveCommunication
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.BtnRecieveHandy1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.LblBase1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmTanemakiReceiveCommunication"
    Me.Text = "Form1"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents DgvList1 As DgvList
  Friend WithEvents BtnRecieveHandy1 As BtnRecieveHandy
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents LblBase1 As LblBase
End Class
