Public Class CmbMstItemAndText

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 得意先コンボボックス＋名称表示 コントロール
  ''' コード入力用テキストボックス（TxtBaseを継承）と
  ''' 得意先フラグコンボボックス（CmbMstBaseを継承）の
  ''' 複合コントロールです
  ''' </summary>
  Private _codeFormat As String
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
  ''' コンボボックスのDisplayMemberを取得／設定する
  ''' </summary>
  ''' <returns></returns>
  Public Property DisplayMember() As String
    Get
      Return CmbDummy.DisplayMember
    End Get
    Set(value As String)
      CmbDummy.DisplayMember = value
    End Set
  End Property

  ''' <summary>
  ''' コンボボックスのValueMemberを取得／設定する
  ''' </summary>
  ''' <returns></returns>
  Public Property ValueMember() As String
    Get
      Return CmbDummy.ValueMember
    End Get
    Set(value As String)
      CmbDummy.ValueMember = value
    End Set
  End Property

  ''' <summary>
  ''' コンボボックスのDataSourceを取得／設定する
  ''' </summary>
  ''' <returns></returns>
  Public Property DataSource() As Object
    Get
      Return CmbDummy.DataSource
    End Get
    Set(value As Object)
      CmbDummy.DataSource = value
    End Set
  End Property

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

#End Region
#End Region

#Region "メソッド"
#Region "パブリック"
  ''' <summary>
  ''' コンボボックスとテキストボックスのリセット
  ''' </summary>
  Public Function GetText() As String

    Return TxtDummy.Text

  End Function
#End Region
#End Region

#Region "プライベート"
  ''' <summary>
  ''' フォームロード時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbMstItemAndText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    _codeFormat = CmbDummy.CodeFormat

  End Sub

  ''' <summary>
  ''' コンボボックスの選択内容をテキストボックスに反映する
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbDummy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDummy.SelectedIndexChanged

    If CmbDummy.SelectedIndex <> -1 Then
      If (CmbDummy.Text.Length >= CmbDummy.CodeFormat.Length) Then
        TxtDummy.Text = CmbDummy.Text.Substring(0, CmbDummy.CodeFormat.Length)
      End If
    End If

    ' イベントを発生させる
    RaiseEvent eventCmbDummy_SelectIndex(Me, New EventArgs)

  End Sub

  ''' <summary>
  ''' テキストボックスによるコード入力対応
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtDummy_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDummy.Validating

    Try
      If IsNumeric(TxtDummy.Text) Then
        CmbDummy.SelectedValue = Val(TxtDummy.Text).ToString(_codeFormat)
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      e.Cancel = True
    End Try

    ' イベントを発生させる
    RaiseEvent eventTxtDummy_Validating(Me, New EventArgs)

#End Region

  End Sub


End Class
