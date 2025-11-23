Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class BtnInput
  Inherits BtnBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：登録対象のDataTable
  Public Property TargetDataTable As DataTable

  ' プロパティ：登録先テーブル名
  Public Property TargetTableName As String

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 取込ボタンボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("取込を行います。")

    Me.AccessKey = Keys.F1
    Me.BtnText = "F1:取込"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)
    Dim mapper As New clsMapping

    Dim TargetRowData As New Dictionary(Of String, String)
    If TargetDataTable Is Nothing OrElse String.IsNullOrEmpty(TargetTableName) Then
      Return
    End If

    Try
      SqlServer.TrnStart()

      For Each row As DataRow In TargetDataTable.Rows
        TargetRowData.Clear()

        For Each col As DataColumn In TargetDataTable.Columns
          Dim key As String = col.ColumnName
          Dim value As Object = row(col)

          TargetRowData.Add(mapper.GetMapping("入荷予定データ")(key), value)

        Next
        SqlServer.Execute(SqlInsTargetTable(TargetRowData))

      Next

      MessageBox.Show("取込が完了しました。")
      SqlServer.TrnCommit()
    Catch ex As Exception
      SqlServer.TrnRollBack()
      MessageBox.Show("エラー: " & ex.Message)
    End Try
  End Sub

#End Region

  Private Function SqlInsTargetTable(prmTargetRow As Dictionary(Of String, String)) As String
    Dim sql As String = String.Empty
    Dim tmpKeyValue As New Dictionary(Of String, String)
    Dim tmpInsertItemz As New Dictionary(Of String, String)

    For Each KeyValue As KeyValuePair(Of String, String) In prmTargetRow
      ComSetDictionaryVal(tmpKeyValue, KeyValue.Key, KeyValue.Value)
    Next
    tmpInsertItemz = ComCreateInsertItem(tmpKeyValue)

    sql &= " INSERT INTO " & TargetTableName & "(" & tmpInsertItemz("Keyz") & ") "
    sql &= " VALUES(" & tmpInsertItemz("Valuez") & ") "

    Return sql

  End Function


  'なかったので仮に作成したので頂ければ削除！
  Private Function ComCreateInsertItem(prmKeyValuez As Dictionary(Of String, String)) As Dictionary(Of String, String)
    Dim result As New Dictionary(Of String, String)

    ' 列名をカンマ区切りで連結
    Dim keys As String = String.Join(",", prmKeyValuez.Keys)

    ' 値をカンマ区切りで連結（シングルクォートで囲む）
    Dim values As String = String.Join(",", prmKeyValuez.Values.Select(Function(v) $"'{v}'"))

    result("Keyz") = keys
    result("Valuez") = values

    Return result
  End Function

End Class