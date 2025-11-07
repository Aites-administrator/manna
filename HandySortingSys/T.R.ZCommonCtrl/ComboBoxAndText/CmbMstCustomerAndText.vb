Public Class CmbMstCustomerAndText

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 得意先コンボボックス＋名称表示 コントロール
  ''' コード入力用テキストボックス（TxtBaseを継承）と
  ''' 得意先フラグコンボボックス（CmbMstBaseを継承）の
  ''' 複合コントロールです
  ''' </summary>
  Private _codeFormat As String

  ''' <summary>
  ''' イベントキャンセル有無
  ''' </summary>
  Private _EventCancel As Boolean = False
  ' コンボボックス内の押下キー
  Private _pressKeyCode As String = String.Empty

#End Region

#Region "パブリック"
  ' Cmb_SelectIndexというイベントを新たに定義
  Public Event eventCmbDummy_SelectIndex As EventHandler
  ' Text_Validatingというイベントを新たに定義
  Public Event eventTxtDummy_Validating As EventHandler
#End Region
#End Region

#Region "プロパティー"
#Region "パブリック"
  ''' <summary>
  ''' コンボボックスのインデックス番号を取得／設定する
  ''' </summary>
  ''' <returns></returns>
  Public Property SelectedIndex() As Integer
    Get
      Return CmbDummy.SelectedIndex
    End Get
    Set(value As Integer)
      If CmbDummy.SelectedIndex <> -1 Then
        CmbDummy.SelectedIndex = value
      End If
    End Set
  End Property

  ''' <summary>
  ''' 選択されている項目の値を取得する
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property SelectedValue() As String
    Get
      Return CmbDummy.SelectedValue
    End Get
  End Property

  ''' <summary>
  ''' テキストボックスのテキストを取得／設定する
  ''' </summary>
  ''' <returns></returns>
  Public Overloads Property Text() As String
    Get
      Return CmbDummy.Text
    End Get
    Set(value As String)
      CmbDummy.Text = value
    End Set
  End Property

  ''' <summary>
  ''' イベントキャンセル有無
  ''' </summary>
  ''' <returns></returns>
  Public Property EventCancel() As Boolean
    Get
      Return Me._EventCancel
    End Get
    Set(ByVal value As Boolean)
      Me._EventCancel = value
    End Set
  End Property

  ''' <summary>
  ''' 
  ''' </summary>
  Public Sub DroppedDown(prmDown As Boolean)

    Me.ActiveControl = Me.CmbDummy
    Me.CmbDummy.Select()
    CmbDummy.DroppedDown = prmDown

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  Public Sub ControlSelect()

    Me.ActiveControl = CmbDummy
    '  CmbDummy.Select()

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="prmColor"></param>
  Public Sub SetBackColor(prmColor As Color)

    CmbDummy.BackColor = prmColor

  End Sub


#End Region
#End Region

#Region "プライベート"
  ''' <summary>
  ''' フォームロード時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbMstCustomerAndText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    _codeFormat = CmbDummy.CodeFormat

    _pressKeyCode = String.Empty

  End Sub

  ''' <summary>
  ''' コンボボックスの選択内容をテキストボックスに反映する
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbDummy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDummy.SelectedIndexChanged

    ' コンボボックス内で上キーが押された場合
    If (_pressKeyCode.Equals("Up")) Then
      _pressKeyCode = ""
      Return
    End If
    ' コンボボックス内で下キーが押された場合
    If (_pressKeyCode.Equals("Down")) Then
      _pressKeyCode = ""
      Return
    End If
    Console.WriteLine("CmbDummy_SelectedIndexChanged")
      ' イベントを発生させる
      RaiseEvent eventCmbDummy_SelectIndex(Me, EventArgs.Empty)

  End Sub


  ''' <summary>
  ''' コンボボックス内での押下キーを記憶する
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbDummy_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbDummy.KeyDown

    _pressKeyCode = ""
    Select Case e.KeyCode
      Case Keys.Up
        _pressKeyCode = "Up"
        'コード
      Case Keys.Left
        'コード
      Case Keys.Right
        'コード
      Case Keys.Down
        'コード
        _pressKeyCode = "Down"

    End Select

  End Sub

  ''' <summary>
  ''' テキストボックスによるコード入力対応
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtDummy_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmbDummy.Validating

    ' イベントを発生させる
    RaiseEvent eventTxtDummy_Validating(Me, EventArgs.Empty)

    If (Me.EventCancel) Then
      e.Cancel = True
    End If

  End Sub

  ''' <summary>
  ''' 数値とバックスペースのみ入力可
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtDummy_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDummy.KeyPress

    ' ESCキー処理
    If e.KeyChar = ChrW(Keys.Escape) Then
      CmbDummy.DroppedDown = False
      Return
    End If

    If Me.CmbDummy.Text.Length >= 6 Then
      If e.KeyChar <> ControlChars.Back Then
        e.Handled = True
      End If
    Else
      ' 数値とバックスペースのみ入力可
      If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
      AndAlso e.KeyChar <> ControlChars.Back Then
        '押されたキーが 0～9でない場合は、イベントをキャンセルする
        e.Handled = True
      End If
    End If

  End Sub

#End Region

End Class
