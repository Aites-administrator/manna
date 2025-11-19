Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass.clsCommonFnc

Public Class frmPasswordEntry
  Inherits FormBase

#Region "レイアウト"

  Friend WithEvents BtnCancel1 As BtnCancel
  Friend WithEvents BtnOk1 As BtnOk
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtPassWord1 As TxtPassWord

  Private Sub InitializeComponent()
    Me.TxtPassWord1 = New T.R.ZCommonCtrl.TxtPassWord()
    Me.BtnCancel1 = New T.R.ZCommonCtrl.BtnCancel()
    Me.BtnOk1 = New T.R.ZCommonCtrl.BtnOk()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'TxtPassWord1
    '
    Me.TxtPassWord1.DisableAllSelect = False
    Me.TxtPassWord1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.TxtPassWord1.ImeMode = System.Windows.Forms.ImeMode.Alpha
    Me.TxtPassWord1.Location = New System.Drawing.Point(33, 103)
    Me.TxtPassWord1.Name = "TxtPassWord1"
    Me.TxtPassWord1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassWord1.Size = New System.Drawing.Size(383, 31)
    Me.TxtPassWord1.TabIndex = 0
    '
    'BtnCancel1
    '
    Me.BtnCancel1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnCancel1.Location = New System.Drawing.Point(33, 187)
    Me.BtnCancel1.Name = "BtnCancel1"
    Me.BtnCancel1.Size = New System.Drawing.Size(147, 55)
    Me.BtnCancel1.TabIndex = 1
    Me.BtnCancel1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "キャンセル"
    Me.BtnCancel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnCancel1.UseVisualStyleBackColor = True
    '
    'BtnOk1
    '
    Me.BtnOk1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
    Me.BtnOk1.Location = New System.Drawing.Point(269, 187)
    Me.BtnOk1.Name = "BtnOk1"
    Me.BtnOk1.Size = New System.Drawing.Size(147, 55)
    Me.BtnOk1.TabIndex = 2
    Me.BtnOk1.Text = "F2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OK"
    Me.BtnOk1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnOk1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.Label1.Location = New System.Drawing.Point(19, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(410, 24)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "パスワードを入力し[OK]をクリックして下さい"
    '
    'frmPasswordEntry
    '
    Me.ClientSize = New System.Drawing.Size(448, 261)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnOk1)
    Me.Controls.Add(Me.BtnCancel1)
    Me.Controls.Add(Me.TxtPassWord1)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "frmPasswordEntry"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region

  Public Sub New()
    ' この呼び出しはデザイナーで必要です。
    InitializeComponent()

  End Sub

  Private Sub BtnOk1_Click(sender As Object, e As EventArgs) Handles BtnOk1.Click
    Call ComGetProcessByFilePath("C:\Windows\System32\calc.exe")
  End Sub
End Class
