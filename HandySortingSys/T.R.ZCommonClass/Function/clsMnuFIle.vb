Imports System.IO


Public Class clsMnuFIle

#Region "メンバ"

  ''' <summary>
  ''' 操作対象ファイルのフルパス
  ''' </summary>
  Private _TargetFilePath As String = String.Empty

#End Region

#Region "プロパティ"

  ''' <summary>
  ''' 操作対象ファイルのフルパス
  ''' </summary>
  ''' <returns></returns>
  Public Property TargetFilePath As String
    Get
      Return _TargetFilePath
    End Get
    Set(value As String)
      _TargetFilePath = value
    End Set
  End Property

  ''' <summary>
  ''' 操作対象ファイルディレクトリ
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property TargetFileDir As String
    Get
      Return System.IO.Path.GetDirectoryName(_TargetFilePath) & "\"
    End Get
  End Property

  ''' <summary>
  ''' 操作対象ファイル名
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property TargetFileName As String
    Get
      Return System.IO.Path.GetFileName(_TargetFilePath)
    End Get
  End Property

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmTargetFilePath">操作対象ファイルのフルパス</param>
  Public Sub New(prmTargetFilePath As String)
    TargetFilePath = prmTargetFilePath
  End Sub

  Public Sub New()

  End Sub

#End Region

#Region "メソッド"
  ''' <summary>
  ''' ファイル読込
  ''' </summary>
  ''' <remarks>
  ''' 使用方法
  '''   Dim tmpFr As New clsMnuFIle("D:\マンナ運輸\ウオクニ販売実績.csv")
  '''   For Each tmpDr As DataRow In tmpFr.Read4Dt().Rows
  '''    Console.Write(tmpDr.Item(0).ToString())
  '''   Next
  ''' </remarks>
  ''' <returns>読込内容</returns>
  Public Function Read4Dt() As DataTable
    Dim tmpDt As New DataTable

    Try
      '接続文字列
      Dim conString As String = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" _
                              + TargetFileDir + ";Extensions=asc,csv,tab,txt;"
      Dim con As New System.Data.Odbc.OdbcConnection(conString)

      Dim commText As String = "SELECT * FROM [" + TargetFileName + "]"
      Dim da As New System.Data.Odbc.OdbcDataAdapter(commText, con)

      'DataTableに格納する
      da.Fill(tmpDt)
    Catch ex As Exception
      clsCommonFnc.ComWriteErrLog(ex)
      Throw New Exception("[" & TargetFilePath & "]の読込に失敗しました。")
    End Try

    Return tmpDt
  End Function
#End Region


End Class
