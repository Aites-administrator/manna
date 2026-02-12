Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc

Public Class FormSendCommunication
  Inherits FormCommunication


#Region "イベントプロシージャー"

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.TextName = "送信"
    Me.TextHandyName = "1.データ受信"
    Me.TextButtonName = "送信（F5）"
    Me.TextMessage = "送信が完了しました。"

    MyBase.OnLoad(e)
  End Sub


#End Region



End Class
