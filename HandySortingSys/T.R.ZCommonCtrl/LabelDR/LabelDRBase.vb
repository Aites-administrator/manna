Public Class LabelDRBase
  Inherits TextBox

#Region "メンバ"

#Region "プライベート"
  ' フォーカス取得フラグ
  ' マウスでのフォーカス移動時の全選択に使用
  Private _OnFocus As Boolean

  ' メッセージ出力ラベル
  Private _msgLabel As Label
  ' メッセージ出力ラベルテキスト
  Private _msgLabelText As String

#End Region

#End Region

#Region "コンストラクタ"

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()
    Me.New(0)

    Multiline = True

    [ReadOnly] = True

  End Sub

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmMaxChar">入力可能最大文字数</param>
  Public Sub New(prmMaxChar As Integer)
    _OnFocus = False
  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"
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

#End Region

#End Region

#Region "イベントプロシージャー"
  Private Sub LabelDRBase_MousUp(sender As Object, e As EventArgs) Handles Me.MouseUp
    If _OnFocus Then
      _OnFocus = False
      sender.SelectAll()
    End If
  End Sub

  Private Sub LabelDRBase_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    sender.SelectAll()
    _OnFocus = True

    'メッセージラベルの定義が未設定の場合
    If _msgLabel Is Nothing Then
      Exit Sub
    Else
      'メッセージラベルへのメッセージの表示
      _msgLabel.Text = _msgLabelText
    End If

  End Sub
#End Region

End Class
