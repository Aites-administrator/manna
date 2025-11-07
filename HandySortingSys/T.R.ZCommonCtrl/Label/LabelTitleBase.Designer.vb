<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LabelTitleBase


  'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.Label1.Location = New System.Drawing.Point(0, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(100, 23)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Label Search Name Base"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabelSearchNameBase
    '
    Me.Size = New System.Drawing.Size(179, 29)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents Label1 As Label
End Class
