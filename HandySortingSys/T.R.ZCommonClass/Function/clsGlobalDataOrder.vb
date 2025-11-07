Public Class clsGlobalDataOrder

  ' シングルクォーテーション
  Public Const SQM As String = "'"

  ' スペース
  Public Const SINGLE_SPACE As String = "' '"

  ''' <summary>
  ''' テキストボックス入力可背景色
  ''' </summary>
  Public Shared ReadOnly MULTIROW_DOUBLUCLICK_COLOR As Color = System.Drawing.Color.FromArgb(128, 0, 0)

  ''' <summary>
  ''' テキストボックス入力可背景色
  ''' </summary>
  Public Shared ReadOnly INPUT_OK_COLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)

  ''' <summary>
  ''' テキストボックス入力不可背景色
  ''' </summary>
  Public Shared ReadOnly INPUT_NG_COLOR As Color = System.Drawing.Color.FromArgb(240, 240, 240)

  ''' <summary>
  '''新規文字色
  ''' </summary>
  Public Shared ReadOnly PROCESS_NEW_COLOR As Color = System.Drawing.Color.FromArgb(255, 255, 0)

  ''' <summary>
  ''' 編集文字色
  ''' </summary>
  Public Shared ReadOnly PROCESS_EDIT_COLOR As Color = System.Drawing.Color.FromArgb(0, 170, 110)

  ''' <summary>
  '''  データリピーターの背景（奇数行）
  ''' </summary>
  Public Shared ReadOnly GRID_ODD_BACKCOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)

  ''' <summary>
  '''  データリピーターの背景（偶数行）
  ''' </summary>
  Public Shared ReadOnly GRID_EVEN_BACKCOLOR As Color = System.Drawing.Color.FromArgb(240, 248, 255)

  ''' <summary>
  '''  ボタンの背景色
  ''' </summary>
  Public Shared ReadOnly BUTTON_BACKCOLOR As Color = System.Drawing.Color.FromArgb(224, 224, 224)

  ''' <summary>
  '''  表題の背景
  ''' </summary>
  Public Shared ReadOnly TITLE_BACKCOLOR As Color = System.Drawing.Color.FromArgb(0, 0, 255)
  Public Shared ReadOnly TITLE_FORECOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)
  'Public Shared ReadOnly TITLE_BACKCOLOR As Color = System.Drawing.Color.FromArgb(0, 0, 0)
  'Public Shared ReadOnly TITLE_FORECOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 0)

  ''' <summary>
  '''  検索ラベルの背景
  ''' </summary>
  Public Shared ReadOnly SERCHLABEL_BACKCOLOR As Color = System.Drawing.Color.FromArgb(240, 240, 240)
  Public Shared ReadOnly SERCHLABEL_FORECOLOR As Color = System.Drawing.Color.FromArgb(0, 0, 0)

  ''' <summary>
  '''  データリピーターの表題の背景
  ''' </summary>
  Public Shared ReadOnly GRIDLABEL_BACKCOLOR As Color = System.Drawing.Color.FromArgb(73, 130, 176)
  Public Shared ReadOnly GRIDLABEL_FORECOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)
  Public Shared ReadOnly GRIDLABEL_BORDERCOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)

  ''' <summary>
  ''' ダブルクリック間隔（デフォルト）
  ''' </summary>
  Public Shared ReadOnly MULTIROW_DOUBLE_CLICK_CYCLE As Double = 0.5

End Class
