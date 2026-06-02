Imports System.Text
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl
Imports ClosedXML.Excel
Imports System.IO

Public Class frmTanaoroshiImport
  Inherits FormBase

  Private Const TABLE_NAME As String = "TRN_TANAOROSHI"

  Private Const CSV_TYPE As String = "棚卸予定データ"

  Private Const CSV_FILE_NAME As String = "tanaoroshi.csv"

  Private Const CSV_COL_COUNT As Integer = 16

  Private Const DATE_LIST_TABLE_NAME As String = "TANAOROSHI_DATE_LIST"
  Private SqlServer As New clsSqlServer


  Private Sub BtnInput1_Click(sender As Object, e As EventArgs) Handles BtnInput1.Click
    Dim dtNyukaData As New DataTable
    Dim ofd As New OpenFileDialog()

    Try
      'CSV取込
      ofd.Filter = "Excelファイル (*.xlsx;*.xls)|*.xlsx;*.xls|CSVファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"
      Dim result = ofd.ShowDialog(Me)

      ShowProcessing("データ取得中…")
      'DataTable変換
      If result = DialogResult.OK Then
        ExcelToCsv(ofd.FileName, System.IO.Path.GetDirectoryName(ofd.FileName) & "\" & CSV_FILE_NAME, CSV_COL_COUNT)

        dtNyukaData = LoadCsvToDataTable(System.IO.Path.GetDirectoryName(ofd.FileName) & "\" & CSV_FILE_NAME)

        dtNyukaData.Columns.Add("取込状況FLG")

        For Each row As DataRow In dtNyukaData.Rows
          row("取込状況FLG") = CInt(TANAOROSHI_STATUS.TORIKOMIZUMI)
        Next
        '値設定
        BtnInput1.TargetDataTable = dtNyukaData
        BtnInput1.TargetTableName = TABLE_NAME
        BtnInput1.TargetCsvType = CSV_TYPE
        DgvList1.SetData(dtNyukaData)
      Else
        HideProcessing()
      End If
    Catch ex As Exception
      HideProcessing()
      ComWriteErrLog(ex, False)
    End Try


  End Sub

  Private Function LoadCsvToDataTable(filePath As String) As DataTable
    Dim dt As New DataTable()
    Try
      Dim lines = IO.File.ReadAllLines(filePath, Encoding.GetEncoding("Shift-JIS"))
      If lines.Length = 0 Then Return dt

      Dim headers = lines(0).Split(","c)
      For Each h In headers
        dt.Columns.Add(h)
      Next

      For i As Integer = 1 To lines.Length - 1
        Dim cols = lines(i).Split(","c)

        Dim irisuIndex = Array.IndexOf(headers, "入数")
        If irisuIndex >= 0 Then
          Dim raw = cols(irisuIndex).Trim()

          If raw = "" OrElse raw = "#N/A" Then
            cols(irisuIndex) = "1"
          End If
        End If

        dt.Rows.Add(cols)
      Next

      Return dt

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function



  Public Sub ExcelToCsv(excelPath As String, csvPath As String, colCount As Integer)

    Using wb As New XLWorkbook(excelPath)
      Dim ws = wb.Worksheet(1)

      Using sw As New StreamWriter(csvPath, False, Encoding.GetEncoding("Shift-JIS"))
        For Each row In ws.RangeUsed().Rows()
          Dim values As New List(Of String)

          For col = 1 To colCount
            Dim cell = row.Cell(col)
            values.Add(cell.GetValue(Of String)())
          Next

          sw.WriteLine(String.Join(",", values))
        Next
      End Using
    End Using

    ' ▼ bk フォルダへ移動
    Dim srcDir As String = Path.GetDirectoryName(excelPath)
    Dim bkDir As String = Path.Combine(srcDir, "bk")

    If Not Directory.Exists(bkDir) Then
      Directory.CreateDirectory(bkDir)
    End If

    Dim destPath As String = Path.Combine(bkDir, Path.GetFileName(excelPath))

    If File.Exists(destPath) Then
      File.Delete(destPath)
    End If

    'File.Move(excelPath, destPath)

  End Sub

  Private Sub frmTanaoroshiImport_Load(sender As Object, e As EventArgs) Handles Me.Load
    AddHandler BtnInput1.InputCompleted, AddressOf InputReceiveProcess
  End Sub

  Private Sub InputReceiveProcess()
    '日付登録
    Try

      SqlServer.Execute(BtnInput.SqlInsDateList(DATE_LIST_TABLE_NAME, BtnInput.DATE_LIST))
      SqlServer.Execute(BtnInput.SqlDelDateList(DATE_LIST_TABLE_NAME))

    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub

End Class
