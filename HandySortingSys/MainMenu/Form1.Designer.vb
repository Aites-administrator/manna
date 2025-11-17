Imports T.R.ZCommonCtrl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
    Me.Button1 = New System.Windows.Forms.Button()
    Me.FunctionBtnSam1 = New T.R.ZCommonCtrl.FunctionBtnSam()
    Me.FunctionBtnSam2 = New T.R.ZCommonCtrl.FunctionBtnSam()
    Me.BtnBase1 = New T.R.ZCommonCtrl.BtnBase()
    Me.BtnBase2 = New T.R.ZCommonCtrl.BtnBase()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(1321, 645)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'FunctionBtnSam1
    '
    Me.FunctionBtnSam1.BackColor = System.Drawing.Color.White
    Me.FunctionBtnSam1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.FunctionBtnSam1.Location = New System.Drawing.Point(702, 162)
    Me.FunctionBtnSam1.Name = "FunctionBtnSam1"
    Me.FunctionBtnSam1.Size = New System.Drawing.Size(123, 50)
    Me.FunctionBtnSam1.TabIndex = 1
    Me.FunctionBtnSam1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "エスケープボタンで反応します"
    Me.FunctionBtnSam1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.FunctionBtnSam1.UseVisualStyleBackColor = False
    '
    'FunctionBtnSam2
    '
    Me.FunctionBtnSam2.BackColor = System.Drawing.Color.White
    Me.FunctionBtnSam2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.FunctionBtnSam2.Location = New System.Drawing.Point(630, 600)
    Me.FunctionBtnSam2.Name = "FunctionBtnSam2"
    Me.FunctionBtnSam2.Size = New System.Drawing.Size(330, 110)
    Me.FunctionBtnSam2.TabIndex = 2
    Me.FunctionBtnSam2.Text = "FunctionBtnSam2"
    Me.FunctionBtnSam2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.FunctionBtnSam2.UseVisualStyleBackColor = False
    '
    'BtnBase1
    '
    Me.BtnBase1.Location = New System.Drawing.Point(516, 390)
    Me.BtnBase1.Name = "BtnBase1"
    Me.BtnBase1.Size = New System.Drawing.Size(251, 69)
    Me.BtnBase1.TabIndex = 3
    Me.BtnBase1.Text = "BtnBase1"
    Me.BtnBase1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnBase1.UseVisualStyleBackColor = True
    '
    'BtnBase2
    '
    Me.BtnBase2.Location = New System.Drawing.Point(867, 442)
    Me.BtnBase2.Name = "BtnBase2"
    Me.BtnBase2.Size = New System.Drawing.Size(75, 23)
    Me.BtnBase2.TabIndex = 4
    Me.BtnBase2.Text = "BtnBase2"
    Me.BtnBase2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnBase2.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1484, 841)
    Me.Controls.Add(Me.BtnBase2)
    Me.Controls.Add(Me.BtnBase1)
    Me.Controls.Add(Me.FunctionBtnSam2)
    Me.Controls.Add(Me.FunctionBtnSam1)
    Me.Controls.Add(Me.Button1)
    Me.DoubleBuffered = True
    Me.KeyPreview = True
    Me.Name = "Form1"
    Me.Text = "Form1(2025/11/16 11:44:35)(2025/11/17 09:47:43)"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents Button1 As Button
  Friend WithEvents FunctionBtnSam1 As T.R.ZCommonCtrl.FunctionBtnSam
  Friend WithEvents FunctionBtnSam2 As FunctionBtnSam
  Friend WithEvents BtnBase1 As BtnBase
  Friend WithEvents BtnBase2 As BtnBase
End Class
