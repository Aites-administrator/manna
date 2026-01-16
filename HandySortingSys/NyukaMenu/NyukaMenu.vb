Imports T.R.ZCommonCtrl
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Public Class NyukaMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String


    Private Sub NyukaMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaMenuBackGroundImage.png"
        SetBackGroundImage(Me, path)

        IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"

        CaptionDateDisp()
        'ボタン設定
        BottonSetting()

  End Sub

    Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_NYUKA_TORIKOMI "
    sql &= "      ,  MAX(SEND_DATE) AS MAX_NYUKA_SEND "
    sql &= "      ,  MAX(RECEIVE_DATE) AS MAX_NYUKA_RECEIVE "
    sql &= "      ,  MAX(OUTPUT_DATE) AS MAX_NYUKA_OUTPUT "
    sql &= " FROM TRN_NYUKA "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_SEND").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_RECEIVE").ToString()
    LblProcDateTime3.Text = tmpNyukaDt.Rows(0).Item("MAX_NYUKA_OUTPUT").ToString()

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "　ﾊﾝﾃﾞｨ入荷" & vbCrLf & "送信"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaSendImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#add8e6")
    BtnMainMenuBase1.Font = New Font("Meiryo", 20, FontStyle.Bold)

    BtnMainMenuBase2.Title = "　ﾊﾝﾃﾞｨ入荷" & vbCrLf & "受信"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaReceiveImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#04cfe3")
    BtnMainMenuBase2.Font = New Font("Meiryo", 20, FontStyle.Bold)


    BtnMainMenuBase3.Title = "　入荷検品書"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaOutputImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#0494e3")
    BtnMainMenuBase3.Font = New Font("Meiryo", 20, FontStyle.Bold)


  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    ComGetProcessByFilePath(GetIniString("M02", "EXE", IniFileName))
  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    ComGetProcessByFilePath(GetIniString("M03", "EXE", IniFileName))

  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
    ComGetProcessByFilePath(GetIniString("M04", "EXE", IniFileName))
  End Sub

    Private Sub LblProcDateTime1_Click(sender As Object, e As EventArgs) Handles LblProcDateTime1.Click

    End Sub
End Class
