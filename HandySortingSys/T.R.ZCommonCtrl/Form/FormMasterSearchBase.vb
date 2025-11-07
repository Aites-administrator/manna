Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass.DrForm
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsDGVColumnSetting
Imports T.R.ZCommonClass.clsDataGridEditTextBox.typValueType
Imports T.R.ZCommonClass.clsReport
Imports System.Reflection

Imports System
Imports Microsoft.VisualBasic.PowerPacks
Imports T.R.ZCommonClass.clsDataGridSearchControl
Imports T.R.ZCommonClass.clsDataRepeater

Public Class FormMasterSearchBase

#Region "メンバ"
#Region "パブリック"

  ' データリピーター保持用
  Public Controlr As Dictionary(Of String, clsDataRepeater)

  Public _ReturnVal As New List(Of Dictionary(Of String, String))

  ''' <summary>
  ''' 画面初期化関数デリゲート
  ''' </summary>
  ''' <param name="prmTargetData">親画面より渡されるパラメータ</param>
  Delegate Sub CallBackInitForm(ByVal prmTargetData As List(Of Dictionary(Of String, String)))

  ''' <summary>
  ''' 画面初期化関数本体
  ''' </summary>
  Public lcCallBackInitForm As CallBackInitForm

  ''' <summary>
  ''' 現在選択している行が新規行かどうか
  ''' </summary>
  Public _isNewRow As Boolean = False

  ''' <summary>
  ''' 新規行を変更したかどうか
  ''' </summary>
  Public _isChanged As Boolean = False

  Public DICT As New Dictionary(Of String, String)
  Public DR1 As New DataRepeater
#End Region

#Region "プライベート"

  ''' <summary>
  ''' データリピーターの表示位置番号
  ''' </summary>
  Private _DataRepeaterIdx As Integer = 0

#End Region
#End Region

#Region "メソッド"

#Region "パブリック"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="prmTargetData"></param>
  ''' <returns></returns>
  Public Function ShowSubForm(Optional prmTargetData As List(Of Dictionary(Of String, String)) = Nothing) As List(Of Dictionary(Of String, String))

    ' 画面初期化処理
    If lcCallBackInitForm IsNot Nothing Then
      lcCallBackInitForm(prmTargetData)
    End If

    Me.ShowDialog()

    Return _ReturnVal

  End Function

  ''' <summary>
  ''' Grid初期化
  ''' </summary>
  ''' <param name="prmDgv">初期化対象のDatagridvidw</param>
  ''' <param name="prmGridSrcSql">一覧表示内容（SQL文）</param>
  ''' <param name="prmSqlCon">DB接続先情報</param>
  Public Sub InitDataRepeater(prmDgv As DataRepeater _
                            , Optional prmGridSrcSql As String = "" _
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

    'MyBase.SetMsgLbl(prmMsglbl)

    ' clsDataRepeaterにメッセージ表示オブジェクトを設定
    For Each tmpKey As String In Controlr.Keys
      Controlr(tmpKey).SetMsgLabel(prmMsglbl)
    Next

  End Sub

  ' senderとEventArgは不定のため使用できません。
  Public Sub SetListForReturnVal(sender As Object, e As EventArgs)

    'DICT.Add("SVCCD", 12345)
    Dim dic As New Dictionary(Of String, String)
    If (Controlr(DR1.Name).SelectedRow.Count <> 0) Then
      dic = Controlr(DR1.Name).SelectedRow
      DICT = dic

      Dim ret As New List(Of Dictionary(Of String, String)) From {
        DICT
      }
      _ReturnVal = ret
    End If
    Close()

  End Sub

  Public Sub SetListForReturnsVal(prmRet As List(Of Dictionary(Of String, String)),
                                  Optional prmClose As Boolean = True)

    _ReturnVal = prmRet
    If (prmClose) Then
      Close()
    End If


  End Sub

  ''' <summary>
  ''' データリピーターダブルクリック時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Public Sub DrTextDoubleClick(sender As Object, e As EventArgs)

    SetListForReturnVal(sender, e)

  End Sub

  ''' <summary>
  ''' データリピーターダブルクリック時（複数選択時）
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Public Sub DrTextDoubleClicks(sender As Object, e As EventArgs)

    SetListForReturnVal(sender, e)

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
