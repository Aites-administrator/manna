Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports Microsoft.VisualBasic.PowerPacks

Public Class FormBaseOrder

  ' 標準フォームの幅・高さ
  Public Const STANDARD_FORM_WIDTH As Integer = 1550

  Public Const STANDARD_FORM_HEIGHT As Integer = 950

  ' ファンクションボタンのサイズ
  Public Const FUNCTION_BUTTON_WIDTH As Integer = 120

  Public Const FUNCTION_BUTTON_HEIGHT As Integer = 40


  ' フォームの背景色
  ''
  Public Shared ReadOnly FORM_BACKCOLOR As Color = System.Drawing.Color.FromArgb(250, 250, 250)

  ''' <summary>
  '''  テキストボックスの背景
  ''' </summary>
  Public Shared ReadOnly TEXT_BACKCOLOR As Color = System.Drawing.Color.FromArgb(255, 255, 255)

  ''' <summary>
  '''  ラベルの背景
  ''' </summary>
  Public Shared ReadOnly LABEL_BACKCOLOR As Color = System.Drawing.Color.FromArgb(240, 240, 240)

  ''' <summary>
  '''  ボタンの背景
  ''' </summary>
  Public Shared ReadOnly BUTTON_BACKCOLOR As Color = System.Drawing.Color.FromArgb(222, 222, 222)

#Region "プライベート"
#Region "メンバ"

  ''' <summary>
  ''' タイトル
  ''' </summary>
  Private _Title As String = String.Empty

  ''' <summary>
  ''' 得意先コード
  ''' </summary>
  Private _TKCode As String = String.Empty

  ''' <summary>
  ''' 得意先名
  ''' </summary>
  Private _TKName As String = String.Empty

  ''' <summary>
  ''' 商品コード
  ''' </summary>
  Private _ItemCode As String = String.Empty

  ''' <summary>
  ''' 商品名
  ''' </summary>
  Private _ItemName As String = String.Empty

  ''' <summary>
  ''' モード
  ''' </summary>
  Private _FormMode As Integer = 0

  ''' <summary>
  ''' 読取専用モード
  ''' </summary>
  Private _FormReadOnly As Boolean = False

#End Region
#End Region

#Region "パブリック"
  ''' <summary>
  ''' 表題
  ''' </summary>
  Public Property FORMTitle As String
    Get
      Return _Title
    End Get
    Set(value As String)
      _Title = value
    End Set
  End Property

  ''' <summary>
  ''' 得意先コード
  ''' </summary>
  Public Property TKCode As String
    Get
      Return _TKCode
    End Get
    Set(value As String)
      _TKCode = value
    End Set
  End Property

  ''' <summary>
  ''' 得意先名
  ''' </summary>
  Public Property TKName As String
    Get
      Return _TKName
    End Get
    Set(value As String)
      _TKName = value
    End Set
  End Property

  ''' <summary>
  ''' 商品コード
  ''' </summary>
  Public Property ItemCode As String
    Get
      Return _ItemCode
    End Get
    Set(value As String)
      _ItemCode = value
    End Set
  End Property

  ''' <summary>
  ''' 商品名
  ''' </summary>
  Public Property ItemName As String
    Get
      Return _ItemName
    End Get
    Set(value As String)
      _ItemName = value
    End Set
  End Property

  ''' <summary>
  ''' モード
  ''' </summary>
  Public Property FormMode As Integer
    Get
      Return _FormMode
    End Get
    Set(value As Integer)
      _FormMode = value
    End Set
  End Property

  ''' <summary>
  ''' 読取専用モード
  ''' </summary>
  Public Property FormReadOnly As Boolean
    Get
      Return _FormReadOnly
    End Get
    Set(value As Boolean)
      _FormReadOnly = value
    End Set
  End Property


#End Region

  Private Sub FormBaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Me.BackColor = FORM_BACKCOLOR

  End Sub

  ''' <summary>
  ''' フォーム上でのキー入力イベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    Dim tmpDirection As String = String.Empty

    ' カーソルキーでのフォーカス移動
    If IsTargetControl(New TxtBase, ActiveControl) Then
      ' テキストボックスでのカーソルキー入力
      If ActiveControl.Text.Equals(String.Empty) Then
        If e.KeyCode = Keys.Down _
          OrElse e.KeyCode = Keys.Right Then
          ' ↓・→（進む）
          Call SetFocusNextCtrl(Me.ActiveControl)

        ElseIf e.KeyCode = Keys.Up _
          OrElse e.KeyCode = Keys.Left Then
          ' ↑・←（戻る）
          Call SetFocusPreviousCtrl(Me.ActiveControl)
        End If
      End If
    ElseIf IsTargetControl(New CmbBase, ActiveControl) Then
      ' コンボボックスでのカーソルキー入力
      If ActiveControl.Text.Equals(String.Empty) Then
        If e.KeyCode = Keys.Right Then
          ' →（進む）
          Call SetFocusNextCtrl(Me.ActiveControl)
        ElseIf e.KeyCode = Keys.Left Then
          ' ←（戻る）
          Call SetFocusPreviousCtrl(Me.ActiveControl)
        End If
      End If
    End If

  End Sub

End Class
