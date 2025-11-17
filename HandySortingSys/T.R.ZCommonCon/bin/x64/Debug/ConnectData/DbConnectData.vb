Public Class DbConnectData

  ''' <summary>
  ''' SQL SERVER接続先
  ''' </summary>

#Region "京都協同管理 本番環境"
  'Public Shared ReadOnly DB_DATASOURCE As String = "192.168.6.250\trasa"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "Aites495344!"
#End Region

#Region "社内京都協同管理テスト環境 スタンドアローン"
  'Public Shared ReadOnly DB_DATASOURCE As String = "localhost\kk"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "Aites495344!"
#End Region

#Region "社内京都協同管理テスト環境2"
  'Public Shared ReadOnly DB_DATASOURCE As String = "211.211.1.134\trasa"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "Aites495344!"
#End Region

#Region "社内モリタ屋テスト環境"
  'Public Shared ReadOnly DB_DATASOURCE As String = "nikserver21\trasa"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "495344"
#End Region

#Region "社内京都協同管理テスト環境2"
  'Public Shared ReadOnly DB_DATASOURCE As String = "211.211.1.152\trasa"
  'Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  'Public Shared ReadOnly DB_USERID As String = "sa"
  'Public Shared ReadOnly DB_PASSWORD As String = "Aites495344!"
#End Region

#Region "展示会用PC環境"
  Public Shared ReadOnly DB_DATASOURCE As String = "localhost\trasa"
  Public Shared ReadOnly DB_DEFAULTDATABASE As String = "TRASA"
  Public Shared ReadOnly DB_USERID As String = "sa"
  Public Shared ReadOnly DB_PASSWORD As String = "Aites495344!"
#End Region


  ''' <summary>
  ''' PCA API接続先
  ''' </summary>
  'Public Shared ReadOnly PCAAPI_USERID As String = "9999"
  'Public Shared ReadOnly PCAAPI_PASSWORD As String = "9999"
  'Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0002"
  'Public Shared ReadOnly PCAAPI_PG_NAME As String = "API操作共通プログラム"
  'Public Shared ReadOnly PCAAPI_PG_ID As String = "ComApiMn"
  'Public Shared ReadOnly PCA_API_VERSION As String = 800
  'Public Shared ReadOnly PCAAPI_USERID As String = "aites"
  'Public Shared ReadOnly PCAAPI_PASSWORD As String = "495344"
  'Public Shared ReadOnly PCAAPI_DATAAREANAME As String = "P20V01C001KON0002"
  'Public Shared ReadOnly PCAAPI_PG_NAME As String = "API操作共通プログラム"
  'Public Shared ReadOnly PCAAPI_PG_ID As String = "ComApiMn"
  'Public Shared ReadOnly PCA_API_VERSION As String = 800


End Class
