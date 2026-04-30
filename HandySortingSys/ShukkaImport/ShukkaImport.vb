Imports System.Text
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class ShukkaImport
  Inherits FormBase


  Private Const TABLE_NAME As String = "TRN_SHUKKA"

  Private Const CSV_TYPE As String = "出荷データ"

  Private Sub BtnInput1_Click(sender As Object, e As EventArgs) Handles BtnInput1.Click
    Dim dtShukkaData As New DataTable
    Dim ofd As New OpenFileDialog()

    Try
      'CSV取込
      ofd.Filter = "CSVファイル|*.csv|すべてのファイル|*.*"
      Dim result = ofd.ShowDialog(Me)

      'DataTable変換
      If result = DialogResult.OK Then
        dtShukkaData = LoadCsvToDataTable(ofd.FileName)

        dtShukkaData.Columns.Add("取込状況FLG")
        For Each row As DataRow In dtShukkaData.Rows
          row("取込状況FLG") = CInt(NYUKA_STATUS.TORIKOMIZUMI)
        Next
        '値設定
        BtnInput1.TargetDataTable = dtShukkaData
        BtnInput1.TargetTableName = TABLE_NAME
        BtnInput1.TargetCsvType = CSV_TYPE
        DgvList1.SetData(dtShukkaData)
      End If
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try


  End Sub

  ''' <summary>
  ''' 販売実績ファイル取込
  ''' </summary>
  ''' <param name="filePath">取込対象CSVファイルパス</param>
  ''' <remarks>
  '''   以下のいづれかの条件に一致する行を取込
  '''   ・[発注区分] = [在庫品]
  '''   ・[発注区分] = [スルー品]
  '''         かつ [発注書区分] = [総量発注書のみで発注] 
  ''' </remarks>
  ''' <returns>CSVの内容を保持したdatatable</returns>
  Private Function LoadCsvToDataTable(filePath As String) As DataTable
    Dim dt As New DataTable()

    Try
      Dim lines = IO.File.ReadAllLines(filePath, Encoding.GetEncoding("Shift-JIS"))
      If lines.Length = 0 Then Return dt

      Dim headers = lines(0).Split(","c)
      For Each h In headers
        dt.Columns.Add(h)
      Next

      ' フィルター対象の列インデックスを取得
      Dim tmpOrderClassIdx As Integer = Array.IndexOf(headers, "発注区分")
      Dim tmpOrderPaperClass As Integer = Array.IndexOf(headers, "発注書区分")


      For i As Integer = 1 To lines.Length - 1
        Dim values = lines(i).Split(","c)
        If values.Length <> headers.Length Then Continue For ' 列数不一致はスキップ

        If values(tmpOrderClassIdx).Trim = "在庫品".Trim Then
          ' 発注区分が在庫品
          dt.Rows.Add(values)
        ElseIf values(tmpOrderClassIdx).Trim = "スルー品".Trim _
                And values(tmpOrderPaperClass).Trim = "総量発注書のみで発注".Trim Then
          '発注区分がスルー品 かつ 発注書区分が総量発注書のみで発注 
          dt.Rows.Add(values)
        ElseIf values(tmpOrderClassIdx).Trim = "事業所直送".Trim _
                And values(tmpOrderPaperClass).Trim = "総量発注書のみで発注".Trim Then
          '発注区分が事業所直送 かつ 発注書区分が総量発注書のみで発注 
          dt.Rows.Add(values)
        End If

      Next

      Return dt

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Function




End Class
