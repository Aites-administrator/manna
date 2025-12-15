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

Public Class frmNyukaSendCommunication
  Inherits FormCommunication

  Private SqlServer As New clsSqlServer
  Private Const SEND_FOLDER As String = "SEND\"
  Private Const SEND_NYUKA_FILE_NAME As String = SEND_FOLDER & "IN_ITEM.DAT"

  Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CmbDateSagyoBi1.SelectedIndex = 0
  End Sub

  Private Sub CmbDateSagyoBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateSagyoBi1.SelectedIndexChanged
    Dim tmpDt As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnNyuka())

    DgvList1.SetData(tmpDt)

  End Sub

  Private Sub FormatFixedLengthTrnNyuka(prmDt As DataTable, prmFileName As String)
    Dim writer As New StreamWriter(prmFileName, False, Encoding.GetEncoding("shift-jis"))
    Try
      Dim line As String = String.Empty

      'DataGridのデータを固定長に変換して出力
      For Each tmpRow In prmDt.Rows
        For Each LenColumnInNyukaTup In LenColumnInNyuka
          If LenColumnInNyukaTup.Item1 = "MAKER_SHOHIN_MEI" Or LenColumnInNyukaTup.Item1 = "MAKER_KIKAKU_MEI" Then
            line &= ToFixedLength(StrConv(tmpRow(LenColumnInNyukaTup.Item1).ToString(), VbStrConv.Narrow), LenColumnInNyukaTup.Item2)
          Else
            line &= ToFixedLength(tmpRow(LenColumnInNyukaTup.Item1).ToString(), LenColumnInNyukaTup.Item2)
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


  Private Function SqlSelTrnNyuka() As String
    Dim sql As String = String.Empty

    sql &= " SELECT TRN_NYUKA.HACHU_NO "
    sql &= " 	    ,	TRN_NYUKA.GYO_NO "
    sql &= "      ,	TRN_NYUKA.JISYA_SHOHIN_CD "
    sql &= "      ,	TRN_NYUKA.MAKER_SHOHIN_MEI "
    sql &= "      ,	TRN_NYUKA.MAKER_KIKAKU_MEI "
    sql &= "      ,	TRN_NYUKA.NYUKA_YOTEISU_MAKER * IIF(MAKER_NIAISU=0,1,MAKER_NIAISU) AS NYUKA_YOTEISU_CASE "
    sql &= "      ,	TRN_NYUKA.NYUKA_YOTEISU_MAKER "
    sql &= "      ,	CONVERT(int,TRN_NYUKA.NYUKA_YOTEISU_JISYA % MST_ITEM.IRISU) NYUKA_YOTEISU_JISYA  "
    sql &= "      ,	TRN_NYUKA.NYUKA_JISSEKISU_MAKER "
    sql &= "      ,	TRN_NYUKA.NYUKA_JISSEKISU_JISYA "
    sql &= "      ,	TRN_NYUKA.MAKER_NIAISU "
    sql &= "      ,	TRN_NYUKA.MAKER_HACHU_TANI "
    sql &= "      ,	JAN "
    sql &= "      ,	ITF "
    sql &= "      ,	TRN_NYUKA.NYUKA_YOTEI_DATE "
    sql &= "      ,	TRN_NYUKA.GOUKI "
    sql &= "      ,	TRN_NYUKA.TANTO_CD "
    sql &= "      ,	LEFT('' + SPACE(8), 8)  RECEIVE_DATE "
    sql &= "      ,	LEFT('' + SPACE(1), 8) SHOMIKIGEN "
    sql &= "      ,	LEFT('0' + SPACE(1), 1) TORIKOMI_JOKYO_FLG "
    sql &= "      ,	LEFT(TRN_NYUKA.HACHU_NO + SPACE(6), 6) + '_' + LEFT(TRN_NYUKA.GYO_NO + SPACE(2), 2) HACHU_GYO_NO "
    sql &= " FROM TRN_NYUKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_NYUKA.JISYA_SHOHIN_CD "
    sql &= " WHERE TORIKOMI_JOKYO_FLG <> " & CInt(STATUS.KEPINZUMI)
    If Not String.IsNullOrWhiteSpace(CmbDateSagyoBi1.SelectedValue) Then
      sql &= " AND NYUKA_YOTEI_DATE = " & CmbDateSagyoBi1.SelectedValue.ToString.Replace("/", "")
    End If

    Return sql

  End Function

  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & SEND_NYUKA_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpCommunicationDate As New Dictionary(Of String, String)

    Try
      ComMessageBox("ハンディターミナルを受信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      Handy.CreateCommnicationFile(PROJECT_DIR_NAME & SEND_NYUKA_FILE_NAME, PROJECT_DIR_NAME & SEND_FOLDER)
      SqlServer.GetResult(tmpDt, SqlSelTrnNyuka)

      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_NYUKA_FILE_NAME)
      Handy.DeleteCommnicationFile()

      '条件項目生成
      tmpWhere.Add("HACHU_NO")
      tmpWhere.Add("GYO_NO")

      '更新項目生成
      tmpUpdColumn.Add("TORIKOMI_JOKYO_FLG")

      '通信日付項目生成
      tmpCommunicationDate.Add("SEND_DATE", ComGetProcTime)

      BtnSendHandy1.Handy = Handy
      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_NYUKA_FILE_NAME
      BtnSendHandy1.TargetTableName = "TRN_NYUKA"
      BtnSendHandy1.TargetLenClumn = LenColumnInNyuka
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetUpdColumn = tmpUpdColumn
      BtnSendHandy1.TargetUpdStatus = CInt(STATUS.SOUSINZUMI)
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

End Class
