Imports System.Data
Imports Microsoft.Office.Interop
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports System.IO

Public Class BtnInput
  Inherits BtnBase

#Region "プライベート"
  Private Const MASTER_DIR As String = "MASTER\"
  Private SqlServer As New clsSqlServer

#End Region

#Region "パブリック"
  ' プロパティ：登録対象のDataTable
  Public Property TargetDataTable As DataTable

  ' プロパティ：登録先テーブル名
  Public Property TargetTableName As String
  ' プロパティ：CSVタイプ
  Public Property TargetCsvType As String

  Private SHOHIN_CD As String = "自社商品CD"
  Private SHOHIN_NM As String = ""


#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 取込ボタンボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("取込を行います。")

    Me.AccessKey = Keys.F1
    Me.BtnText = "取込"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
    Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0


    MakeRoundedButton(Me, 20)
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)
    Dim mapper As New clsMapping
    Dim mapping As New Dictionary(Of String, String)
    Dim TargetRowData As New Dictionary(Of String, String)
    If TargetDataTable Is Nothing OrElse String.IsNullOrEmpty(TargetTableName) Then
      Return
    End If

    Try
      'マスタチェック
      If ReadSettingIniFile("MASTER_CHECK", "VALUE") = "1" Then
        MasterCheck()
      End If


      SqlServer.TrnStart()

      mapping = mapper.GetMapping(TargetCsvType)
      For Each row As DataRow In TargetDataTable.Rows
        TargetRowData.Clear()

        For Each col As DataColumn In TargetDataTable.Columns
          Dim key As String = col.ColumnName
          Dim value As Object = row(col)
          TargetRowData.Add(mapping(key), value)
        Next

        '重複チェック
        If IsDuplicate(TargetRowData) Then
          Throw New Exception("既に取込済みです。")
        Else
          SqlServer.Execute(SqlInsTargetTable(TargetRowData, TargetTableName))
        End If

      Next

      MessageBox.Show("取込が完了しました。")
      SqlServer.TrnCommit()
    Catch ex As Exception
      SqlServer.TrnRollBack()
      TargetDataTable.Clear()
      ComWriteErrLog(ex, False)
    End Try
  End Sub

#End Region

  'Private Function SqlInsTargetTable(prmTargetRow As Dictionary(Of String, String)) As String
  '  Dim sql As String = String.Empty
  '  Dim tmpKeyValue As New Dictionary(Of String, String)
  '  Dim tmpInsertItemz As New Dictionary(Of String, String)

  '  For Each KeyValue As KeyValuePair(Of String, String) In prmTargetRow
  '    ComSetDictionaryVal(tmpKeyValue, KeyValue.Key, KeyValue.Value)
  '  Next
  '  tmpInsertItemz = ComCreateInsertItem(tmpKeyValue)

  '  sql &= " INSERT INTO " & TargetTableName & "(" & tmpInsertItemz("Keyz") & ") "
  '  sql &= " VALUES(" & tmpInsertItemz("Valuez") & ") "

  '  Return sql

  'End Function


  ''なかったので仮に作成したので頂ければ削除！
  'Private Function ComCreateInsertItem(prmKeyValuez As Dictionary(Of String, String)) As Dictionary(Of String, String)
  '  Dim result As New Dictionary(Of String, String)

  '  ' 列名をカンマ区切りで連結
  '  Dim keys As String = String.Join(",", prmKeyValuez.Keys)

  '  ' 値をカンマ区切りで連結（シングルクォートで囲む）
  '  Dim values As String = String.Join(",", prmKeyValuez.Values.Select(Function(v) $"'{v}'"))

  '  result("Keyz") = keys
  '  result("Valuez") = values

  '  Return result
  'End Function

  Private Sub MasterCheck()
    Try
      Dim invalidList = GetInvalidItemList(TargetDataTable)

      If invalidList.Rows.Count > 0 Then
        Dim path = IO.Path.Combine(PROJECT_DIR_NAME & MASTER_DIR & "商品マスタ不備データ一覧_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx")
        ExportExcel(invalidList, path)

        'CSV を出力したフォルダを開く
        Dim folderPath As String = IO.Path.GetDirectoryName(path)
        Process.Start("explorer.exe", folderPath)

        Throw New Exception("マスタに不備があるデータが存在します。" &
                            vbCrLf & "不備データ一覧を確認してください。")
      End If

      If TargetTableName = "TRN_SHUKKA" Then
        Dim CourseList = GetInvalidCourseList(TargetDataTable)
        If CourseList.Rows.Count > 0 Then
          Dim path = IO.Path.Combine(PROJECT_DIR_NAME & MASTER_DIR & "コースマスタ不備データ一覧_" & DateTime.Parse(ComGetProcTime()).ToString("yyyyMMddHHmmss") & ".xlsx")
          ExportExcel(CourseList, path)

          'CSV を出力したフォルダを開く
          Dim folderPath As String = IO.Path.GetDirectoryName(path)
          Process.Start("explorer.exe", folderPath)

          Throw New Exception("マスタに不備があるデータが存在します。" &
                            vbCrLf & "不備データ一覧を確認してください。")
        End If

      End If

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub

  Private Function GetInvalidItemList(dt As DataTable) As DataTable
    Dim result As New DataTable
    result.Columns.Add("区分")
    result.Columns.Add("商品コード")
    result.Columns.Add("商品名")
    result.Columns.Add("入り数")

    'result.Columns.Add("JAN")
    'result.Columns.Add("ITF")
    'result.Columns.Add("棚番")

    Select Case TargetTableName
      Case "TRN_NYUKA"
        SHOHIN_NM = "メーカー商品名"
      Case "TRN_SHUKKA"
        SHOHIN_NM = "自社商品名1"
      Case "TRN_TANAOROSHI"
        SHOHIN_NM = "自社商品名"

    End Select


    For Each row As DataRow In dt.Rows
      Dim shohinCd As String = row(SHOHIN_CD).ToString.Replace("'", "''")
      Dim shohinNM As String = row(SHOHIN_NM).ToString.Replace("'", "''")
      Dim Irisu As String = "1"
      Dim tmp As New DataTable

      Dim sql As String =
            $"SELECT SHOHIN_CD, JAN, ITF, TANA_CD
              FROM MST_ITEM
              WHERE SHOHIN_CD = '{shohinCd}'"

      SqlServer.GetResult(tmp, sql)

      If tmp.Rows.Count = 0 Then
        result.Rows.Add("マスタ登録なし", shohinCd, shohinNM, Irisu)

        Continue For
      End If

      Dim m = tmp.Rows(0)
      Dim jan = m("JAN").ToString()
      Dim itf = m("ITF").ToString()
      Dim tana = m("TANA_CD").ToString()

      If ReadSettingIniFile("JAN_CHECK", "VALUE") = "1" Then
        If String.IsNullOrWhiteSpace(jan) Then
          result.Rows.Add("JAN登録なし", shohinCd, shohinNM, Irisu)
          Continue For
        End If
      End If

      If String.IsNullOrWhiteSpace(tana) Then
        result.Rows.Add("棚番登録なし", shohinCd, shohinNM, Irisu)
        Continue For
      End If
    Next

    Return result
  End Function
  Private Function GetInvalidCourseList(dt As DataTable) As DataTable
    Dim result As New DataTable
    result.Columns.Add("区分")
    result.Columns.Add("コース名")

    For Each row As DataRow In dt.Rows
      Dim courseName As String = row("配送コース名").ToString.Replace("'", "''")
      Dim tmp As New DataTable

      Dim sql As String =
            $"SELECT COURSE_MEI
              FROM MST_COURSE
              WHERE COURSE_MEI COLLATE Japanese_CS_AS_KS_WS = '{courseName}'"

      SqlServer.GetResult(tmp, sql)

      If tmp.Rows.Count = 0 Then
        result.Rows.Add("マスタ登録なし", courseName)

        Continue For
      End If

      Dim m = tmp.Rows(0)
      Dim course = m("COURSE_MEI").ToString()

      If String.IsNullOrWhiteSpace(course) Then
        result.Rows.Add("コース登録なし", course)
        Continue For
      End If
    Next

    Return result.DefaultView.ToTable(True, "区分", "コース名")

  End Function

  Private Sub ExportCsv(dt As DataTable, filePath As String)
    ' フォルダが無ければ作成
    Dim dir As String = IO.Path.GetDirectoryName(filePath)
    If Not IO.Directory.Exists(dir) Then
      IO.Directory.CreateDirectory(dir)
    End If


    Using sw As New StreamWriter(filePath, False, System.Text.Encoding.UTF8)
      ' ヘッダ
      sw.WriteLine(String.Join(",", dt.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName)))

      ' データ
      For Each row As DataRow In dt.Rows
        Dim fields = row.ItemArray.Select(Function(v) v.ToString().Replace(",", ""))
        sw.WriteLine(String.Join(",", fields))
      Next
    End Using
  End Sub




  '重複チェック
  Private Function IsDuplicate(prmTargetRow As Dictionary(Of String, String)) As Boolean
    Dim mapper As New clsMapping
    Dim keyCols = mapper.GetDuplicateKeyColumns(TargetCsvType)
    Dim tmpDt As New DataTable
    If keyCols.Count = 0 Then Return False ' キー定義がなければチェックしない

    Dim whereList As New List(Of String)
    For Each col In keyCols
      If Not prmTargetRow.ContainsKey(col) Then Return False ' 必須キーがなければスキップ
      Dim val = prmTargetRow(col).Replace("'", "''") ' SQLエスケープ
      whereList.Add($"{col} = '{val}'")
    Next

    Dim whereClause = String.Join(" AND ", whereList)
    Dim sql = $"SELECT COUNT(*) cnt FROM {TargetTableName} WHERE {whereClause}"

    SqlServer.GetResult(tmpDt, sql)
    Dim count = tmpDt.Rows(0).Item("cnt").ToString
    Return count > 0
  End Function

  Private Sub ExportExcel(dt As DataTable, filePath As String)
    Dim excel As New Excel.Application
    excel.Visible = False

    Dim wb = excel.Workbooks.Add()
    Dim ws = CType(wb.Sheets(1), Excel.Worksheet)

    dt = dt.DefaultView.ToTable(True)

    Dim rowCount = dt.Rows.Count
    Dim colCount = dt.Columns.Count

    ' 2次元配列を作成（Excelは1-based）
    Dim data(0 To rowCount, 0 To colCount - 1) As Object

    ' ヘッダ
    For c = 0 To colCount - 1
      data(0, c) = dt.Columns(c).ColumnName
    Next

    ' データ
    For i = 0 To rowCount - 1
      For c = 0 To colCount - 1
        data(i + 1, c) = dt.Rows(i)(c)
      Next
    Next

    ' 一括書き込み
    Dim startCell = ws.Cells(1, 1)
    Dim endCell = ws.Cells(rowCount + 1, colCount)
    Dim writeRange = ws.Range(startCell, endCell)
    writeRange.NumberFormat = "@"
    writeRange.Value = data

    ' 列幅自動調整
    ws.Columns.AutoFit()

    wb.SaveAs(filePath)
    wb.Close()
    excel.Quit()
  End Sub


End Class