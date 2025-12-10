Imports T.R.ZCommonCtrl
Public Class frmNyukaReceiveCommunication
  Inherits FormCommunication

  Private Const RECEIVE_FOLDER As String = "D:\manna\RECEIVE\"
  Private Const RECEIVE_NYUKA_FILE_NAME As String = "D:\manna\SEND\IN_ITEM.TXT"

  Private Sub BtnRecieveHandy1_Click(sender As Object, e As EventArgs) Handles BtnRecieveHandy1.Click
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(RECEIVE_NYUKA_FILE_NAME)
    Try
      Handy.CreateCommnicationFile(RECEIVE_NYUKA_FILE_NAME, RECEIVE_FOLDER)
      Handy.DeleteCommnicationFile()

      BtnRecieveHandy1.Handy = Handy
      BtnRecieveHandy1.TargetFileName = RECEIVE_NYUKA_FILE_NAME

    Catch ex As Exception

    End Try

  End Sub
End Class
