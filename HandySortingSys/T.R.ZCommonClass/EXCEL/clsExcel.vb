Public Class clsExcel
  Implements IDisposable

#Region "プライベート変数"
  Private _FilePath As String
  Private _AppExcel As New Microsoft.Office.Interop.Excel.Application
  Private _ExcelBook As Microsoft.Office.Interop.Excel.Workbook
  Private _ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet
  Private _SheetName As String
#End Region

#Region "プライベートプロパティー"
  Private ReadOnly Property AppExcel As Microsoft.Office.Interop.Excel.Application
    Get
      If _AppExcel Is Nothing Then
        _AppExcel = New Microsoft.Office.Interop.Excel.Application
      End If

      Return _AppExcel
    End Get
  End Property

  Private ReadOnly Property ExcelBook As Microsoft.Office.Interop.Excel.Workbook
    Get
      If _ExcelBook Is Nothing Then
        _ExcelBook = AppExcel.Workbooks.Open(_FilePath)
      End If
      Return _ExcelBook
    End Get
  End Property

  Private ReadOnly Property ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet
    Get
      If _ExcelSheet Is Nothing Then
        _ExcelSheet = ExcelBook.Sheets(SheetName)
      End If
      Return _ExcelSheet
    End Get
  End Property
#End Region

#Region "パブリックプロパティー"
  Public Property SheetName As String
    Get
      If _SheetName.Equals(String.Empty) Then
        _SheetName = GetSheetNameByNumber(1)
      End If
      Return _SheetName
    End Get
    Set(value As String)
      _SheetName = value
    End Set
  End Property

  Public WriteOnly Property SheetNamuber As Integer
    Set(value As Integer)
      _SheetName = GetSheetNameByNumber(value)
    End Set
  End Property

  Public Property FilePath As String
    Get
      Return _FilePath
    End Get
    Set(value As String)
      _FilePath = value
    End Set
  End Property

#End Region

#Region "コンストラクタ"
  Public Sub New(FilePath As String)
    _FilePath = FilePath
    _SheetName = String.Empty
  End Sub

  Public Sub New(FilePath As String _
                   , SheetNumber As Integer)
    _FilePath = FilePath
    _SheetName = GetSheetNameByNumber(SheetNumber)
  End Sub

  Public Sub New(FilePath As String _
                   , SheetName As String)
    _FilePath = FilePath
    _SheetName = SheetName
  End Sub

  Public Sub New()

  End Sub
#End Region

#Region "プライベートメソッド"
  Private Function GetSheetNameByNumber(targetNumber As Integer) As String
    Return ExcelBook.Worksheets(targetNumber).Name
  End Function
#End Region

#Region "パブリックメソッド"
  Public Function GetCellValue(pos As Point) As String
    Return CStr(ExcelSheet.Cells(pos.Y, pos.X).Value & "")
  End Function

  Public Function GetCellValue(pos As String) As String
    Return CStr(ExcelSheet.Range(pos).Value & "")
  End Function
#End Region

#Region "IDisposable Support"
  Private disposedValue As Boolean ' 重複する呼び出しを検出するには

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' TODO: マネージド状態を破棄します (マネージド オブジェクト)。
        _ExcelSheet = Nothing
        _ExcelBook = Nothing
        '_AppExcel = Nothing
      End If

      ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下の Finalize() をオーバーライドします。
      ' TODO: 大きなフィールドを null に設定します。
      AppExcel.Quit()

    End If
    disposedValue = True
  End Sub

  ' TODO: 上の Dispose(disposing As Boolean) にアンマネージド リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
  'Protected Overrides Sub Finalize()
  '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
  Public Sub Dispose() Implements IDisposable.Dispose
    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    Dispose(True)
    ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
    ' GC.SuppressFinalize(Me)
  End Sub
#End Region

End Class
