Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports T.R.ZCommonClass

Public Class clsHandyCommunication
  Private Const STATUS_FLAG_FILE_NAME As String = "D:\manna\SEND\Communication.FLG"
  Private Const COMMUNICATION_FILE_NAME As String = "D:\manna\SEND\Acquisition.FLG"
  Private FlgHandySendStart As Boolean = False
  Private watcher As FileSystemWatcher
  Private TargetFileName As String

  Public Sub New(prmFileName As String)
    TargetFileName = prmFileName
  End Sub



  Public Function OpenCommunicationTool() As Boolean
    Try
      Dim p As New Process
      p.StartInfo.FileName = "C:\Program Files (x86)\DENSO WAVE\BHT Advanced Pack II\Tool\通信ツール(バッチ通信)"
      p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
      p.Start()
      ' 起動完了まで少し待つ（必要に応じて調整）
      Thread.Sleep(3000)

      ' Ctrl+S を送信
      SendKeys.SendWait("^s")

      ' 監視開始
      StartWatching()

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function

  Public Function CloseCommunicationTool() As Boolean
    Try
      ' アプリを閉じる
      ' Ctrl+e を送信
      SendKeys.SendWait("^e")

      ' 起動完了まで少し待つ（必要に応じて調整）
      Thread.Sleep(3000)

      ' Alt + F4 を送信して閉じる
      SendKeys.SendWait("%{F4}")

      ' 監視終了
      StopWatching()

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function


  Public Function CreateChkStatusFlagFile() As Boolean
    Try
      Dim timeoutSec As Integer = 120 ' 最大待機時間（秒）
      Dim intervalMs As Integer = 10 ' チェック間隔（ミリ秒）
      Dim elapsed As Integer = 0

      While Not FlgHandySendStart
        Threading.Thread.Sleep(intervalMs)
        elapsed += intervalMs

        If elapsed >= timeoutSec * 1000 Then
          ' タイムアウト
          Return False
        End If
      End While

      ' ファイルができたらOK
      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function


  Public Function ChkStatusFlagFile() As Boolean
    Dim response As New Integer
    Try
      Dim timeoutSec As Integer = 45 ' 最大待機時間（秒）
      Dim intervalMs As Integer = 10 ' チェック間隔（ミリ秒）
      Dim elapsed As Integer = 0

      While IO.File.Exists(STATUS_FLAG_FILE_NAME)
        Threading.Thread.Sleep(intervalMs)
        elapsed += intervalMs

        If elapsed >= timeoutSec * 1000 Then
          ' タイムアウト
          Return False
        End If
      End While

      ' ファイルが消えたらOK
      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function

  Public Function CreateCommnicationFile(prmOutFilePath As String) As Boolean
    Dim response As New Integer
    Try
      File.WriteAllText(COMMUNICATION_FILE_NAME, prmOutFilePath, Encoding.GetEncoding("shift-jis"))
      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function

  Public Function DeleteCommnicationFile() As Boolean
    Dim response As New Integer
    Try
      If File.Exists(COMMUNICATION_FILE_NAME) Then
        File.Delete(COMMUNICATION_FILE_NAME)
      End If

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally

    End Try
  End Function


  Public Function SendFile(filePath As String) As Boolean
    Dim response As New Integer
    Try

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return False
    Finally
    End Try
  End Function

  Private Sub StartWatching()
    If watcher IsNot Nothing Then
      StopWatching()
    End If

    watcher = New FileSystemWatcher()
    watcher.Path = Path.GetDirectoryName(STATUS_FLAG_FILE_NAME)
    watcher.Filter = Path.GetFileName(STATUS_FLAG_FILE_NAME)
    watcher.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.CreationTime Or NotifyFilters.LastWrite

    AddHandler watcher.Created, AddressOf OnFlagCreated
    AddHandler watcher.Deleted, AddressOf OnFlagDeleted

    watcher.EnableRaisingEvents = True
  End Sub

  Private Sub StopWatching()
    If watcher IsNot Nothing Then
      watcher.EnableRaisingEvents = False
      RemoveHandler watcher.Created, AddressOf OnFlagCreated
      RemoveHandler watcher.Deleted, AddressOf OnFlagDeleted
      watcher.Dispose()
      watcher = Nothing
    End If
  End Sub

  Private Sub OnFlagCreated(sender As Object, e As FileSystemEventArgs)
    FlgHandySendStart = True
  End Sub

  Private Sub OnFlagDeleted(sender As Object, e As FileSystemEventArgs)
    If File.Exists(TargetFileName) Then
      File.Delete(TargetFileName)
    End If
  End Sub
End Class
