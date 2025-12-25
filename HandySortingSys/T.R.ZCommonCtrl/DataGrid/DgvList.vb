Public Class DgvList
  Inherits DataGridView


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
      Me.AutoGenerateColumns = True
      Me.DataSource = dt
      Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
      Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
      'Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
      'Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
      Me.DefaultCellStyle.Font = New Font("MS UI Gothic", 16)
      Me.ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", 16)
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub

  Private Sub DgvList_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Me.DataBindingComplete


  End Sub
End Class
