Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbDateSagyoBi
  Inherits CmbDateBase

  Private Const CODE_FORMAT As String = "yyyy/MM/dd"

#Region "コンストラクタ"

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  Public Sub New()
    ' 選択項目抽出SQL文設定
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    ' 初期化
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("出荷日付を選択してください。")

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"
  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    ' データベースより現在日付を文字列で取得し、DateTime値に変換する
    Dim dt As DateTime = DateTime.Parse(ComGetProcDate())

    sql &= " SELECT  CONVERT(varchar(10), CONVERT(date, NYUKA_YOTEI_DATE, 112), 111)  AS ItemCode  "
    sql &= " FROM TRN_NYUKA "
    sql &= " WHERE (TORIKOMI_JOKYO_FLG NOT IN (" & CInt(NYUKA_STATUS.SHUTSURYOKUZUMI) & ")"
    sql &= " OR RECEIVE_DATE IS NULL) "
    sql &= " GROUP BY CONVERT(varchar(10), CONVERT(date, NYUKA_YOTEI_DATE, 112), 111)  "
    sql &= " ORDER BY CONVERT(varchar(10), CONVERT(date, NYUKA_YOTEI_DATE, 112), 111)  DESC"

    Console.WriteLine(sql)

    Return sql
  End Function
#End Region

#End Region

End Class
