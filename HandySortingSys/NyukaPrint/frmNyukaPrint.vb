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
    CmbDateSagyoBi1.SelectedIndex = 0
  End Sub

  Private Sub BtnOutput1_Click(sender As Object, e As EventArgs) Handles BtnOutput1.Click
    'datagridview1.Columns.Add("商品コード", "商品コード")
    'datagridview1.Columns.Add("商品名", "商品名")
    'datagridview1.Columns.Add("規格", "規格")
    'datagridview1.Columns.Add("発注数量", "発注数量")
    'datagridview1.Columns.Add("入荷数量", "入荷数量")
    'datagridview1.Columns.Add("備考", "備考")

    'datagridview1.Rows.Add("17842", "ブルガリアヨーグルト　いちご", "（７０Ｇ×４）×６", "2", "2", "OK")
    'datagridview1.Rows.Add("33722", "クルルマーク　上白糖ＣＩＳ２　いちご", "２０ＫＧ", "2", "1", "NG")

    BtnOutput1.TargetDataGridView = DgvList1
    BtnOutput1.TargetFormatFile = "D:\manna\HandySortingSys\REPORT\【ひな形】入荷検品報告書.xlsx"

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
    sql &= "      ,	'20251202'			            賞味期限 "
    sql &= "      ,	NYUKA_YOTEISU_MAKER		入荷予定数_メーカー "
    sql &= "      ,	NYUKA_YOTEISU_JISYA		入荷予定数_自社 "
    sql &= "      ,	NYUKA_JISSEKISU_MAKER	入荷実績数_メーカー "
    sql &= "      ,	NYUKA_JISSEKISU_JISYA	入荷実績数_自社 "
    sql &= "      ,	MAKER_HACHU_TANI		単位 "
    sql &= " FROM TRN_NYUKA"
    sql &= " WHERE TORIKOMI_JOKYO_FLG = " & CInt(STATUS.KEPINZUMI)
    If Not String.IsNullOrWhiteSpace(CmbDateSagyoBi1.SelectedValue) Then
      sql &= " AND NYUKA_YOTEI_DATE = " & CmbDateSagyoBi1.SelectedValue.ToString.Replace("/", "")
    End If

    Return sql

  End Function

  Private Sub CmbDateSagyoBi1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDateSagyoBi1.SelectedIndexChanged
    Dim tmpDt As New DataTable
    SqlServer.GetResult(tmpDt, SqlSelTrnNyuka())

    DgvList1.SetData(tmpDt)

  End Sub

End Class
