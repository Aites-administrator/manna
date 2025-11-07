<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CmbMstCustomerAndText
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CmbMstCustomerAndText))
    Me.CmbDummy = New T.R.ZCommonCtrl.CmbMstCustomer()
    Me.SuspendLayout()
    '
    'CmbDummy
    '
    Me.CmbDummy.AvailableBlank = False
    Me.CmbDummy.BackColor = System.Drawing.Color.White
    Me.CmbDummy.BorderColor = System.Drawing.SystemColors.ControlText
    Me.CmbDummy.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None
    Me.CmbDummy.BorderWidth = 1
    Me.CmbDummy.CodeFormat = "000000"
    Me.CmbDummy.DisplayMember = "ItemCode"
    Me.CmbDummy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.CmbDummy.DropDownWidth = 360
    Me.CmbDummy.EventCancel = False
    Me.CmbDummy.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.26415!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.CmbDummy.FormattingEnabled = True
    Me.CmbDummy.Location = New System.Drawing.Point(0, 0)
    Me.CmbDummy.Name = "CmbDummy"
    Me.CmbDummy.Size = New System.Drawing.Size(160, 29)
    Me.CmbDummy.SkipChkCode = False
    Me.CmbDummy.TabIndex = 172
    Me.CmbDummy.ValueMember = "ItemCode"
    '
    'CmbMstCustomerAndText
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(176, Byte), Integer))
    Me.Controls.Add(Me.CmbDummy)
    Me.Name = "CmbMstCustomerAndText"
    Me.Size = New System.Drawing.Size(160, 29)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents CmbDummy As CmbMstCustomer
End Class
