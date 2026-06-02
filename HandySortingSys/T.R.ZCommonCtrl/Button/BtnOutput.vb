Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports System.IO

Public Class BtnOutput
  Inherits BtnBase

#Region "プライベート"
  Private Const REPORT_DIR_NAME As String = "REPORT\"
  Private Const REPORT_FILE_NAME As String = "入荷検品一覧表"
  Private SqlServer As New clsSqlServer

  Private Enum LayoutType
    NYUKA = 0
    TANA
  End Enum
#End Region

#Region "パブリック"
  ' プロパティ：フォーマットファイル
  Public Property TargetFormatFile As String

  ' プロパティ：出力データGrid
  Public Property TargetDataGridView As DataGridView

  ' プロパティ：出力データGrid
  Public Property TargetKbn As Integer


  ' 出力完了イベント
  Public Event ReceiveCompleted()
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
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0

    MakeRoundedButton(Me, 20)

  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    Try
      Select Case TargetKbn
        Case LayoutType.NYUKA
          NyukaPrint()
        Case LayoutType.TANA
          TanaPrint()
      End Select

      UpdateTorikomiFlg(TargetKbn, TargetDataGridView)

      RaiseEvent ReceiveCompleted()
    Catch ex As Exception
      ComWriteErrLog(ex, False)
    Finally
      HideProcessing()
    End Try

  End Sub

  Private Sub NyukaPrint()

    Dim list As New List(Of 検品データ)
    Try
      For Each r As DataGridViewRow In TargetDataGridView.Rows
        If Not r.IsNewRow Then
          list.Add(New 検品データ With {
                .発注No = r.Cells("発注No").Value?.ToString(),
                .行No = r.Cells("行NO").Value?.ToString(),
                .発注先名 = r.Cells("発注先名").Value?.ToString(),
                .商品名 = r.Cells("メーカー商品名").Value?.ToString(),
                .規格 = r.Cells("メーカー規格名").Value?.ToString(),
                .荷数 = r.Cells("荷数").Value?.ToString(),
                .賞味期限 = r.Cells("賞味期限").Value?.ToString(),
                .自社数量 = r.Cells("入荷予定数_自社").Value,
                .入り数 = r.Cells("入り数").Value,
                .入荷予定数 = r.Cells("入荷予定数_メーカー").Value,
                .発注単位 = r.Cells("単位").Value?.ToString(),
                .検品結果 = r.Cells("検品結果").Value?.ToString()
            })
        End If
      Next

      Dim builder As New clsExcelReportBuilder()

      builder.Title = "入荷検品書"
      builder.Headers = {
          "発注NO", "行NO", "発注先", "商品", "荷数",
          "賞味期限", "自社数量", "入り数", "入荷予定数", "発注単位", "検品結果"
      }.ToList()

      builder.Rows = list.Select(Function(x) CType({
          x.発注No,
          x.行No,
          x.発注先名,
          x.商品名 & vbLf & x.規格,
          x.荷数,
          x.賞味期限,
          x.自社数量,
          x.入り数,
          x.入荷予定数,
          x.発注単位,
          x.検品結果
      }, Object())).ToList()

      Dim tmpFileName As String = PROJECT_DIR_NAME & REPORT_DIR_NAME & "入荷検品書_" &
                         DateTime.Now.ToString("yyyyMMddHHmmss") & ".xlsx"
      If Not Directory.Exists(tmpFileName) Then
        Throw New DirectoryNotFoundException(
        $"指定されたパスが見つかりません。: '{tmpFileName}'"
        )
      End If

      builder.OutputPath = tmpFileName

      builder.Build()

    Catch ex As Exception
      ComWriteErrLog(ex)

      Throw
    End Try

  End Sub

  Private Sub TanaPrint()

    Dim list As New List(Of Object)
    Try
      For Each r As DataGridViewRow In TargetDataGridView.Rows
        If Not r.IsNewRow Then
          list.Add(New With {
                  .棚番 = r.Cells("棚番エリア").Value?.ToString(),
                  .商品CD = r.Cells("自社商品コード").Value?.ToString(),
                  .商品名 = r.Cells("商品名").Value?.ToString(),
                  .入り数 = r.Cells("入り数").Value,
                  .予定ケース = r.Cells("在庫予定数_ケース数").Value,
                  .予定バラ = r.Cells("在庫予定数_バラ数").Value,
                  .実績ケース = r.Cells("在庫実績数_ケース数").Value,
                  .実績バラ = r.Cells("在庫実績数_バラ数").Value,
                  .賞味期限 = r.Cells("賞味期限").Value?.ToString()
              })
        End If
      Next

      '===============================
      ' ② ExcelReportBuilder 設定
      '===============================
      Dim builder As New clsExcelReportBuilder()

      builder.Title = "棚卸調査票"

      builder.Headers = {
          "棚番エリア",
          "商品コード",
          "商品名",
          "入り数",
          "予定(ケース)",
          "予定(バラ)",
          "実績(ケース)",
          "実績(バラ)",
          "賞味期限"
      }.ToList()

      '===============================
      ' ③ Rows に Object() を詰める
      '===============================
      builder.Rows = list.Select(Function(x) CType({
          x.棚番,
          x.商品CD,
          x.商品名,
          x.入り数,
          x.予定ケース,
          x.予定バラ,
          x.実績ケース,
          x.実績バラ,
          x.賞味期限
      }, Object())).ToList()

      Dim tanaDate As String = ComCreateDateText(TargetDataGridView.Rows(0).Cells("棚卸日").Value?.ToString())
      Dim workDate As String = ComCreateDateText(TargetDataGridView.Rows(0).Cells("作業予定日").Value?.ToString())

      builder.IsTana = True
      builder.TanaDate = tanaDate
      builder.WorkDate = workDate


      '===============================
      ' ④ 出力パス
      '===============================

      Dim tmpFileName As String = PROJECT_DIR_NAME & REPORT_DIR_NAME & "棚卸調査票_" &
          DateTime.Now.ToString("yyyyMMddHHmmss") & ".xlsx"
      If Not Directory.Exists(tmpFileName) Then
        Throw New DirectoryNotFoundException(
        $"指定されたパスが見つかりません。: '{tmpFileName}'"
        )
      End If

      builder.OutputPath = tmpFileName


      '===============================
      ' ⑤ 出力実行
      '===============================
      builder.Build()
    Catch ex As Exception
      ComWriteErrLog(ex)
      Throw
    End Try


  End Sub


  '===============================
  ' ★ 商品名を長いときだけ 2 行にする関数
  '===============================
  Private Function SplitProductName(name As String) As String
    If String.IsNullOrEmpty(name) Then Return ""

    Const limit As Integer = 15

    If name.Length <= limit Then
      Return name
    End If

    Return name.Substring(0, limit) & vbLf & name.Substring(limit)
  End Function

#End Region


  Private Function FormatShomikigen(raw As String) As String
    If String.IsNullOrEmpty(raw) OrElse raw.Length <> 8 Then Return ""
    Return $"{raw.Substring(0, 4)}年{raw.Substring(4, 2)}月{raw.Substring(6, 2)}日"
  End Function

  Private Sub UpdateTorikomiFlg(prmLayoutType As LayoutType, prmDataGridView As DataGridView)
    Try
      For Each DataGridViewRow In TargetDataGridView.Rows
        SqlServer.Execute(If(prmLayoutType = LayoutType.NYUKA, SqlUpdNyuka(DataGridViewRow), SqlUpDateTana(DataGridViewRow)))
      Next
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub

  Private Function SqlUpdNyuka(prmDataRow As DataGridViewRow) As String
    Dim sql As String = String.Empty
    sql += " UPDATE TRN_NYUKA"
    sql += " SET TORIKOMI_JOKYO_FLG = " & CInt(NYUKA_STATUS.SHUTSURYOKUZUMI)
    sql += " , OUTPUT_DATE = '" & ComGetProcTime() & "'"
    sql += " WHERE NYUKA_YOTEI_DATE = '" & prmDataRow.Cells("入荷予定日").Value & "'"
    sql += " AND HACHU_NO = '" & prmDataRow.Cells("発注NO").Value & "'"
    sql += " AND GYO_NO = '" & prmDataRow.Cells("行NO").Value & "'"

    Return sql

  End Function

  Private Function SqlUpDateTana(prmDataRow As DataGridViewRow) As String
    Dim sql As String = String.Empty
    sql += " UPDATE TRN_TANAOROSHI"
    sql += " SET TORIKOMI_JOKYO_FLG = " & CInt(TANAOROSHI_STATUS.SHUTURYOKUZUMI)
    sql += " , OUTPUT_DATE = '" & ComGetProcTime() & "'"
    sql += " WHERE TANAOROSHI_DATE = '" & prmDataRow.Cells("棚卸日").Value & "'"
    sql += " AND SAGYO_YOTEI_DATE = '" & prmDataRow.Cells("作業予定日").Value & "'"
    sql += " AND JISYA_SHOHIN_CD = '" & prmDataRow.Cells("自社商品コード").Value & "'"
    Return sql

  End Function

  Public Class 検品データ
    Public Property 発注先コード As String
    Public Property 発注先名 As String
    Public Property TEL As String
    Public Property FAX As String
    Public Property 商品CD As String
    Public Property メーカー名 As String
    Public Property 商品名 As String
    Public Property 棚番 As String
    Public Property 規格 As String
    Public Property 発注No As String
    Public Property 行No As String
    Public Property 荷数 As String
    Public Property 入荷予定数 As String
    Public Property 賞味期限 As String
    Public Property 入荷予定日 As String
    Public Property 自社数量 As String
    Public Property 入り数 As String
    Public Property 実績数 As String
    Public Property 実績自社数 As String
    Public Property 発注単位 As String
    Public Property 温度帯 As String
    Public Property 検品結果 As String
  End Class
End Class