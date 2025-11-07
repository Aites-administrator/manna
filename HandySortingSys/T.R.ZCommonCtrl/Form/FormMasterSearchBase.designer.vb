<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterSearchBase
  Inherits R.ZCommonCtrl.FormBaseOrder

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Windows フォーム デザイナーで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
  'Windows フォーム デザイナーを使用して変更できます。  
  'コード エディターを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.DataRepeater1 = New Microsoft.VisualBasic.PowerPacks.DataRepeater()
    Me.DataRepeater1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DataRepeater1
    '
    '
    'DataRepeater1.ItemTemplate
    '
    Me.DataRepeater1.ItemTemplate.AllowDrop = True
    Me.DataRepeater1.ItemTemplate.AutoSize = True
    Me.DataRepeater1.ItemTemplate.Size = New System.Drawing.Size(972, 83)
    Me.DataRepeater1.Location = New System.Drawing.Point(26, 98)
    Me.DataRepeater1.Name = "DataRepeater1"
    Me.DataRepeater1.Size = New System.Drawing.Size(980, 190)
    Me.DataRepeater1.TabIndex = 1
    Me.DataRepeater1.Text = "DataRepeater1"
    '
    'FormMasterSearchBase
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1018, 488)
    Me.Controls.Add(Me.DataRepeater1)
    Me.Name = "FormMasterSearchBase"
    Me.Text = "FormSearchMasterBase"
    Me.DataRepeater1.ResumeLayout(False)
    Me.DataRepeater1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Public WithEvents DataRepeater1 As PowerPacks.DataRepeater
End Class
