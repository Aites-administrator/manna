Imports T.R.ZCommonCon.DbConnectData

Public Class clsSqlServer
  Inherits clsComDatabase

  Public Sub New()
    Me.DataSource = DB_DATASOURCE
    Me.DefaultDatabase = DB_DEFAULTDATABASE
    Me.UserId = DB_USERID
    Me.Password = DB_PASSWORD
    Me.Provider = typProvider.sqlServer
  End Sub
End Class
