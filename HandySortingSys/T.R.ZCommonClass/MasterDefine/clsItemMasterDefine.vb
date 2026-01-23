Imports T.R.ZCommonClass.clsDtHeaderMapping
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class clsItemMasterDefine
  Implements IMasterMentenance

  '=== 画面列名 ===
  Private Const COL_RANK As String = "商品ランク"
  Private Const COL_CD As String = "商品コード"
  Private Const COL_NAME As String = "商品名"
  Private Const COL_IRISU As String = "入数"
  Private Const COL_AISU As String = "荷合数"
  Private Const COL_ONDO As String = "温度帯"
  Private Const COL_ZEI As String = "消費税"
  Private Const COL_TANKA As String = "単価単位"
  Private Const COL_SIIRE_CD As String = "仕入先コード"
  Private Const COL_SIIRE_MEI As String = "仕入先名"
  Private Const COL_HASSO_CD As String = "発送先コード"
  Private Const COL_HASSO_MEI As String = "発送先名"
  Private Const COL_MAKER As String = "メーカーコード"
  Private Const COL_JAN As String = "JAN"
  Private Const COL_OLD_JAN As String = "旧JAN"
  Private Const COL_ITF As String = "ITF"
  Private Const COL_KOKEI_KAISIBI As String = "後継開始日"
  Private Const COL_KOKEI_CD As String = "後継商品コード"
  Private Const COL_KOKEI_MEI As String = "後継商品名"
  Private Const COL_LAST_USE As String = "最終使用日"
  Private Const COL_TANA As String = "棚コード"
  Private Const COL_SHOMIKIGEN As String = "賞味期限"

  '=== DB列名 ===
  Private Const DB_RANK As String = "SHOHIN_RANK"
  Private Const DB_CD As String = "SHOHIN_CD"
  Private Const DB_NAME As String = "SHOHIN_MEI"
  Private Const DB_IRISU As String = "IRISU"
  Private Const DB_AISU As String = "AISU"
  Private Const DB_ONDO As String = "ONDO_TAI"
  Private Const DB_ZEI As String = "SHOHI_ZEI"
  Private Const DB_TANKA As String = "TANKA_TANI"
  Private Const DB_SIIRE_CD As String = "SIIRE_CD"
  Private Const DB_SIIRE_MEI As String = "SIIRE_MEI"
  Private Const DB_HASSO_CD As String = "HASSOSAKI_CD"
  Private Const DB_HASSO_MEI As String = "HASSOSAKI_MEI"
  Private Const DB_MAKER As String = "MAKER_CD"
  Private Const DB_JAN As String = "JAN"
  Private Const DB_OLD_JAN As String = "OLD_JAN"
  Private Const DB_ITF As String = "ITF"
  Private Const DB_KOKEI_KAISIBI As String = "KOKEI_KAISIBI"
  Private Const DB_KOKEI_CD As String = "KOKEI_SHOHIN_CD"
  Private Const DB_KOKEI_MEI As String = "KOKEI_SHOHIN_MEI"
  Private Const DB_LAST_USE As String = "LAST_USE_DATE"
  Private Const DB_TANA As String = "TANA_CD"
  Private Const DB_SHOMIKIGEN As String = "SHOMIKIGEN"
  Private Const DB_ENTRY As String = "ENTRY_DATE"
  Private Const DB_UPDATE As String = "UPDATE_DATE"

  Private SqlServer As New clsSqlServer
  Private Const TABLE_NAME As String = "MST_ITEM"

  Private mapper As New clsDtHeaderMapping


  Public ReadOnly Property Title As String Implements IMasterMentenance.Title
    Get
      Return "商品マスタ"
    End Get
  End Property

  Public ReadOnly Property Columns As List(Of MasterColumn) Implements IMasterMentenance.Columns
    Get
      Return New List(Of MasterColumn) From {
          New MasterColumn With {.Name = COL_CD, .DisplayName = COL_CD, .IsEditable = False},
          New MasterColumn With {.Name = COL_NAME, .DisplayName = COL_NAME, .IsEditable = True},
          New MasterColumn With {.Name = COL_IRISU, .DisplayName = COL_IRISU, .IsEditable = True},
          New MasterColumn With {.Name = COL_AISU, .DisplayName = COL_AISU, .IsEditable = True},
          New MasterColumn With {.Name = COL_JAN, .DisplayName = COL_JAN, .IsEditable = True},
          New MasterColumn With {.Name = COL_ITF, .DisplayName = COL_ITF, .IsEditable = True},
          New MasterColumn With {.Name = COL_TANA, .DisplayName = COL_TANA, .IsEditable = True},
          New MasterColumn With {.Name = COL_SHOMIKIGEN, .DisplayName = COL_SHOMIKIGEN, .IsEditable = True}
      }
    End Get
  End Property

  Public ReadOnly Property AllowAdd As Boolean Implements IMasterMentenance.AllowAdd
    Get
      Return False
    End Get
  End Property

  Public ReadOnly Property AllowImport As Boolean Implements IMasterMentenance.AllowImport
    Get
      Return True
    End Get
  End Property

  Public Sub Import() Implements IMasterMentenance.Import
    Dim dlg As New OpenFileDialog()
    Try

      SqlServer.TrnStart()

      '=== Excelファイル選択 ===
      dlg.Filter = "Excel Files|*.xlsx;*.xls"
      dlg.Title = "Excelファイルを選択してください"

      If dlg.ShowDialog() <> DialogResult.OK Then
        Exit Sub
      End If

      Dim filePath As String = dlg.FileName

      Dim headers = ReadExcelHeader(filePath, 8)

      Dim expectedHeaders = mapper.GetJapaneseColumnList("商品マスタExcel")

      Dim missing = expectedHeaders.Where(Function(h) headers.Contains(h) = False).ToList()



      If missing.Count > 0 Then
        Throw New Exception("フォーマットが違います。")
      End If


      '=== Excel → DataTable（ClosedXML）===
      Dim dtExcel As DataTable = ExcelToDataTable(filePath, 8) ' ← 8行目をヘッダにする例



      Using sqlCon = SqlServer.CreateSqlConnection()
        sqlCon.Open()

        '=== 一時テーブル作成（SqlConnection）===
        'SqlServer.Execute(SqlCreateTempTable())
        Dim cmd As New SqlCommand(SqlCreateTempTable(), sqlCon)
        cmd.ExecuteNonQuery()

        '=== BulkCopy（SqlConnection）===
        Using bulk As New SqlBulkCopy(sqlCon)
          bulk.DestinationTableName = "##TMP_MST_ITEM"

          dtExcel = ConvertExcelColumnsToDb(dtExcel, "商品マスタExcel")

          bulk.WriteToServer(dtExcel)
        End Using
      End Using


      '=== MERGE（OleDb）===
      SqlServer.Execute(SqlMerge())

      '=== コミット ===
      SqlServer.TrnCommit()

      ComMessageBox("更新しました。", "商品登録", typMsgBox.MSG_NORMAL)

    Catch ex As Exception
      '=== ロールバック ===
      SqlServer.TrnRollBack()

      Throw New Exception(ex.Message)

    Finally
      SqlServer.Dispose()
    End Try



  End Sub

  Private Function ReadExcelHeader(filePath As String, headerRow As Integer) As List(Of String)
    Dim headers As New List(Of String)

    Using wb As New ClosedXML.Excel.XLWorkbook(filePath)
      Dim ws = wb.Worksheet(1)

      For col = 1 To ws.LastColumnUsed().ColumnNumber()
        Dim value = ws.Cell(headerRow, col).GetString().Trim()

        ' 改行・タブ・余計な空白を除去
        value = value.Replace(vbCrLf, "") _
                         .Replace(vbCr, "") _
                         .Replace(vbLf, "") _
                         .Replace(vbTab, "") _
                         .Trim()


        headers.Add(value)
      Next
    End Using

    Return headers
  End Function


  Public Function LoadData() As DataTable Implements IMasterMentenance.LoadData
    Dim dt As New DataTable
    Dim mapper As New clsDtHeaderMapping

    SqlServer.GetResult(dt, SqlSel())
    dt = mapper.ConvertColumnNamesToJapanese(dt, "商品マスタメンテナンス")

    Return dt
  End Function

  Public Function ValidateRow(row As DataRow) As List(Of String) Implements IMasterMentenance.ValidateRow
    Dim errors As New List(Of String)

    If String.IsNullOrWhiteSpace(row(COL_CD).ToString()) Then errors.Add($"{COL_CD}は必須です。")
    If String.IsNullOrWhiteSpace(row(COL_NAME).ToString()) Then errors.Add($"{COL_NAME}は必須です。")

    Return errors
  End Function

  Public Sub Save(row As DataRow) Implements IMasterMentenance.Save
    Dim DicRow As New Dictionary(Of String, String)
    Dim DicWhere As New Dictionary(Of String, String)

    Try
      DicWhere(DB_CD) = row(COL_CD)

      DicRow(DB_CD) = row(COL_CD)
      DicRow(DB_NAME) = row(COL_NAME)
      DicRow(DB_JAN) = row(COL_JAN)
      DicRow(DB_TANKA) = row(COL_TANKA)
      DicRow(DB_UPDATE) = ComGetProcTime()

      SqlServer.TrnStart()

      If row.RowState = DataRowState.Added Then
        DicRow(DB_ENTRY) = ComGetProcTime()

        If SqlServer.Execute(SqlInsTargetTable(DicRow, TABLE_NAME)) <> 1 Then
          Throw New Exception("登録に失敗しました。")
        End If

      ElseIf row.RowState = DataRowState.Modified Then

        If SqlServer.Execute(CreateUpdateSql(TABLE_NAME, DicRow, DicWhere)) <> 1 Then
          Throw New Exception("更新に失敗しました。")
        End If

      End If

      SqlServer.TrnCommit()

    Catch ex As Exception
      SqlServer.TrnRollBack()
      ComWriteErrLog(ex, False)
    End Try

  End Sub

  Public Sub Delete(row As DataRow) Implements IMasterMentenance.Delete
    Dim DicWhere As New Dictionary(Of String, String)

    Try
      DicWhere(DB_CD) = row(COL_CD)

      If SqlServer.Execute(CreateDeleteSql(TABLE_NAME, DicWhere)) <> 1 Then
        Throw New Exception("削除に失敗しました。")
      End If

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

  Public Function CreateNewRow(dt As DataTable) As DataRow Implements IMasterMentenance.CreateNewRow
    Return dt.NewRow()
  End Function

  Public Function ExcelToDataTable(filePath As String, headerRowIndex As Integer) As DataTable

    Try
      Dim dt As New DataTable()

      Using wb As New XLWorkbook(filePath)
        Dim ws = wb.Worksheet(1)

        '=== ヘッダ行 ===
        Dim headerRow = ws.Row(headerRowIndex)

        For Each cell In headerRow.CellsUsed()
          Dim colName = cell.GetString().Trim()
          If colName = "" Then colName = "Column" & (dt.Columns.Count + 1)
          dt.Columns.Add(colName)
        Next

        '=== データ行 ===
        Dim rowIndex As Integer = headerRowIndex + 1
        While Not ws.Row(rowIndex).IsEmpty()
          Dim row = ws.Row(rowIndex)
          Dim dr = dt.NewRow()

          Dim colIndex As Integer = 1
          For i As Integer = 0 To dt.Columns.Count - 1
            dr(i) = row.Cell(colIndex).GetString()
            colIndex += 1
          Next

          dt.Rows.Add(dr)
          rowIndex += 1
        End While
      End Using

      Return dt

    Catch ex As Exception
      Throw New Exception(ex.Message)
      Return Nothing
    End Try

  End Function


  Public Function ConvertExcelColumnsToDb(dt As DataTable, mappingName As String) As DataTable
    For Each col As DataColumn In dt.Columns
      col.ColumnName = mapper.GetDbColumnName(mappingName, col.ColumnName.Replace(vbCr, "").Replace(vbLf, ""))
    Next
    Return dt
  End Function



  Private Function SqlSel() As String
    Dim sql As String = ""

    sql &= " SELECT  " & DB_CD
    sql &= "    ,    " & DB_NAME
    sql &= "    ,    " & DB_IRISU
    sql &= "    ,    " & DB_AISU
    sql &= "    ,    " & DB_JAN
    sql &= "    ,    " & DB_ITF
    sql &= "    ,    " & DB_TANA
    sql &= "    ,    " & DB_SHOMIKIGEN
    sql &= "    ,    " & DB_ENTRY
    sql &= "    ,    " & DB_UPDATE
    sql &= " FROM " & TABLE_NAME
    sql &= " ORDER BY CAST(" & DB_CD & " AS INT)"

    Return sql
  End Function

  'Private Function SqlSel() As String
  '  Dim sql As String = ""

  '  sql &= " SELECT  " & DB_RANK
  '  sql &= "    ,    " & DB_CD
  '  sql &= "    ,    " & DB_NAME
  '  sql &= "    ,    " & DB_IRISU
  '  sql &= "    ,    " & DB_AISU
  '  sql &= "    ,    " & DB_ONDO
  '  sql &= "    ,    " & DB_ZEI
  '  sql &= "    ,    " & DB_TANKA
  '  sql &= "    ,    " & DB_SIIRE_CD
  '  sql &= "    ,    " & DB_SIIRE_MEI
  '  sql &= "    ,    " & DB_HASSO_CD
  '  sql &= "    ,    " & DB_HASSO_MEI
  '  sql &= "    ,    " & DB_MAKER
  '  sql &= "    ,    " & DB_JAN
  '  sql &= "    ,    " & DB_OLD_JAN
  '  sql &= "    ,    " & DB_ITF
  '  sql &= "    ,    " & DB_KOKEI_KAISIBI
  '  sql &= "    ,    " & DB_KOKEI_CD
  '  sql &= "    ,    " & DB_KOKEI_MEI
  '  sql &= "    ,    " & DB_LAST_USE
  '  sql &= "    ,    " & DB_TANA
  '  sql &= "    ,    " & DB_SHOMIKIGEN
  '  sql &= "    ,    " & DB_ENTRY
  '  sql &= "    ,    " & DB_UPDATE
  '  sql &= " FROM " & TABLE_NAME
  '  sql &= " ORDER BY CAST(" & DB_CD & " AS INT)"

  '  Return sql
  'End Function

  Private Function SqlCreateTempTable() As String
    Dim sql As String = ""

    sql &= "CREATE TABLE ##TMP_MST_ITEM ("
    sql &= " SHOHIN_RANK        CHAR(1),"
    sql &= " SHOHIN_CD          CHAR(5),"
    sql &= " SHOHIN_MEI         NVARCHAR(128),"
    sql &= " IRISU              NUMERIC(10,2),"
    sql &= " AISU               VARCHAR(1),"
    sql &= " ONDO_TAI           CHAR(4),"
    sql &= " SHOHI_ZEI          NUMERIC(1,0),"
    sql &= " TANKA_TANI         CHAR(3),"
    sql &= " SIIRE_CD           CHAR(4),"
    sql &= " SIIRE_MEI          NVARCHAR(64),"
    sql &= " HASSOSAKI_CD       CHAR(4),"
    sql &= " HASSOSAKI_MEI      NVARCHAR(64),"
    sql &= " MAKER_CD           CHAR(20),"
    sql &= " JAN                CHAR(13),"
    sql &= " OLD_JAN            CHAR(13),"
    sql &= " ITF                CHAR(16),"
    sql &= " KOKEI_KAISIBI      VARCHAR(20),"   ' ← DATE → VARCHAR
    sql &= " KOKEI_SHOHIN_CD    CHAR(5),"
    sql &= " KOKEI_SHOHIN_MEI   NVARCHAR(128),"
    sql &= " LAST_USE_DATE      VARCHAR(20),"   ' ← DATE → VARCHAR
    sql &= " TANA_CD            CHAR(4),"
    sql &= " SHOMIKIGEN         VARCHAR(8)"
    sql &= ")"

    Return sql
  End Function



  Private Function SqlMerge() As String

    Dim sql As String = ""

    sql &= "MERGE INTO MST_ITEM AS T"
    Sql &= " USING ##TMP_MST_ITEM AS S"
    Sql &= " ON T.SHOHIN_CD = S.SHOHIN_CD"

    Sql &= " WHEN MATCHED THEN"
    Sql &= "   UPDATE SET"
    Sql &= "     T.SHOHIN_RANK = S.SHOHIN_RANK,"
    Sql &= "     T.SHOHIN_MEI  = S.SHOHIN_MEI,"
    Sql &= "     T.ONDO_TAI    = S.ONDO_TAI,"
    Sql &= "     T.SHOHI_ZEI   = S.SHOHI_ZEI,"
    Sql &= "     T.TANKA_TANI  = S.TANKA_TANI,"
    Sql &= "     T.SIIRE_CD    = S.SIIRE_CD,"
    Sql &= "     T.SIIRE_MEI   = S.SIIRE_MEI,"
    Sql &= "     T.HASSOSAKI_CD = S.HASSOSAKI_CD,"
    Sql &= "     T.HASSOSAKI_MEI = S.HASSOSAKI_MEI,"
    Sql &= "     T.MAKER_CD    = S.MAKER_CD,"
    sql &= "     T.OLD_JAN    = S.OLD_JAN ,"
    sql &= "     T.KOKEI_KAISIBI = TRY_CONVERT(date, NULLIF(S.KOKEI_KAISIBI, '')),"
    sql &= "     T.KOKEI_SHOHIN_CD = S.KOKEI_SHOHIN_CD,"
    Sql &= "     T.KOKEI_SHOHIN_MEI = S.KOKEI_SHOHIN_MEI,"
    Sql &= "     T.LAST_USE_DATE = TRY_CONVERT(date, NULLIF(S.LAST_USE_DATE, '')),"
    ' ★ TANA_CD は更新しない
    ' ★ SHOMIKIGEN は更新しない
    Sql &= "     T.UPDATE_DATE = GETDATE()"

    Sql &= " WHEN NOT MATCHED THEN"
    Sql &= "   INSERT ("
    Sql &= "     SHOHIN_RANK, SHOHIN_CD, SHOHIN_MEI, IRISU, AISU, ONDO_TAI, SHOHI_ZEI,"
    Sql &= "     TANKA_TANI, SIIRE_CD, SIIRE_MEI, HASSOSAKI_CD, HASSOSAKI_MEI,"
    Sql &= "     MAKER_CD, JAN, OLD_JAN, ITF, KOKEI_KAISIBI, KOKEI_SHOHIN_CD,"
    Sql &= "     KOKEI_SHOHIN_MEI, LAST_USE_DATE,"
    ' ★ TANA_CD, SHOMIKIGEN は挿入しない
    Sql &= "     ENTRY_DATE, UPDATE_DATE"
    Sql &= "   )"
    Sql &= "   VALUES ("
    Sql &= "     S.SHOHIN_RANK, S.SHOHIN_CD, S.SHOHIN_MEI, S.IRISU, S.AISU, S.ONDO_TAI, S.SHOHI_ZEI,"
    Sql &= "     S.TANKA_TANI, S.SIIRE_CD, S.SIIRE_MEI, S.HASSOSAKI_CD, S.HASSOSAKI_MEI,"
    Sql &= "     S.MAKER_CD, S.JAN, S.OLD_JAN, S.ITF,"
    Sql &= "     TRY_CONVERT(date, NULLIF(S.KOKEI_KAISIBI, '')),"
    Sql &= "     S.KOKEI_SHOHIN_CD, S.KOKEI_SHOHIN_MEI,"
    Sql &= "     TRY_CONVERT(date, NULLIF(S.LAST_USE_DATE, '')),"
    ' ★ TANA_CD, SHOMIKIGEN は挿入しない
    Sql &= "     GETDATE(), GETDATE()"
    Sql &= "   );"

    Return Sql

  End Function


End Class
