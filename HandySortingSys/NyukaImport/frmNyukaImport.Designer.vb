Imports T.R.ZCommonCtrl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNyukaImport
    Inherits FormBase

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
  Protected Overloads Sub InitializeComponent()
    Me.BtnInput1 = New T.R.ZCommonCtrl.BtnInput()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.LblBase1 = New T.R.ZCommonCtrl.LblBase()
    Me.DgvList1 = New T.R.ZCommonCtrl.DgvList()
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnInput1
    '
    Me.BtnInput1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.BtnInput1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnInput1.ForeColor = System.Drawing.Color.Black
    Me.BtnInput1.Location = New System.Drawing.Point(12, 98)
    Me.BtnInput1.Name = "BtnInput1"
    Me.BtnInput1.Size = New System.Drawing.Size(320, 60)
    Me.BtnInput1.TabIndex = 2
    Me.BtnInput1.TargetCsvType = Nothing
    Me.BtnInput1.TargetDataTable = Nothing
    Me.BtnInput1.TargetTableName = Nothing
    Me.BtnInput1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnInput1.UseVisualStyleBackColor = False
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.Red
    Me.BtnEnd_L1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.Black
    Me.BtnEnd_L1.Location = New System.Drawing.Point(1052, 98)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 1
    Me.BtnEnd_L1.Text = "ESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'LblBase1
    '
    Me.LblBase1.AutoSize = True
    Me.LblBase1.Font = New System.Drawing.Font("MS UI Gothic", 36.0!)
    Me.LblBase1.Location = New System.Drawing.Point(12, 19)
    Me.LblBase1.Name = "LblBase1"
    Me.LblBase1.Size = New System.Drawing.Size(419, 48)
    Me.LblBase1.TabIndex = 0
    Me.LblBase1.Text = "入荷検品データ取込"
    '
    'DgvList1
    '
    Me.DgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DgvList1.Location = New System.Drawing.Point(12, 174)
    Me.DgvList1.Name = "DgvList1"
    Me.DgvList1.RowTemplate.Height = 21
    Me.DgvList1.Size = New System.Drawing.Size(1359, 675)
    Me.DgvList1.TabIndex = 3
    '
    'frmNyukaImport
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1384, 861)
    Me.Controls.Add(Me.DgvList1)
    Me.Controls.Add(Me.BtnInput1)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.LblBase1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmNyukaImport"
    Me.Text = "frmNyukaImport"
    CType(Me.DgvList1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents LblBase1 As T.R.ZCommonCtrl.LblBase
    Friend WithEvents BtnEnd_L1 As T.R.ZCommonCtrl.BtnEnd_L
    Friend WithEvents BtnInput1 As T.R.ZCommonCtrl.BtnInput
    Friend WithEvents DgvList1 As T.R.ZCommonCtrl.DgvList
End Class
