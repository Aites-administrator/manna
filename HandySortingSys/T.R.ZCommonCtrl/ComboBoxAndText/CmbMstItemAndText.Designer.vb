<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CmbMstItemAndText
  Inherits System.Windows.Forms.UserControl

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
    Me.TxtDummy = New T.R.ZCommonCtrl.TxtInputCombo()
    Me.CmbDummy = New T.R.ZCommonCtrl.CmbDrMstItem()
    Me.SuspendLayout()
    '
    'TxtDummy
    '
    Me.TxtDummy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TxtDummy.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 16.30189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.TxtDummy.Location = New System.Drawing.Point(0, 0)
    Me.TxtDummy.Multiline = True
    Me.TxtDummy.MultiLineInput = False
    Me.TxtDummy.Name = "TxtDummy"
    Me.TxtDummy.Size = New System.Drawing.Size(141, 32)
    Me.TxtDummy.TabIndex = 172
    '
    'CmbDummy
    '
    Me.CmbDummy.AvailableBlank = False
    Me.CmbDummy.BorderColor = System.Drawing.SystemColors.ControlText
    Me.CmbDummy.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None
    Me.CmbDummy.BorderWidth = 1
    Me.CmbDummy.CodeFormat = "00000000"
    Me.CmbDummy.DisplayMember = "ItemName"
    Me.CmbDummy.DropDownWidth = 480
    Me.CmbDummy.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 16.30189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.CmbDummy.FormattingEnabled = True
    Me.CmbDummy.IntegralHeight = False
    Me.CmbDummy.Location = New System.Drawing.Point(0, 0)
    Me.CmbDummy.MaxDropDownItems = 5
    Me.CmbDummy.Name = "CmbDummy"
    Me.CmbDummy.Size = New System.Drawing.Size(161, 32)
    Me.CmbDummy.SkipChkCode = False
    Me.CmbDummy.TabIndex = 173
    Me.CmbDummy.ValueMember = "ItemCode"
    '
    'CmbMstItemAndText
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.TxtDummy)
    Me.Controls.Add(Me.CmbDummy)
    Me.Name = "CmbMstItemAndText"
    Me.Size = New System.Drawing.Size(161, 32)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents TxtDummy As TxtInputCombo
  Friend WithEvents CmbDummy As CmbDrMstItem
End Class
