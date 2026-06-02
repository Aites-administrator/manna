Imports System.Text
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmNyukaImport
  Inherits FormBase

  Private Const TABLE_NAME As String = "TRN_NYUKA"

  Private Const CSV_TYPE As String = "入荷予定データ"
  Private Const DATE_LIST_TABLE_NAME As String = "NYUKA_DATE_LIST"
  Private SqlServer As New clsSqlServer

  Private Sub BtnInput1_Click(sender As Object, e As EventArgs) Handles BtnInput1.Click
    Dim dtNyukaData As New DataTable
    Dim ofd As New OpenFileDialog()

    Try

      'CSV取込
      ofd.Filter = "CSVファイル|*.csv|すべてのファイル|*.*"
      Dim result = ofd.ShowDialog(Me)

      ShowProcessing("データ取得中…")
      'DataTable変換
      If result = DialogResult.OK Then
        dtNyukaData = LoadCsvToDataTable(ofd.FileName)

        For Each row As DataRow In dtNyukaData.Rows
          row("取込状況FLG") = CInt(NYUKA_STATUS.TORIKOMIZUMI)
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

  Private Sub frmNyukaImport_Load(sender As Object, e As EventArgs) Handles Me.Load
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


  Private Function LoadCsvToDataTable(filePath As String) As DataTable
    Dim dt As New DataTable()
    Try
      Dim lines = IO.File.ReadAllLines(filePath, Encoding.GetEncoding("Shift-JIS"))
      If lines.Length = 0 Then Return dt

      Dim headers = lines(0).Split(","c)
      For Each h In headers
        dt.Columns.Add(RemoveQuotes(h))
      Next
      For i As Integer = 1 To lines.Length - 1
        Dim fields = lines(i).Split(","c)
        For j As Integer = 0 To fields.Length - 1
          fields(j) = RemoveQuotes(fields(j))
        Next
        dt.Rows.Add(fields)
      Next
      Return dt

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function

  Private Function RemoveQuotes(value As String) As String
    If String.IsNullOrEmpty(value) Then Return value

    ' 前後の " を削除
    If value.StartsWith("""") AndAlso value.EndsWith("""") Then
      value = value.Substring(1, value.Length - 2)
    End If

    ' CSV のエスケープ "" → "
    value = value.Replace("""""", """")
    Return value
  End Function


End Class
