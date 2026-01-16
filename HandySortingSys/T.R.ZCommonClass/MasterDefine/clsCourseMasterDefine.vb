Imports T.R.ZCommonClass.clsCommonFnc
Public Class clsCourseMasterDefine
  Implements IMasterMentenance

  Private Const COL_CD As String = "コースコード"
  Private Const COL_NAME As String = "コース名"
  Private Const COL_ORDER As String = "表示順"

  Private Const DB_CD As String = "COURSE_CD"
  Private Const DB_NAME As String = "COURSE_MEI"
  Private Const DB_ORDER As String = "DISP_ORDER"
  Private Const DB_ENTRY As String = "ENTRY_DATE"
  Private Const DB_UPDATE As String = "UPDATE_DATE"

  Private SqlServer As New clsSqlServer
  Private TABLE_NAME As String = "MST_COURSE"

  Public ReadOnly Property Title As String Implements IMasterMentenance.Title
    Get
      Return "コースマスタ"
    End Get
  End Property

  Public ReadOnly Property Columns As List(Of MasterColumn) Implements IMasterMentenance.Columns
    Get
      Return New List(Of MasterColumn) From {
          New MasterColumn With {.Name = COL_CD, .DisplayName = COL_CD, .IsEditable = False},
          New MasterColumn With {.Name = COL_NAME, .DisplayName = COL_NAME, .IsEditable = True},
          New MasterColumn With {.Name = COL_ORDER, .DisplayName = COL_ORDER, .IsEditable = True}
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
    ' 取り込み不要
  End Sub

  Public Function LoadData() As DataTable Implements IMasterMentenance.LoadData
    Dim tmpDt As New DataTable()
    Dim mapper As New clsDtHeaderMapping

    SqlServer.GetResult(tmpDt, SqlSelCourseMaster)
    tmpDt = mapper.ConvertColumnNamesToJapanese(tmpDt, "コースマスタ")

    Return tmpDt
  End Function

  Public Function ValidateRow(row As DataRow) As List(Of String) Implements IMasterMentenance.ValidateRow
    Dim errors As New List(Of String)

    If String.IsNullOrWhiteSpace(row(COL_CD).ToString()) Then
      errors.Add("コースコードは必須です。")
    End If

    If String.IsNullOrWhiteSpace(row(COL_NAME).ToString()) Then
      errors.Add("コース名は必須です。")
    End If

    Return errors
  End Function

  Public Sub Save(row As DataRow) Implements IMasterMentenance.Save
    Dim DicRow As New Dictionary(Of String, String)
    Dim DicWhere As New Dictionary(Of String, String)
    Try
      DicWhere(DB_CD) = row(COL_CD)
      DicRow(DB_CD) = row(COL_CD)
      DicRow(DB_NAME) = row(COL_NAME)
      DicRow(DB_ORDER) = row(COL_ORDER)
      DicRow(DB_UPDATE) = ComGetProcTime()  '現在日付

      SqlServer.TrnStart()

      If row.RowState = DataRowState.Added Then
        ' INSERT
        DicRow(DB_ENTRY) = ComGetProcTime() '現在日付

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
    ' DELETE
    Dim DicWhere As New Dictionary(Of String, String)
    Try
      DicWhere(DB_CD) = row(COL_CD)
      If SqlServer.Execute(CreateDeleteSql(TABLE_NAME, DicWhere)) <> 1 Then
        Throw New Exception("削除に失敗しました。")

      End If
    Catch ex As Exception

    End Try

  End Sub

  Public Function CreateNewRow(dt As DataTable) As DataRow Implements IMasterMentenance.CreateNewRow
    Dim newRow = dt.NewRow()

    Dim maxCode As Integer = 0

    If dt.Rows.Count > 0 Then
      maxCode = dt.AsEnumerable().
            Where(Function(r) Not IsDBNull(r(COL_CD)) AndAlso r(COL_CD).ToString() <> "").
            Max(Function(r) CInt(r(COL_CD)))
    End If

    newRow(COL_CD) = maxCode + 1

    Return newRow
  End Function


  Private Function SqlSelCourseMaster() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  " & DB_CD
    sql &= "    ,    " & DB_NAME
    sql &= "    ,    " & DB_ORDER
    sql &= "    ,    " & DB_ENTRY
    sql &= "    ,    " & DB_UPDATE
    sql &= " FROM MST_COURSE "
    sql &= " ORDER BY CAST(" & DB_CD & " AS INT) "

    Return sql
  End Function

End Class
