Imports T.R.ZCommonClass.clsCommonFnc
Imports System.IO
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System.ComponentModel

Public Class FormCommunication
  Inherits FormBase


  '★継承先で自由に差し替えられる文言
  Public Overridable Property TextName As String = "送信"
  Public Overridable Property TextHandyName As String = "データ受信"
  Public Overridable Property TextButtonName As String = "送信（F5）"
  Public Overridable Property TextDisplayName As String = "入荷検品"
  Public Overridable Property TextDataGrid As DgvList
  Public Overridable Property TextHandy As New ClsHandyCommunication.clsHandyCommunication("")


#Region "イベントプロシージャー"

  Public Sub New()
  End Sub


  Public Sub RegisterSendButton(btn As BtnSendHandy)
    AddHandler btn.SendCompleted, AddressOf OnSendCompleted
  End Sub

  Public Sub RegisterReceiveButton(btn As BtnRecieveHandy)
    AddHandler btn.ReceiveCompleted, AddressOf OnReceiveompleted
  End Sub

  Protected Overridable Sub OnSendCompleted()

  End Sub

  Protected Overridable Sub OnReceiveompleted()

  End Sub

  Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TextDataGrid.UseCustomSize = True
    TextDataGrid.GridFontSize = 14
    TextDataGrid.HeaderFontSize = 14
    TextDataGrid.ApplyInitialLayout()

  End Sub

  Protected Overrides Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'FormCommunication
    '
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.DoubleBuffered = True
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FormCommunication"
    Me.ResumeLayout(False)

  End Sub

  Protected Overrides Sub OnLoad(e As EventArgs)
    MyBase.OnLoad(e)
    Me.BackColor = Color.Aqua


    Me.Size = New Size(1700, 900)


    CreateInstructionPanel()
  End Sub

  Private Sub CreateInstructionPanel()

    ' ★右側パネル
    Dim pnl As New Panel()
    pnl.Width = 700
    pnl.Dock = DockStyle.Right
    pnl.BackColor = Color.FromArgb(255, 250, 230)
    pnl.Padding = New Padding(10)
    Me.Controls.Add(pnl)

    ' ★RichTextBox（全部太字）
    Dim rtb As New RichTextBox()
    rtb.ReadOnly = True
    rtb.BorderStyle = BorderStyle.None
    rtb.BackColor = pnl.BackColor
    rtb.Font = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.Width = 700
    rtb.Height = pnl.Height - 20
    pnl.Controls.Add(rtb)

    rtb.Clear()

    ' タイトル
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("【ハンディ" & Me.TextName & "手順】" & vbCrLf)

    ' ハンディ操作（青）
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.RoyalBlue
    rtb.AppendText("【ハンディ操作】" & vbCrLf)

    ' 本文
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("1. 「" & Me.TextHandyName & "」を選択します。" & vbCrLf)
    rtb.AppendText("2. " & Me.TextDisplayName & "を選択します。" & vbCrLf)

    ' PC操作（緑）
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.ForestGreen
    rtb.AppendText("【PC操作】" & vbCrLf)

    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("3. " & Me.TextButtonName & " ボタンを押します。" & vbCrLf)
    rtb.AppendText("4. 通信ツールが立ち上がります。待機中になったら、ハンディをクレードルに置いてください。" & vbCrLf)

    ' 通信中（オレンジ）
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.DarkOrange
    rtb.AppendText("【通信中】" & vbCrLf)

    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("5. 完了メッセージが出るまで、ハンディをクレードルから外さないでください。" & vbCrLf)

    ' 通信中（オレンジ）
    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.DarkOliveGreen
    rtb.AppendText("【通信完了】" & vbCrLf)

    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("6. 完了メッセージが出たら、「OK」ボタンを押してください。" & vbCrLf)

    rtb.SelectionFont = New Font("Meiryo", 18, FontStyle.Bold)
    rtb.SelectionColor = Color.Black
    rtb.AppendText("7. 「閉じる」ボタンを押してください。" & vbCrLf)
  End Sub

  Private Sub FormCommunication_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


  End Sub

  Private Sub FormCommunication_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    Try
      ' DAT ファイルをすべてバックアップへ移動
      Dim folder As String = TextHandy.TargetFolder

      For Each filePath In Directory.GetFiles(folder, "*.DAT")
        Dim fileName As String = Path.GetFileName(filePath)
        TextHandy.MoveToBackupFolder(fileName)
      Next

      TextHandy.CloseCommunicationTool()

    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub



#End Region

End Class
