Imports System.IO.Ports
Imports System.Text
Imports System.IO
Imports System.Threading
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl
Imports ClsHandyCommunication

Public Class frmNyukaSendCommunication
  Inherits FormCommunication

  Private SqlServer As New clsSqlServer
  Private Const SEND_FOLDER As String = "D:\manna\SEND\"
  Private Const SEND_NYUKA_FILE_NAME As String = "D:\manna\SEND\IN_ITEM.DAT"

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


      For Each tmpRow In prmDt.Rows
        line &= ToFixedLength(tmpRow("HACHU_NO").ToString(), 6)
        line &= ToFixedLength(tmpRow("GYO_NO").ToString(), 2)
        line &= ToFixedLength(tmpRow("JISYA_SHOHIN_CD").ToString(), 5)
        line &= ToFixedLength(StrConv(tmpRow("MAKER_SHOHIN_MEI").ToString(), VbStrConv.Narrow), 80)
        line &= ToFixedLength(StrConv(tmpRow("MAKER_KIKAKU_MEI").ToString(), VbStrConv.Narrow), 30)
        line &= ToFixedLength(tmpRow("NYUKA_YOTEISU_CASE").ToString(), 4)
        line &= ToFixedLength(tmpRow("NYUKA_YOTEISU_KOGUCHI").ToString(), 4)
        line &= ToFixedLength(tmpRow("NYUKA_YOTEISU_JISYA").ToString(), 4)
        line &= ToFixedLength(tmpRow("NYUKA_JISSEKISU_CASE").ToString(), 4)
        line &= ToFixedLength(tmpRow("NYUKA_JISSEKISU_JISYA").ToString(), 4)
        line &= ToFixedLength(tmpRow("MAKER_NIAISU").ToString(), 2)
        line &= ToFixedLength(tmpRow("MAKER_HACHU_TANI").ToString(), 6)
        line &= ToFixedLength(tmpRow("JAN").ToString(), 13)
        line &= ToFixedLength(tmpRow("ITF").ToString(), 16)
        line &= ToFixedLength(tmpRow("NYUKA_YOTEI_DATE").ToString(), 8)
        line &= ToFixedLength(tmpRow("GOUKI").ToString(), 2)
        line &= ToFixedLength(tmpRow("TANTO").ToString(), 3)
        line &= ToFixedLength(tmpRow("KENPIN_DATE").ToString(), 8)
        line &= ToFixedLength(tmpRow("STATUS").ToString(), 1)
        line &= ToFixedLength(tmpRow("HACHU_GYO_NO").ToString(), 9)
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
    sql &= "      ,	TRN_NYUKA.NYUKA_YOTEISU_MAKER NYUKA_YOTEISU_KOGUCHI "
    sql &= "      ,	CONVERT(int,TRN_NYUKA.NYUKA_YOTEISU_JISYA % MST_ITEM.IRISU) NYUKA_YOTEISU_JISYA  "
    sql &= "      ,	TRN_NYUKA.NYUKA_JISSEKISU_MAKER NYUKA_JISSEKISU_CASE "
    sql &= "      ,	TRN_NYUKA.NYUKA_JISSEKISU_JISYA "
    sql &= "      ,	TRN_NYUKA.MAKER_NIAISU "
    sql &= "      ,	TRN_NYUKA.MAKER_HACHU_TANI "
    sql &= "      ,	JAN "
    sql &= "      ,	ITF "
    sql &= "      ,	TRN_NYUKA.NYUKA_YOTEI_DATE "
    sql &= "      ,	LEFT('' + SPACE(2), 2)  GOUKI "
    sql &= "      ,	LEFT('' + SPACE(3), 3)  TANTO "
    sql &= "      ,	LEFT('' + SPACE(8), 8)  KENPIN_DATE "
    sql &= "      ,	LEFT('0' + SPACE(1), 1) STATUS "
    sql &= "      ,	LEFT(TRN_NYUKA.HACHU_NO + SPACE(6), 6) + '_' + LEFT(TRN_NYUKA.GYO_NO + SPACE(2), 2) HACHU_GYO_NO "
    sql &= " FROM TRN_NYUKA "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_NYUKA.JISYA_SHOHIN_CD "
    If Not String.IsNullOrWhiteSpace(CmbDateSagyoBi1.SelectedValue) Then
      sql &= " WHERE NYUKA_YOTEI_DATE = " & CmbDateSagyoBi1.SelectedValue.ToString.Replace("/", "")
    End If

    Return sql

  End Function

  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(SEND_NYUKA_FILE_NAME)

    Try
      Handy.CreateCommnicationFile(SEND_NYUKA_FILE_NAME, SEND_FOLDER)
      SqlServer.GetResult(tmpDt, SqlSelTrnNyuka)

      FormatFixedLengthTrnNyuka(tmpDt, SEND_NYUKA_FILE_NAME)
      Handy.DeleteCommnicationFile()

      BtnSendHandy1.Handy = Handy
      BtnSendHandy1.TargetFileName = SEND_NYUKA_FILE_NAME

    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub

End Class
