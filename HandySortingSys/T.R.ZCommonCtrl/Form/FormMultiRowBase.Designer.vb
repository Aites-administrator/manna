<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMultiRowBase
  Inherits R.ZCommonCtrl.FormBaseOrder

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
    Me.GcMultiRow1 = New GrapeCity.Win.MultiRow.GcMultiRow()
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GcMultiRow1
    '
    Me.GcMultiRow1.Location = New System.Drawing.Point(145, 125)
    Me.GcMultiRow1.Name = "GcMultiRow1"
    Me.GcMultiRow1.Size = New System.Drawing.Size(240, 150)
    Me.GcMultiRow1.TabIndex = 0
    Me.GcMultiRow1.Text = "GcMultiRow1"
    '
    'FormMultiRowBase
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1134, 509)
    Me.Controls.Add(Me.GcMultiRow1)
    Me.Name = "FormMultiRowBase"
    Me.Text = "Form1(2022/05/25 14:07:26)"
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Public WithEvents GcMultiRow1 As GrapeCity.Win.MultiRow.GcMultiRow
End Class
