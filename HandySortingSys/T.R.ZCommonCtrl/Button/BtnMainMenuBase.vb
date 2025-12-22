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
      Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
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
#End Region


#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()

  End Sub


#End Region

#Region "イベントプロシージャー"
  Private Sub MenuButtonControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
    ResizeIcon
  End Sub

#End Region

  Private Sub ResizeIcon()

    If _Icon IsNot Nothing _
      AndAlso Me.Height > 0 Then
      Dim scale As Double = 0.6
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

End Class
