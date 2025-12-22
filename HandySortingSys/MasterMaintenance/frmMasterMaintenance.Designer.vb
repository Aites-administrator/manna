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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
        Me.LblProcDateTime6 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.LblProcDateTime5 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.LblProcDateTime4 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.BtnMenuBase4 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.BtnMenuBase2 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.BtnMenuBase3 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
        Me.LblProcDateTime3 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.LblProcDateTime2 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.LblProcDateTime1 = New T.R.ZCommonCtrl.LblProcDateTime()
        Me.BtnMenuBase8 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.BtnMenuBase5 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.BtnMenuBase1 = New T.R.ZCommonCtrl.BtnMenuBase()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblProcDateTime5)
        Me.Panel1.Controls.Add(Me.LblProcDateTime6)
        Me.Panel1.Controls.Add(Me.LblProcDateTime4)
        Me.Panel1.Controls.Add(Me.BtnMenuBase8)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnMenuBase5)
        Me.Panel1.Controls.Add(Me.BtnMenuBase1)
        Me.Panel1.Location = New System.Drawing.Point(338, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 342)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(258, 33)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "マスターメンテナンス"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblProcDateTime3)
        Me.Panel2.Controls.Add(Me.LblProcDateTime1)
        Me.Panel2.Controls.Add(Me.BtnMenuBase4)
        Me.Panel2.Controls.Add(Me.LblProcDateTime2)
        Me.Panel2.Controls.Add(Me.BtnMenuBase2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.BtnMenuBase3)
        Me.Panel2.Location = New System.Drawing.Point(12, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(320, 342)
        Me.Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 33)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "データ取込"
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
        Me.LblBase1.Location = New System.Drawing.Point(4, 20)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(304, 48)
        Me.LblBase1.TabIndex = 7
        Me.LblBase1.Text = "管理者メニュー"
        '
        'LblProcDateTime6
        '
        Me.LblProcDateTime6.AutoSize = True
        Me.LblProcDateTime6.Location = New System.Drawing.Point(88, 300)
        Me.LblProcDateTime6.Name = "LblProcDateTime6"
        Me.LblProcDateTime6.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime6.TabIndex = 15
        Me.LblProcDateTime6.Text = "2025/12/12 12:12:12"
        '
        'LblProcDateTime5
        '
        Me.LblProcDateTime5.AutoSize = True
        Me.LblProcDateTime5.Location = New System.Drawing.Point(88, 204)
        Me.LblProcDateTime5.Name = "LblProcDateTime5"
        Me.LblProcDateTime5.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime5.TabIndex = 14
        Me.LblProcDateTime5.Text = "2025/12/12 12:12:12"
        '
        'LblProcDateTime4
        '
        Me.LblProcDateTime4.AutoSize = True
        Me.LblProcDateTime4.Location = New System.Drawing.Point(88, 108)
        Me.LblProcDateTime4.Name = "LblProcDateTime4"
        Me.LblProcDateTime4.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime4.TabIndex = 13
        Me.LblProcDateTime4.Text = "2025/12/12 12:12:12"
        '
        'BtnMenuBase4
        '
        Me.BtnMenuBase4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnMenuBase4.Location = New System.Drawing.Point(17, 42)
        Me.BtnMenuBase4.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnMenuBase4.Name = "BtnMenuBase4"
        Me.BtnMenuBase4.Size = New System.Drawing.Size(290, 60)
        Me.BtnMenuBase4.TabIndex = 6
        Me.BtnMenuBase4.Text = "入荷検品データ取込"
        Me.BtnMenuBase4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMenuBase4.UseVisualStyleBackColor = True
        '
        'BtnMenuBase2
        '
        Me.BtnMenuBase2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnMenuBase2.Location = New System.Drawing.Point(17, 234)
        Me.BtnMenuBase2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnMenuBase2.Name = "BtnMenuBase2"
        Me.BtnMenuBase2.Size = New System.Drawing.Size(290, 60)
        Me.BtnMenuBase2.TabIndex = 5
        Me.BtnMenuBase2.Text = "棚番マスタ"
        Me.BtnMenuBase2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMenuBase2.UseVisualStyleBackColor = True
        '
        'BtnMenuBase3
        '
        Me.BtnMenuBase3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnMenuBase3.Location = New System.Drawing.Point(17, 138)
        Me.BtnMenuBase3.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnMenuBase3.Name = "BtnMenuBase3"
        Me.BtnMenuBase3.Size = New System.Drawing.Size(290, 60)
        Me.BtnMenuBase3.TabIndex = 2
        Me.BtnMenuBase3.Text = "担当マスタ"
        Me.BtnMenuBase3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMenuBase3.UseVisualStyleBackColor = True
        '
        'BtnEnd_L1
        '
        Me.BtnEnd_L1.BackColor = System.Drawing.Color.Red
        Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.BtnEnd_L1.ForeColor = System.Drawing.Color.Black
        Me.BtnEnd_L1.Location = New System.Drawing.Point(338, 455)
        Me.BtnEnd_L1.Name = "BtnEnd_L1"
        Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
        Me.BtnEnd_L1.TabIndex = 3
        Me.BtnEnd_L1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEnd_L1.UseVisualStyleBackColor = False
        '
        'LblProcDateTime3
        '
        Me.LblProcDateTime3.AutoSize = True
        Me.LblProcDateTime3.Location = New System.Drawing.Point(88, 300)
        Me.LblProcDateTime3.Name = "LblProcDateTime3"
        Me.LblProcDateTime3.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime3.TabIndex = 12
        Me.LblProcDateTime3.Text = "2025/12/12 12:12:12"
        '
        'LblProcDateTime2
        '
        Me.LblProcDateTime2.AutoSize = True
        Me.LblProcDateTime2.Location = New System.Drawing.Point(88, 204)
        Me.LblProcDateTime2.Name = "LblProcDateTime2"
        Me.LblProcDateTime2.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime2.TabIndex = 12
        Me.LblProcDateTime2.Text = "2025/12/12 12:12:12"
        '
        'LblProcDateTime1
        '
        Me.LblProcDateTime1.AutoSize = True
        Me.LblProcDateTime1.Location = New System.Drawing.Point(88, 108)
        Me.LblProcDateTime1.Name = "LblProcDateTime1"
        Me.LblProcDateTime1.Size = New System.Drawing.Size(219, 24)
        Me.LblProcDateTime1.TabIndex = 12
        Me.LblProcDateTime1.Text = "2025/12/12 12:12:12"
        '
        'BtnMenuBase8
        '
        Me.BtnMenuBase8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnMenuBase8.Location = New System.Drawing.Point(17, 234)
        Me.BtnMenuBase8.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnMenuBase8.Name = "BtnMenuBase8"
        Me.BtnMenuBase8.Size = New System.Drawing.Size(290, 60)
        Me.BtnMenuBase8.TabIndex = 5
        Me.BtnMenuBase8.Text = "棚番マスタ"
        Me.BtnMenuBase8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMenuBase8.UseVisualStyleBackColor = True
        '
        'BtnMenuBase5
        '
        Me.BtnMenuBase5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnMenuBase5.Location = New System.Drawing.Point(17, 138)
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
        Me.BtnMenuBase1.Location = New System.Drawing.Point(17, 42)
        Me.BtnMenuBase1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnMenuBase1.Name = "BtnMenuBase1"
        Me.BtnMenuBase1.Size = New System.Drawing.Size(290, 60)
        Me.BtnMenuBase1.TabIndex = 1
        Me.BtnMenuBase1.Text = "コースマスター"
        Me.BtnMenuBase1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMenuBase1.UseVisualStyleBackColor = True
        '
        'frmMasterMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 527)
        Me.Controls.Add(Me.LblBase1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnEnd_L1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "frmMasterMaintenance"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
  Friend WithEvents BtnMenuBase8 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents Label2 As Label
  Friend WithEvents BtnMenuBase5 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents BtnMenuBase1 As T.R.ZCommonCtrl.BtnMenuBase
  Friend WithEvents BtnEnd_L1 As T.R.ZCommonCtrl.BtnEnd_L
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnMenuBase2 As T.R.ZCommonCtrl.BtnMenuBase
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnMenuBase3 As T.R.ZCommonCtrl.BtnMenuBase
    Friend WithEvents BtnMenuBase4 As T.R.ZCommonCtrl.BtnMenuBase
    Friend WithEvents LblProcDateTime3 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblProcDateTime2 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblProcDateTime1 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblProcDateTime6 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblProcDateTime5 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblProcDateTime4 As T.R.ZCommonCtrl.LblProcDateTime
    Friend WithEvents LblBase1 As T.R.ZCommonCtrl.LblBase
End Class
