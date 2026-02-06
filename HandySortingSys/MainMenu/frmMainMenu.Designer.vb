Imports T.R.ZCommonCtrl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainMenu
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
    Me.PanelBase1 = New T.R.ZCommonCtrl.PanelBase()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.PanelBase2 = New System.Windows.Forms.Panel()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TanemakiSendStatus = New System.Windows.Forms.Label()
    Me.LblTanemakiSend = New System.Windows.Forms.Label()
    Me.SoudashiSendStatus = New System.Windows.Forms.Label()
    Me.LblSoudashiSend = New System.Windows.Forms.Label()
    Me.NyukaSendStatus = New System.Windows.Forms.Label()
    Me.LblNyukaSend = New System.Windows.Forms.Label()
    Me.TanemakiReceiveStatus = New System.Windows.Forms.Label()
    Me.LblTanemakiReceive = New System.Windows.Forms.Label()
    Me.SoudashiReceiveStatus = New System.Windows.Forms.Label()
    Me.LblSoudashiReceive = New System.Windows.Forms.Label()
    Me.NyukaReceiveStatus = New System.Windows.Forms.Label()
    Me.LblNyukaReceive = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.BtnMainMenuBase6 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.BtnMainMenuBase4 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.BtnMainMenuBase3 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.BtnMainMenuBase2 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.BtnMainMenuBase1 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.BtnEnd_L1 = New T.R.ZCommonCtrl.BtnEnd_L()
    Me.BtnMainMenuBase5 = New T.R.ZCommonCtrl.BtnMainMenuBase()
    Me.PanelBase1.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.PanelBase2.SuspendLayout()
    Me.SuspendLayout()
    '
    'PanelBase1
    '
    Me.PanelBase1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.PanelBase1.BorderColor = System.Drawing.Color.Black
    Me.PanelBase1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelBase1.BorderWidth = 2
    Me.PanelBase1.Controls.Add(Me.PictureBox1)
    Me.PanelBase1.Controls.Add(Me.PanelBase2)
    Me.PanelBase1.Controls.Add(Me.Label18)
    Me.PanelBase1.CornerRadius = 10
    Me.PanelBase1.Location = New System.Drawing.Point(8, 601)
    Me.PanelBase1.Name = "PanelBase1"
    Me.PanelBase1.Size = New System.Drawing.Size(1020, 192)
    Me.PanelBase1.TabIndex = 13
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(363, 8)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(73, 47)
    Me.PictureBox1.TabIndex = 15
    Me.PictureBox1.TabStop = False
    '
    'PanelBase2
    '
    Me.PanelBase2.BackColor = System.Drawing.Color.White
    Me.PanelBase2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelBase2.Controls.Add(Me.Label9)
    Me.PanelBase2.Controls.Add(Me.Label8)
    Me.PanelBase2.Controls.Add(Me.Label7)
    Me.PanelBase2.Controls.Add(Me.Label6)
    Me.PanelBase2.Controls.Add(Me.TanemakiSendStatus)
    Me.PanelBase2.Controls.Add(Me.LblTanemakiSend)
    Me.PanelBase2.Controls.Add(Me.SoudashiSendStatus)
    Me.PanelBase2.Controls.Add(Me.LblSoudashiSend)
    Me.PanelBase2.Controls.Add(Me.NyukaSendStatus)
    Me.PanelBase2.Controls.Add(Me.LblNyukaSend)
    Me.PanelBase2.Controls.Add(Me.TanemakiReceiveStatus)
    Me.PanelBase2.Controls.Add(Me.LblTanemakiReceive)
    Me.PanelBase2.Controls.Add(Me.SoudashiReceiveStatus)
    Me.PanelBase2.Controls.Add(Me.LblSoudashiReceive)
    Me.PanelBase2.Controls.Add(Me.NyukaReceiveStatus)
    Me.PanelBase2.Controls.Add(Me.LblNyukaReceive)
    Me.PanelBase2.Controls.Add(Me.Label2)
    Me.PanelBase2.Controls.Add(Me.Label5)
    Me.PanelBase2.Controls.Add(Me.Label4)
    Me.PanelBase2.Controls.Add(Me.Label3)
    Me.PanelBase2.Controls.Add(Me.Label1)
    Me.PanelBase2.Location = New System.Drawing.Point(-12, 61)
    Me.PanelBase2.Name = "PanelBase2"
    Me.PanelBase2.Size = New System.Drawing.Size(1029, 130)
    Me.PanelBase2.TabIndex = 14
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.Color.Black
    Me.Label9.Location = New System.Drawing.Point(734, 12)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(2, 110)
    Me.Label9.TabIndex = 15
    Me.Label9.Text = "Label9"
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(438, 12)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(2, 110)
    Me.Label8.TabIndex = 14
    Me.Label8.Text = "Label8"
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(155, 12)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(2, 110)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "Label7"
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.Color.Black
    Me.Label6.Location = New System.Drawing.Point(22, 46)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(1000, 2)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "Label6"
    '
    'TanemakiSendStatus
    '
    Me.TanemakiSendStatus.AutoSize = True
    Me.TanemakiSendStatus.Location = New System.Drawing.Point(894, 57)
    Me.TanemakiSendStatus.Name = "TanemakiSendStatus"
    Me.TanemakiSendStatus.Size = New System.Drawing.Size(34, 24)
    Me.TanemakiSendStatus.TabIndex = 10
    Me.TanemakiSendStatus.Text = "済"
    '
    'LblTanemakiSend
    '
    Me.LblTanemakiSend.AutoSize = True
    Me.LblTanemakiSend.Location = New System.Drawing.Point(746, 57)
    Me.LblTanemakiSend.Name = "LblTanemakiSend"
    Me.LblTanemakiSend.Size = New System.Drawing.Size(106, 24)
    Me.LblTanemakiSend.TabIndex = 11
    Me.LblTanemakiSend.Text = "20260228"
    '
    'SoudashiSendStatus
    '
    Me.SoudashiSendStatus.AutoSize = True
    Me.SoudashiSendStatus.BackColor = System.Drawing.Color.Red
    Me.SoudashiSendStatus.ForeColor = System.Drawing.Color.White
    Me.SoudashiSendStatus.Location = New System.Drawing.Point(587, 57)
    Me.SoudashiSendStatus.Name = "SoudashiSendStatus"
    Me.SoudashiSendStatus.Size = New System.Drawing.Size(34, 24)
    Me.SoudashiSendStatus.TabIndex = 8
    Me.SoudashiSendStatus.Text = "未"
    '
    'LblSoudashiSend
    '
    Me.LblSoudashiSend.AutoSize = True
    Me.LblSoudashiSend.Location = New System.Drawing.Point(455, 57)
    Me.LblSoudashiSend.Name = "LblSoudashiSend"
    Me.LblSoudashiSend.Size = New System.Drawing.Size(106, 24)
    Me.LblSoudashiSend.TabIndex = 9
    Me.LblSoudashiSend.Text = "20260228"
    '
    'NyukaSendStatus
    '
    Me.NyukaSendStatus.AutoSize = True
    Me.NyukaSendStatus.Location = New System.Drawing.Point(308, 57)
    Me.NyukaSendStatus.Name = "NyukaSendStatus"
    Me.NyukaSendStatus.Size = New System.Drawing.Size(34, 24)
    Me.NyukaSendStatus.TabIndex = 6
    Me.NyukaSendStatus.Text = "済"
    '
    'LblNyukaSend
    '
    Me.LblNyukaSend.AutoSize = True
    Me.LblNyukaSend.Location = New System.Drawing.Point(161, 57)
    Me.LblNyukaSend.Name = "LblNyukaSend"
    Me.LblNyukaSend.Size = New System.Drawing.Size(106, 24)
    Me.LblNyukaSend.TabIndex = 7
    Me.LblNyukaSend.Text = "20260228"
    '
    'TanemakiReceiveStatus
    '
    Me.TanemakiReceiveStatus.AutoSize = True
    Me.TanemakiReceiveStatus.Location = New System.Drawing.Point(894, 90)
    Me.TanemakiReceiveStatus.Name = "TanemakiReceiveStatus"
    Me.TanemakiReceiveStatus.Size = New System.Drawing.Size(34, 24)
    Me.TanemakiReceiveStatus.TabIndex = 4
    Me.TanemakiReceiveStatus.Text = "済"
    '
    'LblTanemakiReceive
    '
    Me.LblTanemakiReceive.AutoSize = True
    Me.LblTanemakiReceive.Location = New System.Drawing.Point(746, 90)
    Me.LblTanemakiReceive.Name = "LblTanemakiReceive"
    Me.LblTanemakiReceive.Size = New System.Drawing.Size(106, 24)
    Me.LblTanemakiReceive.TabIndex = 5
    Me.LblTanemakiReceive.Text = "20260228"
    '
    'SoudashiReceiveStatus
    '
    Me.SoudashiReceiveStatus.AutoSize = True
    Me.SoudashiReceiveStatus.Location = New System.Drawing.Point(587, 90)
    Me.SoudashiReceiveStatus.Name = "SoudashiReceiveStatus"
    Me.SoudashiReceiveStatus.Size = New System.Drawing.Size(34, 24)
    Me.SoudashiReceiveStatus.TabIndex = 2
    Me.SoudashiReceiveStatus.Text = "済"
    '
    'LblSoudashiReceive
    '
    Me.LblSoudashiReceive.AutoSize = True
    Me.LblSoudashiReceive.Location = New System.Drawing.Point(455, 90)
    Me.LblSoudashiReceive.Name = "LblSoudashiReceive"
    Me.LblSoudashiReceive.Size = New System.Drawing.Size(106, 24)
    Me.LblSoudashiReceive.TabIndex = 3
    Me.LblSoudashiReceive.Text = "20260228"
    '
    'NyukaReceiveStatus
    '
    Me.NyukaReceiveStatus.AutoSize = True
    Me.NyukaReceiveStatus.BackColor = System.Drawing.Color.Red
    Me.NyukaReceiveStatus.ForeColor = System.Drawing.Color.White
    Me.NyukaReceiveStatus.Location = New System.Drawing.Point(308, 90)
    Me.NyukaReceiveStatus.Name = "NyukaReceiveStatus"
    Me.NyukaReceiveStatus.Size = New System.Drawing.Size(34, 24)
    Me.NyukaReceiveStatus.TabIndex = 1
    Me.NyukaReceiveStatus.Text = "未"
    '
    'LblNyukaReceive
    '
    Me.LblNyukaReceive.AutoSize = True
    Me.LblNyukaReceive.Location = New System.Drawing.Point(161, 90)
    Me.LblNyukaReceive.Name = "LblNyukaReceive"
    Me.LblNyukaReceive.Size = New System.Drawing.Size(106, 24)
    Me.LblNyukaReceive.TabIndex = 1
    Me.LblNyukaReceive.Text = "20260228"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(23, 57)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 24)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "送信"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(746, 12)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(70, 24)
    Me.Label5.TabIndex = 0
    Me.Label5.Text = "種まき"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(455, 15)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(75, 24)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "総出し"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(163, 15)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(106, 24)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "入荷検品"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(23, 90)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "受信"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(442, 8)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(159, 24)
    Me.Label18.TabIndex = 3
    Me.Label18.Text = "12/23 08:20:00"
    '
    'BtnMainMenuBase6
    '
    Me.BtnMainMenuBase6.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase6.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase6.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase6.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase6.Icon = Nothing
    Me.BtnMainMenuBase6.Location = New System.Drawing.Point(696, 361)
    Me.BtnMainMenuBase6.Name = "BtnMainMenuBase6"
    Me.BtnMainMenuBase6.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase6.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase6.TabIndex = 12
    Me.BtnMainMenuBase6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase6.Title = Nothing
    Me.BtnMainMenuBase6.UseVisualStyleBackColor = True
    '
    'BtnMainMenuBase4
    '
    Me.BtnMainMenuBase4.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase4.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase4.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase4.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase4.Icon = Nothing
    Me.BtnMainMenuBase4.Location = New System.Drawing.Point(10, 361)
    Me.BtnMainMenuBase4.Name = "BtnMainMenuBase4"
    Me.BtnMainMenuBase4.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase4.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase4.TabIndex = 10
    Me.BtnMainMenuBase4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase4.Title = Nothing
    Me.BtnMainMenuBase4.UseVisualStyleBackColor = True
    '
    'BtnMainMenuBase3
    '
    Me.BtnMainMenuBase3.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase3.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase3.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase3.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase3.Icon = Nothing
    Me.BtnMainMenuBase3.Location = New System.Drawing.Point(696, 116)
    Me.BtnMainMenuBase3.Name = "BtnMainMenuBase3"
    Me.BtnMainMenuBase3.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase3.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase3.TabIndex = 9
    Me.BtnMainMenuBase3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase3.Title = Nothing
    Me.BtnMainMenuBase3.UseVisualStyleBackColor = True
    '
    'BtnMainMenuBase2
    '
    Me.BtnMainMenuBase2.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase2.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase2.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase2.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase2.Icon = Nothing
    Me.BtnMainMenuBase2.Location = New System.Drawing.Point(355, 116)
    Me.BtnMainMenuBase2.Name = "BtnMainMenuBase2"
    Me.BtnMainMenuBase2.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase2.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase2.TabIndex = 8
    Me.BtnMainMenuBase2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase2.Title = Nothing
    Me.BtnMainMenuBase2.UseVisualStyleBackColor = True
    '
    'BtnMainMenuBase1
    '
    Me.BtnMainMenuBase1.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase1.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase1.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase1.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase1.Icon = Nothing
    Me.BtnMainMenuBase1.Location = New System.Drawing.Point(10, 116)
    Me.BtnMainMenuBase1.Name = "BtnMainMenuBase1"
    Me.BtnMainMenuBase1.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase1.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase1.TabIndex = 7
    Me.BtnMainMenuBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase1.Title = Nothing
    Me.BtnMainMenuBase1.UseVisualStyleBackColor = True
    '
    'BtnEnd_L1
    '
    Me.BtnEnd_L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
    Me.BtnEnd_L1.FlatAppearance.BorderSize = 0
    Me.BtnEnd_L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnEnd_L1.Font = New System.Drawing.Font("メイリオ", 16.0!, System.Drawing.FontStyle.Bold)
    Me.BtnEnd_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnEnd_L1.Location = New System.Drawing.Point(704, 796)
    Me.BtnEnd_L1.Name = "BtnEnd_L1"
    Me.BtnEnd_L1.Size = New System.Drawing.Size(320, 60)
    Me.BtnEnd_L1.TabIndex = 14
    Me.BtnEnd_L1.Text = "閉じる(ESC)"
    Me.BtnEnd_L1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnEnd_L1.UseVisualStyleBackColor = False
    '
    'BtnMainMenuBase5
    '
    Me.BtnMainMenuBase5.BtnForeColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase5.ButtonColor = System.Drawing.Color.Empty
    Me.BtnMainMenuBase5.FlatAppearance.BorderSize = 0
    Me.BtnMainMenuBase5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMainMenuBase5.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Bold)
    Me.BtnMainMenuBase5.Icon = Nothing
    Me.BtnMainMenuBase5.Location = New System.Drawing.Point(355, 361)
    Me.BtnMainMenuBase5.Name = "BtnMainMenuBase5"
    Me.BtnMainMenuBase5.SetAccessKey = System.Windows.Forms.Keys.None
    Me.BtnMainMenuBase5.Size = New System.Drawing.Size(331, 235)
    Me.BtnMainMenuBase5.TabIndex = 15
    Me.BtnMainMenuBase5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnMainMenuBase5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnMainMenuBase5.Title = Nothing
    Me.BtnMainMenuBase5.UseVisualStyleBackColor = True
    '
    'frmMainMenu
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1034, 861)
    Me.Controls.Add(Me.BtnMainMenuBase5)
    Me.Controls.Add(Me.BtnEnd_L1)
    Me.Controls.Add(Me.PanelBase1)
    Me.Controls.Add(Me.BtnMainMenuBase6)
    Me.Controls.Add(Me.BtnMainMenuBase4)
    Me.Controls.Add(Me.BtnMainMenuBase3)
    Me.Controls.Add(Me.BtnMainMenuBase2)
    Me.Controls.Add(Me.BtnMainMenuBase1)
    Me.DoubleBuffered = True
    Me.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
    Me.MaximizeBox = False
    Me.Name = "frmMainMenu"
    Me.Text = "frmMainMenu"
    Me.PanelBase1.ResumeLayout(False)
    Me.PanelBase1.PerformLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.PanelBase2.ResumeLayout(False)
    Me.PanelBase2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents PanelBase1 As PanelBase
  Friend WithEvents BtnMainMenuBase6 As BtnMainMenuBase
    Friend WithEvents BtnMainMenuBase4 As BtnMainMenuBase
    Friend WithEvents BtnMainMenuBase3 As BtnMainMenuBase
  Friend WithEvents BtnMainMenuBase2 As BtnMainMenuBase
  Friend WithEvents BtnMainMenuBase1 As BtnMainMenuBase
  Friend WithEvents BtnEnd_L1 As BtnEnd_L
  Friend WithEvents PanelBase2 As Panel
  Friend WithEvents TanemakiSendStatus As Label
  Friend WithEvents LblTanemakiSend As Label
  Friend WithEvents SoudashiSendStatus As Label
  Friend WithEvents LblSoudashiSend As Label
  Friend WithEvents NyukaSendStatus As Label
  Friend WithEvents LblNyukaSend As Label
  Friend WithEvents TanemakiReceiveStatus As Label
  Friend WithEvents LblTanemakiReceive As Label
  Friend WithEvents SoudashiReceiveStatus As Label
  Friend WithEvents LblSoudashiReceive As Label
  Friend WithEvents NyukaReceiveStatus As Label
  Friend WithEvents LblNyukaReceive As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents PictureBox1 As PictureBox
  Friend WithEvents Label18 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
  Friend WithEvents BtnMainMenuBase5 As BtnMainMenuBase
End Class
