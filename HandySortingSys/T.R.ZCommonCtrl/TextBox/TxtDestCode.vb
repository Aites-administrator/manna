Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtDestCode
  Inherits TxtCodeBase

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' 納入先名
  ''' </summary>
  Private _destName As String

  ''' <summary>
  ''' 住所１
  ''' </summary>
  Private _destAddress01 As String

  ''' <summary>
  ''' 住所２
  ''' </summary>
  Private _destAddress02 As String

  ''' <summary>
  ''' 電話番号
  ''' </summary>
  Private _destPhoneNumber As String

  ''' <summary>
  ''' Fax番号
  ''' </summary>
  Private _destFaxNumber As String
#End Region
#End Region

#Region "コンストラクタ"

  Public Sub New()
    MyBase.New()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("納入先コードを入力してください。")
  End Sub

  Private Sub InitializeComponent()

    Me.SuspendLayout()

    Me.ResumeLayout(False)

  End Sub
#End Region

#Region "パブリック"
  ''' <summary>
  ''' 納入先名の取得
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>デフォルト False</remarks>
  Public ReadOnly Property DestName As String
    Get
      Return _destName
    End Get
  End Property

  Public ReadOnly Property DestAddress01 As String
    Get
      Return _destAddress01
    End Get
  End Property

  Public ReadOnly Property DestAddress02 As String
    Get
      Return _destAddress02
    End Get
  End Property

  Public ReadOnly Property DestPhoneNumber As String
    Get
      Return _destPhoneNumber
    End Get
  End Property

  Public ReadOnly Property DestFaxNumber As String
    Get
      Return _destFaxNumber
    End Get
  End Property
#End Region

#Region "メソッド"
#Region "パブリック"

  ''' <summary>
  ''' 納入先コードの取得
  ''' </summary>
  ''' <param name="prmDestCode">納入先コード</param>
  Public Sub GetDestinationData(prmDestCode As String)

    If (String.IsNullOrEmpty(prmDestCode)) Then
      _destName = ""
      _destAddress01 = ""
      _destAddress02 = ""
      _destPhoneNumber = ""
      _destFaxNumber = ""
      Return
    End If

    '納入先コードの検索
    Dim tmpDic As Dictionary(Of String, String) = GetDestItemCode(prmDestCode)
    ' 納入先コード
    If tmpDic.ContainsKey(CTRL_DELIVERY_CODE) Then
      Me.Text = tmpDic(CTRL_DELIVERY_CODE)
    Else
      Me.Text = ""
    End If

    ' 納入名
    If tmpDic.ContainsKey(CTRL_DELIVERY_NAME) Then
      _destName = tmpDic(CTRL_DELIVERY_NAME)
    Else
      _destName = ""
    End If

    ' 住所０１
    If tmpDic.ContainsKey(CTRL_DELIVERY_ADDRESS1) Then
      _destAddress01 = tmpDic(CTRL_DELIVERY_ADDRESS1)
    Else
      _destAddress01 = ""
    End If

    ' 住所０２
    If tmpDic.ContainsKey(CTRL_DELIVERY_ADDRESS2) Then
      _destAddress02 = tmpDic(CTRL_DELIVERY_ADDRESS2)
    Else
      _destAddress02 = ""
    End If

    ' 電話番号
    If tmpDic.ContainsKey(CTRL_DELIVERY_PHONE) Then
      _destPhoneNumber = tmpDic(CTRL_DELIVERY_PHONE)
    Else
      _destPhoneNumber = ""
    End If

    ' FAX番号
    If tmpDic.ContainsKey(CTRL_DELIVERY_FAX) Then
      _destFaxNumber = tmpDic(CTRL_DELIVERY_FAX)
    Else
      _destFaxNumber = ""
    End If

  End Sub
#End Region

#Region "プライベート"
  ''' <summary>
  ''' 納入先一覧一覧表示データ抽出SQL文作成
  ''' </summary>
  ''' <param name="prmCode"></param>
  ''' <returns>作成したSQL文</returns>
  Private Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT FORMAT(TKCODE, '000000') AS " & CTRL_DELIVERY_CUSTOMERCODE      ' 得意先コード
    sql &= "       ,FORMAT(DESTINATION_CODE, '000000') AS " & CTRL_DELIVERY_CODE    ' 納入コード
    sql &= "       ,DESTINATION_NAME AS " & CTRL_DELIVERY_NAME                      ' 納入先名
    sql &= "       ,FURIGANA AS " & CTRL_DELIVERY_KANA                              ' 納入先名フリガナ
    sql &= "       ,(ADDRESS01 + ADDRESS02) AS " & CTRL_DELIVERY_ADDRESS            ' 納入先住所１＆２
    sql &= "       ,ADDRESS01 AS " & CTRL_DELIVERY_ADDRESS1                         ' 納入先住所１
    sql &= "       ,ADDRESS02 AS " & CTRL_DELIVERY_ADDRESS2                         ' 納入先住所２
    sql &= "       ,TELA  AS " & CTRL_DELIVERY_PHONE                                ' 納入先電話番号
    sql &= "       ,TELF AS " & CTRL_DELIVERY_FAX                                   ' 納入先ＦＡＸ番号
    sql &= " FROM  DESTINATION   "
    sql &= " WHERE DESTINATION_CODE = " & StringToInt(prmCode)

    Return sql
  End Function

  ''' <summary>
  ''' 納入先コードより納入先データを取得する
  ''' </summary>
  ''' <param name="prmMaItemCode"></param>
  ''' <returns></returns>
  Private Function GetDestItemCode(prmMaItemCode As String) As Dictionary(Of String, String)
    Dim ret As New Dictionary(Of String, String)
    Dim tmpDb As New clsSqlServer()
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelListSrc(prmMaItemCode))
      If tmpDt.Rows.Count > 0 Then
        ret.Add(CTRL_DELIVERY_CODE, tmpDt.Rows(0)(CTRL_DELIVERY_CODE).ToString())
        ret.Add(CTRL_DELIVERY_NAME, tmpDt.Rows(0)(CTRL_DELIVERY_NAME).ToString())

        ret.Add(CTRL_DELIVERY_ADDRESS1, tmpDt.Rows(0)(CTRL_DELIVERY_ADDRESS1).ToString())
        ret.Add(CTRL_DELIVERY_ADDRESS2, tmpDt.Rows(0)(CTRL_DELIVERY_ADDRESS2).ToString())
        ret.Add(CTRL_DELIVERY_PHONE, tmpDt.Rows(0)(CTRL_DELIVERY_PHONE).ToString())
        ret.Add(CTRL_DELIVERY_FAX, tmpDt.Rows(0)(CTRL_DELIVERY_FAX).ToString())

      End If
    Catch ex As Exception
      Call ComWriteErrLog(ex)
      Throw New Exception("納入先コードの取得に失敗しました。")
    Finally
      tmpDb.Dispose()
      tmpDt.Dispose()
    End Try

    Return ret
  End Function

  ''' <summary>
  ''' 納入コードの入力判定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtSch1DestCode_Validated(sender As Object, e As EventArgs) Handles Me.Validated

    Try
      _destName = String.Empty


      If (String.IsNullOrEmpty(Me.Text) = False) Then
        GetDestinationData(Me.Text)
      End If
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try

  End Sub

#End Region
#End Region

End Class

