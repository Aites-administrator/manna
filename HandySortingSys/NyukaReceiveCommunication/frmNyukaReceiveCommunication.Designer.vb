Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNyukaReceiveCommunication
  Inherits FormCommunication

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
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
        Me.BtnRecieveHandy1 = New T.R.ZCommonCtrl.BtnRecieveHandy()
        Me.SuspendLayout()
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
        Me.LblBase1.Location = New System.Drawing.Point(12, 19)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(562, 48)
        Me.LblBase1.TabIndex = 11
        Me.LblBase1.Text = "ハンディ入荷検品データ送信"
        '
        'BtnEnd_L1
        '
        Me.BtnEnd_L1.BackColor = System.Drawing.Color.Red
        Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.BtnEnd_L1.ForeColor = System.Drawing.Color.Black
        Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 12)
        Me.BtnEnd_L1.Name = "BtnEnd_L1"
        Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
        Me.BtnEnd_L1.TabIndex = 12
        Me.BtnEnd_L1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEnd_L1.UseVisualStyleBackColor = False
        '
        'BtnRecieveHandy1
        '
        Me.BtnRecieveHandy1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnRecieveHandy1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.BtnRecieveHandy1.ForeColor = System.Drawing.Color.Black
        Me.BtnRecieveHandy1.Location = New System.Drawing.Point(1052, 80)
        Me.BtnRecieveHandy1.Name = "BtnRecieveHandy1"
        Me.BtnRecieveHandy1.Size = New System.Drawing.Size(320, 60)
        Me.BtnRecieveHandy1.TabIndex = 13
        Me.BtnRecieveHandy1.TargetFileName = Nothing
        Me.BtnRecieveHandy1.Text = "F6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "受信"
        Me.BtnRecieveHandy1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRecieveHandy1.UseVisualStyleBackColor = False
        '
        'frmNyukaReceiveCommunication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1384, 861)
        Me.Controls.Add(Me.BtnRecieveHandy1)
        Me.Controls.Add(Me.BtnEnd_L1)
        Me.Controls.Add(Me.LblBase1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmNyukaReceiveCommunication"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblBase1 As LblBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
    Friend WithEvents BtnRecieveHandy1 As BtnRecieveHandy
End Class
