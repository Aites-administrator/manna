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
Public Class frmTanemakiSendCommunication
  Inherits FormCommunication
  Private SqlServer As New clsSqlServer
  Private BlnTorikomiZumi As Boolean = False
  Private Const SEND_FOLDER As String = "SEND\"
  Private Const SEND_SHUKKA_FILE_NAME As String = SEND_FOLDER & "OUT_COURSE.DAT"
  Private Const SEND_TANEMAKI_FILE_NAME As String = SEND_FOLDER & "OUT_ITEM.DAT"


  Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CmbDateNohinBi1.SelectedIndex = 0
  End Sub


  Private Sub CmbDateNohinBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateNohinBi1.SelectedIndexChanged
    Dim mapper As New clsDtHeaderMapping
    Dim tmpDt As New DataTable
    Dim tmpDtJP As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnSoudashiCourseSelect())
    'BlnTorikomiZumi = tmpDt.AsEnumerable().Any(Function(row) row.Field(Of Integer)("TORIKOMI_JOKYO_FLG") = 1)
    tmpDtJP = mapper.ConvertColumnNamesToJapanese(tmpDt, "種まきコースリスト")

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


  Private Function SqlSelTrnSoudashiCourseSelect() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MST_COURSE.COURSE_CD COURSE_CD "
    sql &= "      ,  HAISOU_COURSE_MEI HAISOU_COURSE_MEI "
    sql &= "      ,  CASE WHEN MAX(TANEMAKI_SEND_DATE) IS NOT NULL THEN '有' "
    sql &= "         ELSE '無' "
    sql &= "         END AS TANEMAKI_SEND_DATE "
    sql &= "      ,  CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > " & CInt(SHUKKA_STATUS.TANEMAKI_ZUMI) & " THEN '済' "
    sql &= "         ELSE '未' "
    sql &= "         END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_COURSE "
    sql &= " ON MST_COURSE.COURSE_MEI = TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= " WHERE TORIKOMI_JOKYO_FLG < " & CInt(SHUKKA_STATUS.TANEMAKI_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If

    sql &= " GROUP BY COURSE_CD "
    sql &= "    ,   HAISOU_COURSE_MEI "
    sql &= "    ,   NOUHINBI "
    sql &= "    ,   MST_COURSE.DISP_ORDER "
    sql &= " ORDER BY MST_COURSE.DISP_ORDER "

    Return sql

  End Function

  Private Function SqlSelTrnTanemakiCourse(prmCourseList As List(Of String)) As String
    Dim sql As String = String.Empty


    sql &= " SELECT	NOUHINBI AS NOUHINBI  "
    sql &= " 	    	,	MST_COURSE.COURSE_CD AS COURSE_CD "　'コースコード
    sql &= "      ,	TRN_SHUKKA.HAISOU_COURSE_MEI HAISOU_COURSE_MEI " 'コース名
    sql &= "      ,	MAX(TANEMAKI_GOUKI) AS GOUKI "
    sql &= "      ,	MAX(TANEMAKI_TANTO_CD) AS TANTO_CD "
    sql &= "      ,	MAX(TANEMAKI_SEND_DATE) AS SEND_DATE "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI) & " THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_COURSE "
    sql &= " ON MST_COURSE.COURSE_MEI = TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    '棚番
    'If prmTanaList.Count > 0 Then
    '  Dim tanaInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
    '  sql &= " AND LEFT(MST_ITEM.TANA_CD,2) IN (" & tanaInClause & ")"
    'End If
    'コース
    If prmCourseList.Count > 0 Then
      Dim CourseInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
      sql &= " AND MST_COURSE.COURSE_CD IN (" & CourseInClause & ")"
    End If

    '検討ーーーーーー
    sql &= " GROUP BY MST_COURSE.COURSE_CD "
    sql &= "    ,   NOUHINBI "
    sql &= "    ,   TRN_SHUKKA.HAISOU_COURSE_MEI  "
    sql &= " ORDER BY MST_COURSE.COURSE_CD "

    Return sql

  End Function

  Private Function SqlSelTrnTanemaki(prmCourseList As List(Of String)) As String
    Dim sql As String = String.Empty

    sql &= " SELECT TRN_SHUKKA.NOUHINBI "
    sql &= "    ,MST_COURSE.COURSE_CD "
    sql &= "    ,TRN_SHUKKA.HAISOU_COURSE_MEI HAISOU_COURSE_MEI "
    sql &= "    ,TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= "    ,TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2 AS JISYA_SHOHIN_MEI "
    sql &= "    ,MST_ITEM.JAN "
    sql &= "    ,MST_ITEM.ITF "
    sql &= "    ,MAX(COURSE_SURYO.SHUKKA_YOTEISU_CASE) AS SHUKKA_COURSE_YOTEISU_CASE "
    sql &= "    ,MAX(COURSE_SURYO.SHUKKA_YOTEISU_BARA) AS SHUKKA_COURSE_YOTEISU_BARA "
    sql &= "    ,JIGYOSHO_CD "
    sql &= "    ,JIGYOSHO_MEI "
    sql &= "    ,SUM(CONVERT(INT, TRN_SHUKKA.JISYA_HACHU_SURYO / ISNULL(MST_ITEM.IRISU, 1))) AS SHUKKA_YOTEISU_CASE "
    sql &= "    ,SUM(CONVERT(INT, TRN_SHUKKA.JISYA_HACHU_SURYO % ISNULL(MST_ITEM.IRISU, 1))) AS SHUKKA_YOTEISU_BARA "
    sql &= "    ,'C/S' AS CASE_TANI "
    sql &= "    ,HACHU_TANI AS BARA_TANI "
    sql &= "    ,MAX(SOUDASHI_GOUKI) AS GOUKI "
    sql &= "    ,MAX(SOUDASHI_TANTO_CD) AS TANTO_CD "
    sql &= "    ,MAX(SOUDASHI_RECEIVE_DATE) AS RECEIVE_DATE "
    sql &= "    ,CASE WHEN MIN(TORIKOMI_JOKYO_FLG) > " & CInt(SHUKKA_STATUS.TANEMAKI_ZUMI) & " THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_COURSE ON MST_COURSE.COURSE_MEI = TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= " LEFT JOIN ( "
    sql &= "    SELECT TRN_SHUKKA.NOUHINBI "
    sql &= "          ,MST_COURSE.COURSE_CD "
    sql &= "          ,TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= "          ,SUM(CONVERT(INT, TRN_SHUKKA.JISYA_HACHU_SURYO / ISNULL(MST_ITEM.IRISU, 1))) AS SHUKKA_YOTEISU_CASE "
    sql &= "          ,SUM(CONVERT(INT, TRN_SHUKKA.JISYA_HACHU_SURYO % ISNULL(MST_ITEM.IRISU, 1))) AS SHUKKA_YOTEISU_BARA "
    sql &= "    FROM TRN_SHUKKA "
    sql &= "    LEFT JOIN MST_ITEM ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= "    LEFT JOIN MST_COURSE ON MST_COURSE.COURSE_MEI = TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    '棚番
    'If prmTanaList.Count > 0 Then
    '  Dim tanaInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
    '  sql &= " AND LEFT(MST_ITEM.TANA_CD,2) IN (" & tanaInClause & ")"
    'End If
    'コース
    If prmCourseList.Count > 0 Then
      Dim CourseInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
      sql &= " AND MST_COURSE.COURSE_CD IN (" & CourseInClause & ")"
    End If
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND TRN_SHUKKA.NOUHINBI = '' "
    Else
      sql &= " AND TRN_SHUKKA.NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= "    GROUP BY TRN_SHUKKA.NOUHINBI, MST_COURSE.COURSE_CD, TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= " ) COURSE_SURYO "
    sql &= "    ON COURSE_SURYO.NOUHINBI = TRN_SHUKKA.NOUHINBI "
    sql &= "   AND COURSE_SURYO.COURSE_CD = MST_COURSE.COURSE_CD "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    '棚番
    'If prmTanaList.Count > 0 Then
    '  Dim tanaInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
    '  sql &= " AND LEFT(MST_ITEM.TANA_CD,2) IN (" & tanaInClause & ")"
    'End If
    'コース
    If prmCourseList.Count > 0 Then
      Dim CourseInClause As String = String.Join(",", prmCourseList.Select(Function(cd) $"'{cd}'"))
      sql &= " AND MST_COURSE.COURSE_CD IN (" & CourseInClause & ")"
    End If
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND TRN_SHUKKA.NOUHINBI = '' "
    Else
      sql &= " AND TRN_SHUKKA.NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " GROUP BY TRN_SHUKKA.NOUHINBI "
    sql &= "        ,MST_COURSE.COURSE_CD "
    sql &= "        ,TRN_SHUKKA.HAISOU_COURSE_MEI "
    sql &= "        ,JIGYOSHO_CD "
    sql &= "        ,JIGYOSHO_MEI "
    sql &= "        ,TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= "        ,TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2 "
    sql &= "        ,MST_ITEM.JAN "
    sql &= "        ,MST_ITEM.ITF "
    sql &= "        ,HACHU_TANI "
    sql &= "        ,COURSE_SURYO.SHUKKA_YOTEISU_CASE "
    sql &= "        ,COURSE_SURYO.SHUKKA_YOTEISU_BARA "
    sql &= " ORDER BY TRN_SHUKKA.NOUHINBI "
    sql &= "        ,MST_COURSE.COURSE_CD "
    sql &= "        ,TRN_SHUKKA.JISYA_SHOHIN_CD "

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
      Dim selectedCouseList As New List(Of String)

      For Each row As DataGridViewRow In DgvList1.Rows
        If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("チェック").Value) = True Then
          Dim tanaCd As String = row.Cells(1).Value?.ToString()
          If Not String.IsNullOrEmpty(tanaCd) AndAlso Not selectedCouseList.Contains(tanaCd) Then
            selectedCouseList.Add(tanaCd)
          End If

          If row.Cells("送信済み").Value?.ToString() = "有" Then
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



      SqlServer.GetResult(tmpDt, SqlSelTrnTanemakiCourse(selectedCouseList))



      'コースマスタ
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_SHUKKA_FILE_NAME, LenColumnInTanemakiCourse)

      '種まきデータ 未実施
      SqlServer.GetResult(tmpDt, SqlSelTrnTanemaki(selectedCouseList))
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_TANEMAKI_FILE_NAME, LenColumnInTANEMAKI)

      Handy.DeleteCommnicationFile()

      ''条件項目生成
      tmpWhere.Add("HAISOU_COURSE_MEI")
      tmpWhere.Add("JISYA_SHOHIN_CD")

      ''更新項目生成
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      ''通信日付項目生成
      tmpCommunicationDate.Add("TANEMAKI_SEND_DATE", ComGetProcTime)

      BtnSendHandy1.Handy = Handy
      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_TANEMAKI_FILE_NAME
      BtnSendHandy1.TargetTableName = "TRN_SHUKKA"
      BtnSendHandy1.TargetLenClumn = LenColumnInTANEMAKI
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetUpdColumn = tmpUpdColumn
      BtnSendHandy1.TargetUpdStatus = CInt(SHUKKA_STATUS.TANEMAKI_SOUSINZUMI)
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

End Class
