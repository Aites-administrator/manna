Imports System.Drawing.Drawing2D
''' <summary>
''' Btn操作クラス
''' </summary>
''' 
Public Class BtnMainMenuBase

  Inherits BtnBase

#Region "プライベート"
  '--- タイトル ---
  Private _Title As String
  ' メッセージ出力ラベルテキスト
  Private _msgLabelText As String
  '--- アイコン ---
  Private _Icon As Image
  '--- 背景色 ---
  Private _ButtonColor As Color
  '--- テキスト色 ---
  Private _ForeColor As Color
  '--- アクセスキー ---
  Private _SetAccessKey As Keys

#End Region

#Region "パブリック"
  '--- タイトル ---
  Public Property Title As String
    Get
      Return _Title
    End Get
    Set(value As String)
      _Title = value
      Me.Text = value
      Me.TextAlign = ContentAlignment.MiddleRight
    End Set
  End Property
  '--- アイコン ---
  Public Property Icon As Image
    Get
      Return _Icon
    End Get
    Set(value As Image)
      _Icon = value

      ResizeIcon()
    End Set
  End Property
  '--- 背景色 ---
  Public Property ButtonColor As Color
    Get
      Return _ButtonColor
    End Get
    Set(value As Color)
      _ButtonColor = value
      Me.BackColor = value
      Me.FlatStyle = FlatStyle.Flat
      Me.FlatAppearance.BorderSize = 0
    End Set
  End Property

  '--- ボタン文字色 ---
  Public Property BtnForeColor As Color
    Get
      Return _ForeColor
    End Get
    Set(value As Color)
      _ForeColor = value
      Me.ForeColor = value
    End Set
  End Property

  '--- アクセスキー ---
  Public Property SetAccessKey As Keys
    Get
      Return _SetAccessKey
    End Get
    Set(value As Keys)
      _SetAccessKey = value
      Me.AccessKey = value
    End Set
  End Property

#End Region


#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()
    Me.AccessKey = SetAccessKey
    MyBase.InitLayout()
  End Sub

  Protected Overrides Sub InitLayout()
    If Me.Font Is Nothing OrElse Me.Font.Size = 0 Then
      Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    End If

    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0

  End Sub

#End Region

#Region "イベントプロシージャー"
  Private Sub MenuButtonControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
    ResizeIcon()
    MakeRoundedButton(Me, 20)

  End Sub

#End Region

  Private Sub ResizeIcon()

    If _Icon IsNot Nothing _
      AndAlso Me.Height > 0 Then
      Dim scale As Double = 0.35
      Dim targetHeight As Integer = CInt(Me.Height * scale)
      Dim ratio As Double = _Icon.Width / _Icon.Height
      Dim targetWidth As Integer = CInt(targetHeight * ratio)
      Dim resized As New Bitmap(_Icon, targetWidth, targetHeight)
      Me.Image = resized
      Me.ImageAlign = ContentAlignment.MiddleLeft
      Me.TextImageRelation = TextImageRelation.ImageBeforeText
    Else
      Me.Image = Nothing
    End If
  End Sub

  Protected Overloads Sub MakeRoundedButton(btn As Button, radius As Integer)
    Dim path As New GraphicsPath()
    path.AddArc(0, 0, radius, radius, 180, 90)
    path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
    path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
    path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
    path.CloseAllFigures()
    btn.Region = New Region(path)
  End Sub


End Class
