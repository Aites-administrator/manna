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

Public Class frmItemSendCommunication
  Inherits FormSendCommunication
  Private SqlServer As New clsSqlServer
  Private BlnTorikomiZumi As Boolean = False
  Private Const SEND_FOLDER As String = "SEND\"
  Private Const SEND_ITEM_FILE_NAME As String = SEND_FOLDER & "MST_ITEM.DAT"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Dim mapper As New clsDtHeaderMapping
    Dim tmpDt As New DataTable
    Dim tmpDtJP As New DataTable
    Me.TextDataGrid = DgvList1

    SqlServer.GetResult(tmpDt, SqlSelTrnShopItemSelect())
    tmpDtJP = mapper.ConvertColumnNamesToJapanese(tmpDt, "商品マスタ")

    DgvList1.SetData(tmpDtJP)

    MyBase.OnLoad(e)
  End Sub


  'Private Sub frmNyukaSendCommunication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  'End Sub


  Private Sub FormatFixedLengthTrnNyuka(prmDt As DataTable, prmFileName As String, prmLenColumn As List(Of Tuple(Of String, Integer)))
    Dim writer As New StreamWriter(prmFileName, False, Encoding.GetEncoding("shift-jis"))
    Try
      Dim line As String = String.Empty
      Dim tmpListTuple As List(Of Tuple(Of String, Integer)) = prmLenColumn
      'DataGridのデータを固定長に変換して出力
      For Each tmpRow In prmDt.Rows
        For Each LenColumnInTup In tmpListTuple
          If LenColumnInTup.Item1 = "SHOHIN_MEI" Then
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


  Private Function SqlSelTrnShopItemSelect() As String
    Dim sql As String = String.Empty

    sql &= " SELECT SHOHIN_CD AS SHOHIN_CD "
    sql &= " 	    , SHOHIN_MEI AS SHOHIN_MEI "
    sql &= " 	    , JAN AS JAN "
    sql &= "      , ITF AS ITF "
    sql &= "      , IRISU AS IRISU"
    sql &= "      , TANKA_TANI AS TANKA_TANI "
    sql &= "      , LEFT(MST_ITEM.TANA_CD, 1) + '-' + SUBSTRING(MST_ITEM.TANA_CD, 2, 1) + '-' + RIGHT(MST_ITEM.TANA_CD, 2) AS TANA_CD "
    sql &= " FROM MST_ITEM "
    sql &= " WHERE MST_ITEM.TANA_CD IS NOT NULL"
    sql &= " ORDER BY SHOHIN_CD "

    Return sql

  End Function

  Private Sub BtnSendHandy1_Click(sender As Object, e As EventArgs) Handles BtnSendHandy1.Click
    Dim tmpDt As New DataTable
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(PROJECT_DIR_NAME & SEND_ITEM_FILE_NAME)
    Dim tmpWhere As New List(Of String)
    Dim tmpUpdColumn As New List(Of String)
    Dim tmpCommunicationDate As New Dictionary(Of String, String)

    Try

      'ComMessageBox("ハンディターミナルを受信画面にしてクレードルに置いてください。", "お願い", typMsgBox.MSG_WARNING, typMsgBoxButton.BUTTON_OK)

      Handy.TargetFolder = PROJECT_DIR_NAME & SEND_FOLDER

      BtnSendHandy1.Handy = Handy
      BtnSendHandy1.TargetFileName = PROJECT_DIR_NAME & SEND_ITEM_FILE_NAME

      '条件項目生成
      tmpWhere.Add("SHOHIN_CD")

      '通信日付項目生成
      tmpCommunicationDate.Add("SEND_DATE", ComGetProcTime)

      Handy.CreateAcquisitionFlag(PROJECT_DIR_NAME & SEND_ITEM_FILE_NAME)
      SqlServer.GetResult(tmpDt, SqlSelTrnShopItemSelect)
      FormatFixedLengthTrnNyuka(tmpDt, PROJECT_DIR_NAME & SEND_ITEM_FILE_NAME, LenColumnInMstItem)

      Handy.DeleteAcquisitionFlag()

      BtnSendHandy1.TargetLenClumn = LenColumnInMstItem
      BtnSendHandy1.TargetWhere = tmpWhere
      BtnSendHandy1.TargetCommunicationDate = tmpCommunicationDate


    Catch ex As Exception
      ComWriteErrLog(ex, False)
    End Try
  End Sub


End Class
