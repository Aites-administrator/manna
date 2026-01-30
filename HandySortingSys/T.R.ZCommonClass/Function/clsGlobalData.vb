Public Class clsGlobalData


  ''' <summary>
  ''' 環境フラグ
  ''' </summary>
  Public Shared ReadOnly KANKYO_HONBAN As String = clsCommonFnc.ReadSettingIniFile("KANKYO_HONBAN", "VALUE")

  ''' <summary>
  ''' プロジェクトフォルダ名
  ''' </summary>
  Public Shared ReadOnly PROJECT_DIR_NAME As String = clsCommonFnc.ReadSettingIniFile("PROJECT_FORDER", "VALUE")
  '  Public Shared ReadOnly PROJECT_DIR_NAME As String = "D:\manna\"

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
  ''' 送信フォルダ
  ''' </summary>
  Public Const SEND_FOLDER As String = "SEND\"

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
  ''' <summary>
  ''' パスワードファイル名
  ''' </summary>
  Public Const SEND_PASSWORD_FILE_NAME As String = SEND_FOLDER & "PASSWORD.DAT"


  ''' <summary>
  ''' イメージフォルダ
  ''' </summary>
  Public Shared ReadOnly IMAGE_FORDER As String = "IMAGE\"

End Class
