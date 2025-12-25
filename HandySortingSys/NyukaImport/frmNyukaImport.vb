Imports System.Text
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmNyukaImport
  Inherits FormBase

  Private Const TABLE_NAME As String = "TRN_NYUKA"

  Private Const CSV_TYPE As String = "入荷予定データ"

  Private Sub BtnInput1_Click(sender As Object, e As EventArgs) Handles BtnInput1.Click
    Dim dtNyukaData As New DataTable
    Dim ofd As New OpenFileDialog()

    Try
      'CSV取込
      ofd.Filter = "CSVファイル|*.csv|すべてのファイル|*.*"
      Dim result = ofd.ShowDialog(Me)

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
      End If
    Catch ex As Exception
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
        dt.Rows.Add(lines(i).Split(","c))
      Next
      Return dt

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function

End Class
