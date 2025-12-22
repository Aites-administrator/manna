Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmNyukaPrint
  Inherits FormBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
  Private datagridview1 As New DataGridView
#End Region

  Private Sub frmNyukaPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    CmbDateSagyoBi1.SelectedIndex = 0
  End Sub

  Private Sub BtnOutput1_Click(sender As Object, e As EventArgs) Handles BtnOutput1.Click
    Try
      BtnOutput1.TargetDataGridView = DgvList1

    Catch ex As Exception

    End Try

  End Sub

  Private Function SqlSelTrnNyuka() As String
    Dim sql As String = String.Empty

    sql &= " SELECT	NYUKA_YOTEI_DATE		入荷予定日 "
    sql &= "      ,	HACHU_NO				    発注NO "
    sql &= "      ,	GYO_NO					    行NO"
    sql &= "      ,	HACHUSAKI_OYA_NO + '-' + CAST(HACHUSAKI_EDA_NO AS NVARCHAR)	　発注先コード"
    sql &= "      ,	TEL         		　　TEL"
    sql &= "      ,	FAX         		　　FAX"
    sql &= "      ,	HACHUSAKIMEI		　　発注先名"
    sql &= "      ,	CAST(JISYA_SOKO_CD AS NVARCHAR) + '  ' + JISYA_SOKO_MEI      倉庫"
    sql &= "      ,	ONDOTAI       		　温度帯"
    sql &= "      ,	TANABAN			        棚番 "
    sql &= "      ,	JISYA_SHOHIN_CD			自社商品コード "
    sql &= "      ,	MAKER_MEI		        メーカー名 "
    sql &= "      ,	MAKER_SHOHIN_MEI		メーカー商品名 "
    sql &= "      ,	MAKER_KIKAKU_MEI		メーカー規格名 "
    sql &= "      ,	MAKER_NIAISU			            荷数 "
    sql &= "      ,	MST_ITEM.SHOMIKIGEN			            賞味期限 "
    sql &= "      ,	MST_ITEM.IRISU		入り数 "
    sql &= "      ,	NYUKA_YOTEISU_MAKER		入荷予定数_メーカー "
    sql &= "      ,	NYUKA_YOTEISU_JISYA		入荷予定数_自社 "
    sql &= "      , CASE "
    sql &= "          WHEN NYUKA_YOTEISU_MAKER = NYUKA_JISSEKISU_MAKER "
    sql &= "          THEN 'OK'  "
    sql &= "        ELSE CAST(NYUKA_JISSEKISU_MAKER - NYUKA_YOTEISU_MAKER AS NVARCHAR) "
    sql &= "        END AS 検品結果 "
    sql &= "      ,	ISNULL(NYUKA_JISSEKISU_JISYA,0)	入荷実績数_自社 "
    sql &= "      ,	MAKER_HACHU_TANI		単位 "
    sql &= " FROM TRN_NYUKA"
    sql &= " LEFT JOIN MST_ITEM "
    sql &= " ON MST_ITEM.SHOHIN_CD = JISYA_SHOHIN_CD "
    If CmbDateSagyoBi1.SelectedValue Is Nothing Then
      sql &= " WHERE NYUKA_YOTEI_DATE = ''"
    Else
      sql &= " WHERE NYUKA_YOTEI_DATE = " & CmbDateSagyoBi1.SelectedValue.ToString.Replace("/", "")
    End If
    sql &= " ORDER BY HACHU_NO,GYO_NO "


    Return sql

  End Function

  Private Sub CmbDateSagyoBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateSagyoBi1.SelectedIndexChanged
    Dim tmpDt As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnNyuka())

    DgvList1.SetData(tmpDt)

  End Sub

End Class
