Imports Microsoft.Office.Interop

Public Class clsExcelReportBuilder
  Public Property Title As String
  Public Property Headers As List(Of String)
  Public Property Rows As List(Of Object())
  Public Property OutputPath As String
  Public Property IsTana As Boolean = False
  Public Property TanaDate As String
  Public Property WorkDate As String


  Public Property TitleFontSize As Integer = 28
  Public Property BodyFontSize As Integer = 13
  Public Property FontName As String = "メイリオ"

  Public Sub Build()

    Dim excelApp As New Excel.Application
    excelApp.Visible = False
    excelApp.ScreenUpdating = False
    excelApp.DisplayAlerts = False

    Dim wb As Excel.Workbook = excelApp.Workbooks.Add()
    Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

    Dim row As Integer = 1

    Try
      '===========================
      ' タイトル
      '===========================
      ws.Cells(row, 1).Value = Title
      ws.Range(ws.Cells(row, 1), ws.Cells(row, Headers.Count)).Merge()

      With ws.Cells(row, 1)
        .Font.Bold = True
        .Font.Size = TitleFontSize
        .Font.Name = FontName
        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
      End With

      row += 2

      '===========================
      ' 棚卸専用：棚卸日・作業予定日
      '===========================
      If IsTana Then
        ws.Cells(row, 1).Value = "棚卸日：" & TanaDate
        ws.Cells(row, 1).Font.Size = BodyFontSize
        ws.Cells(row, 1).Font.Name = FontName
        row += 1

        ws.Cells(row, 1).Value = "作業予定日：" & WorkDate
        ws.Cells(row, 1).Font.Size = BodyFontSize
        ws.Cells(row, 1).Font.Name = FontName
      End If

      '===========================
      ' 出力日時（ヘッダーの次の行・最後の列）
      '===========================
      ws.Cells(row, Headers.Count).Value =
                "出力日時：" & DateTime.Now.ToString("yyyy/MM/dd HH:mm")
      ws.Cells(row, Headers.Count).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
      ws.Cells(row, Headers.Count).Font.Size = BodyFontSize - 1
      ws.Cells(row, Headers.Count).Font.Name = FontName

      row += 1


      '===========================
      ' ヘッダー
      '===========================
      For i = 0 To Headers.Count - 1
        With ws.Cells(row, i + 1)
          .Value = Headers(i)
          .Font.Bold = True
          .Font.Size = BodyFontSize
          .Font.Name = FontName
          .Interior.Color = RGB(220, 230, 241)
          .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
          .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End With
      Next

      row += 1

      '===========================
      ' 明細（2次元配列で一括書き込み）
      '===========================
      Dim itemCount = Rows.Count
      Dim colCount = Headers.Count

      Dim data(itemCount - 1, colCount - 1) As Object

      For i = 0 To itemCount - 1
        Dim rowData = Rows(i)
        For c = 0 To colCount - 1
          data(i, c) = rowData(c)
        Next
      Next

      Dim startCell = ws.Cells(row, 1)
      Dim endCell = ws.Cells(row + itemCount - 1, colCount)
      Dim writeRange = ws.Range(startCell, endCell)

      ws.Cells.NumberFormat = "@"

      writeRange.Value = data
      writeRange.Font.Size = BodyFontSize
      writeRange.Font.Name = FontName

      With writeRange.Borders
        .LineStyle = Excel.XlLineStyle.xlContinuous
        .Weight = Excel.XlBorderWeight.xlThin
      End With

      row += itemCount + 2

      '===========================
      ' 列幅自動調整（共通ロジック）
      '===========================
      ws.Columns("A:Z").AutoFit()

      For col = 1 To colCount
        Dim headerText As String = Headers(col - 1)

        ' 商品列は広め
        If headerText.Contains("商品") OrElse headerText.Contains("規格") Then
          ws.Columns(col).ColumnWidth = 35
          ws.Columns(col).WrapText = True
          Continue For
        End If

        ' 発注先列は折り返し＋幅広
        If headerText.Contains("発注先") Then
          ws.Columns(col).ColumnWidth = 25
          ws.Columns(col).WrapText = True
          Continue For
        End If

        ' 名称系は中くらい
        If headerText.Contains("名称") Then
          ws.Columns(col).ColumnWidth = 20
          Continue For
        End If

        ' 数値列は狭め
        If headerText.Contains("数") OrElse headerText.Contains("入り数") Then
          ws.Columns(col).ColumnWidth = 12
          Continue For
        End If
      Next


      '===========================
      ' 印刷設定
      '===========================
      With ws.PageSetup
        .PaperSize = Excel.XlPaperSize.xlPaperA4
        .Orientation = Excel.XlPageOrientation.xlPortrait
        .Zoom = False
        .FitToPagesWide = 1
        .FitToPagesTall = False
        .LeftMargin = excelApp.InchesToPoints(0.3)
        .RightMargin = excelApp.InchesToPoints(0.3)
        .TopMargin = excelApp.InchesToPoints(0.5)
        .BottomMargin = excelApp.InchesToPoints(0.5)
        .CenterHorizontally = True
        .PrintGridlines = False
        .CenterFooter = "&P / &N"
      End With

      '===========================
      ' 保存
      '===========================
      wb.SaveAs(OutputPath)

      excelApp.ScreenUpdating = True
      excelApp.DisplayAlerts = True
      excelApp.Visible = True
      wb.Activate()

    Finally
      System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
      System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
      ws = Nothing
      wb = Nothing
      GC.Collect()
      GC.WaitForPendingFinalizers()
    End Try

  End Sub

End Class