
Public Class Form1
  Shared Sub Main()
    Application.Run(New Form1)
  End Sub

  Public Function GetParentProcessID() As Integer
    Dim tmpMyProcId As Integer = System.Diagnostics.Process.GetCurrentProcess().Id
    Dim tmpQuery As String
    Dim tmpObjectSearcher As System.Management.ManagementObjectSearcher
    Dim tmpObjectEnumlator As System.Management.ManagementObjectCollection.ManagementObjectEnumerator
    Dim tmpBaseObject As System.Management.ManagementBaseObject

    tmpQuery = String.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", tmpMyProcId)
    tmpObjectSearcher = New System.Management.ManagementObjectSearcher("root\CIMV2", tmpQuery)

    'クエリから結果を取得
    tmpObjectEnumlator = tmpObjectSearcher.Get().GetEnumerator()


    If (False = tmpObjectEnumlator.MoveNext()) Then Throw New ApplicationException("Couldn't Get ParrentProcessId.")
    tmpBaseObject = tmpObjectEnumlator.Current

    '親プロセスのPIDを取得
    Return tmpBaseObject.Item("ParentProcessId")
  End Function
End Class
