Public Class DgvList
  Inherits DataGridView
  ' プロパティ：ファイル名
  Public Property TargetColumnName As String = ""


#Region "コンストラクタ"

  ''' <summary>
  ''' データグリッド
  ''' </summary>
  Public Sub New()

  End Sub

  Protected Overrides Sub InitLayout()
  End Sub

#End Region

  Public Sub SetData(dt As DataTable)
    Try
      Me.DataSource = Nothing
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
      Me.DefaultCellStyle.Font = New Font("MS UI Gothic", 20)
      Me.ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", 20)

      Me.AutoGenerateColumns = True
      Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
      Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
      'Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
      'Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

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

  Private Sub AdjustColumnWidths()
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

End Class
