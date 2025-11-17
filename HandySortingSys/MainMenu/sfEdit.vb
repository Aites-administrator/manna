Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass

Public Class sfEdit
  Inherits T.R.ZCommonCtrl.SFBase


  ' 呼出し元画面コードサンプル
  '''' <summary>
  '''' データ入力用サブフォーム表示
  '''' </summary>
  '''' <param name="prmInitialData">サブフォーム初期表示データ</param>
  'Private Sub ShowEditForm(Optional prmInitialData As Dictionary(Of String, String) = Nothing)
  '  Dim tmpSubForm As New sfEdit(Me)

  '  'サブフォームでデータ更新が行われた場合、一覧表示を更新する
  '  If typSfResult.SF_OK = tmpSubForm.ShowSubForm(prmInitialData, Me) Then
  '    MsgBox("OK")
  '  Else
  '    MsgBox("Cancel")
  '  End If
  'End Sub

#Region "メンバ"

#Region "private"

  ''' <summary>
  ''' 更新フラグ
  ''' </summary>
  Private _EditFlg As Boolean = False

  ''' <summary>
  ''' 呼出元フォーム保持
  ''' </summary>
  Private _ParentForm As Form1

  ''' <summary>
  ''' 初期データ
  ''' </summary>
  Private _TargetData As New Dictionary(Of String, String)

#End Region

#End Region

#Region "プロパティー"

#Region "プライベート"

  ''' <summary>
  ''' 更新モードフラグ
  ''' </summary>
  ''' <remarks>
  ''' 以下の制御を行う
  ''' ・モードラベルの文言
  ''' ・キー項目の入力可否
  ''' </remarks>
  ''' <returns>
  '''  True   …更新モード
  '''  False  …新規モード
  ''' </returns>
  Private Property EditFlg As Boolean
    Get
      Return _EditFlg
    End Get
    Set(value As Boolean)
      _EditFlg = value

      ' キー項目入力制限
      'CmbMaterial1.Enabled = Not _EditFlg

      ' モードラベル文言設定
      'With lblEditType
      '  If _EditFlg Then
      '    .Text = "更新"
      '    .ForeColor = Color.Blue
      '  Else
      '    .Text = "新規"
      '    .ForeColor = Color.Black
      '  End If
      'End With

    End Set
  End Property

#End Region

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmParentForm"></param>
  Public Sub New(prmParentForm As Form1)

    ' この呼び出しはデザイナーで必要です。
    InitializeComponent()

    ' InitializeComponent() 呼び出しの後で初期化を追加します。
    MyBase.lcCallBackInitForm = AddressOf InitForm

    _ParentForm = prmParentForm

    MyBase.SfResult = typSfResult.SF_CANCEL

  End Sub

#End Region

#Region "メソッド"

#Region "プライベート"

  ''' <summary>
  ''' 画面初期化
  ''' </summary>
  ''' <param name="prmTargetData">呼出元画面で設定されたパラメータ</param>
  ''' <remarks>
  '''   パラメータを画面に表示する
  ''' </remarks>
  Private Sub InitForm(prmTargetData As Dictionary(Of String, String))

    EditFlg = prmTargetData IsNot Nothing

    _TargetData = prmTargetData
  End Sub

  ''' <summary>
  ''' 一覧画面より渡されたデータを画面に表示
  ''' </summary>
  Private Sub SetTargetData()
    Dim tmpKeyName As String

    If _TargetData IsNot Nothing Then

      With _TargetData

        ' コンボボックスの初期データ表示
        'tmpKeyName = "PlantCoder"
        'If .ContainsKey(tmpKeyName) Then
        '  Me.CmbPlant1.SelectedValue = .Item(tmpKeyName)
        'End If

        ' テキストボックスの初期データ表示
        'tmpKeyName = "LastUpdate"
        'If .ContainsKey(tmpKeyName) Then
        '  Me.txtLastupdate.Text = .Item(tmpKeyName)
        'End If

      End With

    End If

  End Sub


#End Region

#Region "SQL関連"

  ''' <summary>
  ''' マスタ参照用SQL文
  ''' </summary>
  ''' <returns></returns>
  Private Function SqlSelXXXX() As String
    Dim sql As String = String.Empty

    sql &= " SELECT * "
    sql &= " FROM "
    sql &= " WHERE 1 = 1"

    Return sql

  End Function


  ''' <summary>
  ''' 新規レコード作成用SQL文
  ''' </summary>
  ''' <returns></returns>
  Private Function SqlInsXXX() As String
    Dim sql As String = String.Empty
    Dim tmpKeyValue As New Dictionary(Of String, String)
    Dim tmpInsertItemz As New Dictionary(Of String, String)

    ComSetDictionaryVal(tmpKeyValue, "[**テーブル項目名**]", "[**設定する値**]")
    tmpInsertItemz = ComCreateInsertItem(tmpKeyValue)

    sql &= " INSERT INTO [**テーブル名**](" & tmpInsertItemz("Keyz") & ") "
    sql &= " VALUES(" & tmpInsertItemz("Valuez") & ") "

    Return sql

  End Function

  ''' <summary>
  ''' データ更新用SQL文
  ''' </summary>
  ''' <returns></returns>
  Private Function SqlUpdXXXX() As String
    Dim sql As String = String.Empty

    sql &= " UPDATE XXXX"
    sql &= " SET LASTUPDATE = '" & ComGetProcDate() & "'"
    sql &= "    ,XXXXX = " & 1
    sql &= " WHERE 1 = 1 "
    sql &= "   AND LASTUPDATE = '" & 1 & "'"

    Return sql
  End Function

#End Region

#Region "DB操作関連"

  ''' <summary>
  ''' 新規データ追加処理
  ''' </summary>
  Private Sub InsertDb()
    Dim tmpDb As New clsSqlServer

    Try
      If 1 <> tmpDb.Execute(SqlInsXXX()) Then
        Throw New Exception("追加に失敗しました")
      End If
    Catch ex As Exception
      ComWriteErrLog(ex)
      Throw New Exception("追加に失敗しました")
    Finally
      tmpDb.Dispose()
    End Try

  End Sub

  ''' <summary>
  ''' 既存データ更新処理
  ''' </summary>
  Private Sub UpdateDb()
    Dim tmpDb As New clsSqlServer

    Try
      If 1 <> tmpDb.Execute(SqlUpdXXXX()) Then
        Throw New Exception("更新に失敗しました")
      End If
    Catch ex As Exception
      ComWriteErrLog(ex)
      Throw New Exception("更新に失敗しました")
    Finally
      tmpDb.Dispose()
    End Try

  End Sub

  ''' <summary>
  ''' マスタ参照処理
  ''' </summary>
  ''' <remarks>
  ''' キー項目に一致するデータを画面に表示する
  ''' ユーザー操作によるキー項目編集後に実行すること
  ''' ※キー項目オブジェクトのSelectedIndexChanged, Validated等で実行
  ''' </remarks>
  Private Sub ReadMst()
    Dim tmpDb As New clsSqlServer
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelXXXX())
      With tmpDt.Rows
        If .Count > 0 Then
          ' 取得した値を画面に反映
          'If .Item(0).Item("SEALING_CODE").ToString() <> "" Then
          '  Me.CmbSeal.SelectedValue = .Item(0).Item("SEALING_CODE").ToString()
          'Else
          '  Me.CmbSeal.SelectedIndex = -1
          'End If
          'Me.txtLastupdate.Text = .Item(0).Item("LAST_UPDATE").ToString()

          ' 更新モードに変更
          Me.EditFlg = True

        End If
      End With
    Catch ex As Exception
      ComWriteErrLog(ex)
      Throw New Exception("設定の取得に失敗しました")
    Finally
      tmpDt.Dispose()
      tmpDb.Dispose()
    End Try

  End Sub
#End Region

#End Region

#Region "イベントプロシージャー"

#Region "フォーム関連"

  ''' <summary>
  ''' フォームロード時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Call SetTargetData()
  End Sub

#End Region

#End Region







  Private Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'BtnBase1
    '
    '
    'TextBox1
    '
    '
    'BtnBase2
    '
    '
    'sfEdit
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.ClientSize = New System.Drawing.Size(686, 415)
    Me.DoubleBuffered = True
    Me.KeyPreview = True
    Me.Name = "sfEdit"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

End Class
