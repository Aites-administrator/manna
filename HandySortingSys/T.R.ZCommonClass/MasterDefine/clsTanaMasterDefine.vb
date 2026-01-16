Imports T.R.ZCommonClass.clsCommonFnc

Public Class clsTanaMasterDefine
  Implements IMasterMentenance

  '=== 画面列名 ===
  Private Const COL_CD As String = "棚番"
  Private Const COL_ONDO As String = "温度帯"
  Private Const COL_FLOOR As String = "フロア"
  Private Const COL_BLOCK As String = "ブロック"

  '=== DB列名 ===
  Private Const DB_CD As String = "TANA_CD"
  Private Const DB_ONDO As String = "TANA_ONDO"
  Private Const DB_FLOOR As String = "FLOOR"
  Private Const DB_BLOCK As String = "BLOCK"
  Private Const DB_ENTRY As String = "ENTRY_DATE"
  Private Const DB_UPDATE As String = "UPDATE_DATE"

  Private SqlServer As New clsSqlServer
  Private Const TABLE_NAME As String = "MST_TANA"

  Public ReadOnly Property Title As String Implements IMasterMentenance.Title
    Get
      Return "棚番マスタ"
    End Get
  End Property

  Public ReadOnly Property Columns As List(Of MasterColumn) Implements IMasterMentenance.Columns
    Get
      Return New List(Of MasterColumn) From {
          New MasterColumn With {.Name = COL_CD, .DisplayName = COL_CD, .IsEditable = True},
          New MasterColumn With {.Name = COL_ONDO, .DisplayName = COL_ONDO, .IsEditable = True},
          New MasterColumn With {.Name = COL_FLOOR, .DisplayName = COL_FLOOR, .IsEditable = True},
          New MasterColumn With {.Name = COL_BLOCK, .DisplayName = COL_BLOCK, .IsEditable = True}
      }
    End Get
  End Property

  Public ReadOnly Property AllowAdd As Boolean Implements IMasterMentenance.AllowAdd
    Get
      Return True
    End Get
  End Property

  Public ReadOnly Property AllowImport As Boolean Implements IMasterMentenance.AllowImport
    Get
      Return False
    End Get
  End Property

  Public Sub Import() Implements IMasterMentenance.Import
    ' 棚番は取り込み不要
  End Sub

  Public Function LoadData() As DataTable Implements IMasterMentenance.LoadData
    Dim dt As New DataTable
    Dim mapper As New clsDtHeaderMapping

    SqlServer.GetResult(dt, SqlSel())
    dt = mapper.ConvertColumnNamesToJapanese(dt, "棚番マスタ")

    Return dt
  End Function

  Public Function ValidateRow(row As DataRow) As List(Of String) Implements IMasterMentenance.ValidateRow
    Dim errors As New List(Of String)

    If String.IsNullOrWhiteSpace(row(COL_CD).ToString()) Then errors.Add($"{COL_CD}は必須です。")
    If String.IsNullOrWhiteSpace(row(COL_ONDO).ToString()) Then errors.Add($"{COL_ONDO}は必須です。")
    If String.IsNullOrWhiteSpace(row(COL_FLOOR).ToString()) Then errors.Add($"{COL_FLOOR}は必須です。")
    If String.IsNullOrWhiteSpace(row(COL_BLOCK).ToString()) Then errors.Add($"{COL_BLOCK}は必須です。")

    Return errors
  End Function

  Public Sub Save(row As DataRow) Implements IMasterMentenance.Save
    Dim DicRow As New Dictionary(Of String, String)
    Dim DicWhere As New Dictionary(Of String, String)

    Try
      ' WHERE 条件
      DicWhere(DB_CD) = row(COL_CD)

      ' 更新項目
      DicRow(DB_CD) = row(COL_CD)
      DicRow(DB_ONDO) = row(COL_ONDO)
      DicRow(DB_FLOOR) = row(COL_FLOOR)
      DicRow(DB_BLOCK) = row(COL_BLOCK)
      DicRow(DB_UPDATE) = ComGetProcTime()  ' 現在日付

      SqlServer.TrnStart()

      If row.RowState = DataRowState.Added Then
        ' INSERT
        DicRow(DB_ENTRY) = ComGetProcTime() ' 現在日付

        If SqlServer.Execute(SqlInsTargetTable(DicRow, TABLE_NAME)) <> 1 Then
          Throw New Exception("登録に失敗しました。")
        End If

      ElseIf row.RowState = DataRowState.Modified Then
        ' UPDATE
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
    Dim newRow = dt.NewRow()

    Return newRow
  End Function

  Private Function SqlSel() As String
    Dim sql As String = String.Empty

    sql &= $" SELECT  " & DB_CD
    sql &= $"    ,    " & DB_ONDO
    sql &= $"    ,    " & DB_FLOOR
    sql &= $"    ,    " & DB_BLOCK
    sql &= $"    ,    " & DB_ENTRY
    sql &= $"    ,    " & DB_UPDATE
    sql &= $" FROM {TABLE_NAME}"
    sql &= $" ORDER BY CAST(" & DB_CD & " AS INT)"

    Return sql
  End Function

End Class
