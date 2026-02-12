Public Class DgvList
  Inherits DataGridView

  Private CommunicationWidth As Integer = 902

  ' プロパティ：ファイル名
  Public Property TargetColumnName As String = ""
  Public Property GridFontSize As Integer = 20
  Public Property HeaderFontSize As Integer = 20
  Public Property UseCustomSize As Boolean = False
  Public Property CustomAutoSizeColumnsMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
  Public Property CustomAutoSizeRowsMode As DataGridViewAutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells


#Region "コンストラクタ"

  ''' <summary>
  ''' データグリッド
  ''' </summary>
  Public Sub New()
  End Sub

  Public Sub ApplyInitialLayout()
    If UseCustomSize Then
      Me.AutoSizeColumnsMode = CustomAutoSizeColumnsMode
      Me.AutoSizeRowsMode = CustomAutoSizeRowsMode
      Me.Width = CommunicationWidth
    End If
  End Sub



  Protected Overrides Sub InitLayout()

  End Sub

#End Region

  Public Sub SetData(dt As DataTable)
    Try


      Me.AutoGenerateColumns = True

      Me.DataSource = dt
      Me.AllowUserToAddRows = False
      Me.ReadOnly = False

      For Each tmpClomn In Me.Columns
        ' チェック列だけ編集可能にする
        If tmpClomn.Name <> "チェック" Then
          tmpClomn.ReadOnly = True
        End If

      Next
      ' フォント設定
      Me.EnableHeadersVisualStyles = False ' 
      Me.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
      Me.DefaultCellStyle.Font = New Font("MS UI Gothic", GridFontSize)
      Me.ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", HeaderFontSize)

      'Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
      'Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

      If UseCustomSize Then
        Me.AutoSizeColumnsMode = CustomAutoSizeColumnsMode
        Me.AutoSizeRowsMode = CustomAutoSizeRowsMode
        Me.Width = CommunicationWidth
      Else
        Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
      End If


      'Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
      'Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

      ' ★チェック列を強制的に CheckBoxColumn にする
      If Me.Columns.Contains("チェック") Then
        Dim colIndex = Me.Columns("チェック").Index

        Dim chkCol As New DataGridViewCheckBoxColumn()
        chkCol.Name = "チェック"
        chkCol.HeaderText = "チェック"
        chkCol.DataPropertyName = "チェック"
        chkCol.ReadOnly = False

        Me.Columns.Remove("チェック")
        Me.Columns.Insert(colIndex, chkCol)
      End If
      ' ★ここで取り込み状況フラグを先頭へ
      If Me.Columns.Contains(TargetColumnName) Then
        Me.Columns(TargetColumnName).DisplayIndex = 0
      End If


    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub

  Private Sub DgvList_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Me.DataBindingComplete
    Try
      ' レイアウト完了後に実行するため BeginInvoke を使う
      Me.BeginInvoke(New Action(Sub()
                                  AdjustColumnWidths()
                                End Sub))
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub

  Public Sub AdjustColumnWidths()
    Try
      Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

      Using g As Graphics = Me.CreateGraphics()
        For Each col As DataGridViewColumn In Me.Columns

          ' ヘッダ幅
          Dim headerSize As SizeF = g.MeasureString(col.HeaderText, Me.ColumnHeadersDefaultCellStyle.Font)
          Dim maxWidth As Integer = CInt(headerSize.Width) + 30

          ' セル幅
          For Each row As DataGridViewRow In Me.Rows
            If row.Cells(col.Index).Value IsNot Nothing Then
              Dim cellText As String = row.Cells(col.Index).Value.ToString()
              Dim cellSize As SizeF = g.MeasureString(cellText, Me.DefaultCellStyle.Font)
              maxWidth = Math.Max(maxWidth, CInt(cellSize.Width) + 30)
            End If
          Next

          col.Width = maxWidth
        Next
      End Using

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub

  Private Sub DgvList_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Me.RowPrePaint
    Try
      Dim row = Me.Rows(e.RowIndex)


      If Me.Columns.Contains(TargetColumnName) Then
        Dim cellValue = row.Cells(TargetColumnName).Value

        If cellValue IsNot Nothing AndAlso (cellValue.ToString() = "0" OrElse cellValue.ToString() = "未") Then
          row.DefaultCellStyle.BackColor = Color.LightPink
          row.DefaultCellStyle.ForeColor = Color.Black
        Else
          ' 通常色に戻す
          row.DefaultCellStyle.BackColor = Me.DefaultCellStyle.BackColor
          row.DefaultCellStyle.ForeColor = Me.DefaultCellStyle.ForeColor
        End If
      End If

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub
  Private Sub DgvList1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellClick
    If e.RowIndex < 0 Then Exit Sub

    If Me.Columns(e.ColumnIndex).Name = "チェック" Then

      ' ★編集モードに入る
      Me.BeginEdit(True)

      Dim cell = Me.Rows(e.RowIndex).Cells("チェック")
      cell.Value = Not CBool(cell.Value)

      ' ★編集を確定（これがないと UI が更新されない）
      Me.CommitEdit(DataGridViewDataErrorContexts.Commit)

      ' ★さらに確実に更新
      Me.EndEdit()
    End If

  End Sub

  Private Sub DgvList_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
    ' ヘッダークリック以外は無視
    If e.RowIndex <> -1 Then Exit Sub

    ' 「チェック」列のヘッダーをクリックしたときだけ動作
    If Me.Columns(e.ColumnIndex).Name = "チェック" Then

      ' 現在の状態を確認（全部チェック済みか）
      Dim allChecked As Boolean =
            Me.Rows.Cast(Of DataGridViewRow)().
            All(Function(r) CBool(r.Cells("チェック").Value))

      ' 全部チェック or 全部解除
      For Each row As DataGridViewRow In Me.Rows
        row.Cells("チェック").Value = Not allChecked
      Next

      ' UI 更新
      Me.Refresh()
    End If
  End Sub

  Public Sub TrimDataTable(dt As DataTable)
    For Each col As DataColumn In dt.Columns
      If col.DataType Is GetType(String) Then
        For Each row As DataRow In dt.Rows
          If Not row.IsNull(col) Then
            Dim s = CStr(row(col))
            Dim trimmed = s.Trim()
            If trimmed <> s Then
              row(col) = trimmed
            End If
          End If
        Next
      End If
    Next

    dt.AcceptChanges()
  End Sub


End Class
