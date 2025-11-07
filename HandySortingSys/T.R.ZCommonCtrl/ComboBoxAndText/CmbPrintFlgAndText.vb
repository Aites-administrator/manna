Public Class CmbPrintFlgAndText

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 印刷フラグコンボボックス＋名称表示 コントロール
  ''' コード入力用テキストボックス（TxtBaseを継承）と
  ''' 印刷フラグコンボボックス（CmbMstBaseを継承）の
  ''' 複合コントロールです
  ''' </summary>
  Private _codeFormat As String
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
      CmbDummy.SelectedIndex = value
    End Set
  End Property
#End Region
#End Region

#Region "メソッド"
#Region "パブリック"

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

#Region "プライベート"
  ''' <summary>
  ''' フォームロード時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub ComboBoxAndText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    _codeFormat = CmbDummy.CodeFormat

  End Sub

  ''' <summary>
  ''' コンボボックスの選択内容をテキストボックスに反映する
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbDummy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDummy.SelectedIndexChanged

    If CmbDummy.SelectedIndex <> -1 Then
      TxtDummy.Text = CmbDummy.Text
    End If

  End Sub

  ''' <summary>
  ''' テキストボックスによるコード入力対応
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtDummy_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDummy.Validating

    Dim wkText As TextBox = CType(sender, TextBox)

    Try
      If IsNumeric(wkText.Text) Then
        CmbDummy.SelectedValue = Val(wkText.Text).ToString(_codeFormat)
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      e.Cancel = True
    End Try

  End Sub
#End Region

End Class
