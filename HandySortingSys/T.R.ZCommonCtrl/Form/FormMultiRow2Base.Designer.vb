<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMultiRow2Base
  Inherits System.Windows.Forms.Form

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
    Me.GcMultiRow1 = New GrapeCity.Win.MultiRow.GcMultiRow()
    Me.GcMultiRow2 = New GrapeCity.Win.MultiRow.GcMultiRow()
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.GcMultiRow2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GcMultiRow1
    '
    Me.GcMultiRow1.Location = New System.Drawing.Point(102, 138)
    Me.GcMultiRow1.Name = "GcMultiRow1"
    Me.GcMultiRow1.Size = New System.Drawing.Size(240, 150)
    Me.GcMultiRow1.TabIndex = 1
    Me.GcMultiRow1.Text = "GcMultiRow1"
    '
    'GcMultiRow2
    '
    Me.GcMultiRow2.Location = New System.Drawing.Point(429, 138)
    Me.GcMultiRow2.Name = "GcMultiRow2"
    Me.GcMultiRow2.Size = New System.Drawing.Size(240, 150)
    Me.GcMultiRow2.TabIndex = 2
    Me.GcMultiRow2.Text = "GcMultiRow2"
    '
    'FormMultiRow2Base
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(800, 450)
    Me.Controls.Add(Me.GcMultiRow2)
    Me.Controls.Add(Me.GcMultiRow1)
    Me.Name = "FormMultiRow2Base"
    Me.Text = "FormMultiRow2Base"
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.GcMultiRow2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Public WithEvents GcMultiRow1 As GrapeCity.Win.MultiRow.GcMultiRow
  Public WithEvents GcMultiRow2 As GrapeCity.Win.MultiRow.GcMultiRow
End Class
