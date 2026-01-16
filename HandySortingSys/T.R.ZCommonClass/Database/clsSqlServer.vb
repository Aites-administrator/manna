Imports T.R.ZCommonCon.DbConnectData
Imports System.Data.SqlClient

Public Class clsSqlServer
  Inherits clsComDatabase

  Public Sub New()
    Me.DataSource = DB_DATASOURCE
    Me.DefaultDatabase = DB_DEFAULTDATABASE
    Me.UserId = DB_USERID
    Me.Password = DB_PASSWORD
    Me.Provider = typProvider.sqlServer
  End Sub

  Public Function CreateSqlConnection() As SqlConnection
    Dim conStr As String =
        "Server=" & DB_DATASOURCE & ";" &
        "Database=" & DB_DEFAULTDATABASE & ";" &
        "User ID=" & DB_USERID & ";" &
        "Password=" & DB_PASSWORD & ";"

    Return New SqlConnection(conStr)
  End Function
End Class
