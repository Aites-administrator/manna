Imports T.R.ZCommonClass.clsCommonFnc

Public Class clsTantoMasterDefine
  Implements IMasterMentenance

  '=== 画面列名 ===
  Private Const COL_CD As String = "担当者コード"
  Private Const COL_NAME As String = "担当者名"

  '=== DB列名 ===
  Private Const DB_CD As String = "TANTO_CD"
  Private Const DB_NAME As String = "TANTO_NM"
  Private Const DB_ENTRY As String = "ENTRY_DATE"
  Private Const DB_UPDATE As String = "UPDATE_DATE"

  Private SqlServer As New clsSqlServer
  Private Const TABLE_NAME As String = "MST_TANTO"

  Public ReadOnly Property Title As String Implements IMasterMentenance.Title
    Get
      Return "担当者マスタ"
    End Get
  End Property

  Public ReadOnly Property Columns As List(Of MasterColumn) Implements IMasterMentenance.Columns
    Get
      Return New List(Of MasterColumn) From {
          New MasterColumn With {.Name = COL_CD, .DisplayName = COL_CD, .IsEditable = True},
          New MasterColumn With {.Name = COL_NAME, .DisplayName = COL_NAME, .IsEditable = True}
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
    ' 担当者は取り込み不要
  End Sub

  Public Function LoadData() As DataTable Implements IMasterMentenance.LoadData
    Dim dt As New DataTable
    Dim mapper As New clsDtHeaderMapping

    SqlServer.GetResult(dt, SqlSel())
    dt = mapper.ConvertColumnNamesToJapanese(dt, "担当者マスタ")

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
    Dim newRow = dt.NewRow()

    Return newRow
  End Function

  Private Function SqlSel() As String
    Dim sql As String = ""

    sql &= $" SELECT  " & DB_CD
    sql &= $"    ,    " & DB_NAME
    sql &= $"    ,    " & DB_ENTRY
    sql &= $"    ,    " & DB_UPDATE
    sql &= $" FROM " & TABLE_NAME
    sql &= $" ORDER BY CAST(" & DB_CD & " AS INT)"

    Return sql
  End Function

End Class
