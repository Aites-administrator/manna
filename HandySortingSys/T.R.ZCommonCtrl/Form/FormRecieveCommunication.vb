Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc

Public Class FormRecieveCommunication
  Inherits FormCommunication


#Region "イベントプロシージャー"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextName = "受信"
    Me.TextHandyName = "10.データ送信"
    Me.TextButtonName = "受信（F6）"
    Me.TextMessage = "受信が完了しました。"

    MyBase.OnLoad(e)
  End Sub



#End Region



End Class
