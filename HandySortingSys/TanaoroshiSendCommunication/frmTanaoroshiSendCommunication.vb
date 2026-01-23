Imports T.R.ZCommonCtrl
Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsLenColumnDef
Imports ClsHandyCommunication

Public Class frmTanaoroshiSendCommunication
  Inherits FormSendCommunication
  Private SqlServer As New clsSqlServer
  Private Const SEND_FOLDER As String = "SEND\"
  Private Const SEND_TANA_FILE_NAME As String = SEND_FOLDER & "TANALIST.DAT"
  Private Const SEND_TANAOROSHI_FILE_NAME As String = SEND_FOLDER & "IN_TANA.DAT"


  Protected Overrides Sub OnLoad(e As EventArgs)

    Me.TextDisplayName = "棚卸"

    MyBase.OnLoad(e)
  End Sub

  Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CmbDateTanaoroshiBi1.SelectedIndex = 0
    RegisterSendButton(Me.BtnSendHandy1)


  End Sub

  Private Sub CmbDateSagyoBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateTanaoroshiBi1.SelectedIndexChanged
    ReloadGrid()
  End Sub

  Private Sub FormatFixedLengthTrnNyuka(prmDt As DataTable, prmFileName As String, prmLenColumn As List(Of Tuple(Of String, Integer)))

    Dim writer As New StreamWriter(prmFileName, False, Encoding.GetEncoding("shift-jis"))
    Try
      Dim line As String = String.Empty
      Dim tmpListTuple As List(Of Tuple(Of String, Integer)) = prmLenColumn
      'DataGridのデータを固定長に変換して出力
      For Each tmpRow In prmDt.Rows
        For Each LenColumnInTup In tmpListTuple
          If LenColumnInTup.Item1 = "JISYA_SHOHIN_MEI" Then
            line &= ToFixedLength(StrConv(tmpRow(LenColumnInTup.Item1).ToString(), VbStrConv.Narrow), LenColumnInTup.Item2)
          Else
            line &= ToFixedLength(tmpRow(LenColumnInTup.Item1).ToString(), LenColumnInTup.Item2)
          End If
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


  Private Function SqlSelTrnTanaoroshi() As String
    Dim sql As String = String.Empty

    sql &= " SELECT TANAOROSHI_DATE "
    sql &= " 	    ,	SAGYO_YOTEI_DATE "
    sql &= "      ,	LEFT(MST_ITEM.TANA_CD,2) AS TANA_CD "
    sql &= "      ,	LEFT(MST_ITEM.TANA_CD,1) + '-' + SUBSTRING(MST_ITEM.TANA_CD,2,1) +'-' + RIGHT(MST_ITEM.TANA_CD,2)  AS TANA_AREA "
    sql &= "      ,	TRN_TANAOROSHI.JISYA_SHOHIN_CD "
    sql &= "      ,	TRN_TANAOROSHI.JISYA_SHOHIN_MEI "
    sql &= "      ,	TRN_TANAOROSHI.IRISU "
    sql &= "      ,	MST_ITEM.JAN  "
    sql &= "      ,	MST_ITEM.ITF "
    sql &= "      ,	CONVERT(int,TRN_TANAOROSHI.TANA_DATE_ZAIKO_SU / ISNULL(TRN_TANAOROSHI.IRISU,1)) AS TANA_YOTEISU_CASE "
    sql &= "      ,	CONVERT(int,TRN_TANAOROSHI.TANA_DATE_ZAIKO_SU / ISNULL(TRN_TANAOROSHI.IRISU,1)) AS TANA_YOTEISU_BARA "
    sql &= "      ,	TANA_JISSEKI_CASE "
    sql &= "      ,	TANA_JISSEKI_BARA "
    sql &= "      ,	'C/S' AS CASE_TANI "
    sql &= "      ,	MST_ITEM.TANKA_TANI AS BARA_TANI "
    sql &= "      ,	MST_ITEM.SHOMIKIGEN "
    sql &= "      ,	TRN_TANAOROSHI.GOUKI "
    sql &= "      ,	TRN_TANAOROSHI.TANTO_CD "
    sql &= "      ,	TRN_TANAOROSHI.RECEIVE_DATE "
    sql &= "      , CASE WHEN TORIKOMI_JOKYO_FLG = " & TANAOROSHI_STATUS.TANAOROSHI_ZUMI & " THEN '1' ELSE '0' END AS TORIKOMI_JOKYO_FLG "
    sql &= "      ,	'' as INDEX_ID "
    sql &= " FROM TRN_TANAOROSHI "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_TANAOROSHI.JISYA_SHOHIN_CD "
    sql &= " WHERE 1 = 1 "
    If CmbDateTanaoroshiBi1.SelectedValue Is Nothing Then
      sql &= " AND TANAOROSHI_DATE = ''"
    Else
      sql &= " AND TANAOROSHI_DATE = " & CmbDateTanaoroshiBi1.SelectedValue.ToString.Replace("/", "")
    End If

    Return sql

  End Function

  Private Function SqlSelTrnTanaoroshiTana() As String
    Dim sql As String = String.Empty

    sql &= " SELECT LEFT(MST_ITEM.TANA_CD,2) AS TANA_CD "
    sql &= "      ,	MST_TANA.TANA_ONDO + ' ' + MST_TANA.FLOOR AS TANA_NAME "
    sql &= "      , CASE WHEN MAX(TORIKOMI_JOKYO_FLG) = " & TANAOROSHI_STATUS.TANAOROSHI_ZUMI & " THEN '1' ELSE '0' END AS TORIKOMI_JOKYO_FLG "
    sql &= "      ,	'' as INDEX_ID "
    sql &= " FROM TRN_TANAOROSHI "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_TANAOROSHI.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_TANA "
    sql &= " ON MST_TANA.TANA_CD = MST_ITEM.TANA_CD "
    sql &= " WHERE 1 = 1 "
    If CmbDateTanaoroshiBi1.SelectedValue Is Nothing Then
      sql &= " AND TANAOROSHI_DATE = ''"
    Else
      sql &= " AND TANAOROSHI_DATE = " & CmbDateTanaoroshiBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " GROUP BY LEFT(MST_ITEM.TANA_CD,2) "
    sql &= "    ,   MST_TANA.TANA_ONDO + ' ' + MST_TANA.FLOOR "
    sql &= " ORDER BY LEFT(MST_ITEM.TANA_CD, 2) "

    Return sql

  End Function

  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & SEND_TANAOROSHI_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpCommunicationDate As New Dictionary(Of String, String)

    Try
      'ComMessageBox("ハンディターミナルを受信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      BtnSendHandy1.Handy = Handy
      Handy.TargetFolder = PROJECT_DIR_NAME & SEND_FOLDER

      Handy.CreateAcquisitionFlag(PROJECT_DIR_NAME & SEND_TANAOROSHI_FILE_NAME)
      SqlServer.GetResult(tmpDt, SqlSelTrnTanaoroshi)

      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_TANAOROSHI_FILE_NAME, LenColumnInTanaoroshi)

      SqlServer.GetResult(tmpDt, SqlSelTrnTanaoroshiTana())
      '棚番マスタ
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_TANA_FILE_NAME, LenColumnInTanaoroshiTana)

      Handy.DeleteAcquisitionFlag()

      '条件項目生成
      tmpWhere.Add("TANAOROSHI_DATE")
      tmpWhere.Add("SAGYO_YOTEI_DATE")
      tmpWhere.Add("JISYA_SHOHIN_CD")

      '更新項目生成
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      '通信日付項目生成
      tmpCommunicationDate.Add("SEND_DATE", ComGetProcTime)

      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_TANAOROSHI_FILE_NAME
      BtnSendHandy1.TargetTableName = "TRN_TANAOROSHI"
      BtnSendHandy1.TargetLenClumn = LenColumnInTanaoroshi
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetUpdColumn = tmpUpdColumn
      BtnSendHandy1.TargetUpdStatus = CInt(TANAOROSHI_STATUS.SOUSINZUMI)
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

  Private Sub ReloadGrid()
    Dim mapper As New clsDtHeaderMapping
    Dim tmpDt As New DataTable
    Dim tmpDtJP As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnTanaoroshi())

    tmpDtJP = mapper.ConvertColumnNamesToJapanese(tmpDt, "棚卸予定データ")

    DgvList1.TargetColumnName = "取込状況FLG"


    DgvList1.SetData(tmpDtJP)
  End Sub


End Class
