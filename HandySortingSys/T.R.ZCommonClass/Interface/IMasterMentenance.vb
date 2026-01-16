Public Interface IMasterMentenance
  ReadOnly Property Title As String
  ReadOnly Property Columns As List(Of MasterColumn)
  Function LoadData() As DataTable
  Function ValidateRow(row As DataRow) As List(Of String)
  Function CreateNewRow(dt As DataTable) As DataRow

  Sub Save(row As DataRow)
  Sub Delete(row As DataRow)
  ReadOnly Property AllowAdd As Boolean
  ReadOnly Property AllowImport As Boolean
  Sub Import()
End Interface
