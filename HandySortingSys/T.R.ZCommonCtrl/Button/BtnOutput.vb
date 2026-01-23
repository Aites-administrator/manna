Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class BtnOutput
  Inherits BtnBase

#Region "プライベート"
  Private Const REPORT_DIR_NAME As String = "REPORT\"
  Private Const REPORT_FILE_NAME As String = "入荷検品一覧表"
  Private SqlServer As New clsSqlServer

  Private Enum LayoutType
    NYUKA = 0
    TANA
  End Enum
#End Region

#Region "パブリック"
  ' プロパティ：フォーマットファイル
  Public Property TargetFormatFile As String

  ' プロパティ：出力データGrid
  Public Property TargetDataGridView As DataGridView

  ' プロパティ：出力データGrid
  Public Property TargetKbn As Integer
#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 取込ボタンボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("出力を行います。")

    Me.AccessKey = Keys.F5
    Me.BtnText = "報告書出力"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0

    MakeRoundedButton(Me, 20)

  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    Try
      Select Case TargetKbn
        Case LayoutType.NYUKA
          NyukaPrint()
        Case LayoutType.TANA
          TanaPrint()
      End Select

      UpdateTorikomiFlg(TargetKbn, TargetDataGridView)
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub

  'Private Sub NyukaPrint()
  '  Dim excelApp As New Excel.Application
  '  excelApp.Visible = False
  '  With excelApp
  '    .ScreenUpdating = False
  '    .DisplayAlerts = False
  '  End With

  '  Dim wb As Excel.Workbook = excelApp.Workbooks.Add()
  '  Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

  '  Dim row As Integer = 1

  '  Try
  '    ' タイトル行
  '    ws.Cells(row, 1).Value = "入荷検品一覧表"
  '    ws.Range(ws.Cells(row, 1), ws.Cells(row, 13)).Merge()
  '    With ws.Cells(row, 1)
  '      .Font.Bold = True
  '      .Font.Size = 16
  '      .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '    End With
  '    row += 2

  '    ' データ抽出
  '    Dim list As New List(Of 検品データ)
  '    For Each r As DataGridViewRow In TargetDataGridView.Rows
  '      If Not r.IsNewRow Then
  '        list.Add(New 検品データ With {
  '          .温度帯 = r.Cells("温度帯").Value?.ToString(),
  '          .発注No = r.Cells("発注No").Value?.ToString(),
  '          .行No = r.Cells("行NO").Value?.ToString(),
  '          .発注先コード = r.Cells("発注先コード").Value?.ToString(),
  '          .発注先名 = r.Cells("発注先名").Value?.ToString(),
  '          .商品CD = r.Cells("自社商品コード").Value?.ToString(),
  '          .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
  '          .規格 = r.Cells("メーカー規格名").Value?.ToString(),
  '          .荷数 = r.Cells("荷数").Value?.ToString(),
  '          .賞味期限 = r.Cells("賞味期限").Value?.ToString(),
  '          .入荷予定数 = Convert.ToInt32(r.Cells("入荷予定数_メーカー").Value),
  '          .入り数 = Convert.ToInt32(r.Cells("入り数").Value),
  '          .自社数量 = Convert.ToInt32(r.Cells("入荷予定数_自社").Value),
  '          .発注単位 = r.Cells("単位").Value?.ToString(),
  '          .検品結果 = r.Cells("検品結果").Value?.ToString()
  '        })
  '      End If
  '    Next

  '    ' 並べ替え（必要に応じて）
  '    list = list.OrderBy(Function(x) x.商品CD).ThenBy(Function(x) x.商品名).ThenBy(Function(x) x.発注No).ToList()

  '    ' ヘッダー
  '    Dim headers = {
  '      "チェック", "発注NO", "行NO", "発注先コード", "発注先名",
  '      "商品CD", "商品名/規格名", "荷数", "賞味期限",
  '      "自社数量", "入り数", "入荷予定数", "発注単位", "検品結果"
  '    }
  '    For i = 0 To headers.Length - 1
  '      With ws.Cells(row, i + 1)
  '        .Value = headers(i)
  '        .Font.Bold = True
  '        .Interior.Color = RGB(220, 230, 241)
  '        .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
  '        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '      End With
  '    Next
  '    row += 1

  '    ' 明細（2次元配列で一括書き込み）
  '    Dim itemCount = list.Count
  '    Dim data(itemCount - 1, 13) As Object

  '    For i = 0 To itemCount - 1
  '      Dim item = list(i)
  '      data(i, 0) = "□"
  '      data(i, 1) = item.発注No
  '      data(i, 2) = item.行No
  '      data(i, 3) = item.発注先コード
  '      data(i, 4) = item.発注先名
  '      data(i, 5) = item.商品CD
  '      data(i, 6) = item.商品名 & vbLf & item.規格
  '      data(i, 7) = item.荷数
  '      data(i, 8) = FormatShomikigen(item.賞味期限)
  '      data(i, 9) = item.自社数量
  '      data(i, 10) = item.入り数
  '      data(i, 11) = item.入荷予定数
  '      data(i, 12) = item.発注単位
  '      data(i, 13) = item.検品結果
  '    Next

  '    Dim startCell = ws.Cells(row, 1)
  '    Dim endCell = ws.Cells(row + itemCount - 1, 14)
  '    Dim writeRange = ws.Range(startCell, endCell)
  '    writeRange.Value = data

  '    ' WrapText設定
  '    ws.Range(ws.Cells(row, 7), ws.Cells(row + itemCount - 1, 7)).WrapText = True
  '    For col = 1 To 14
  '      If col <> 7 Then
  '        ws.Range(ws.Cells(row, col), ws.Cells(row + itemCount - 1, col)).WrapText = False
  '      End If
  '    Next

  '    ' 罫線
  '    With writeRange.Borders
  '      .LineStyle = Excel.XlLineStyle.xlContinuous
  '      .Weight = Excel.XlBorderWeight.xlThin
  '    End With

  '    row += itemCount + 2

  '    ' 整形
  '    ws.Cells.Font.Size = 9
  '    ws.Columns("A:F").AutoFit()
  '    ws.Columns("G").ColumnWidth = 30
  '    ws.Columns("H:M").AutoFit()

  '    ' 印刷設定
  '    With ws.PageSetup
  '      .PaperSize = Excel.XlPaperSize.xlPaperA4
  '      .Orientation = Excel.XlPageOrientation.xlPortrait
  '      .Zoom = False
  '      .FitToPagesWide = 1
  '      .FitToPagesTall = False
  '      .LeftMargin = excelApp.InchesToPoints(0.3)
  '      .RightMargin = excelApp.InchesToPoints(0.3)
  '      .TopMargin = excelApp.InchesToPoints(0.5)
  '      .BottomMargin = excelApp.InchesToPoints(0.5)
  '      .CenterHorizontally = True
  '      .PrintGridlines = False
  '    End With

  '    ' 保存＆表示
  '    Dim path = PROJECT_DIR_NAME & REPORT_DIR_NAME
  '    If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
  '    path &= REPORT_FILE_NAME & "_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"
  '    wb.SaveAs(path)

  '    With excelApp
  '      .ScreenUpdating = True
  '      .DisplayAlerts = True
  '      .Visible = True
  '      wb.Activate()
  '    End With

  '  Catch ex As Exception
  '    Throw New Exception(ex.Message)
  '  Finally
  '    ' メモリ解放（Excelは開いたまま）
  '    System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
  '    System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
  '    ws = Nothing
  '    wb = Nothing
  '    GC.Collect()
  '    GC.WaitForPendingFinalizers()
  '  End Try
  'End Sub
  Private Sub NyukaPrint()
    Dim excelApp As New Excel.Application
    excelApp.Visible = False
    With excelApp
      .ScreenUpdating = False
      .DisplayAlerts = False
    End With

    Dim wb As Excel.Workbook = excelApp.Workbooks.Add()
    Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

    Dim row As Integer = 1

    Try
      ' タイトル行（1行目）
      ws.Cells(row, 1).Value = "入荷検品書"
      ws.Range(ws.Cells(row, 1), ws.Cells(row, 11)).Merge()
      With ws.Cells(row, 1)
        .Font.Bold = True
        .Font.Size = 28
        .Font.Name = "メイリオ"
        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
      End With
      ws.Rows(row).RowHeight = 30
      row += 1

      ' ★ 出力日時は後で書くため、ここでは row だけ進める
      Dim outputDateRow As Integer = row
      row += 1

      ' データ抽出
      Dim list As New List(Of 検品データ)
      For Each r As DataGridViewRow In TargetDataGridView.Rows
        If Not r.IsNewRow Then
          list.Add(New 検品データ With {
                    .温度帯 = r.Cells("温度帯").Value?.ToString(),
                    .発注No = r.Cells("発注No").Value?.ToString(),
                    .行No = r.Cells("行NO").Value?.ToString(),
                    .発注先コード = r.Cells("発注先コード").Value?.ToString(),
                    .発注先名 = r.Cells("発注先名").Value?.ToString(),
                    .商品CD = r.Cells("自社商品コード").Value?.ToString(),
                    .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
                    .規格 = r.Cells("メーカー規格名").Value?.ToString(),
                    .荷数 = r.Cells("荷数").Value?.ToString(),
                    .賞味期限 = r.Cells("賞味期限").Value?.ToString(),
                    .入荷予定数 = Convert.ToInt32(r.Cells("入荷予定数_メーカー").Value),
                    .入り数 = Convert.ToInt32(r.Cells("入り数").Value),
                    .自社数量 = Convert.ToInt32(r.Cells("入荷予定数_自社").Value),
                    .発注単位 = r.Cells("単位").Value?.ToString(),
                    .検品結果 = r.Cells("検品結果").Value?.ToString()
                })
        End If
      Next

      ' 並べ替え
      list = list.OrderBy(Function(x) x.商品CD).ThenBy(Function(x) x.商品名).ThenBy(Function(x) x.発注No).ToList()

      ' ヘッダー
      Dim headers = {
            "発注NO", "行NO", "発注先", "商品", "荷数", "賞味期限",
            "自社数量", "入り数", "入荷予定数", "発注単位", "検品結果"
        }
      For i = 0 To headers.Length - 1
        With ws.Cells(row, i + 1)
          .Value = headers(i)
          .Font.Bold = True
          .Font.Size = 13
          .Font.Name = "メイリオ"
          .Interior.Color = RGB(220, 230, 241)
          .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
          .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With
      Next
      row += 1

      ' 明細（2次元配列で一括書き込み）
      Dim itemCount = list.Count
      Dim data(itemCount - 1, 10) As Object

      For i = 0 To itemCount - 1
        Dim item = list(i)
        data(i, 0) = item.発注No
        data(i, 1) = item.行No
        data(i, 2) = item.発注先コード & vbLf & item.発注先名
        data(i, 3) = item.商品CD & vbLf & item.商品名 & " " & item.規格
        data(i, 4) = item.荷数
        data(i, 5) = FormatShomikigen(item.賞味期限)
        data(i, 6) = item.自社数量
        data(i, 7) = item.入り数
        data(i, 8) = item.入荷予定数
        data(i, 9) = item.発注単位
        data(i, 10) = item.検品結果
      Next

      Dim startCell = ws.Cells(row, 1)
      Dim endCell = ws.Cells(row + itemCount - 1, 11)
      Dim writeRange = ws.Range(startCell, endCell)
      writeRange.Value = data
      writeRange.Font.Size = 13
      writeRange.Font.Name = "メイリオ"

      ' WrapText設定
      ws.Range(ws.Cells(row, 3), ws.Cells(row + itemCount - 1, 4)).WrapText = True

      ' 罫線
      With writeRange.Borders
        .LineStyle = Excel.XlLineStyle.xlContinuous
        .Weight = Excel.XlBorderWeight.xlThin
      End With

      row += itemCount + 2

      ' 全体フォント設定
      With ws.Cells.Font
        .Name = "メイリオ"
        .Size = 13
      End With

      ' タイトル行のフォント再設定
      With ws.Cells(1, 1)
        .Font.Size = 28
        .Font.Bold = True
      End With
      ws.Rows(1).RowHeight = 30

      ' ★ AutoFit を先に実行（出力日時はまだ入れていない）
      ws.Columns("A:B").AutoFit()
      ws.Columns("C").ColumnWidth = 30
      ws.Columns("D").ColumnWidth = 30
      ws.Columns("E:K").AutoFit()




      ' ★ AutoFit 後に出力日時を書き込む（列幅に影響しない）
      With ws.Cells(outputDateRow, 11)
        .Value = "出力日時：" & Format(Now, "yyyy/MM/dd HH:mm")
        .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        .Font.Size = 12          ' ← 少し大きく
        .Font.Name = "メイリオ"
        .ShrinkToFit = False     ' ← はみ出しOK
      End With

      ' 印刷設定
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

      ' 保存＆表示
      Dim path = PROJECT_DIR_NAME & REPORT_DIR_NAME
      If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
      path &= REPORT_FILE_NAME & "_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx"
      wb.SaveAs(path)

      With excelApp
        .ScreenUpdating = True
        .DisplayAlerts = True
        .Visible = True
        wb.Activate()
      End With

    Catch ex As Exception
      Throw New Exception(ex.Message)
    Finally
      System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
      System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
      ws = Nothing
      wb = Nothing
      GC.Collect()
      GC.WaitForPendingFinalizers()
    End Try
  End Sub

  Private Sub TanaPrint()

    Dim excelApp As New Excel.Application
    excelApp.Visible = False
    With excelApp
      .ScreenUpdating = False
      .DisplayAlerts = False
    End With

    Dim wb As Excel.Workbook = excelApp.Workbooks.Add()
    Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

    Dim row As Integer = 1

    Try
      '===============================
      ' ① タイトル行
      '===============================
      ws.Cells(row, 1).Value = "棚卸調査票"
      ws.Range(ws.Cells(row, 1), ws.Cells(row, 15)).Merge()

      With ws.Cells(row, 1)
        .Font.Bold = True
        .Font.Size = 32
        .Font.Name = "メイリオ"
        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
      End With
      ws.Rows(row).RowHeight = 40
      row += 1

      '===============================
      ' ② DataGridView → List 変換
      '===============================
      Dim list As New List(Of Object)

      For Each r As DataGridViewRow In TargetDataGridView.Rows
        If Not r.IsNewRow Then
          list.Add(New With {
                    .棚卸日 = r.Cells("棚卸日").Value?.ToString(),
                    .作業予定日 = r.Cells("作業予定日").Value?.ToString(),
                    .棚番エリア = r.Cells("棚番エリア").Value?.ToString(),
                    .自社商品コード = r.Cells("自社商品コード").Value?.ToString(),
                    .商品名 = r.Cells("商品名").Value?.ToString(),
                    .入り数 = r.Cells("入り数").Value,
                    .在庫予定ケース = r.Cells("在庫予定数_ケース数").Value,
                    .ケース単位_予定 = r.Cells("ケース単位_予定").Value?.ToString(),
                    .在庫予定バラ = r.Cells("在庫予定数_バラ数").Value,
                    .バラ単位_予定 = r.Cells("バラ単位_予定").Value?.ToString(),
                    .在庫実績ケース = r.Cells("在庫実績数_ケース数").Value,
                    .ケース単位_実績 = r.Cells("ケース単位_実績").Value?.ToString(),
                    .在庫実績バラ = r.Cells("在庫実績数_バラ数").Value,
                    .バラ単位_実績 = r.Cells("バラ単位_実績").Value?.ToString(),
                    .賞味期限 = r.Cells("賞味期限").Value?.ToString()
                })
        End If
      Next

      '===============================
      ' ③ 棚卸日・作業予定日（ヘッダ）
      '===============================
      If list.Count > 0 Then
        ws.Cells(row, 1).Value = "棚卸日：" & list(0).棚卸日
        ws.Cells(row, 5).Value = "作業予定日：" & list(0).作業予定日

        ws.Range(ws.Cells(row, 1), ws.Cells(row, 5)).Font.Size = 14
        ws.Range(ws.Cells(row, 1), ws.Cells(row, 5)).Font.Name = "メイリオ"
      End If
      row += 2

      '===============================
      ' ④ 一覧ヘッダ
      '===============================
      Dim headers = {
            "棚番エリア",
            "自社商品コード",
            "商品名",
            "入り数",
            "在庫予定数(ケース)",
            "ケース単位",
            "在庫予定数(バラ数)",
            "バラ単位",
            "在庫実績数(ケース)",
            "ケース単位",
            "在庫実績数(バラ)",
            "バラ単位",
            "賞味期限"
        }

      For i = 0 To headers.Length - 1
        With ws.Cells(row, i + 1)
          .Value = headers(i)
          .Font.Bold = True
          .Font.Size = 14
          .Font.Name = "メイリオ"
          .Interior.Color = RGB(200, 220, 240)
          .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
          .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
          .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End With
      Next
      ws.Rows(row).RowHeight = 25
      row += 1

      '===============================
      ' ⑤ 明細（2次元配列で一括書き込み）
      '===============================
      Dim itemCount = list.Count
      Dim data(itemCount - 1, 12) As Object

      ' ★ A列を文字列扱いに固定（Excel の暴走防止）
      ws.Columns("A").NumberFormat = "@"

      For i = 0 To itemCount - 1
        Dim item = list(i)

        ' ★ 棚番は絶対に文字列扱い
        data(i, 0) = "'" & item.棚番エリア

        data(i, 1) = item.自社商品コード
        data(i, 2) = SplitProductName(item.商品名)   ' ★ 長いときだけ 2 行
        data(i, 3) = item.入り数
        data(i, 4) = item.在庫予定ケース
        data(i, 5) = item.ケース単位_予定
        data(i, 6) = item.在庫予定バラ
        data(i, 7) = item.バラ単位_予定
        data(i, 8) = item.在庫実績ケース
        data(i, 9) = item.ケース単位_実績
        data(i, 10) = item.在庫実績バラ
        data(i, 11) = item.バラ単位_実績
        data(i, 12) = item.賞味期限
      Next

      Dim startCell = ws.Cells(row, 1)
      Dim endCell = ws.Cells(row + itemCount - 1, 13)
      Dim writeRange = ws.Range(startCell, endCell)

      writeRange.Value = data
      writeRange.Font.Size = 13
      writeRange.Font.Name = "メイリオ"

      With writeRange.Borders
        .LineStyle = Excel.XlLineStyle.xlContinuous
        .Weight = Excel.XlBorderWeight.xlThin
      End With

      ' ★ 商品名列は折り返し
      ws.Columns("C").WrapText = True
      ws.Columns("C").ColumnWidth = 30

      row += itemCount + 2

      '===============================
      ' ⑥ 列幅調整
      '===============================
      ws.Columns("A:M").AutoFit()
      ws.Columns("A").ColumnWidth = 12

      '===============================
      ' ⑦ 印刷設定
      '===============================
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

      '===============================
      ' ⑧ 保存＆表示
      '===============================
      Dim path = PROJECT_DIR_NAME & REPORT_DIR_NAME
      If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
      path &= "棚卸調査票_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

      wb.SaveAs(path)

      With excelApp
        .ScreenUpdating = True
        .DisplayAlerts = True
        .Visible = True
        wb.Activate()
      End With

    Catch ex As Exception
      Throw New Exception(ex.Message)

    Finally
      System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
      System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
      ws = Nothing
      wb = Nothing
      GC.Collect()
      GC.WaitForPendingFinalizers()
    End Try

  End Sub


  '===============================
  ' ★ 商品名を長いときだけ 2 行にする関数
  '===============================
  Private Function SplitProductName(name As String) As String
    If String.IsNullOrEmpty(name) Then Return ""

    Const limit As Integer = 15

    If name.Length <= limit Then
      Return name
    End If

    Return name.Substring(0, limit) & vbLf & name.Substring(limit)
  End Function

#End Region


  Private Function FormatShomikigen(raw As String) As String
    If String.IsNullOrEmpty(raw) OrElse raw.Length <> 8 Then Return ""
    Return $"{raw.Substring(0, 4)}年{raw.Substring(4, 2)}月{raw.Substring(6, 2)}日"
  End Function

  Private Sub UpdateTorikomiFlg(prmLayoutType As LayoutType, prmDataGridView As DataGridView)
    Try
      For Each DataGridViewRow In TargetDataGridView.Rows
        SqlServer.Execute(If(prmLayoutType = LayoutType.NYUKA, SqlUpdNyuka(DataGridViewRow), SqlUpDateTana(DataGridViewRow)))
      Next
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub

  Private Function SqlUpdNyuka(prmDataRow As DataGridViewRow) As String
    Dim sql As String = String.Empty
    sql += " UPDATE TRN_NYUKA"
    sql += " SET TORIKOMI_JOKYO_FLG = " & CInt(NYUKA_STATUS.SHUTSURYOKUZUMI)
    sql += " , OUTPUT_DATE = '" & ComGetProcTime() & "'"
    sql += " WHERE NYUKA_YOTEI_DATE = '" & prmDataRow.Cells("入荷予定日").Value & "'"
    sql += " AND HACHU_NO = '" & prmDataRow.Cells("発注NO").Value & "'"
    sql += " AND GYO_NO = '" & prmDataRow.Cells("行NO").Value & "'"

    Return sql

  End Function

  Private Function SqlUpDateTana(prmDataRow As DataGridViewRow) As String
    Dim sql As String = String.Empty
    sql += " UPDATE TRN_TANAOROSHI"
    sql += " SET TORIKOMI_JOKYO_FLG = " & CInt(TANAOROSHI_STATUS.SHUTURYOKUZUMI)
    sql += " , OUTPUT_DATE = '" & ComGetProcTime() & "'"
    sql += " WHERE TANAOROSHI_DATE = '" & prmDataRow.Cells("棚卸日").Value & "'"
    sql += " AND SAGYO_YOTEI_DATE = '" & prmDataRow.Cells("作業予定日").Value & "'"
    sql += " AND JISYA_SHOHIN_CD = '" & prmDataRow.Cells("自社商品コード").Value & "'"
    Return sql

  End Function

  Public Class 検品データ
    Public Property 発注先コード As String
    Public Property 発注先名 As String
    Public Property TEL As String
    Public Property FAX As String
    Public Property 商品CD As String
    Public Property メーカー名 As String
    Public Property 商品名 As String
    Public Property 棚番 As String
    Public Property 規格 As String
    Public Property 発注No As String
    Public Property 行No As String
    Public Property 荷数 As String
    Public Property 入荷予定数 As String
    Public Property 賞味期限 As String
    Public Property 入荷予定日 As String
    Public Property 自社数量 As String
    Public Property 入り数 As String
    Public Property 実績数 As String
    Public Property 実績自社数 As String
    Public Property 発注単位 As String
    Public Property 温度帯 As String
    Public Property 検品結果 As String
  End Class
End Class