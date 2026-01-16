Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports T.R.ZCommonClass.clsGlobalData

Public Class clsHandyCommunication

#Region "パブリック"
  ' プロパティ：作業フォルダ（送受信フォルダ）
  Public Property TargetFolder As String
#End Region

  ' 通信ツール側が作るフラグ（状態通知）
  Private Const COMMUNICATION_FLG As String = "Communication.FLG"

  ' 上位アプリ側が作るフラグ（取得要求）
  Private Const ACQUISITION_FLG As String = "Acquisition.FLG"
  Private LastReceivedFileName As String


  Private Const BHT_COMMICATION_TOOL As String =
      "C:\Program Files (x86)\DENSO WAVE\BHT Advanced Pack II\BHTADP2T.exe"

  Private StatusFlagFilePath As String
  Private AcquisitionFlagFilePath As String

  Private FlgHandySendStart As Boolean = False
  Private watcher As FileSystemWatcher
  Private TargetFileName As String
  Private p As New Process

  Public Sub New(prmFileName As String)
    TargetFileName = prmFileName
  End Sub


  '==========================================================
  ' 通信ツール起動
  '==========================================================
  Public Function OpenCommunicationTool() As Boolean
    Try
      If KANKYO_HONBAN <> "HONBAN" Then
        Return True
      End If

      p.StartInfo.FileName = BHT_COMMICATION_TOOL
      p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
      p.Start()

      Thread.Sleep(3000)

      ' Ctrl+S で開始
      SendKeys.SendWait("^s")

      Thread.Sleep(1000)

      StartWatching()

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  '==========================================================
  ' 通信ツール終了
  '==========================================================
  Public Function CloseCommunicationTool() As Boolean
    Try
      If KANKYO_HONBAN <> "HONBAN" Then
        Return True
      End If

      ' DATファイルがあるなら待機
      If ExistsOtherDatFile(TargetFileName) Then
        Return False
      End If

      WaitCommunicationFlagDeleted()

      SendKeys.SendWait("^e")
      Thread.Sleep(3000)

      If Not p.HasExited Then
        If Process.GetProcessesByName(p.ProcessName).Any() Then
          p.Kill()
        End If
      End If

      StopWatching()

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  '==========================================================
  ' Communication.FLG が作られるのを待つ
  '==========================================================
  Public Function WaitCommunicationFlagCreated() As Boolean
    Try
      If KANKYO_HONBAN <> "HONBAN" Then
        Return True
      End If

      FlgHandySendStart = False

      Dim timeoutSec As Integer = 45
      Dim intervalMs As Integer = 20
      Dim elapsed As Integer = 0

      While Not FlgHandySendStart
        If Not Process.GetProcessesByName(p.ProcessName).Any() Then
          Return False
        End If

        Thread.Sleep(intervalMs)
        elapsed += intervalMs

        If elapsed >= timeoutSec * 1000 Then
          Return False
        End If
      End While

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  '==========================================================
  ' Communication.FLG が消えるのを待つ
  '==========================================================
  Public Function WaitCommunicationFlagDeleted() As Boolean
    Try

      If KANKYO_HONBAN <> "HONBAN" Then
        Return True

      End If

      Dim timeoutSec As Integer = 45
      Dim intervalMs As Integer = 20
      Dim elapsed As Integer = 0

      While IO.File.Exists(StatusFlagFilePath)
        If Not Process.GetProcessesByName(p.ProcessName).Any() Then
          Return False
        End If

        Thread.Sleep(intervalMs)
        elapsed += intervalMs

        If elapsed >= timeoutSec * 1000 Then
          Return False
        End If
      End While

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  Private Function ReadCommunicationFlag() As String
    If IO.File.Exists(StatusFlagFilePath) Then
      Return IO.File.ReadAllText(StatusFlagFilePath, Encoding.GetEncoding("shift-jis")).Trim()
    End If
    Return ""
  End Function

  Public Sub MoveToBackupFolder(fileName As String)
    If KANKYO_HONBAN <> "HONBAN" Then
      Exit Sub
    End If


    Dim src As String = Path.Combine(TargetFolder, fileName)

    If Not IO.File.Exists(src) Then Exit Sub

    Dim bkFolder As String = Path.Combine(TargetFolder, "bk")
    Directory.CreateDirectory(bkFolder)

    Dim dest As String = Path.Combine(bkFolder, $"{Path.GetFileNameWithoutExtension(fileName)}_{Now:yyyyMMddHHmmss}{Path.GetExtension(fileName)}")
    File.Move(src, dest)
  End Sub

  Private Function ExistsOtherDatFile(Optional prmTargetFileName As String = "") As Boolean
    Dim datFiles = Directory.GetFiles(TargetFolder, "*.dat")

    If String.IsNullOrWhiteSpace(prmTargetFileName) Then
      Return datFiles.Any()
    End If

    Dim targetName = Path.GetFileName(prmTargetFileName)

    Return datFiles.Any(Function(f) Path.GetFileName(f) <> targetName)
  End Function




  '==========================================================
  ' Acquisition.FLG を作成（上位アプリ側）
  '==========================================================
  Public Function CreateAcquisitionFlag(prmOutFilePath As String) As Boolean
    Try
      StatusFlagFilePath = TargetFolder & "\" & COMMUNICATION_FLG
      AcquisitionFlagFilePath = TargetFolder & "\" & ACQUISITION_FLG

      IO.File.WriteAllText(AcquisitionFlagFilePath, prmOutFilePath, Encoding.GetEncoding("shift-jis"))
      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  '==========================================================
  ' Acquisition.FLG 削除
  '==========================================================
  Public Function DeleteAcquisitionFlag() As Boolean
    Try
      If IO.File.Exists(AcquisitionFlagFilePath) Then
        IO.File.Delete(AcquisitionFlagFilePath)
      End If

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  Public Function WatchAndArchiveSentFiles(prmTargetFileName As String, ByRef prmTargetSendFlg As Boolean) As Boolean
    Try
      If KANKYO_HONBAN <> "HONBAN" Then
        Return True
      End If

      StatusFlagFilePath = Path.Combine(TargetFolder, COMMUNICATION_FLG)

      Do While True


        ' DATファイルがなければターゲットが送信されたかを確認
        If Not ExistsOtherDatFile(prmTargetFileName) Then
          'ターゲットが送信済みなら終了
          If prmTargetSendFlg Then
            Exit Do
          End If
        End If

        If Not WaitCommunicationFlagCreated() Then Exit Do

        Dim fileName = ReadCommunicationFlag()


        If Not WaitCommunicationFlagDeleted() Then Exit Do

        If fileName = Path.GetFileName(prmTargetFileName) Then
          prmTargetSendFlg = True
        Else
          MoveToBackupFolder(fileName)
        End If

      Loop

      Return True

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function

  '==========================================================
  ' FileSystemWatcher
  '==========================================================
  Private Sub StartWatching()
    If watcher IsNot Nothing Then
      StopWatching()
    End If

    watcher = New FileSystemWatcher()
    watcher.Path = TargetFolder
    watcher.Filter = COMMUNICATION_FLG
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
    ' 特に処理なし
  End Sub

End Class
