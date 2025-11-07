Imports T.R.ZCommonCon.DbConnectData
Imports T.R.ZCommonClass.clsCommonFnc

Public Class clsSqlServer
  Inherits clsComDatabase

  Public Sub New()
    Me.DataSource = DB_DATASOURCE
    Me.DefaultDatabase = DB_DEFAULTDATABASE
    Me.UserId = DB_USERID
    Me.Password = DB_PASSWORD
    Me.Provider = typProvider.sqlServer
  End Sub

  ''' <summary>
  ''' 接続情報取得
  ''' </summary>
  ''' <param name="prmMachineName">コンピュータ名</param>
  ''' <param name="prmServiceName">サービス名</param>
  ''' <returns>接続情報</returns>
  Public Function GetDbConect(prmMachineName As String, prmServiceName As String) As DataTable
    Dim tmpDt As New DataTable
    Dim sql As String = String.Empty

    sql = ""
    sql += "SELECT  MACHINE_NAME "
    sql += "    ,   SERVICE_NAME "
    sql += "    ,   ID "
    sql += "    ,   PASSWORD "
    sql += "    ,   OPTION1 "
    sql += "    ,   OPTION2 "
    sql += "    ,   OPTION3 "
    sql += "FROM DB_CONECT_TBL "
    sql += "WHERE MACHINE_NAME = '" & prmMachineName & "'"
    sql += "AND SERVICE_NAME = '" & prmServiceName & "'"

    Try
      GetResult(tmpDt, sql)

    Catch ex As Exception
      ComWriteErrLog(ex.Message)
    End Try

    Return tmpDt
  End Function

End Class
