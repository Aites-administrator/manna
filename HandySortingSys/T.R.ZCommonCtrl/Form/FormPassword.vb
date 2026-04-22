Imports T.R.ZCommonClass.clsCommonFnc
Public Class FormPassword
  Inherits Form

  Friend WithEvents lblMessage As Label
  Friend WithEvents TxtPassWord As TxtPassWord

  Public Property MessageText As String
    Get
      Return lblMessage.Text
    End Get
    Set(value As String)
      lblMessage.Text = value
    End Set
  End Property

  Public ReadOnly Property Password As String
    Get
      Return TxtPassWord.Text
    End Get
  End Property

  Public Function PasswordInputBox(message As String, title As String) As String
    Using frm As New FormPassword
      frm.Text = title
      frm.MessageText = message

      If frm.ShowDialog() = DialogResult.OK Then
        Return frm.Password
      Else
        Return Nothing
      End If
    End Using
  End Function

  Private Sub InitializeComponent()
    Me.TxtPassWord = New T.R.ZCommonCtrl.TxtPassWord()
    Me.lblMessage = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'TxtPassWord
    '
    Me.TxtPassWord.DisableAllSelect = False
    Me.TxtPassWord.ImeMode = System.Windows.Forms.ImeMode.Alpha
    Me.TxtPassWord.Location = New System.Drawing.Point(12, 183)
    Me.TxtPassWord.Name = "TxtPassWord"
    Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassWord.Size = New System.Drawing.Size(439, 19)
    Me.TxtPassWord.TabIndex = 0
    '
    'lblMessage
    '
    Me.lblMessage.AutoSize = True
    Me.lblMessage.Location = New System.Drawing.Point(12, 18)
    Me.lblMessage.Name = "lblMessage"
    Me.lblMessage.Size = New System.Drawing.Size(38, 12)
    Me.lblMessage.TabIndex = 1
    Me.lblMessage.Text = "Label1"
    '
    'FormPassword
    '
    Me.ClientSize = New System.Drawing.Size(463, 221)
    Me.Controls.Add(Me.lblMessage)
    Me.Controls.Add(Me.TxtPassWord)
    Me.Name = "FormPassword"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
End Class
