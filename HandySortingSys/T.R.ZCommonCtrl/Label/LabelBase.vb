'----------------------------------------------
' 検索タイトル名ラベル
' ＜仮作成＞
'----------------------------------------------

Public Class LabelBase
  Inherits Label

#Region "メンバ"

#Region "プライベート"

  ''' <summary>
  ''' ボーダーラインの色 
  ''' </summary>
  Private _BorderColor As Color = Color.Red

  ''' <summary>
  ''' ボーダーラインの色 
  ''' </summary>
  Private _BorderThickness As Integer = 0

  Private Const WM_PAINT = &HF

#End Region

#End Region

#Region "パブリック"

  ''' <summary>
  ''' ボータラインの太さ
  ''' </summary>
  ''' <returns></returns>
  Public Property BorderThickness() As Integer
    Get
      Return _BorderThickness
    End Get
    Set(ByVal value As Integer)
      _BorderThickness = value
    End Set
  End Property

  ''' <summary>
  ''' ボーダーラインの色 
  ''' </summary>
  ''' <returns></returns>
  Public Property BorderColor() As Color
    Get
      Return _BorderColor
    End Get
    Set(ByVal value As Color)
      _BorderColor = value
    End Set
  End Property

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()

    With Me
      .BorderColor = Color.Black
      .TabStop = False
    End With

  End Sub

#End Region

#Region "プロテクテッド"

  ''' <summary>
  ''' WndProcメソッドオーバーライド
  ''' </summary>
  ''' <param name="m"></param>
  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

    MyBase.WndProc(m)

    If (m.Msg = WM_PAINT) Then
      If (BorderThickness() <> 0) Then

        Using g As Graphics = CreateGraphics()
          ' 指定色で描画する
          Dim p As New System.Drawing.Pen(_BorderColor, BorderThickness())
          g.DrawRectangle(p, 0, 0, Me.Width - BorderThickness(), Me.Height - BorderThickness())
        End Using
      End If
    End If

  End Sub

#End Region

End Class
