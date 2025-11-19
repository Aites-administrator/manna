<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMasterMaintenance
  Inherits System.Windows.Forms.Form

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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.BtnMenuBase8 = New T.R.ZCommonCtrl.BtnMenuBase()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnMenuBase5 = New T.R.ZCommonCtrl.BtnMenuBase()
    Me.BtnMenuBase1 = New T.R.ZCommonCtrl.BtnMenuBase()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.BtnMenuBase8)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.BtnMenuBase5)
    Me.Panel1.Controls.Add(Me.BtnMenuBase1)
    Me.Panel1.Location = New System.Drawing.Point(16, 12)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(320, 429)
    Me.Panel1.TabIndex = 2
    '
    'BtnMenuBase8
    '
    Me.BtnMenuBase8.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.BtnMenuBase8.Location = New System.Drawing.Point(17, 325)
    Me.BtnMenuBase8.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
    Me.BtnMenuBase8.Name = "BtnMenuBase8"
    Me.BtnMenuBase8.Size = New System.Drawing.Size(290, 60)
    Me.BtnMenuBase8.TabIndex = 5
    Me.BtnMenuBase8.Text = "棚番マスタ"
    Me.BtnMenuBase8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMenuBase8.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.Label2.Location = New System.Drawing.Point(30, 11)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(258, 33)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "マスターメンテナンス"
    '
    'BtnMenuBase5
    '
    Me.BtnMenuBase5.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.BtnMenuBase5.Location = New System.Drawing.Point(17, 195)
    Me.BtnMenuBase5.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
    Me.BtnMenuBase5.Name = "BtnMenuBase5"
    Me.BtnMenuBase5.Size = New System.Drawing.Size(290, 60)
    Me.BtnMenuBase5.TabIndex = 2
    Me.BtnMenuBase5.Text = "担当マスタ"
    Me.BtnMenuBase5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMenuBase5.UseVisualStyleBackColor = True
    '
    'BtnMenuBase1
    '
    Me.BtnMenuBase1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.BtnMenuBase1.Location = New System.Drawing.Point(17, 72)
    Me.BtnMenuBase1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
    Me.BtnMenuBase1.Name = "BtnMenuBase1"
    Me.BtnMenuBase1.Size = New System.Drawing.Size(290, 60)
    Me.BtnMenuBase1.TabIndex = 1
    Me.BtnMenuBase1.Text = "コースマスター"
    Me.BtnMenuBase1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMenuBase1.UseVisualStyleBackColor = True
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.Red
    Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.Black
    Me.BtnEnd_L1.Location = New System.Drawing.Point(16, 447)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 3
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'frmMasterMaintenance
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(353, 515)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
    Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
    Me.Name = "frmMasterMaintenance"
    Me.Text = "Form1"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents Panel1 As Panel
  Friend WithEvents BtnMenuBase8 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents Label2 As Label
  Friend WithEvents BtnMenuBase5 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents BtnMenuBase1 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents BtnEnd_L1 As T.R.ZCommonCtrl.BtnEnd_L
End Class
