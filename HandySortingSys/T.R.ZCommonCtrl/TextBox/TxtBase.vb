Imports System.Runtime.InteropServices
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtBase
  Inherits TextBox

#Region "定数定義"
  Private Const WM_PASTE As Integer = &H302
  Private Const WM_LBUTTONDOWN As Integer = &H201
  Private Const WM_RBUTTONDOWN As Integer = &H204
  Private Const WM_MBUTTONDOWN As Integer = &H207
  Private Const WM_LBUTTONDBLCLK As Integer = &H203
  Private Const WM_MBUTTONDBLCLK As Integer = &H206
  Private Const WM_SETFOCUS As Integer = &H7
#End Region

#Region "メンバ"
#Region "プライベート"
  ' フォーカス取得フラグ
  ' マウスでのフォーカス移動時の全選択に使用
  Private _OnFocus As Boolean

  ' メッセージ出力ラベル
  Private _msgLabel As Label
  ' メッセージ出力ラベルテキスト
  Private _msgLabelText As String

  ''' <summary>
  ''' 入力可能最大文字数
  ''' </summary>
  Private _MaxChar As Integer

  ''' <summary>
  ''' Multiline設定時、改行入力可能設定
  ''' </summary>
  Private _MultiLineInput As Boolean = False

  ''' <summary>
  ''' 最終入力テキスト
  ''' </summary>
  Private _LastText As String

  ''' <summary>
  ''' デフォルト背景色
  ''' </summary>
  Private _BackColor As Color

  ''' <summary>
  ''' フォーカス選択不可設定
  ''' </summary>
  Private _NoFocus As Boolean = False

#End Region

#Region "パブリック"

  Delegate Sub CallBackValidated(sender As Object, e As EventArgs)
  Public lcCallBackValidated As CallBackValidated = Nothing

  Delegate Sub CallBackSetText()
  Public lcCallBackSetText As CallBackSetText = Nothing

#End Region

#End Region

#Region "プロパティー"

#Region "パブリック"
  ''' <summary>
  ''' 最終入力テキスト
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>
  '''   更新前に最終に入力されていたテキスト
  ''' </remarks>
  Public ReadOnly Property LastText As String
    Get
      Return _LastText
    End Get
  End Property

  ''' <summary>
  ''' Multiline設定時、改行入力可能設定
  ''' </summary>
  ''' <returns>True：改行入力可能、False:改行入力不可</returns>
  Public Property MultiLineInput As Boolean
    Get
      Return _MultiLineInput
    End Get
    Set(value As Boolean)
      _MultiLineInput = value
    End Set
  End Property

  ''' <summary>
  ''' Textプロパティのオーバーライド
  ''' </summary>
  ''' <returns></returns>
  Public Overrides Property Text As String
    Get
      Return MyBase.Text
    End Get
    Set(value As String)
      MyBase.Text = value

      If lcCallBackSetText IsNot Nothing Then
        Call lcCallBackSetText()
      End If

      If _LastText <> value Then
        ' 最終入力テキスト更新
        _LastText = value
      End If
    End Set
  End Property

  ''' <summary>
  ''' フォーカス選択不可設定
  ''' </summary>
  ''' <returns>True：選択可能、False:選択不可</returns>
  Public Property NoFocus As Boolean
    Get
      Return _NoFocus
    End Get
    Set(value As Boolean)
      _NoFocus = value
    End Set
  End Property

#End Region

#End Region

#Region "コンストラクタ"

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()
    Me.New(0)
  End Sub

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmMaxChar">入力可能最大文字数</param>
  Public Sub New(prmMaxChar As Integer)
    _OnFocus = False
    _MaxChar = prmMaxChar
    _LastText = String.Empty
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

  Public Function GetMaxChar() As Integer
    Return _MaxChar
  End Function

  Public Sub SetMaxChar(prmMaxChar As Integer)
    _MaxChar = prmMaxChar
  End Sub
#End Region

#End Region

#Region "イベントプロシージャー"
  Private Sub TxtBase_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    Dim wkText As TextBox = CType(sender, TextBox)
    clsCommonFnc.SetLeftMargin(wkText.Handle, 10)

  End Sub

  Private Sub TxtBase_MousUp(sender As Object, e As EventArgs) Handles Me.MouseUp
    If _OnFocus Then
      _OnFocus = False
      sender.SelectAll()
    End If
  End Sub

  Private Sub TxtBase_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    sender.SelectAll()
    _OnFocus = True

    _BackColor = Me.BackColor
    Me.BackColor = Color.Aqua

    'メッセージラベルの定義が未設定の場合
    If _msgLabel Is Nothing Then
      Exit Sub
    Else
      'メッセージラベルへのメッセージの表示
      _msgLabel.Text = _msgLabelText
    End If

  End Sub

  Private Sub TxtBase_Leave(sender As Object, e As EventArgs) Handles Me.Leave
    Me.BackColor = _BackColor
  End Sub
  ''' <summary>
  ''' キー入力時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    ' 入力可能最大文字数が設定されている場合は最大文字数までの入力を可能とする
    If Me.Text.Length >= _MaxChar AndAlso _MaxChar > 0 AndAlso Me.SelectedText.Length < _MaxChar Then
      If e.KeyChar <> ControlChars.Back Then
        e.Handled = True
      End If
    End If

    ' 改行入力不可の場合
    If (MultiLineInput = False) Then
      If e.KeyChar = vbCr Then
        e.Handled = True
      End If
    End If

    e.KeyChar = ComXmlEscapeToZenkaku(e.KeyChar)

  End Sub

  ''' <summary>
  ''' 更新後処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub EditTxtValidated(sender As Object, e As EventArgs) Handles Me.Validated
    Dim tmpValue As String = DirectCast(sender, TextBox).Text

    If lcCallBackValidated IsNot Nothing Then
      Call lcCallBackValidated(sender, e)
    End If

    If _LastText <> tmpValue Then
      ' 最終入力テキスト更新
      _LastText = tmpValue

    End If

  End Sub

#End Region

#Region "プロテクテッド"

  ''' <summary>
  ''' WndProcメソッドオーバーライド(フォーカス選択不可判定）
  ''' </summary>
  ''' <param name="m"></param>
  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

    If (NoFocus) Then
      Select Case m.Msg
        Case WM_PASTE
          Return
        Case WM_LBUTTONDOWN
          Return
        Case WM_RBUTTONDOWN
          Return
        Case WM_MBUTTONDOWN
          Return
        Case WM_LBUTTONDBLCLK
          Return
        Case WM_MBUTTONDBLCLK
          Return
        Case WM_SETFOCUS
          Return
      End Select
    End If

    MyBase.WndProc(m)

  End Sub

#End Region
End Class
