Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class BtnOutput
  Inherits BtnBase

#Region "プライベート"
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
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    Select Case TargetKbn
      Case LayoutType.NYUKA
  '      NyukaPrint()
      Case LayoutType.TANA
    End Select



    '' Excel起動
    'Dim xlApp As New Microsoft.Office.Interop.Excel.Application
    'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(Me.TargetFormatFile)
    'Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlBook.Sheets(1)

    '' 基本情報例（必要に応じて）
    'xlSheet.Range("B3").Value = DateTime.Now.ToString("yyyy/MM/dd")   ' 入荷日
    'xlSheet.Range("B4").Value = "12345"                               ' 伝票番号
    'xlSheet.Range("B5").Value = "山田"                                ' 検品担当者

    '' Gridの内容をExcelに書き込む
    'Dim rowIndex As Integer = 8   ' Excelの開始行（ひな形に合わせて調整）
    'For Each row As DataGridViewRow In Me.TargetDataGridView.Rows
    '  If Not row.IsNewRow Then
    '    xlSheet.Cells(rowIndex, 1).Value = row.Cells("商品コード").Value
    '    xlSheet.Cells(rowIndex, 2).Value = row.Cells("商品名").Value
    '    xlSheet.Cells(rowIndex, 3).Value = row.Cells("規格").Value
    '    xlSheet.Cells(rowIndex, 4).Value = row.Cells("発注数量").Value
    '    xlSheet.Cells(rowIndex, 5).Value = row.Cells("入荷数量").Value
    '    xlSheet.Cells(rowIndex, 6).Value = row.Cells("備考").Value
    '    rowIndex += 1
    '  End If
    'Next

    '' 保存
    'Dim savePath As String = "D:\manna\HandySortingSys\REPORT\検品報告書_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".xlsx"
    'xlBook.SaveAs(savePath)

    '' 終了処理
    'xlBook.Close()
    'xlApp.Quit()

    MessageBox.Show("報告書を出力しました！" & vbCrLf & "D:\manna\HandySortingSys\REPORT\検品一覧表.xlsx")

  End Sub

  'Private Sub NyukaPrint()
  '  Dim excelApp As New Excel.Application
  '  Dim maxRowsPerPage As Integer = 40 ' 
  '  Dim currentPageRowCount As Integer = 0


  '  excelApp.Visible = False
  '  Dim wb = excelApp.Workbooks.Add()
  '  Dim ws = CType(wb.Sheets(1), Excel.Worksheet)

  '  Dim row = 1

  '  ' タイトル
  '  ' DataGridViewのデータをListに変換
  '  Dim list As New List(Of 検品データ)
  '  For Each r As DataGridViewRow In TargetDataGridView.Rows
  '    If Not r.IsNewRow Then
  '      list.Add(New 検品データ With {
  '              .発注先コード = r.Cells("発注先コード").Value?.ToString(),
  '              .発注先名 = r.Cells("発注先名").Value?.ToString(),
  '              .商品CD = r.Cells("自社商品コード").Value?.ToString(),
  '              .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
  '              .規格 = r.Cells("メーカー規格名").Value?.ToString(),
  '              .発注No = r.Cells("発注No").Value?.ToString(),
  '              .入荷予定数 = $"{r.Cells("入荷予定数_メーカー").Value}({r.Cells("入荷予定数_自社").Value})",
  '              .実績数 = $"{r.Cells("入荷実績数_メーカー").Value}({r.Cells("入荷実績数_自社").Value})",
  '              .賞味期限 = "",
  '              .入荷予定日 = r.Cells("入荷予定日").Value?.ToString(),
  '              .倉庫 = r.Cells("倉庫").Value?.ToString()
  '          })
  '    End If
  '  Next

  '  ' 発注先ごとにグループ化
  '  Dim grouped = list.GroupBy(Function(x) x.発注先コード)
  '  Dim groupList = grouped.ToList()

  '  ' ヘッダー情報（全体共通）
  '  Dim first = list.FirstOrDefault()
  '  If first IsNot Nothing Then
  '    OutCommonHeader(ws, row, currentPageRowCount, first)

  '  End If

  '  For j = 0 To groupList.Count - 1
  '    Dim group = groupList(j)
  '    first = group.First()

  '    Dim requiredRows As Integer = 1 + 1 + group.Count() + 1 + 1

  '    ' ヘッダー情報（発注先ごと）
  '    'ws.Cells(row, 1).Value = $"入荷予定日: {first.入荷予定日}"
  '    'row += 1
  '    'ws.Cells(row, 1).Value = $"倉庫: {first.倉庫}"
  '    'row += 1

  '    ' 改ページが必要ならここで追加
  '    If currentPageRowCount + requiredRows > maxRowsPerPage Then
  '      ws.HPageBreaks.Add(ws.Cells(row, 1))
  '      currentPageRowCount = 0
  '      OutCommonHeader(ws, row, currentPageRowCount, first)
  '    End If

  '    ' 発注先見出し
  '    ws.Cells(row, 1).Value = $"発注先: {first.発注先名}（{first.発注先コード}）"
  '    ws.Cells(row, 1).Font.Bold = True

  '    row += 1 : currentPageRowCount += 1

  '    ' 明細ヘッダー
  '    Dim headers = {"商品CD", "商品名", "規格", "発注No", "入荷予定数", "実績数", "賞味期限"}
  '    For k = 0 To headers.Length - 1
  '      ws.Cells(row, k + 1).Value = headers(k)
  '      ws.Cells(row, k + 1).Font.Bold = True
  '      ws.Cells(row, k + 1).Interior.Color = RGB(220, 230, 241)
  '      ws.Cells(row, k + 1).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
  '    Next
  '    row += 1 : currentPageRowCount += 1

  '    ' 明細行
  '    For Each item In group
  '      ws.Cells(row, 1).Value = item.商品CD
  '      ws.Cells(row, 2).Value = item.商品名
  '      ws.Cells(row, 3).Value = item.規格
  '      ws.Cells(row, 4).Value = item.発注No
  '      ws.Cells(row, 5).Value = item.入荷予定数
  '      ws.Cells(row, 6).Value = item.実績数
  '      ws.Cells(row, 7).Value = If(String.IsNullOrEmpty(item.賞味期限), "", item.賞味期限)
  '      For c = 1 To 7
  '        ws.Cells(row, c).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
  '      Next
  '      row += 1 : currentPageRowCount += 1
  '    Next

  '    ' 合計行
  '    ws.Cells(row, 1).Value = $"合計: {group.Count()} 件"
  '    ws.Cells(row, 1).Font.Bold = True
  '    row += 2 : currentPageRowCount += 2
  '  Next

  '  ws.Columns.AutoFit()

  '  ' 印刷設定
  '  With ws.PageSetup
  '    .PaperSize = Excel.XlPaperSize.xlPaperA4
  '    .Orientation = Excel.XlPageOrientation.xlLandscape
  '    .Zoom = False
  '    .FitToPagesWide = 1
  '    .FitToPagesTall = False
  '    .LeftMargin = excelApp.InchesToPoints(0.3)
  '    .RightMargin = excelApp.InchesToPoints(0.3)
  '    .TopMargin = excelApp.InchesToPoints(0.5)
  '    .BottomMargin = excelApp.InchesToPoints(0.5)
  '    .CenterHorizontally = True
  '    .CenterVertically = False
  '    .PrintGridlines = False
  '    .PrintTitleRows = "" ' タイトル行を各ページに表示（必要なら調整）
  '  End With

  '  Dim path = "D:\manna\HandySortingSys\REPORT\検品一覧表_ヘッダー付き.xlsx"
  '  wb.SaveAs(path)
  '  wb.Close(SaveChanges:=False)
  '  excelApp.Visible = True
  '  excelApp.Workbooks.Open(path)
  'End Sub

  'Sub OutCommonHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer, first As 検品データ)
  '  ws.Cells(row, 1).Value = "検品一覧表"
  '  ws.Range(ws.Cells(row, 1), ws.Cells(row, 7)).Merge()
  '  ws.Cells(row, 1).Font.Bold = True
  '  ws.Cells(row, 1).Font.Size = 14
  '  ws.Cells(row, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '  row += 2 : currentPageRowCount += 2

  '  ws.Cells(row, 1).Value = $"入荷予定日: {first.入荷予定日}"
  '  row += 1 : currentPageRowCount += 1
  '  ws.Cells(row, 1).Value = $"倉庫: {first.倉庫}"
  '  row += 1 : currentPageRowCount += 1
  'End Sub

  'Sub OutCommonHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer, first As 検品データ)
  '  ws.Cells(row, 1).Value = "検品一覧表"
  '  ws.Range(ws.Cells(row, 1), ws.Cells(row, 7)).Merge()
  '  ws.Cells(row, 1).Font.Bold = True
  '  ws.Cells(row, 1).Font.Size = 14
  '  ws.Cells(row, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '  row += 2 : currentPageRowCount += 2

  '  ws.Cells(row, 1).Value = $"入荷予定日: {first.入荷予定日}"
  '  row += 1 : currentPageRowCount += 1
  '  ws.Cells(row, 1).Value = $"倉庫: {first.倉庫}"
  '  row += 1 : currentPageRowCount += 1
  'End Sub

  '下記がA4縦でOKのもの

  'Private Sub NyukaPrint()
  '  Dim excelApp As New Excel.Application
  '  excelApp.Visible = False
  '  Dim wb = excelApp.Workbooks.Add()
  '  Dim ws = CType(wb.Sheets(1), Excel.Worksheet)

  '  Dim row As Integer = 1
  '  Dim maxRowsPerPage As Integer = 45
  '  Dim currentPageRowCount As Integer = 0

  '  ' 印刷設定（A4縦）
  '  With ws.PageSetup
  '    .PaperSize = Excel.XlPaperSize.xlPaperA4
  '    .Orientation = Excel.XlPageOrientation.xlPortrait
  '    .Zoom = False
  '    .FitToPagesWide = 1
  '    .FitToPagesTall = False
  '    .LeftMargin = excelApp.InchesToPoints(0.3)
  '    .RightMargin = excelApp.InchesToPoints(0.3)
  '    .TopMargin = excelApp.InchesToPoints(0.5)
  '    .BottomMargin = excelApp.InchesToPoints(0.5)
  '    .CenterHorizontally = True
  '    .PrintTitleRows = ""
  '  End With

  '  ' DataGridView からデータを抽出
  '  Dim dataList As New List(Of 検品データ)
  '  For Each r As DataGridViewRow In TargetDataGridView.Rows
  '    If Not r.IsNewRow Then
  '      dataList.Add(New 検品データ With {
  '              .発注先コード = r.Cells("発注先コード").Value?.ToString(),
  '              .発注先名 = r.Cells("発注先名").Value?.ToString(),
  '              .TEL = r.Cells("TEL").Value?.ToString(),
  '              .FAX = r.Cells("FAX").Value?.ToString(),
  '              .商品CD = r.Cells("自社商品コード").Value?.ToString(),
  '              .メーカー名 = r.Cells("メーカー名").Value?.ToString(),
  '              .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
  '              .棚番 = r.Cells("棚番").Value?.ToString(),
  '              .発注No = r.Cells("発注No").Value?.ToString(),
  '              .規格 = r.Cells("メーカー規格名").Value?.ToString(),
  '              .荷数 = r.Cells("荷数").Value?.ToString(),
  '              .入荷予定数 = $"{r.Cells("入荷予定数_メーカー").Value?.ToString()}{r.Cells("単位").Value?.ToString()}",
  '              .自社数量 = r.Cells("入荷予定数_自社").Value,
  '              .実績数 = $"{r.Cells("入荷実績数_メーカー").Value}{r.Cells("単位").Value?.ToString()}",
  '              .実績自社数 = r.Cells("入荷実績数_自社").Value,
  '              .賞味期限 = r.Cells("賞味期限").Value?.ToString(),
  '              .入荷予定日 = r.Cells("入荷予定日").Value?.ToString(),
  '              .倉庫 = r.Cells("倉庫").Value?.ToString()
  '          })
  '    End If
  '  Next

  '  ' 共通ヘッダー出力
  '  Dim first = dataList.FirstOrDefault()
  '  If first IsNot Nothing Then
  '    OutCommonHeader(ws, row, currentPageRowCount, first)
  '  End If

  '  ' 発送主ごとにグループ化
  '  Dim grouped = dataList.GroupBy(Function(x) x.発注先コード).ToList()

  '  For i = 0 To grouped.Count - 1
  '    Dim group = grouped(i)
  '    Dim firstGroup = group.First()

  '    Dim requiredRows = 1 + 1 + 2 + (group.Count() * 2) + 2
  '    If i > 0 AndAlso currentPageRowCount + requiredRows > maxRowsPerPage Then
  '      ws.HPageBreaks.Add(ws.Cells(row, 1))
  '      currentPageRowCount = 0
  '      OutCommonHeader(ws, row, currentPageRowCount, first)
  '    End If

  '    ' 発送主情報
  '    ws.Cells(row, 1).Value = $"発注先：{firstGroup.発注先コード}　{firstGroup.発注先名}"
  '    row += 1 : currentPageRowCount += 1
  '    ws.Cells(row, 1).Value = $"TEL: {firstGroup.TEL}　FAX: {firstGroup.FAX}"
  '    row += 1 : currentPageRowCount += 1

  '    ' 明細ヘッダー（2行構成）
  '    OutDetailHeader(ws, row, currentPageRowCount)

  '    ' 明細（2行で1件）
  '    For Each item In group
  '      ' 上段（row）
  '      ws.Cells(row, 1).Value = item.商品CD
  '      ws.Cells(row, 2).Value = item.メーカー名 ' 商品名は下段に
  '      ws.Cells(row, 3).Value = item.棚番
  '      ws.Cells(row, 4).Value = item.発注No
  '      ws.Cells(row, 5).Value = $"{item.入荷予定数}"
  '      ws.Cells(row, 6).Value = $"{item.実績数}" ' 例：10 C/S（自社数量）
  '      Dim shomikigen As String = String.Empty

  '      If item.賞味期限.Length = 8 Then
  '        shomikigen = item.賞味期限.Substring(0, 4) & "年" & item.賞味期限.Substring(4, 2) & "月" & item.賞味期限.Substring(6, 2) & "日"
  '      End If
  '      ws.Cells(row, 7).Value = shomikigen

  '      ' 下段（row+1）
  '      ws.Cells(row + 1, 1).Value = item.商品名
  '      ws.Cells(row + 1, 2).Value = "" ' 横結合で吸収される
  '      ws.Cells(row + 1, 3).Value = $"{item.規格}"
  '      ws.Cells(row + 1, 4).Value = $"{item.荷数}"
  '      ws.Cells(row + 1, 5).Value = $"{item.自社数量}"          ' 入荷予定の自社数量
  '      ws.Cells(row + 1, 6).Value = $"{item.自社数量}"          ' 実績の自社数量
  '      ws.Cells(row + 1, 7).Value = ""                           ' 縦結合で上段に吸収

  '      ' セル結合
  '      ws.Range(ws.Cells(row + 1, 1), ws.Cells(row + 1, 2)).Merge()   ' 下段：商品名（列1-2横結合）
  '      ws.Range(ws.Cells(row, 7), ws.Cells(row + 1, 7)).Merge()       ' 賞味期限（列7縦結合）

  '      ' 罫線・整形（上段：外枠＋上線、内側水平線なしのため下線は描かない）
  '      For c = 1 To 7
  '        With ws.Cells(row, c)
  '          .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone ' 内側水平線なし
  '          .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '          .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
  '          .WrapText = True
  '        End With
  '      Next

  '      ' 罫線・整形（下段：外枠＋下線、上線は非表示）
  '      For c = 1 To 7
  '        With ws.Cells(row + 1, c)
  '          .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone     ' 内側水平線なし
  '          .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
  '          .HorizontalAlignment = IIf(c = 3, Excel.XlHAlign.xlHAlignRight, Excel.XlHAlign.xlHAlignCenter)
  '          .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
  '          .WrapText = True
  '        End With
  '      Next

  '      ' 商品名セル（結合セル）の外周罫線補強
  '      With ws.Range(ws.Cells(row + 1, 1), ws.Cells(row + 1, 2))
  '        .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
  '        .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
  '      End With

  '      ' 賞味期限セル（結合セル）の右罫線補強
  '      With ws.Range(ws.Cells(row, 7), ws.Cells(row + 1, 7))
  '        .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
  '      End With

  '      ' 商品CDセルの → と ↓ を点線に
  '      With ws.Cells(row, 1).Borders
  '        .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlDot
  '        .Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
  '      End With

  '      ' 棚番セルの → と ↓ を点線に
  '      With ws.Cells(row, 3).Borders
  '        .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlDot
  '        .Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
  '      End With

  '      ' 規格名セル（下段・列3）の → を非表示
  '      With ws.Cells(row + 1, 3).Borders
  '        .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
  '      End With

  '      row += 2
  '      currentPageRowCount += 2
  '    Next

  '    ' 合計行
  '    ws.Cells(row, 1).Value = $"合計：{group.Count()} 件"
  '    ws.Cells(row, 1).Font.Bold = True
  '    row += 2 : currentPageRowCount += 2
  '  Next

  '  ' 列幅調整
  '  ws.Columns(1).ColumnWidth = 12 ' 商品CD
  '  ws.Columns(2).ColumnWidth = 25 ' メーカー名／商品名
  '  ws.Columns(3).ColumnWidth = 10 ' 棚番
  '  ws.Columns(4).ColumnWidth = 22 ' 発注No／規格・荷数
  '  ws.Columns(5).ColumnWidth = 18 ' 入荷予定数／自社数量
  '  ws.Columns(6).ColumnWidth = 18 ' 入荷実績数／自社数量
  '  ws.Columns(7).ColumnWidth = 15 ' 賞味期限

  '  ' 保存＆表示
  '  Dim path = "D:\manna\HandySortingSys\REPORT\NyukaPrint.xlsx"
  '  wb.SaveAs(path)
  '  wb.Close(SaveChanges:=False)
  '  excelApp.Visible = True
  '  excelApp.Workbooks.Open(path)
  'End Sub

  'Sub OutCommonHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer, first As 検品データ)
  '  ws.Cells(row, 1).Value = "検品一覧表"
  '  ws.Range(ws.Cells(row, 1), ws.Cells(row, 7)).Merge()
  '  With ws.Cells(row, 1)
  '    .Font.Bold = True
  '    .Font.Size = 14
  '    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '  End With
  '  row += 2 : currentPageRowCount += 2

  '  ws.Cells(row, 1).Value = $"入荷予定日: {first.入荷予定日}"
  '  row += 1 : currentPageRowCount += 1
  '  ws.Cells(row, 1).Value = $"倉庫: {first.倉庫}"
  '  row += 1 : currentPageRowCount += 1
  'End Sub

  'Sub OutDetailHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer)
  '  Dim headers = {
  '      "商品CD",
  '      "メーカー名／商品名",
  '      "棚番",
  '      "発注No／規格・荷数",
  '      "入荷予定数／自社数量",
  '      "入荷実績数／自社数量",
  '      "賞味期限"
  '  }

  '  Dim headerColor = RGB(220, 230, 241)

  '  For c = 1 To headers.Length
  '    With ws.Cells(row, c)
  '      .Value = headers(c - 1)
  '      .Font.Bold = True
  '      .Interior.Color = headerColor
  '      .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
  '      .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
  '      .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
  '      .WrapText = True
  '    End With
  '  Next

  '  row += 1
  '  currentPageRowCount += 1
  'End Sub



  Private Sub NyukaPrint()
    Dim excelApp As New Excel.Application
    Dim wb = excelApp.Workbooks.Add()
    Dim ws = CType(wb.Sheets(1), Excel.Worksheet)

    Try
      excelApp.Visible = False

      Dim row As Integer = 1
      Dim maxRowsPerPage As Integer = 45
      Dim currentPageRowCount As Integer = 0

      ' 印刷設定（A4縦）
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
        .PrintTitleRows = ""
      End With

      ' DataGridView からデータを抽出
      Dim dataList As New List(Of 検品データ)
      For Each r As DataGridViewRow In TargetDataGridView.Rows
        If Not r.IsNewRow Then
          dataList.Add(New 検品データ With {
                    .発注先コード = r.Cells("発注先コード").Value?.ToString(),
                    .発注先名 = r.Cells("発注先名").Value?.ToString(),
                    .TEL = r.Cells("TEL").Value?.ToString(),
                    .FAX = r.Cells("FAX").Value?.ToString(),
                    .商品CD = r.Cells("自社商品コード").Value?.ToString(),
                    .メーカー名 = r.Cells("メーカー名").Value?.ToString(),
                    .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
                    .棚番 = r.Cells("棚番").Value?.ToString(),
                    .発注No = r.Cells("発注No").Value?.ToString(),
                    .規格 = r.Cells("メーカー規格名").Value?.ToString(),
                    .荷数 = r.Cells("荷数").Value?.ToString(),
                    .入荷予定数 = $"{r.Cells("入荷予定数_メーカー").Value?.ToString()}{r.Cells("単位").Value?.ToString()}",
                    .自社数量 = r.Cells("入荷予定数_自社").Value,
                    .実績数 = $"{r.Cells("入荷実績数_メーカー").Value}{r.Cells("単位").Value?.ToString()}",
                    .実績自社数 = r.Cells("入荷実績数_自社").Value,
                    .賞味期限 = r.Cells("賞味期限").Value?.ToString(),
                    .入荷予定日 = r.Cells("入荷予定日").Value?.ToString(),
                    .倉庫 = r.Cells("倉庫").Value?.ToString(),
                    .温度帯 = r.Cells("温度帯").Value?.ToString()
                })
        End If
      Next

      ' 共通ヘッダー出力
      Dim first = dataList.FirstOrDefault()
      If first IsNot Nothing Then
        OutCommonHeader(ws, row, currentPageRowCount, first)
      Else
        Exit Sub
      End If

      ' 発注先ごとにグループ化
      Dim grouped = dataList.GroupBy(Function(x) New With {
            Key .温度帯 = If(String.IsNullOrEmpty(x.温度帯), "その他", x.温度帯),
            Key .発注先コード = x.発注先コード
        }).OrderBy(Function(g) g.Key.温度帯).
           ThenBy(Function(g) g.Key.発注先コード).
           ToList()

      For i = 0 To grouped.Count - 1
        Dim group = grouped(i)
        Dim firstGroup = group.First()

        Dim requiredRows = 1 + 1 + 2 + (group.Count() * 2) + 2
        If i > 0 AndAlso currentPageRowCount + requiredRows > maxRowsPerPage Then
          ws.HPageBreaks.Add(ws.Cells(row, 1))
          currentPageRowCount = 0
          OutCommonHeader(ws, row, currentPageRowCount, first)
        End If

        ' 発注先情報
        ws.Cells(row, 1).Value = $"発注先：{firstGroup.発注先コード}　{firstGroup.発注先名}"
        row += 1 : currentPageRowCount += 1
        ws.Cells(row, 1).Value = $"TEL: {firstGroup.TEL}　FAX: {firstGroup.FAX}"
        row += 1 : currentPageRowCount += 1

        ' 明細ヘッダー（2行構成）
        OutDetailHeader(ws, row, currentPageRowCount)

        Dim totalRows = group.Count() * 2
        Dim data(0 To totalRows - 1, 0 To 6) As Object
        Dim rr As Integer = 0

        For Each item In group
          ' 上段
          data(rr, 0) = item.商品CD
          data(rr, 1) = item.メーカー名
          data(rr, 2) = item.棚番
          data(rr, 3) = item.発注No
          data(rr, 4) = item.入荷予定数
          data(rr, 5) = item.実績数
          data(rr, 6) = FormatShomikigen(item.賞味期限)

          ' 下段
          data(rr + 1, 0) = item.商品名
          data(rr + 1, 1) = ""
          data(rr + 1, 2) = $"{item.規格}"
          data(rr + 1, 3) = If(item.荷数 = 0, "", $"{item.荷数}")
          data(rr + 1, 4) = $"{item.自社数量}"
          data(rr + 1, 5) = $"{item.実績自社数}"
          data(rr + 1, 6) = ""

          rr += 2
        Next

        ' 値の一括出力
        Dim startRow = row
        Dim endRow = row + totalRows - 1
        ws.Range(ws.Cells(startRow, 1), ws.Cells(endRow, 7)).Value = data

        ' セル結合（下段：商品名 1-2 横結合、賞味期限 7 縦結合）
        For j = 0 To group.Count() - 1
          Dim baseRow = startRow + j * 2
          ws.Range(ws.Cells(baseRow + 1, 1), ws.Cells(baseRow + 1, 2)).Merge()   ' 商品名
          ws.Range(ws.Cells(baseRow, 7), ws.Cells(baseRow + 1, 7)).Merge()       ' 賞味期限
        Next

        ' 罫線・整形（範囲でまとめてベース設定）
        With ws.Range(ws.Cells(startRow, 1), ws.Cells(endRow, 7))
          .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
          .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
          .WrapText = True
        End With

        ' 上段：外枠＋上線、下線なし（内側水平線なし）
        For rTop = startRow To endRow Step 2
          For c = 1 To 7
            With ws.Cells(rTop, c)
              .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
              .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
              .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
              .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            End With
          Next
          ' 商品CDセルの → と ↓ を点線に
          With ws.Cells(rTop, 1).Borders
            .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlDot
            .Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
          End With
          ' 棚番セルの → と ↓ を点線に
          With ws.Cells(rTop, 3).Borders
            .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlDot
            .Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
          End With
          ' 賞味期限セル（結合セル）の右罫線補強
          With ws.Range(ws.Cells(rTop, 7), ws.Cells(rTop + 1, 7))
            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
          End With
        Next

        ' 下段：外枠＋下線、上線なし（内側水平線なし）
        For rBottom = startRow + 1 To endRow Step 2
          For c = 1 To 7
            With ws.Cells(rBottom, c)
              .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
              .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
              .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone
              .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
              .HorizontalAlignment = If(c = 3, Excel.XlHAlign.xlHAlignRight, Excel.XlHAlign.xlHAlignCenter)
            End With
          Next
          ' 商品名セル（結合セル）の外周罫線補強（左・下）
          With ws.Range(ws.Cells(rBottom, 1), ws.Cells(rBottom, 2))
            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
          End With
          ' 規格名セル（下段・列3）の → を非表示
          With ws.Cells(rBottom, 3).Borders
            .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
          End With
        Next

        ' 行送り
        row = endRow + 1
        currentPageRowCount += totalRows

        ' 合計行
        ws.Cells(row, 1).Value = $"合計：{group.Count()} 件"
        ws.Cells(row, 1).Font.Bold = True
        row += 2 : currentPageRowCount += 2
      Next

      ' 列幅調整（従来どおり）
      ws.Columns(1).ColumnWidth = 12
      ws.Columns(2).ColumnWidth = 25
      ws.Columns(3).ColumnWidth = 13
      ws.Columns(4).ColumnWidth = 20
      ws.Columns(5).ColumnWidth = 18
      ws.Columns(6).ColumnWidth = 18
      ws.Columns(7).ColumnWidth = 15

      ' 保存＆表示（従来どおり）
      Dim path = "D:\manna\HandySortingSys\REPORT\NyukaPrint.xlsx"
      wb.SaveAs(path)
      wb.Close(SaveChanges:=False)
      excelApp.Visible = True
      excelApp.Workbooks.Open(path)
    Catch ex As Exception
    Finally
      ws = Nothing
      wb = Nothing
      excelApp = Nothing
    End Try

  End Sub

  Sub OutCommonHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer, first As 検品データ)
    ws.Cells(row, 1).Value = "検品一覧表"
    ws.Range(ws.Cells(row, 1), ws.Cells(row, 7)).Merge()
    With ws.Cells(row, 1)
      .Font.Bold = True
      .Font.Size = 14
      .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End With
    row += 2 : currentPageRowCount += 2

    ws.Cells(row, 1).Value = $"入荷予定日: {first.入荷予定日}"
    'row += 1 : currentPageRowCount += 1
    With ws.Cells(row, 7)
      .Value = $"倉庫: {first.倉庫}"
      .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    End With

    row += 1 : currentPageRowCount += 1
    ws.Cells(row, 1).Value = $"温度帯: {If(String.IsNullOrEmpty(first.温度帯), "その他", first.温度帯)}"
    row += 1 : currentPageRowCount += 1
  End Sub

  Sub OutDetailHeader(ws As Excel.Worksheet, ByRef row As Integer, ByRef currentPageRowCount As Integer)
    Dim headers = {
        "商品CD",
        "メーカー名／商品名",
        "棚番",
        "発注No／規格・荷数",
        "入荷予定数／自社数量",
        "入荷実績数／自社数量",
        "賞味期限"
    }

    Dim headerColor = RGB(220, 230, 241)

    For c = 1 To headers.Length
      With ws.Cells(row, c)
        .Value = headers(c - 1)
        .Font.Bold = True
        .Interior.Color = headerColor
        .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        .WrapText = True
      End With
    Next

    row += 1
    currentPageRowCount += 1
  End Sub

  Private Function FormatShomikigen(raw As String) As String
    If Not String.IsNullOrEmpty(raw) AndAlso raw.Length = 8 Then
      Return raw.Substring(0, 4) & "年" & raw.Substring(4, 2) & "月" & raw.Substring(6, 2) & "日"
    End If
    Return ""
  End Function

#End Region

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
    Public Property 荷数 As String
    Public Property 入荷予定数 As String
    Public Property 賞味期限 As String
    Public Property 入荷予定日 As String
    Public Property 自社数量 As String
    Public Property 倉庫 As String
    Public Property 実績数 As String
    Public Property 実績自社数 As String

    Public Property 温度帯 As String
  End Class
End Class