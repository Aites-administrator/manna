Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports ClsHandyCommunication

Public Class BtnRecieveHandy
  Inherits BtnBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：ファイル名
  Public Property TargetFileName As String
  Public Property Handy As New ClsHandyCommunication.clsHandyCommunication(TargetFileName)
  ' プロパティ：データグリッド
  Public Property TargetDataGridView As DgvList
  ' プロパティ：項目長
  Public Property TargetLenClumn As List(Of Tuple(Of String, Integer))
  ' プロパティ：更新テーブル
  Public Property TargetTableName As String
  ' プロパティ：更新条件
  Public Property TargetWhere As List(Of String)
  ' プロパティ：更新項目
  Public Property TargetUpdColumn As List(Of String)
  ' プロパティ：更新項目
  Public Property TargetItemUpdColumn As List(Of String)
  ' プロパティ：更新ステータス
  Public Property TargetUpdStatus As String

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 受信ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("受信を行います。")

    Me.AccessKey = Keys.F6
    Me.BtnText = "受信"
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

    Dim tmpDt As New DataTable
    Try
      '通信ツール開示
      Handy.OpenCommunicationTool()

      '状態管理ファイル作成チェック
      If Not Handy.CreateChkStatusFlagFile() Then
        Exit Sub
      Else
        Console.WriteLine("ファイル作成OK")

      End If
      '状態管理ファイルチェック
      If Not Handy.ChkStatusFlagFile() Then
        Exit Sub
      Else
        Console.WriteLine("状態管理OK")
      End If
      tmpDt = ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn)
      TargetDataGridView.SetData(ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn))

      SqlServer.TrnStart()

      For Each tmpRow In tmpDt.Rows
        If tmpRow("TORIKOMI_JOKYO_FLG").ToString = "0" Then
          Continue For
        End If
        '更新項目生成
        Dim tmpUpdColumn As New Dictionary(Of String, String)
        For Each UpdColumn In TargetUpdColumn
          If UpdColumn = "TORIKOMI_JOKYO_FLG" Then
            tmpUpdColumn.Add(UpdColumn, TargetUpdStatus)
          Else
            tmpUpdColumn.Add(UpdColumn, tmpRow(UpdColumn).ToString)
          End If
        Next

        '条件項目生成
        Dim tmpWhere As New Dictionary(Of String, String)
        For Each Where In TargetWhere
          tmpWhere.Add(Where, tmpRow(Where).ToString)
        Next

        '更新処理
        SqlServer.Execute(CreateUpdateSql(TargetTableName, tmpUpdColumn, tmpWhere))

        '条件項目生成
        If TargetItemUpdColumn IsNot Nothing Then
          Dim tmpItemUpdColumn As New Dictionary(Of String, String)
          For Each ItemUpdColumn In TargetItemUpdColumn
            tmpItemUpdColumn.Add(ItemUpdColumn, tmpRow(ItemUpdColumn).ToString)
          Next

          tmpWhere.Clear()
          tmpWhere.Add("SHOHIN_CD", tmpRow("JISYA_SHOHIN_CD").ToString)

          '更新処理
          SqlServer.Execute(CreateUpdateSql("MST_ITEM", tmpItemUpdColumn, tmpWhere))

        End If


      Next

      SqlServer.TrnCommit()

      'Excel出力
      DataTable2Excel(ParseFixedLengthTextToTable(TargetFileName, TargetLenClumn), "D:\manna\OUTPUT\OUTPUT.xlsx")

      Handy.CloseCommunicationTool()

      ComMessageBox("受信が完了しました。", "確認", typMsgBox.MSG_NORMAL)
    Catch ex As Exception
      SqlServer.TrnRollBack()
      ComWriteErrLog(ex, False)
      Handy.CloseCommunicationTool()
    Finally
    End Try
  End Sub

#End Region

#Region "ファンクション"
  Private Sub UpdItem(prmItemCd As String)

  End Sub

  Private Function SqlUpdItem(prmItemCd As String) As String
    Dim sql As String = String.Empty

    sql += " UPDATE MST_ITEM "
    sql += " WHERE ITEM_CODE = '" & prmItemCd & "'"

    Return sql
  End Function
#End Region



End Class