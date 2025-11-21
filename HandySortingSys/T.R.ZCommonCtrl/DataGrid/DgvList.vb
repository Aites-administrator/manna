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
    Me.DataSource = Nothing
    Me.AutoGenerateColumns = True
    Me.DataSource = dt
    Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    Me.AllowUserToAddRows = False
    Me.ReadOnly = True

    ' フォント設定
    Me.EnableHeadersVisualStyles = False ' 
    Me.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
    Me.DefaultCellStyle.Font = New Font("MS UI Gothic", 16)
    Me.ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", 16)
  End Sub

End Class
