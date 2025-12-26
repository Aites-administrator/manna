Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTanemakiMenu
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
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.BtnEnd_L2 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.BtnMainMenuBase2 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.LblProcDateTime2 = New T.R.ZCommonCtrl.LblProcDateTime()
    Me.LblProcDateTime1 = New T.R.ZCommonCtrl.LblProcDateTime()
    Me.BtnMainMenuBase1 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.SuspendLayout()
    '
    'BtnEnd_L2
    '
    Me.BtnEnd_L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L2.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnEnd_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L2.Location = New System.Drawing.Point(702, 785)
    Me.BtnEnd_L2.Name = "BtnEnd_L2"
    Me.BtnEnd_L2.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L2.TabIndex = 29
    Me.BtnEnd_L2.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
    Me.BtnEnd_L2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L2.UseVisualStyleBackColor = False
    '
    'BtnMainMenuBase2
    '
    Me.BtnMainMenuBase2.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase2.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase2.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase2.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase2.Icon = Nothing
    Me.BtnMainMenuBase2.Location = New System.Drawing.Point(644, 297)
    Me.BtnMainMenuBase2.Name = "BtnMainMenuBase2"
    Me.BtnMainMenuBase2.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase2.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase2.TabIndex = 28
    Me.BtnMainMenuBase2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnMainMenuBase2.Title = Nothing
    Me.BtnMainMenuBase2.UseVisualStyleBackColor = True
    '
    'LblProcDateTime2
    '
    Me.LblProcDateTime2.AutoSize = True
    Me.LblProcDateTime2.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
    Me.LblProcDateTime2.Location = New System.Drawing.Point(756, 547)
    Me.LblProcDateTime2.Name = "LblProcDateTime2"
    Me.LblProcDateTime2.Size = New System.Drawing.Size(219, 24)
    Me.LblProcDateTime2.TabIndex = 26
    Me.LblProcDateTime2.Text = "2025/12/12 12:12:12"
    '
    'LblProcDateTime1
    '
    Me.LblProcDateTime1.AutoSize = True
    Me.LblProcDateTime1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
    Me.LblProcDateTime1.Location = New System.Drawing.Point(231, 547)
    Me.LblProcDateTime1.Name = "LblProcDateTime1"
    Me.LblProcDateTime1.Size = New System.Drawing.Size(219, 24)
    Me.LblProcDateTime1.TabIndex = 25
    Me.LblProcDateTime1.Text = "2025/12/12 12:12:12"
    '
    'BtnMainMenuBase1
    '
    Me.BtnMainMenuBase1.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase1.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase1.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase1.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase1.Icon = Nothing
    Me.BtnMainMenuBase1.Location = New System.Drawing.Point(119, 297)
    Me.BtnMainMenuBase1.Name = "BtnMainMenuBase1"
    Me.BtnMainMenuBase1.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase1.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase1.TabIndex = 27
    Me.BtnMainMenuBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnMainMenuBase1.Title = Nothing
    Me.BtnMainMenuBase1.UseVisualStyleBackColor = True
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 15)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(376, 48)
    Me.LblBase1.TabIndex = 24
    Me.LblBase1.Text = "種まき処理メニュー"
    '
    'frmTanemakiMenu
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1034, 861)
    Me.Controls.Add(Me.BtnEnd_L2)
    Me.Controls.Add(Me.BtnMainMenuBase2)
    Me.Controls.Add(Me.LblProcDateTime2)
    Me.Controls.Add(Me.LblProcDateTime1)
    Me.Controls.Add(Me.BtnMainMenuBase1)
    Me.Controls.Add(Me.LblBase1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmTanemakiMenu"
    Me.Text = "Form1"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents BtnEnd_L2 As BtnEnd_L
  Friend WithEvents BtnMainMenuBase2 As BtnMainMenuBase
  Friend WithEvents LblProcDateTime2 As LblProcDateTime
  Friend WithEvents LblProcDateTime1 As LblProcDateTime
  Friend WithEvents BtnMainMenuBase1 As BtnMainMenuBase
  Friend WithEvents LblBase1 As LblBase
End Class
