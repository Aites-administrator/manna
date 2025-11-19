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

#Region "パブリック"
  Public BtnText As String
  Public AccessKey As Keys
#End Region


#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()

    'イメージがコントロールのテキストの上部に表示されるように指定します。
    Me.TextImageRelation = TextImageRelation.ImageAboveText
    BtnText = Nothing
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

  Protected Overrides Sub InitLayout()
    Dim tmpKeyLblHeader As String = String.Empty
    If BtnText IsNot Nothing Then
      Select Case Me.AccessKey
        Case Keys.Escape
          tmpKeyLblHeader = "ESC"
        Case Keys.F1
          tmpKeyLblHeader = "F1"
        Case Keys.F2
          tmpKeyLblHeader = "F2"
        Case Keys.F3
          tmpKeyLblHeader = "F3"
        Case Keys.F4
          tmpKeyLblHeader = "F4"
        Case Keys.F5
          tmpKeyLblHeader = "F5"
        Case Keys.F6
          tmpKeyLblHeader = "F6"
        Case Keys.F7
          tmpKeyLblHeader = "F7"
        Case Keys.F8
          tmpKeyLblHeader = "F8"
        Case Keys.F9
          tmpKeyLblHeader = "F9"
        Case Keys.F10
          tmpKeyLblHeader = "F10"
        Case Keys.F11
          tmpKeyLblHeader = "F11"
        Case Keys.F12
          tmpKeyLblHeader = "F12"
      End Select

      Me.Text = tmpKeyLblHeader & vbCrLf & BtnText
      Me.Font = New Font("Segoe UI", 11, FontStyle.Regular)
    End If
    MyBase.InitLayout()
  End Sub

#End Region

End Class
