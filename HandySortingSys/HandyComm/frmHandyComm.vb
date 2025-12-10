Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl
Imports ClsHandyCommunication
Public Class frmHandyComm
  Inherits FormBase
  'Dim Handy As New ClsHandyCommunication.clsHandyCommunication("COM5", 115200)


  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Try


      'Handy.ReceiveToFile("D:\manna\LOG\test1.csv")

      MessageBox.Show("完了")
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally

    End Try

  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Try
      ''通信ツール開示
      'Handy.OpenCommunicationTool()

      'Handy.SendFile("D:\manna\SEND\IN_NYUKA.DAT")

      ComMessageBox("送信が完了しました。", "確認", typMsgBox.MSG_NORMAL)

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'Handy.CloseCommunicationTool()


    End Try

  End Sub
End Class
