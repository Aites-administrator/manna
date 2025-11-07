Imports Microsoft.VisualBasic.PowerPacks
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class MFBaseDrv

#Region "メンバ"

#Region "プライベート"
  ''' <summary>
  ''' データリピーターの表示位置番号
  ''' </summary>
  Private _DataRepeaterIdx As Integer = 0

#End Region

#Region "パブリック"

  ' データリピーター保持用
  Public Controlr As Dictionary(Of String, clsDataRepeater)

#End Region

#End Region

#Region "メソッド"

#Region "パブリック"

  ''' <summary>
  ''' DataRepeater初期化
  ''' </summary>
  ''' <param name="prmDgv">初期化対象のDatagridvidw</param>
  ''' <param name="prmGridSrcSql">一覧表示内容（SQL文）</param>
  ''' <param name="prmSqlCOn">DB接続先情報</param>
  Public Sub InitDataRepeater(prmDgv As DataRepeater _
                            , prmGridSrcSql As String _
                            , Optional prmSqlCon As clsComDatabase = Nothing)

    Dim tmpDataRepeater As clsDataRepeater = Nothing

    If Controlr.ContainsKey(prmDgv.Name) Then
      ' 二回目の初期化に対応してません

    Else
      tmpDataRepeater = New clsDataRepeater(prmDgv, prmGridSrcSql)
      Call Controlr.Add(prmDgv.Name, tmpDataRepeater)
      With tmpDataRepeater
        If prmSqlCon Is Nothing Then
          .SqlCon = New clsSqlServer
        Else
          .SqlCon = prmSqlCon
        End If
      End With
    End If

  End Sub

  ''' <summary>
  ''' 画面上の全てのコントロールにメッセージラベルを設定
  ''' </summary>
  ''' <param name="prmMsglbl">メッセージを表示するラベル</param>
  ''' <remarks>
  '''  clsDataGridが対象
  ''' </remarks>
  Public Overloads Sub SetMsgLbl(prmMsglbl As Label)

    MyBase.SetMsgLbl(prmMsglbl)

    ' clsDataRepeaterにメッセージ表示オブジェクトを設定
    For Each tmpKey As String In Controlr.Keys
      Controlr(tmpKey).SetMsgLabel(prmMsglbl)
    Next

  End Sub

#End Region

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' フォームロード時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' DataRepeater保持用連想配列初期化
    Controlr = New Dictionary(Of String, clsDataRepeater)
  End Sub

#End Region

End Class