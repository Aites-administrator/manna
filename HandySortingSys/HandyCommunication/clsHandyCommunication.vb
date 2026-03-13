Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class clsHandyCommunication

#Region "パブリック"
  ' プロパティ：作業フォルダ（送受信フォルダ）
  Public Property TargetFolder As String
#End Region

  ' 通信ツール側が作るフラグ（状態通知）
  Private Const COMMUNICATION_FLG As String = "Communication.FLG"

  ' 上位アプリ側が作るフラグ（取得要求）
  Private Const ACQUISITION_FLG As String = "Acquisition.FLG"
  ' 最終ファイル名
  Private Const LAST_FILE_NAME As String = "RECEIVE\END.DAT"
  Private LastReceivedFileName As String

  Private Const BHT_COMMICATION_TOOL As String =
      "C:\Program Files (x86)\DENSO WAVE\BHT Advanced Pack II\BHTADP2T.exe"

  Private StatusFlagFilePath As String
  Private AcquisitionFlagFilePath As String

  Private FlgHandySendStart As Boolean = False
  Private watcher As FileSystemWatcher
  Private TargetFileName As String
  Private p As New Process

  Private USE_FILE_NAME As String = String.Empty
  Public ComFlgDel As Boolean = True
  Public EndFlg As Boolean = False
  Public EndComFlg As Boolean = False



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

      IO.File.Delete(PROJECT_DIR_NAME & LAST_FILE_NAME)

      Thread.Sleep(3000)

      ' Ctrl+S で開始
      SendKeys.SendWait("^s")

      Thread.Sleep(1000)

      'StartWatching()

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

      '' DATファイルがあるなら待機
      'If ExistsOtherDatFile(TargetFileName) Then
      '  Return False
      'End If

      'WaitCommunicationFlagDeleted()

      If Not Process.GetProcessesByName(p.ProcessName).Any() Then
        StopWatching()
        Return True
      End If

      SendKeys.SendWait("^e")
      Thread.Sleep(1000)

      If Not p.HasExited Then
        If Process.GetProcessesByName(p.ProcessName).Any() Then
          p.Kill()
        End If
      End If

      IO.File.Delete(PROJECT_DIR_NAME & LAST_FILE_NAME)

      StopWatching()

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  ''==========================================================
  '' Communication.FLG が作られるのを待つ
  ''==========================================================
  'Public Function WaitCommunicationFlagCreated(ByRef prmFileName As String) As Boolean
  '  Try
  '    If KANKYO_HONBAN <> "HONBAN" Then
  '      Return True
  '    End If

  '    FlgHandySendStart = False

  '    Dim timeoutSec As Integer = 45
  '    Dim intervalMs As Integer = 20
  '    Dim elapsed As Integer = 0

  '    While Not FlgHandySendStart
  '      Application.DoEvents()

  '      WriteProgressLog($"FLG作成中")

  '      If Not Process.GetProcessesByName(p.ProcessName).Any() Then
  '        Return False
  '      End If

  '      'Thread.Sleep(intervalMs)
  '      elapsed += intervalMs

  '      If elapsed >= timeoutSec * 1000 Then
  '        Return False
  '      End If
  '    End While

  '    WriteProgressLog($"読み取り状態確認開始")

  '    If Not WaitUntilCommunicationFlagReadable(1000) Then
  '      Return False
  '    End If

  '    prmFileName = ReadCommunicationFlag()
  '    WriteProgressLog($"FLG作成完了")

  '    Return True
  '  Catch ex As Exception
  '    Throw New Exception(ex.Message)
  '  End Try
  'End Function

  'Private Function WaitUntilCommunicationFlagReadable(timeoutMs As Integer) As Boolean
  '  Dim elapsed = 0

  '  While elapsed < timeoutMs
  '    Try
  '      WriteProgressLog(StatusFlagFilePath)

  '      ' ファイルが存在し、かつ読み取り可能か？
  '      If IO.File.Exists(StatusFlagFilePath) Then
  '        Using fs = IO.File.Open(StatusFlagFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
  '          Return True   ' ← 読み取れる状態になった！
  '        End Using
  '      End If
  '    Catch
  '      ' まだ書き込み中 or ロック中 → 少し待つ
  '    End Try

  '    Thread.Sleep(20)
  '    elapsed += 20
  '  End While

  '  Return False   ' 読み取れる状態にならなかった
  'End Function


  '==========================================================
  ' Communication.FLG が消えるのを待つ
  '==========================================================
  Public Function WaitCommunicationFlagDeleted() As Boolean
    Try

      If KANKYO_HONBAN <> "HONBAN" Then
        Return True

      End If

      'Dim timeoutSec As Integer = 45
      'Dim intervalMs As Integer = 20
      'Dim elapsed As Integer = 0

      'While IO.File.Exists(StatusFlagFilePath)
      '  If Not Process.GetProcessesByName(p.ProcessName).Any() Then
      '    Return False
      '  End If

      '  Thread.Sleep(intervalMs)
      '  elapsed += intervalMs

      '  If elapsed >= timeoutSec * 1000 Then
      '    Return False
      '  End If
      'End While

      While Not ComFlgDel

      End While

      Return True
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function


  Private Function ReadCommunicationFlag() As String
    StatusFlagFilePath = Path.Combine(TargetFolder, COMMUNICATION_FLG)

    If IO.File.Exists(StatusFlagFilePath) Then

      Using fs As New FileStream(
            StatusFlagFilePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite   ' ← 共有許可（読み書きOK）
        )
        Using sr As New StreamReader(fs, Encoding.GetEncoding("shift-jis"))
          Return sr.ReadToEnd().Trim()
        End Using
      End Using
    End If

    Return ""

    'If IO.File.Exists(StatusFlagFilePath) Then
    '  Return IO.File.ReadAllText(StatusFlagFilePath, Encoding.GetEncoding("shift-jis")).Trim()
    'End If
    'Return ""
  End Function

  Public Sub MoveToBackupFolder(fileName As String)
    If KANKYO_HONBAN <> "HONBAN" Then
      Exit Sub
    End If

    If fileName = AcquisitionFlagFilePath Then
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
    Return True
    'Try
    '  StatusFlagFilePath = TargetFolder & "\" & COMMUNICATION_FLG
    '  AcquisitionFlagFilePath = TargetFolder & "\" & ACQUISITION_FLG

    '  IO.File.WriteAllText(AcquisitionFlagFilePath, prmOutFilePath, Encoding.GetEncoding("shift-jis"))
    '  Return True
    'Catch ex As Exception
    '  Throw New Exception(ex.Message)
    'End Try
  End Function


  '==========================================================
  ' Acquisition.FLG 削除
  '==========================================================
  Public Function DeleteAcquisitionFlag() As Boolean
    Return True
    'Try
    '  If IO.File.Exists(AcquisitionFlagFilePath) Then
    '    IO.File.Delete(AcquisitionFlagFilePath)
    '  End If

    '  Return True
    'Catch ex As Exception
    '  Throw New Exception(ex.Message)
    'End Try
  End Function


  Public Function WatchAndArchiveSentFiles(prmTargetFileName As String, ByRef prmTargetSendFlg As Boolean) As Boolean
    Try
      If KANKYO_HONBAN <> "HONBAN" Then
        Return True
      End If

      'StatusFlagFilePath = Path.Combine(TargetFolder, COMMUNICATION_FLG)

      Do While True
        Application.DoEvents()

        'Thread.Sleep(50)

        '通信完了していれば終了
        If EndComFlg Then
          Exit Do
        End If

        'Dim fileName As String = USE_FILE_NAME

        'If String.IsNullOrWhiteSpace(fileName) Then
        '  WriteProgressLog($"空のあとの取得する: {USE_FILE_NAME}")
        '  USE_FILE_NAME = ReadCommunicationFlag() 'Application.DoEvents()
        '  WriteProgressLog($"空のあとの取得できたか: {USE_FILE_NAME}")

        '  If String.IsNullOrWhiteSpace(USE_FILE_NAME) Then
        '    Continue Do
        '  Else
        '    fileName = USE_FILE_NAME
        '  End If
        'End If

        'If Not WaitCommunicationFlagDeleted() Then

        '  Return False
        'End If

        'If fileName = Path.GetFileName(prmTargetFileName) Then
        '  prmTargetSendFlg = True
        'Else
        '  'Dim MoveFile As String = Path.GetDirectoryName(prmTargetFileName) & "\" & fileName
        '  'If IO.File.Exists(MoveFile) Then
        '  '  WriteProgressLog($"ファイル移動: {MoveFile} {prmTargetFileName} ")
        '  '  'MoveToBackupFolder(MoveFile)
        '  'End If
        'End If

      Loop

      Return True

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function

  Public Function WatchAndReceiveFiles(
    prmLastFileName As String,
    ByRef prmAllReceiveComplete As Boolean
) As Boolean

    Try
      If KANKYO_HONBAN <> "HONBAN" Then Return True

      'StopWatching()
      'StatusFlagFilePath = Path.Combine(TargetFolder, COMMUNICATION_FLG)

      Do While True
        Application.DoEvents()
        'Thread.Sleep(50)

        If IO.File.Exists(PROJECT_DIR_NAME & LAST_FILE_NAME) Then
          Exit Do
        End If


        '通信完了していれば終了
        'If EndComFlg Then
        '  Exit Do
        'End If

        'If IO.File.Exists(prmLastFileName) Then
        '  Exit Do
        'End If

        '' Communication.FLG 作成待ち
        '' ファイル名取得
        'Dim fileName As String = USE_FILE_NAME

        'WriteProgressLog($"ファイル名は？: {USE_FILE_NAME}")
        'If String.IsNullOrWhiteSpace(fileName) Then
        '  USE_FILE_NAME = ReadCommunicationFlag() 'Application.DoEvents()
        '  WriteProgressLog($"空のあとの取得ができたかどうか: {USE_FILE_NAME}")
        '  If String.IsNullOrWhiteSpace(USE_FILE_NAME) Then
        '    Continue Do
        '  Else
        '    fileName = USE_FILE_NAME
        '  End If
        'End If


        'WriteProgressLog($"FLG作成検知: {fileName}")



        '' Communication.FLG 削除待ち
        'If Not WaitCommunicationFlagDeleted() Then
        '  Return False
        'End If

        'WriteProgressLog($"FLG削除検知: {fileName}")


        '' DAT 実体が来るまで待つ
        'Dim datPath = Path.Combine(TargetFolder, fileName)
        'Dim timeout = 0
        'While Not IO.File.Exists(datPath)
        '  Thread.Sleep(20)
        '  timeout += 20
        '  If timeout > 5000 Then Exit While
        'End While

        'WriteProgressLog($"DAT検知: {fileName}")


        '' 最後のファイルなら終了
        'If fileName = Path.GetFileName(prmLastFileName) Then
        '  prmAllReceiveComplete = True
        '  Exit Do
        'Else
        '  'WriteProgressLog($"ファイル移動: {fileName} {prmLastFileName} ")
        '  'If IO.File.Exists(fileName) Then
        '  '  ' それ以外はバックアップへ
        '  '  'MoveToBackupFolder(fileName)
        '  'End If

        'End If

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
    AddHandler watcher.Changed, AddressOf OnFlagChanged
    AddHandler watcher.Deleted, AddressOf OnFlagDeleted

    watcher.EnableRaisingEvents = True
  End Sub

  Private Sub StopWatching()
    If watcher IsNot Nothing Then
      watcher.EnableRaisingEvents = False
      RemoveHandler watcher.Created, AddressOf OnFlagCreated
      RemoveHandler watcher.Changed, AddressOf OnFlagChanged
      RemoveHandler watcher.Deleted, AddressOf OnFlagDeleted
      watcher.Dispose()
      watcher = Nothing
    End If
    WriteProgressLog("ウォッチ終了")

  End Sub

  Private Sub OnFlagCreated(sender As Object, e As FileSystemEventArgs)
    Try
      'FlgHandySendStart = True
      If Path.GetFileName(e.FullPath) = COMMUNICATION_FLG Then
        ComFlgDel = False
      End If

      WriteProgressLog("Create時ファイル作成:" & e.FullPath)
      'For i As Integer = 1 To 10
      'USE_FILE_NAME = ReadCommunicationFlag()
      '  If Not String.IsNullOrWhiteSpace(USE_FILE_NAME) Then
      '    Exit For
      '  End If
      'Next

      USE_FILE_NAME = ReadCommunicationFlag()
      If (LAST_FILE_NAME = USE_FILE_NAME) Then
        EndFlg = True
      Else
        EndFlg = False
      End If

      WriteProgressLog("Create時ファイル内は、" & USE_FILE_NAME)

    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub

  Private Sub OnFlagChanged(sender As Object, e As FileSystemEventArgs)
    Dim InFileName As String = String.Empty
    Try
      'FlgHandySendStart = True
      WriteProgressLog("ファイル作成:" & e.FullPath)
      InFileName = ReadCommunicationFlag()
      If Not String.IsNullOrWhiteSpace(InFileName) Then
        USE_FILE_NAME = InFileName
        If (LAST_FILE_NAME = USE_FILE_NAME) Then
          EndFlg = True
        Else
          EndFlg = False
        End If

      End If
      WriteProgressLog("ファイル内は、" & USE_FILE_NAME)

      WriteProgressLog("ENDFLG" & EndFlg.ToString)
    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub

  Private Sub OnFlagDeleted(sender As Object, e As FileSystemEventArgs)
    Try
      WriteProgressLog("ファイル削除開始")
      ' 特に処理なし
      If Path.GetFileName(e.FullPath) = COMMUNICATION_FLG Then
        ComFlgDel = True
      End If

      WriteProgressLog("削除：" & Path.GetFileName(e.FullPath))

      If EndFlg Then
        WriteProgressLog("完了！ツール閉じます！")

        CloseCommunicationTool()
        EndComFlg = True
      End If

    Catch ex As Exception
      ComWriteErrLog(ex)

    End Try
  End Sub

  Public Sub MoveAllFile()
    ' DAT ファイルをすべてバックアップへ移動
    Dim folder As String = Me.TargetFolder

    For Each filePath In Directory.GetFiles(folder, "*.DAT")
      Dim fileName As String = Path.GetFileName(filePath)
      Me.MoveToBackupFolder(fileName)
    Next

  End Sub

End Class
