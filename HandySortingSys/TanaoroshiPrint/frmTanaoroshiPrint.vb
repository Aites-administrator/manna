Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl
Imports DateListChk

Public Class frmTanaoroshiPrint
  Inherits FormBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
  Private datagridview1 As New DataGridView
#End Region

  Private Sub frmNyukaPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    CmbDateSagyoBi1.SelectedIndex = 0
    CmbDateSagyoBi1.InitCmb()
    AddHandler BtnOutput1.ReceiveCompleted, AddressOf ReceiveCompleted

  End Sub

  Private Sub ReceiveCompleted()
    '日付登録
    Try

      HideProcessing()

    Catch ex As Exception
      ComWriteErrLog(ex)
    End Try

  End Sub
  Private Sub BtnOutput1_Click(sender As Object, e As EventArgs) Handles BtnOutput1.Click
    Try
      ShowProcessing("データ取得中…")

      BtnOutput1.TargetDataGridView = DgvList1

    Catch ex As Exception
      ReceiveCompleted()
    End Try

  End Sub

  Private Function SqlSelTrnNyuka() As String
    Dim sql As String = String.Empty

    sql &= " SELECT	TANAOROSHI_DATE AS 棚卸日 "
    sql &= "      , SAGYO_YOTEI_DATE AS 作業予定日 "
    sql &= "      , LEFT(MST_ITEM.TANA_CD,1) + '-' + SUBSTRING(MST_ITEM.TANA_CD,2,1) +'-' + RIGHT(MST_ITEM.TANA_CD,2) AS 棚番エリア "
    sql &= "      , JISYA_SHOHIN_CD AS 自社商品コード "
    sql &= "      , JISYA_SHOHIN_MEI AS 商品名 "
    sql &= "      , TRN_TANAOROSHI.IRISU AS 入り数 "
    sql &= "      , CONVERT(int,TRN_TANAOROSHI.TANA_DATE_ZAIKO_SU / ISNULL(TRN_TANAOROSHI.IRISU,1)) AS 在庫予定数_ケース数 "
    sql &= "      ,	'C/S' AS ケース単位_予定 "
    sql &= "      ,	CONVERT(int,TRN_TANAOROSHI.TANA_DATE_ZAIKO_SU % ISNULL(TRN_TANAOROSHI.IRISU,1)) AS 在庫予定数_バラ数 "
    sql &= "      , MST_ITEM.TANKA_TANI　AS バラ単位_予定 "
    sql &= "      , TANA_JISSEKI_CASE AS 在庫実績数_ケース数 "
    sql &= "      ,	'C/S' AS ケース単位_実績 "
    sql &= "      , TANA_JISSEKI_BARA AS 在庫実績数_バラ数 "
    sql &= "      , MST_ITEM.TANKA_TANI AS バラ単位_実績 "
    sql &= "      , MST_ITEM.SHOMIKIGEN AS 賞味期限 "
    sql &= " FROM TRN_TANAOROSHI "
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = TRN_TANAOROSHI.JISYA_SHOHIN_CD "
    If CmbDateSagyoBi1.SelectedValue Is Nothing Then
      sql &= " WHERE TANAOROSHI_DATE = ''"
    Else
      sql &= " WHERE TANAOROSHI_DATE = " & CmbDateSagyoBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " ORDER BY MST_ITEM.TANA_CD "


    Return sql

  End Function

  Private Sub CmbDateSagyoBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateSagyoBi1.SelectedIndexChanged
    Dim tmpDt As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnNyuka())

    DgvList1.SetData(tmpDt)

  End Sub

  Private Sub BtnDataListChk_Click(sender As Object, e As EventArgs) Handles BtnDataListChk.Click
    Try

      Dim frm As New frmDateListChk("TANAOROSHI_ZUMI_DATE_LIST")

      frm.ShowDialog()

      CmbDateSagyoBi1.InitCmb()

    Catch ex As Exception

      ComMessageBox(ex.Message,
                    "エラー",
                    typMsgBox.MSG_ERROR)

    End Try
  End Sub



End Class
