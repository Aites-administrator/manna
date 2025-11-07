Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtMstStaff
  Inherits TxtCodeBase

  ' 担当者マスタ入力用テキストボックス
#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 担当者名
  ''' </summary>
  Private _tantoName As String

  ''' <summary>
  ''' 備考
  ''' </summary>
  Private _tantoMark As String

#End Region
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("担当者コードを入力してください。")
  End Sub

  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub
#End Region

#Region "パブリック"
  ''' <summary>
  ''' 担当者名の取得
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>デフォルト False</remarks>
  Public ReadOnly Property TantoName As String
    Get
      Return _tantoName
    End Get
  End Property

#End Region

#Region "メソッド"
#Region "パブリック"

  ''' <summary>
  ''' 担当者コードの取得
  ''' </summary>
  ''' <param name="prmTantoCode">担当者コード</param>
  Public Sub GetTantoData(prmTantoCode As String)

    If (String.IsNullOrEmpty(prmTantoCode)) Then
      _tantoName = ""
      _tantoMark = ""
      Return
    End If

    '担当者コードの検索
    Dim tmpDic As Dictionary(Of String, String) = GetTantoItemCode(prmTantoCode)
    ' 担当者コード
    If tmpDic.ContainsKey(CTRL_SERV_CODE) Then
      Me.Text = tmpDic(CTRL_SERV_CODE)
    End If

    ' 担当者名
    If tmpDic.ContainsKey(CTRL_SERV_NAME) Then
      _tantoName = tmpDic(CTRL_SERV_NAME)
    Else
      _tantoName = ""
    End If

    ' 担当者備考
    If tmpDic.ContainsKey(CTRL_SERV_REMARKS) Then
      _tantoMark = tmpDic(CTRL_SERV_REMARKS)
    Else
      _tantoMark = ""
    End If

  End Sub
#End Region

#Region "プライベート"
  ''' <summary>
  ''' 担当者一覧表示データ抽出SQL文作成
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Private Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT CAST(TANTO_CODE AS varchar) AS " & CTRL_SERV_CODE                   ' 担当者コード
    sql &= "       ,CAST(TANTO_NAME AS varchar) AS " & CTRL_SERV_NAME                   ' 担当者名
    sql &= "       ,CAST(TANTO_SUB_CODE AS varchar) AS " & CTRL_SERV_SUB_CODE           ' 担当者サブコード
    sql &= "       ,CAST(TANTO_FURIGANA AS varchar) AS " & CTRL_SERV_KANA               ' 担当者フリガナ
    sql &= "       ,CAST(MEMO_TEXT AS varchar) AS " & CTRL_SERV_REMARKS                 ' 担当者備考
    sql &= "       ,CAST(KUBUN AS varchar) " & CTRL_STOP_FLG                            ' 区分
    sql &= "       ,FORMAT(TDATE, 'yyyy/MM/dd HH:mm:ss') AS " & CTRL_REGISTERED_DATE    ' 登録日時
    sql &= "       ,FORMAT(KDATE, 'yyyy/MM/dd HH:mm:ss') AS " & CTRL_UPDATE_DATE        ' 更新日時
    sql &= " FROM MST_TANTO "

    sql &= " WHERE TANTO_CODE = '" & prmCode & "'"

    Return sql
  End Function

  ''' <summary>
  ''' 担当者コードより担当者データを取得する
  ''' </summary>
  ''' <param name="prmTantoItemCode"></param>
  ''' <returns></returns>
  Private Function GetTantoItemCode(prmTantoItemCode As String) As Dictionary(Of String, String)
    Dim ret As New Dictionary(Of String, String)
    Dim tmpDb As New clsSqlServer()
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelListSrc(prmTantoItemCode))
      If tmpDt.Rows.Count > 0 Then
        ret.Add(CTRL_SERV_CODE, tmpDt.Rows(0)(CTRL_SERV_CODE).ToString())
        ret.Add(CTRL_SERV_NAME, tmpDt.Rows(0)(CTRL_SERV_NAME).ToString())
        ret.Add(CTRL_SERV_REMARKS, tmpDt.Rows(0)(CTRL_SERV_REMARKS).ToString())
      End If
    Catch ex As Exception
      Call ComWriteErrLog(ex)
      Throw New Exception("担当者コードの取得に失敗しました。")
    Finally
      tmpDb.Dispose()
      tmpDt.Dispose()
    End Try

    Return ret
  End Function

  ''' <summary>
  ''' 担当者コードの入力判定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtTantoCode_Validated(sender As Object, e As EventArgs) Handles Me.Validated

    Try
      _tantoName = String.Empty


      If (String.IsNullOrEmpty(Me.Text) = False) Then
        GetTantoData(Me.Text)
      End If
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

#End Region
#End Region

End Class
