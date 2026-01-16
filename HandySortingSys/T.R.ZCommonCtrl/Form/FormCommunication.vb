Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc

Public Class FormCommunication
  Inherits FormBase


#Region "イベントプロシージャー"

  Public Sub RegisterSendButton(btn As BtnSendHandy)
    AddHandler btn.SendCompleted, AddressOf OnSendCompleted
  End Sub

  Public Sub RegisterReceiveButton(btn As BtnRecieveHandy)
    AddHandler btn.ReceiveCompleted, AddressOf OnReceiveompleted
  End Sub

  Protected Overridable Sub OnSendCompleted()

  End Sub

  Protected Overridable Sub OnReceiveompleted()

  End Sub

  Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Me.BackColor = Color.Aqua
  End Sub



#End Region

End Class
