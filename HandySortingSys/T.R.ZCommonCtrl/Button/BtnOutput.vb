Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class BtnOutput
  Inherits BtnBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：フォーマットファイル
  Public Property TargetFormatFile As String

  ' プロパティ：出力データGrid
  Public Property TargetDataGridView As DataGridView

#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 取込ボタンボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("出力を行います。")

    Me.AccessKey = Keys.F5
    Me.BtnText = "報告書出力"
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

    MessageBox.Show("test")

    ' Excel起動
    Dim xlApp As New Microsoft.Office.Interop.Excel.Application
    Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(Me.TargetFormatFile)
    Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlBook.Sheets(1)

    ' 基本情報例（必要に応じて）
    xlSheet.Range("B3").Value = DateTime.Now.ToString("yyyy/MM/dd")   ' 入荷日
    xlSheet.Range("B4").Value = "12345"                               ' 伝票番号
    xlSheet.Range("B5").Value = "山田"                                ' 検品担当者

    ' Gridの内容をExcelに書き込む
    Dim rowIndex As Integer = 8   ' Excelの開始行（ひな形に合わせて調整）
    For Each row As DataGridViewRow In Me.TargetDataGridView.Rows
      If Not row.IsNewRow Then
        xlSheet.Cells(rowIndex, 1).Value = row.Cells("商品コード").Value
        xlSheet.Cells(rowIndex, 2).Value = row.Cells("商品名").Value
        xlSheet.Cells(rowIndex, 3).Value = row.Cells("規格").Value
        xlSheet.Cells(rowIndex, 4).Value = row.Cells("発注数量").Value
        xlSheet.Cells(rowIndex, 5).Value = row.Cells("入荷数量").Value
        xlSheet.Cells(rowIndex, 6).Value = row.Cells("備考").Value
        rowIndex += 1
      End If
    Next

    ' 保存
    Dim savePath As String = "D:\manna\HandySortingSys\REPORT\検品報告書_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".xlsx"
    xlBook.SaveAs(savePath)

    ' 終了処理
    xlBook.Close()
    xlApp.Quit()

    MessageBox.Show("報告書を出力しました！" & vbCrLf & savePath)

  End Sub

#End Region


End Class