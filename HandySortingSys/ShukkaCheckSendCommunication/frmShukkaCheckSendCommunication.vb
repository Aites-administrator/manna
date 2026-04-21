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
Public Class frmShukkaCheckSendCommunication
  Inherits FormSendCommunication
  Private SqlServer As New clsSqlServer
  Private BlnTorikomiZumi As Boolean = False
  Private Const SEND_SHOP_FILE_NAME As String = SEND_FOLDER & "MST_SHOP.DAT"
  Private Const SEND_SHOPITEM_FILE_NAME As String = SEND_FOLDER & "SHOPITEM.DAT"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextDataGrid = DgvList1

    Me.TextDisplayName = "4.出荷検品"
    MyBase.OnLoad(e)
  End Sub

  Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CmbDateNohinBi1.SelectedIndex = 0
    RegisterSendButton(Me.BtnSendHandy1)

  End Sub

  Protected Overrides Sub OnSendCompleted()
    MyBase.OnSendCompleted()
    ReloadGrid()
  End Sub


  Private Sub CmbDateNohinBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateNohinBi1.SelectedIndexChanged
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
          If LenColumnInTup.Item1 = "JISYA_SHOHIN_MEI" Or LenColumnInTup.Item1 = "JIGYOSHO_MEI" Then
            line &= ToFixedLength(StrConv(tmpRow(LenColumnInTup.Item1).ToString(), VbStrConv.Narrow), LenColumnInTup.Item2)
          ElseIf LenColumnInTup.Item1 = "KENPIN_RECEIVE_DATE" Then

            ' ★ DateTime → yyyyMMddHHmmss に変換
            Dim tmpVal As String = String.Empty

            If Not IsDBNull(tmpRow(LenColumnInTup.Item1)) AndAlso
               TypeOf tmpRow(LenColumnInTup.Item1) Is DateTime Then

              tmpVal = CType(tmpRow(LenColumnInTup.Item1), DateTime).ToString("yyyyMMddHHmmss")

            Else
              tmpVal = ""   ' 必要なら空白埋めなどに変更
            End If

            line &= ToFixedLength(tmpVal, LenColumnInTup.Item2)

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


  Private Function SqlSelTrnShopItemSelect() As String
    Dim sql As String = String.Empty

    sql &= " SELECT	NOUHINBI AS NOUHINBI "
    sql &= " 	    ,	JIGYOSHO_CD AS JIGYOSHO_CD "
    sql &= " 	    ,	JIGYOSHO_MEI AS JIGYOSHO_MEI "
    sql &= "      ,	JISYA_SHOHIN_CD AS JISYA_SHOHIN_CD "
    sql &= "      ,	TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2 AS JISYA_SHOHIN_MEI "
    sql &= "      ,	MST_ITEM.JAN AS JAN "
    sql &= "      ,	MST_ITEM.ITF AS ITF "
    sql &= "      ,	CONVERT(int,SUM(TRN_SHUKKA.JISYA_HACHU_SURYO) / ISNULL(MAX(MST_ITEM.IRISU),1)) AS SHUKKA_YOTEISU_CASE "
    sql &= "      ,	CONVERT(int,SUM(TRN_SHUKKA.JISYA_HACHU_SURYO) % ISNULL(MAX(MST_ITEM.IRISU),1)) AS SHUKKA_YOTEISU_BARA "
    sql &= "      ,	MAX(KENPIN_GOUKI) AS KENPIN_GOUKI "
    sql &= "      ,	MAX(KENPIN_TANTO_CD) AS KENPIN_TANTO_CD "
    sql &= "      ,	MAX(KENPIN_RECEIVE_DATE) AS KENPIN_RECEIVE_DATE "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) >= " & CInt(SHUKKA_STATUS.KENPIN_ZUMI) & " THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= "      ,	 'C/S' AS CASE_TANI"
    sql &= "      ,	 HACHU_TANI AS BARA_TANI"
    sql &= "      ,	 '' AS INDEX_ID"
    sql &= " FROM TRN_SHUKKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_SHUKKA.JISYA_SHOHIN_CD "
    sql &= " LEFT JOIN MST_TANA "
    sql &= " ON MST_TANA.TANA_CD = LEFT(MST_ITEM.TANA_CD,2) "
    sql &= " WHERE TORIKOMI_JOKYO_FLG >= " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    sql &= " AND TORIKOMI_JOKYO_FLG < " & CInt(SHUKKA_STATUS.KENPIN_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " GROUP BY NOUHINBI "
    sql &= "    ,	JIGYOSHO_CD "
    sql &= "    ,	JIGYOSHO_MEI "
    sql &= "    ,	JISYA_SHOHIN_CD "
    sql &= "    ,	TRN_SHUKKA.JISYA_SHOHIN_MEI1 + TRN_SHUKKA.JISYA_SHOHIN_MEI2 "
    sql &= "    , MST_ITEM.ITF "
    sql &= "    , MST_ITEM.JAN "
    sql &= "    , HACHU_TANI "
    sql &= " ORDER BY NOUHINBI,JIGYOSHO_CD,JISYA_SHOHIN_CD "

    Return sql

  End Function

  Private Function SqlSelTrnShop() As String
    Dim sql As String = String.Empty


    sql &= " SELECT	JIGYOSHO_CD AS JIGYOSHO_CD "
    sql &= " 	    	,	JIGYOSHO_MEI AS JIGYOSHO_MEI "
    sql &= "      ,	CASE WHEN MIN(TORIKOMI_JOKYO_FLG) >= " & CInt(SHUKKA_STATUS.KENPIN_ZUMI) & " THEN 1 ELSE 0 END AS TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_SHUKKA "
    sql &= " WHERE TORIKOMI_JOKYO_FLG >= " & CInt(SHUKKA_STATUS.SOUDASHI_ZUMI)
    sql &= " AND TORIKOMI_JOKYO_FLG < " & CInt(SHUKKA_STATUS.KENPIN_ZUMI)
    If CmbDateNohinBi1.SelectedValue Is Nothing Then
      sql &= " AND NOUHINBI = ''"
    Else
      sql &= " AND NOUHINBI = " & CmbDateNohinBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " GROUP BY JIGYOSHO_CD "
    sql &= "    ,   JIGYOSHO_MEI "
    sql &= " ORDER BY JIGYOSHO_CD "

    Return sql

  End Function
  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & SEND_SHOPITEM_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpCommunicationDate As New Dictionary(Of String, String)

    Try

      'ComMessageBox("ハンディターミナルを受信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      BtnSendHandy1.Handy = Handy
      Me.TextHandy = Handy

      Handy.TargetFolder = PROJECT_DIR_NAME & SEND_FOLDER

      Handy.CreateAcquisitionFlag(PROJECT_DIR_NAME & SEND_SHOPITEM_FILE_NAME)
      SqlServer.GetResult(tmpDt, SqlSelTrnShopItemSelect)
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_SHOPITEM_FILE_NAME, LenColumnInShukkaCheck)



      '総出しデータ 未実施
      SqlServer.GetResult(tmpDt, SqlSelTrnShop())
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_SHOP_FILE_NAME, LenColumnInShop)

      'パスワードデータ
      tmpDt.Clear()
      If Not tmpDt.Columns.Contains("PASSWORD") Then
        tmpDt.Columns.Add("PASSWORD", GetType(String))
      End If

      Dim rowPass As DataRow = tmpDt.NewRow
      rowPass("PASSWORD") = ReadSettingIniFile("PASS", "VALUE")
      tmpDt.Rows.Add(rowPass)
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_PASSWORD_FILE_NAME, LenColumnInPASSWORD)


      Handy.DeleteAcquisitionFlag()

      ''条件項目生成
      tmpWhere.Add("NOUHINBI")
      tmpWhere.Add("JIGYOSHO_CD")
      tmpWhere.Add("JISYA_SHOHIN_CD")

      ''更新項目生成
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      ''通信日付項目生成
      tmpCommunicationDate.Add("KENPIN_SEND_DATE", ComGetProcTime)

      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_SHOPITEM_FILE_NAME
      BtnSendHandy1.TargetTableName = "TRN_SHUKKA"
      BtnSendHandy1.TargetLenClumn = LenColumnInShukkaCheck
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetUpdColumn = tmpUpdColumn
      BtnSendHandy1.TargetUpdStatus = CInt(SHUKKA_STATUS.KENPIN_SOUSINZUMI)
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

  Private Sub ReloadGrid()
    Dim mapper As New clsDtHeaderMapping
    Dim tmpDt As New DataTable
    Dim tmpDtJP As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnShopItemSelect())
    tmpDtJP = mapper.ConvertColumnNamesToJapanese(tmpDt, "出荷検品データ")

    DgvList1.SetData(tmpDtJP)
  End Sub


End Class
