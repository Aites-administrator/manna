<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TxtBtnLblBase
  Inherits System.Windows.Forms.UserControl

  'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TxtBtnLblBase))
    Me.TxtDummy = New T.R.ZCommonCtrl.TxtMstBase()
    Me.BtnLinkBtn1 = New T.R.ZCommonCtrl.BtnLinkBtn()
    Me.TxtName = New T.R.ZCommonCtrl.TxtBase()
    Me.SuspendLayout()
    '
    'TxtDummy
    '
    Me.TxtDummy.Font = New System.Drawing.Font("MS UI Gothic", 14.26415!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.TxtDummy.ImeMode = System.Windows.Forms.ImeMode.Alpha
    Me.TxtDummy.Location = New System.Drawing.Point(0, 0)
    Me.TxtDummy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
    Me.TxtDummy.Name = "TxtDummy"
    Me.TxtDummy.Size = New System.Drawing.Size(192, 27)
    Me.TxtDummy.TabIndex = 1
    Me.TxtDummy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'BtnLinkBtn1
    '
    Me.BtnLinkBtn1.Image = CType(resources.GetObject("BtnLinkBtn1.Image"), System.Drawing.Image)
    Me.BtnLinkBtn1.Location = New System.Drawing.Point(192, 0)
    Me.BtnLinkBtn1.Name = "BtnLinkBtn1"
    Me.BtnLinkBtn1.Size = New System.Drawing.Size(16, 28)
    Me.BtnLinkBtn1.TabIndex = 2
    Me.BtnLinkBtn1.Text = "BtnLinkBtn1"
    Me.BtnLinkBtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnLinkBtn1.UseVisualStyleBackColor = True
    '
    'TxtName
    '
    Me.TxtName.Font = New System.Drawing.Font("MS UI Gothic", 14.26415!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.TxtName.Location = New System.Drawing.Point(264, 0)
    Me.TxtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(346, 27)
    Me.TxtName.TabIndex = 6
    '
    'TxtBtnLblBase
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.BtnLinkBtn1)
    Me.Controls.Add(Me.TxtDummy)
    Me.Name = "TxtBtnLblBase"
    Me.Size = New System.Drawing.Size(625, 39)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents TxtDummy As TxtMstBase
  Friend WithEvents BtnLinkBtn1 As BtnLinkBtn
  Friend WithEvents TxtName As TxtBase
End Class
