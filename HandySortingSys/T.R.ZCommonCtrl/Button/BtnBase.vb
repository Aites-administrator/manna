Imports System.Drawing.Text
Imports System.Text.RegularExpressions
''' <summary>
''' Btn操作クラス
''' </summary>
''' 
Public Class BtnBase

  Inherits Button

#Region "プライベート"
  ' メッセージ出力ラベル
  Private _msgLabel As Label
  ' メッセージ出力ラベルテキスト
  Private _msgLabelText As String


#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()

    'イメージがコントロールのテキストの上部に表示されるように指定します。
    Me.TextImageRelation = TextImageRelation.ImageAboveText

  End Sub


#End Region

#Region "イベントプロシージャー"
  Private Sub BtnBase_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter

    'メッセージラベルの定義が未設定の場合
    If _msgLabel Is Nothing Then
      Exit Sub
    Else
      'メッセージラベルへのメッセージの表示
      _msgLabel.Text = _msgLabelText
    End If

  End Sub

  ''' <summary>
  ''' メッセージラベルの定義
  ''' </summary>
  ''' <param name="msgLabel">メッセージを表示するラベル情報</param>
  Public Sub SetMsgLabel(msgLabel As Label)

    _msgLabel = msgLabel

  End Sub

  ''' <summary>
  ''' メッセージラベルへのメッセージ表示
  ''' </summary>
  ''' <param name="msg">メッセージ</param>
  Public Sub SetMsgLabelText(msg As String)

    _msgLabelText = msg

  End Sub

  ''' <summary>
  ''' ファンクションキー名設定
  ''' </summary>
  ''' <param name="prmFuncName">ファンクションキー名</param>
  Public Sub SetFunctionKeyName(prmFuncName As String)

    ' キャンバス
    Dim gra As Graphics = Graphics.FromImage(Me.Image)

    ' 書き出すテキストのフォントを作成
    Dim myFont As Font = New Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
    ' 黒色で書きだす
    Dim myBrush As New SolidBrush(Color.FromArgb(0, 0, 0))
    ' アンチエイリアス設定
    gra.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
    ' 書き出し
    gra.DrawString(prmFuncName, myFont, myBrush, 10, 2)

    ' コントロール上のテキストおよびイメージの位置
    Me.TextImageRelation = TextImageRelation.ImageAboveText

  End Sub

  ''' <summary>
  ''' コンボボックスマーク設定
  ''' </summary>
  ''' <param name="prmMark">コンボボックスマーク</param>
  Public Sub SetComboMark(prmMark As String)

    ' キャンバス
    Dim gra As Graphics = Graphics.FromImage(Me.Image)

    ' 書き出すテキストのフォントを作成
    Dim myFont As Font = New Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
    ' 黒色で書きだす
    Dim myBrush As New SolidBrush(Color.FromArgb(0, 0, 0))
    ' アンチエイリアス設定
    gra.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
    ' 書き出し
    gra.DrawString(prmMark, myFont, myBrush, 10, 2)

    ' コントロール上のテキストおよびイメージの位置
    Me.TextImageRelation = TextImageRelation.ImageAboveText

  End Sub

  ''' <summary>
  ''' ファンクションテキスト設定
  ''' </summary>
  ''' <param name="prmText">テキスト</param>
  Public Sub SetText(prmText As String)

    ' キャンバス
    Dim gra As Graphics = Graphics.FromImage(Me.Image)

    ' 書き出すテキストのフォントを作成
    Dim myFont As Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular)
    ' 黒色で書きだす
    Dim myBrush As New SolidBrush(Color.FromArgb(0, 0, 0))
    ' アンチエイリアス設定
    gra.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
    ' 書き出し
    Select Case prmText.Length
      Case 2
        drawIntervalString(gra, prmText, myFont, myBrush, 35, 22, 5)

      Case 3
        drawIntervalString(gra, prmText, myFont, myBrush, 26, 22, 4)
      Case 4
        drawIntervalString(gra, prmText, myFont, myBrush, 17, 22, 3)
      Case 5
        Dim chkKana As Boolean = False
        For i = 0 To prmText.Length - 1
          If Regex.IsMatch(prmText(i), "^[ァ-ー]+$") Then
            chkKana = True
          End If
        Next
        If (chkKana) Then
          drawIntervalString(gra, prmText, myFont, myBrush, 16, 22, 3)
        Else
          gra.DrawString(prmText, myFont, myBrush, 10, 22)
        End If
      Case Else
        gra.DrawString(prmText, myFont, myBrush, 10, 22)
    End Select

    ' コントロール上のテキストおよびイメージの位置
    Me.TextImageRelation = TextImageRelation.ImageAboveText

  End Sub

  ''' <summary>
  ''' ファンクションテキスト設定
  ''' </summary>
  ''' <param name="prmText">テキスト</param>
  Public Sub SetText2(prmText As String)

    ' キャンバス
    Dim gra As Graphics = Graphics.FromImage(Me.Image)

    ' 書き出すテキストのフォントを作成
    Dim myFont As Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular)
    ' 黒色で書きだす
    Dim myBrush As New SolidBrush(Color.FromArgb(0, 0, 0))
    ' アンチエイリアス設定
    gra.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
    ' 書き出し
    gra.DrawString(prmText, myFont, myBrush, 35, 12)

    ' コントロール上のテキストおよびイメージの位置
    Me.TextImageRelation = TextImageRelation.ImageAboveText

  End Sub



  ''' <summary>
  ''' ファンクションテキスト間隔設定
  ''' </summary>
  ''' <param name="prmGra">キャンバス</param>
  ''' <param name="prmText">テキスト</param>
  ''' <param name="prmFont">フォント</param>
  ''' <param name="prmBrush">ブラシの色</param>
  ''' <param name="x">横位置</param>
  ''' <param name="y">縦位置</param>
  ''' <param name="prmInterval"></param>
  Public Sub drawIntervalString(prmGra As Graphics,
                                prmText As String,
                                prmFont As Font,
                                prmBrush As Brush,
                                x As Integer,
                                y As Integer,
                                prmInterval As Integer)
    If (prmInterval > 0) Then
      Dim sz As SizeF

      For Each c As Char In prmText

        sz = prmGra.MeasureString(c.ToString, prmFont, PointF.Empty, StringFormat.GenericTypographic)

        prmGra.DrawString(c.ToString, prmFont, prmBrush, x, y)

        x = x + sz.Width + prmInterval

      Next
    Else
      prmGra.DrawString(prmText, prmFont, prmBrush, x, y)
    End If

  End Sub

  ''' <summary>
  ''' ファンクションテキスト設定
  ''' </summary>
  ''' <param name="prmText">テキスト</param>
  Public Sub SetFunctionText(prmFunName As String, prmText As String)

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName(prmFunName)

    SetText(prmText)

  End Sub

  ''' <summary>
  ''' ファンクションボタン初期設定
  ''' </summary>
  Public Sub InitSetFunction()

    Me.BackColor = Color.Transparent

    Me.FlatStyle = FlatStyle.Flat
    Me.Text = ""
    Me.FlatAppearance.BorderSize = 0
    Me.FlatAppearance.MouseDownBackColor = Color.Transparent
    Me.FlatAppearance.MouseOverBackColor = Color.Transparent

    ' 画像を設定
    Me.Image = My.Resources.ButtonFunction

    Me.Size = New Size(115, 48)

    Me.TabStop = False

  End Sub

#End Region

End Class
