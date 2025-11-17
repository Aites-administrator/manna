Public Class clsGlobalData

  ''' <summary>
  ''' ログ保存フォルダ名
  ''' </summary>
  Public Shared ReadOnly LOG_DIR_NAME As String = "LOG"

  ''' <summary>
  ''' プログラム名
  ''' </summary>
  Public Shared ReadOnly PRG_TITLE As String = "IZデジタルスムーズ.DX (配合)"

  ''' <summary>
  ''' 印刷用Accessファイル原紙保存先
  ''' </summary>
  Public Shared ReadOnly REPORT_ORG_FILEPATH As String = "../report/IZDS_REPORT_ORG.accdb"

  ''' <summary>
  ''' 印刷用Accessファイル
  ''' </summary>
  Public Shared ReadOnly REPORT_FILENAME As String = "IZDS_REPORT.accdb"

  ''' <summary>
  ''' 印刷プレビューフラグ
  ''' </summary>
  Public Shared ReadOnly PRINT_PREVIEW As Integer = 1     '0：プレビューしない、1：プレビューする
  Public Shared ReadOnly PRINT_NON_PREVIEW As Integer = 0


  Public Shared ReadOnly FTP_PATH_UPLOAD As String = "..\FTP\UPLOAD\"
  Public Shared ReadOnly FTP_PATH_ANS As String = "..\FTP\BACKUP\"
  Public Shared ReadOnly FTP_PATH_DOWNLOAD As String = "..\FTP\DOWNLOAD\"
  Public Shared ReadOnly FTP_PATH_BACKUP As String = "..\FTP\BACKUP\"
  Public Shared ReadOnly FTP_PATH_DELETE As String = "..\FTP\DELETE\"

  Public Shared ReadOnly FTP_USER As String = "1111"
  Public Shared ReadOnly FTP_PASSWORD As String = "1111"

  Public Shared ReadOnly FTP_FILE_DIGITS As String = ""
  Public Shared ReadOnly FTP_FILE_NAME_LENGTH As String = "12"

  Public Shared ReadOnly STAFF_DIGITS As Integer = 2

  Public Shared ReadOnly GRID_DEFAULT_FONT_SIZE As Single = 14
  Public Shared ReadOnly GRID_DEFAULT_ROW_HEIGHT As Single = 35


  Public Enum RecipeType
    Horizontal = 0
    Vertical
  End Enum
End Class
