Imports GrapeCity.Win.MultiRow
Imports T.R.ZCommonClass

Public Class FormMultiRow2Base


#Region "メンバ"
#Region "パブリック"

  ' MultiRow保持用
  Public Controlr As Dictionary(Of String, clsMultiRow)

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

  Public DICT As New Dictionary(Of String, String)
  Public MR1 As New GcMultiRow
  Public MR2 As New GcMultiRow

#End Region

#End Region

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
  ''' MultiRow初期化
  ''' </summary>
  ''' <param name="prmDgv">初期化対象のDatagridvidw</param>
  Public Sub InitMultiRow(prmDgv As GcMultiRow,
                          prmIdxCellEnd As Integer)

    Dim tmpMultiRow As clsMultiRow = Nothing


    If Controlr.ContainsKey(prmDgv.Name) Then
      ' 二回目の初期化に対応してません

    Else
      Dim prmSqlCon As clsComDatabase = Nothing
      tmpMultiRow = New clsMultiRow(prmDgv, prmIdxCellEnd)
      Call Controlr.Add(prmDgv.Name, tmpMultiRow)
      With tmpMultiRow
        If prmSqlCon Is Nothing Then
          .SqlCon = New clsSqlServer
        Else
          .SqlCon = prmSqlCon
        End If
      End With
    End If

  End Sub

  ''' <summary>
  ''' MultiRow初期化
  ''' </summary>
  ''' <param name="prmDgv">初期化対象のDatagridvidw</param>
  ''' <param name="prmGridSrcSql">一覧表示内容（SQL文）</param>
  ''' <param name="prmSqlCon">DB接続先情報</param>
  Public Sub InitMultiRow(prmDgv As GcMultiRow _
                        , prmIdxCellEnd As Integer _
                        , prmGridSrcSql As String _
                        , Optional prmSqlCon As clsComDatabase = Nothing)

    Dim tmpMultiRow As clsMultiRow = Nothing

    _ReturnVal.Clear()

    If Controlr.ContainsKey(prmDgv.Name) Then
      ' 二回目の初期化に対応してません

    Else
      tmpMultiRow = New clsMultiRow(prmDgv, prmIdxCellEnd, prmGridSrcSql)
      Call Controlr.Add(prmDgv.Name, tmpMultiRow)
      With tmpMultiRow
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
  Public Overloads Sub SetMsgLbl(prmMsglbl As Label)

    ' clsDataRepeaterにメッセージ表示オブジェクトを設定
    For Each tmpKey As String In Controlr.Keys
      Controlr(tmpKey).SetMsgLabel(prmMsglbl)
    Next

  End Sub

  ' senderとEventArgは不定のため使用できません。
  ' SelectedRowsは非表示のコントロールは取得されないため使用せず
  Public Sub SetListForReturnVal(sender As Object, e As EventArgs)

    Dim dic As New Dictionary(Of String, String)

    ' 初期行数が1行の場合はカレント行が存在しない為、カレント行の再設定を行う
    Try
      Dim tmpCurrentPos As New Point(Me.GcMultiRow1.CurrentCell.CellIndex, Me.GcMultiRow1.CurrentCell.RowIndex)
      Me.GcMultiRow1.CurrentCell = Nothing
      Me.GcMultiRow1.CurrentCellPosition = New CellPosition(tmpCurrentPos.Y, tmpCurrentPos.X)
    Catch ex As Exception
      ' 行数0の場合はカレント行の設定が行えないのでエラーが発生するが
      ' 以降の処理で行数0の判断が行われ正常に処理される為、ここでのエラーは無視する
    End Try


    If (Me.GcMultiRow1.SelectedRows.Count <= 0) Then
      _ReturnVal.Clear()
    Else

      Dim row As Row = Me.GcMultiRow1.SelectedRows(0)
      Dim strValue As String = String.Empty

      For i = 0 To row.Cells.Count - 1
        ' 得意先コード
        If String.IsNullOrWhiteSpace(row.Item(i).DataField) = False Then
          If (row.Item(i).Value Is DBNull.Value) Then
            strValue = ""
          Else
            strValue = row.Item(i).Value
          End If
          dic.Add(row.Item(i).DataField, strValue)
        End If
      Next

      DICT = dic

      Dim ret As New List(Of Dictionary(Of String, String)) From {
        DICT
      }
      _ReturnVal = ret

    End If

    Close()

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="prmRet"></param>
  ''' <param name="prmClose"></param>
  Public Sub SetListForReturnsVal(prmRet As List(Of Dictionary(Of String, String)),
                                  Optional prmClose As Boolean = True)

    _ReturnVal = prmRet
    If (prmClose) Then
      Close()
    End If

  End Sub

#Region "イベントプロシージャー"

  ''' <summary>
  ''' フォームロード時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    With GcMultiRow1

      ' 水平スクロールバーのみ非表示にする場合
      .ScrollBars = ScrollBars.Vertical

      ' Enterキーを「セルの編集開始、編集確定」から「セルの移動」に変更
      .ShortcutKeyManager.Unregister(Keys.Enter)
      .ShortcutKeyManager.Register(SelectionActions.MoveToNextCell, Keys.Enter)

      ' DELTEキーの割り当て解除
      .ShortcutKeyManager.Unregister(Keys.Delete)

      ' ユーザーによる行の削除を禁止
      .AllowUserToDeleteRows = False

      ' 編集モードをプログラム制御モードに設定
      .EditMode = GrapeCity.Win.MultiRow.EditMode.EditOnEnter

      ' 選択モードを単一選択モードに設定
      .MultiSelect = False

      ' セクションをGcMultiRowの幅に自動拡張します
      .AllowAutoExtend = True

    End With

    ' MultiRow保持用連想配列初期化
    Controlr = New Dictionary(Of String, clsMultiRow)

  End Sub
#End Region


End Class