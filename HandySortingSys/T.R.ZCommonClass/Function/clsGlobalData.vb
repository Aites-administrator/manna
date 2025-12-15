Public Class clsGlobalData

  ''' <summary>
  ''' プロジェクトフォルダ名
  ''' </summary>
  Public Shared ReadOnly PROJECT_DIR_NAME As String = "C:\manna\"

  ''' <summary>
  ''' ログ保存フォルダ名
  ''' </summary>
  Public Shared ReadOnly LOG_DIR_NAME As String = "LOG"

  ''' <summary>
  ''' プログラム名
  ''' </summary>
  Public Shared ReadOnly PRG_TITLE As String = "ハンディ仕分システム"

  ''' <summary>
  ''' 印刷プレビューフラグ
  ''' </summary>
  Public Shared ReadOnly PRINT_PREVIEW As Integer = 1     '0：プレビューしない、1：プレビューする
  Public Shared ReadOnly PRINT_NON_PREVIEW As Integer = 0

  ''' <summary>
  ''' パスワード入力画面モジュール名
  ''' </summary>
  ''' <remarks>
  ''' パスワード入力が必要な画面は本画面からのみ起動可
  ''' </remarks>
  Public Shared ReadOnly PASSWORD_ENTRY_MODULE As String = "PasswordEntry"

  ''' <summary>
  ''' パスワード
  ''' </summary>
  Public Shared ReadOnly PASSWORD As String = "1234"

End Class
