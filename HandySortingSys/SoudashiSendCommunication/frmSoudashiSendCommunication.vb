Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Imports T.R.ZCommonCtrl
Imports ClsHandyCommunication



Public Class frmSoudashiSendCommunication
  Inherits FormCommunication
  Private SqlServer As New clsSqlServer
  Private BlnTorikomiZumi As Boolean = False
  Private Const SEND_FOLDER As String = "SEND\"
  Private Const SEND_SHUKKA_FILE_NAME As String = SEND_FOLDER & "PICK_TANA.DAT"
  Private Const SEND_SOUDASHI_FILE_NAME As String = SEND_FOLDER & "PICK_ITEM.DAT"


  Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CmbDateNohinBi1.SelectedIndex = 0
  End Sub


  Private Sub CmbDateNohinBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateNohinBi1.SelectedIndexChanged
    Dim mapper As New clsDtHeaderMapping
    Dim tmpDt As New DataTable
    Dim tmpDtJP As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnSoudashiTanaSelect())
    'BlnTorikomiZumi = tmpDt.AsEnumerable().Any(Function(row) row.Field(Of Integer)("TORIKOMI_JOKYO_FLG") = 1)
    tmpDtJP = mapper.ConvertColumnNamesToJapanese(tmpDt, "総出し棚データ")

    If Not tmpDtJP.Columns.Contains("チェック") Then
      tmpDtJP.Columns.Add("チェック", GetType(Boolean))
      For Each row As DataRow In tmpDtJP.Rows
        row("チェック") = False ' 初期値
      Next
    End If
    ' チェック列を一番左に移動！
    tmpDtJP.Columns("チェック").SetOrdinal(0)

    DgvList1.SetData(tmpDtJP)

  End Sub

  Private Sub FormatFixedLengthTrnNyuka(prmDt As DataTable, prmFileName As String, prmLenColumn As List(Of Tuple(Of String, Integer)))
    Dim writer As New StreamWriter(prmFileName, False, Encoding.GetEncoding("shift-jis"))
    Try
      Dim line As String = String.Empty
      Dim tmpListTuple As List(Of Tuple(Of String, Integer)) = prmLenColumn
      'DataGridのデータを固定長に変換して出力
      For Each tmpRow In prmDt.Rows
        For Each LenColumnInTup In tmpListTuple
          line &= ToFixedLength(tmpRow(LenColumnInTup.Item1).ToString(), LenColumnInTup.Item2)
        Next

        writer.WriteLine(line)
        line = String.Empty
      Next


    Catch ex As Exception
      Throw New Exception(ex.Message)
    Finally
      writer.Close()
    End Try

  End Sub

  Public Function ToFixedLength(input As String, byteLength As Integer) As String
    Dim enc = System.Text.Encoding.GetEncoding("shift-jis")
    If input Is Nothing Then input = ""
    Dim bytes = enc.GetBytes(input)

    If bytes.Length > byteLength Then
      Dim result As String = ""
      Dim total As Integer = 0
      For Each c As Char In input
        Dim b = enc.GetBytes(c.ToString())
        If total + b.Length > byteLength Then Exit For
        result &= c
        total += b.Length
      Next
      Return result
    Else
      Return input & New String(" "c, byteLength - bytes.Length)
    End If
  End Function


  Private Function SqlSelTrnSoudashiTanaSelect() As String
    Dim sql As String = String.Empty

    sql &= " SELECT		LEFT(MST_ITEM.TANA_CD,2) AS TANA_CD "
    sql &= "      ,	MST_TANA.TANA_ONDO + ' ' + MST_TANA.FLOOR AS TANA_NAME "
    sql &= "      ,	CASE WHEN MAX(SOUDASHI_SEND_DATE) is not null THEN '有' ELSE '無' END AS SOUDASHI_SEND_DATE "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > " & SHUKKA_STATUS.SOUDASHI_ZUMI & " THEN '済' ELSE '未' END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_TANA "
    sql &= " ON MST_TANA.TANA_CD = MST_ITEM.TANA_CD "
    sql &= " WHERE TORIKOMI_JOKYO_FLG < " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If

    sql &= " GROUP BY LEFT(MST_ITEM.TANA_CD,2),MST_TANA.TANA_ONDO,MST_TANA.FLOOR "
    sql &= "    ,   NOUHINBI "
    sql &= "    ,   MST_TANA.TANA_ONDO,MST_TANA.FLOOR "
    sql &= "    ,   MST_TANA.FLOOR "
    sql &= " ORDER BY LEFT(MST_ITEM.TANA_CD, 2) "

    Return sql

  End Function

  Private Function SqlSelTrnSoudashiTana(prmTanaList As List(Of String)) As String
    Dim sql As String = String.Empty


    sql &= " SELECT	NOUHINBI AS NOUHINBI  "
    sql &= " 	    	,	LEFT(MST_ITEM.TANA_CD,2) AS TANA_CD "
    sql &= "      ,	MST_TANA.TANA_ONDO + ' ' + MST_TANA.FLOOR AS TANA_NAME "
    sql &= "      ,	MAX(SOUDASHI_GOUKI) AS GOUKI "
    sql &= "      ,	MAX(SOUDASHI_TANTO_CD) AS TANTO_CD "
    sql &= "      ,	MAX(SOUDASHI_RECEIVE_DATE) AS RECEIVE_DATE "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > 1 THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_TANA "
    sql &= " ON MST_TANA.TANA_CD = MST_ITEM.TANA_CD "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    If prmTanaList.Count > 0 Then
      Dim tanaInClause As String = String.Join(",", prmTanaList.Select(Function(cd) $"'{cd}'"))
      sql &= " AND LEFT(MST_ITEM.TANA_CD,2) IN (" & tanaInClause & ")"
    End If


    sql &= " GROUP BY LEFT(MST_ITEM.TANA_CD,2),MST_TANA.TANA_ONDO,MST_TANA.FLOOR "
    sql &= "    ,   NOUHINBI "
    sql &= "    ,   MST_TANA.TANA_ONDO,MST_TANA.FLOOR "
    sql &= "    ,   MST_TANA.FLOOR "
    sql &= " ORDER BY LEFT(MST_ITEM.TANA_CD, 2) "

    Return sql

  End Function

  Private Function SqlSelTrnSoudashi(prmTanaList As List(Of String)) As String
    Dim sql As String = String.Empty

    sql &= " SELECT	LEFT(MST_ITEM.TANA_CD,2) AS TANA_CD "
    sql &= " 	    ,	LEFT(MST_ITEM.TANA_CD,1) + '-' + SUBSTRING(MST_ITEM.TANA_CD,2,1) +'-' + RIGHT(MST_ITEM.TANA_CD,2)  AS TANA_AREA "
    sql &= "      ,	TRN_SHUKKA.JISYA_SHOHIN_CD AS JISYA_SHOHIN_CD  "
    sql &= "      ,	TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2 AS JISYA_SHOHIN_MEI "
    sql &= "      ,	MST_ITEM.JAN AS JAN "
    sql &= "      ,	MST_ITEM.ITF AS ITF "
    sql &= "      ,	SUM(CONVERT(int,TRN_SHUKKA.JISYA_HACHU_SURYO / ISNULL(MST_ITEM.IRISU,1))) AS SHUKKA_YOTEISU_CASE "
    sql &= "      ,	SUM(CONVERT(int,TRN_SHUKKA.JISYA_HACHU_SURYO % ISNULL(MST_ITEM.IRISU,1))) AS SHUKKA_YOTEISU_BARA "
    sql &= "      ,	MAX(SOUDASHI_GOUKI) AS GOUKI "
    sql &= "      ,	MAX(SOUDASHI_TANTO_CD) AS TANTO_CD "
    sql &= "      ,	MAX(SOUDASHI_RECEIVE_DATE) AS RECEIVE_DATE "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > 1 THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_TANA "
    sql &= " ON MST_TANA.TANA_CD = MST_ITEM.TANA_CD "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    If prmTanaList.Count > 0 Then
      Dim tanaInClause As String = String.Join(",", prmTanaList.Select(Function(cd) $"'{cd}'"))
      sql &= " AND LEFT(MST_ITEM.TANA_CD,2) IN (" & tanaInClause & ")"
    End If

    sql &= " GROUP BY MST_ITEM.TANA_CD "
    sql &= "    ,   NOUHINBI "
    sql &= "    ,TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= "    ,TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2"
    sql &= "    ,MST_ITEM.JAN"
    sql &= "    ,MST_ITEM.ITF "
    sql &= " ORDER BY LEFT(MST_ITEM.TANA_CD, 2),TRN_SHUKKA.JISYA_SHOHIN_CD "

    Return sql

  End Function


  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & SEND_SHUKKA_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpCommunicationDate As New Dictionary(Of String, String)

    Try

      'ComMessageBox("ハンディターミナルを受信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      Handy.CreateCommnicationFile(PROJECT_DIR_NAME & SEND_SHUKKA_FILE_NAME, PROJECT_DIR_NAME & SEND_FOLDER)

      ' チェックされたTANA_CDのリストを取得
      Dim selectedTanaList As New List(Of String)

      For Each row As DataGridViewRow In DgvList1.Rows
        If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("チェック").Value) = True Then
          Dim tanaCd As String = row.Cells(1).Value?.ToString()
          If Not String.IsNullOrEmpty(tanaCd) AndAlso Not selectedTanaList.Contains(tanaCd) Then
            selectedTanaList.Add(tanaCd)
          End If

          If row.Cells("SOUDASHI_SEND_DATE").Value?.ToString() = "有" Then
            BtnSendHandy1.TargetCancelParentClick = True
          End If
        End If
      Next

      If BtnSendHandy1.TargetCancelParentClick Then
        Dim result As String = InputBox("送信済みのデータが含まれます。本当に送信しますか？", "認証")
        If result = ReadSettingIniFile("PASS", "VALUE") Then
          BtnSendHandy1.TargetCancelParentClick = False
        Else
          BtnSendHandy1.TargetCancelParentClick = True
          Exit Sub
        End If

      End If



      SqlServer.GetResult(tmpDt, SqlSelTrnSoudashiTana(selectedTanaList))



      '棚番マスタ
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_SHUKKA_FILE_NAME, LenColumnInSoudashiTana)

      '総出しデータ 未実施
      SqlServer.GetResult(tmpDt, SqlSelTrnSoudashi(selectedTanaList))
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_SOUDASHI_FILE_NAME, LenColumnInSoudashi)

      Handy.DeleteCommnicationFile()

      ''条件項目生成
      tmpWhere.Add("JISYA_SHOHIN_CD")

      ''更新項目生成
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      ''通信日付項目生成
      tmpCommunicationDate.Add("SOUDASHI_SEND_DATE", ComGetProcTime)

      BtnSendHandy1.Handy = Handy
      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_SOUDASHI_FILE_NAME
      BtnSendHandy1.TargetTableName = "TRN_SHUKKA"
      BtnSendHandy1.TargetLenClumn = LenColumnInSoudashi
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetUpdColumn = tmpUpdColumn
      BtnSendHandy1.TargetUpdStatus = CInt(SHUKKA_STATUS.SOUDASHI_SOUSINZUMI)
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub
End Class
