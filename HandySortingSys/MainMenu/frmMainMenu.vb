Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl

Public Class frmMainMenu
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String
  Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "MainMenuBackGroundImage.png"
    SetBackGroundImage(Me, path)

    '    If IO.File.Exists(path) Then
    '  Me.BackgroundImage = Image.FromFile(path)
    '  Me.BackgroundImageLayout = ImageLayout.Stretch
    'End If

    path = PROJECT_DIR_NAME & IMAGE_FORDER & "information.png"
    If IO.File.Exists(path) Then

      PanelBase1.BackColor = ColorTranslator.FromHtml("#212480")
      With Label18
        .Text = "Information"
        .ForeColor = Color.White
        .Font = New Font("Meiryo UI", 24, FontStyle.Bold)
        .BackColor = Color.Transparent
      End With

      With PictureBox1
        .Image = Image.FromFile(path)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        .BackColor = Color.Transparent
      End With
    End If

    'ボタン設定
    BottonSetting()

    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"
    CaptionDateDisp()
  End Sub

  Private Sub frmMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
  End Sub



  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(NYUKA_YOTEI_DATE) AS NYUKA_YOTEI_DATE "
    sql &= "      ,  CASE WHEN COUNT(SEND_DATE) < COUNT(*) "
    sql &= "         THEN NULL"
    sql &= "         ELSE MIN(SEND_DATE)"
    sql &= "         END AS SEND_DATE"
    sql &= "      ,  CASE WHEN COUNT(RECEIVE_DATE) < COUNT(*) "
    sql &= "         THEN NULL"
    sql &= "         ELSE MIN(RECEIVE_DATE)"
    sql &= "         END AS RECEIVE_DATE"

    'sql &= "      ,  MIN(SEND_DATE) SEND_DATE "
    'sql &= "      ,  MIN(RECEIVE_DATE) RECEIVE_DATE "
    sql &= " FROM TRN_NYUKA "
    sql &= " WHERE NYUKA_YOTEI_DATE = ("
    sql &= "       SELECT	MAX(NYUKA_YOTEI_DATE)"
    sql &= "       FROM	TRN_NYUKA"
    sql &= " )"

    Return sql


  End Function
  Private Function SqlSelSoudashiMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(NOUHINBI) AS NOUHINBI "
    sql &= "      ,  CASE WHEN COUNT(SOUDASHI_SEND_DATE) < COUNT(*) "
    sql &= "         THEN NULL"
    sql &= "         ELSE MIN(SOUDASHI_SEND_DATE)"
    sql &= "         END AS SOUDASHI_SEND_DATE"
    sql &= "      ,  CASE WHEN COUNT(SOUDASHI_RECEIVE_DATE) < COUNT(*) "
    sql &= "         THEN NULL"
    sql &= "         ELSE MIN(SOUDASHI_RECEIVE_DATE)"
    sql &= "         END AS SOUDASHI_RECEIVE_DATE"
    'sql &= "      ,  MIN(SOUDASHI_SEND_DATE) SOUDASHI_SEND_DATE"
    'sql &= "      ,  MIN(SOUDASHI_RECEIVE_DATE) SOUDASHI_RECEIVE_DATE "
    sql &= " FROM TRN_SHUKKA "
    sql &= " WHERE NOUHINBI = ("
    sql &= "       SELECT	MAX(NOUHINBI)"
    sql &= "       FROM	TRN_SHUKKA "
    sql &= " )"

    Return sql

  End Function

  Private Function SqlSelTanemakiMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(NOUHINBI) AS NOUHINBI "
    sql &= "      ,  CASE WHEN COUNT(TANEMAKI_SEND_DATE) < COUNT(*) "
    sql &= "         THEN NULL"
    sql &= "         ELSE MIN(TANEMAKI_SEND_DATE)"
    sql &= "         END AS TANEMAKI_SEND_DATE"
    sql &= "      ,  CASE WHEN SUM( "
    sql &= "                  CASE WHEN TANEMAKI_RECEIVE_DATE IS NULL "
    sql &= "                        AND KENPIN_RECEIVE_DATE IS NULL "
    sql &= "                  THEN 1 "
    sql &= "                  ELSE 0 "
    sql &= "                  END) > 0 "
    sql &= "        THEN NULL "
    sql &= "        ELSE 1 "
    sql &= "        END AS TANEMAKI_RECEIVE_DATE "
    'sql &= "      ,  CASE WHEN COUNT(KENPIN_RECEIVE_DATE) < COUNT(*) "
    'sql &= "         THEN NULL"
    'sql &= "         ELSE MIN(KENPIN_RECEIVE_DATE)"
    'sql &= "         END AS KENPIN_RECEIVE_DATE"
    'sql &= "      ,  MIN(TANEMAKI_SEND_DATE) TANEMAKI_SEND_DATE "
    'sql &= "      ,  MIN(TANEMAKI_RECEIVE_DATE) TANEMAKI_RECEIVE_DATE "
    'sql &= "      ,  MIN(KENPIN_RECEIVE_DATE) KENPIN_RECEIVE_DATE "
    sql &= " FROM TRN_SHUKKA "
    sql &= " WHERE NOUHINBI = ("
    sql &= "       SELECT	MAX(NOUHINBI)"
    sql &= "       FROM	TRN_SHUKKA "
    sql &= " )"

    Return sql

  End Function

  Private Function SqlSelTanaoroshiMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(TANAOROSHI_DATE) AS TANAOROSHI_DATE "
    sql &= "      ,  MIN(RECEVE_DATE) TORIKOMI_JOKYO_FLG "
    sql &= " FROM TRN_TANAOROSHI "
    sql &= " WHERE NOUHINBI = ("
    sql &= "       SELECT	MAX(TANAOROSHI_DATE)"
    sql &= "       FROM	TRN_TANAOROSHI "
    sql &= " )"

    Return sql

  End Function

  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)
    Dim tmpSouDashiDt As New DataTable
    SqlServer.GetResult(tmpSouDashiDt, SqlSelSoudashiMaxDate)
    Dim tmpTanemakiDt As New DataTable
    SqlServer.GetResult(tmpTanemakiDt, SqlSelTanemakiMaxDate)


    LblNyukaSend.Text = If(String.IsNullOrWhiteSpace(tmpNyukaDt.Rows(0)("NYUKA_YOTEI_DATE").ToString), "", tmpNyukaDt.Rows(0)("NYUKA_YOTEI_DATE").ToString)
    LblNyukaReceive.Text = If(String.IsNullOrWhiteSpace(tmpNyukaDt.Rows(0)("NYUKA_YOTEI_DATE").ToString), "", tmpNyukaDt.Rows(0)("NYUKA_YOTEI_DATE").ToString)
    LblSoudashiSend.Text = If(String.IsNullOrWhiteSpace(tmpSouDashiDt.Rows(0)("NOUHINBI").ToString), "", tmpSouDashiDt.Rows(0)("NOUHINBI").ToString)
    LblSoudashiReceive.Text = If(String.IsNullOrWhiteSpace(tmpSouDashiDt.Rows(0)("NOUHINBI").ToString), "", tmpSouDashiDt.Rows(0)("NOUHINBI").ToString)
    LblTanemakiSend.Text = If(String.IsNullOrWhiteSpace(tmpTanemakiDt.Rows(0)("NOUHINBI").ToString), "", tmpTanemakiDt.Rows(0)("NOUHINBI").ToString)
    LblTanemakiReceive.Text = If(String.IsNullOrWhiteSpace(tmpTanemakiDt.Rows(0)("NOUHINBI").ToString), "", tmpTanemakiDt.Rows(0)("NOUHINBI").ToString)

    '入荷送信ステータス更新
    InformationSetting(NyukaSendStatus, tmpNyukaDt.Rows(0)("SEND_DATE").ToString, LblNyukaSend.Text)
    '入荷受信ステータス更新
    InformationSetting(NyukaReceiveStatus, tmpNyukaDt.Rows(0)("RECEIVE_DATE").ToString, LblNyukaReceive.Text)
    '総出し送信ステータス更新
    InformationSetting(SoudashiSendStatus, tmpSouDashiDt.Rows(0)("SOUDASHI_SEND_DATE").ToString, LblSoudashiSend.Text)
    '総出し受信ステータス更新
    InformationSetting(SoudashiReceiveStatus, tmpSouDashiDt.Rows(0)("SOUDASHI_RECEIVE_DATE").ToString, LblSoudashiReceive.Text)
    '種まき送信ステータス更新
    InformationSetting(TanemakiSendStatus, tmpTanemakiDt.Rows(0)("TANEMAKI_SEND_DATE").ToString, LblTanemakiSend.Text)
    '総出し受信ステータス更新
    InformationSetting(TanemakiReceiveStatus, tmpTanemakiDt.Rows(0)("TANEMAKI_RECEIVE_DATE").ToString, LblTanemakiReceive.Text)




    'With NyukaSendStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(NYUKA_STATUS.SOUSINZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  ElseIf IsDBNull(tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString) Then
    '    .Text = ""
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If

    'End With


    'With NyukaReceiveStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(NYUKA_STATUS.KEPINZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If
    'End With

    'With SoudashiSendStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(SHUKKA_STATUS.SOUDASHI_SOUSINZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If
    'End With

    'With SoudashiReceiveStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(SHUKKA_STATUS.SOUDASHI_ZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If
    'End With


    'With TanemakiSendStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(SHUKKA_STATUS.TANEMAKI_SOUSINZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If
    'End With

    'With TanemakiReceiveStatus
    '  If tmpNyukaDt.Rows(0)("TORIKOMI_JOKYO_FLG").ToString < CInt(SHUKKA_STATUS.TANEMAKI_ZUMI) Then
    '    .Text = "未"
    '    .BackColor = Color.Red
    '    .ForeColor = Color.White
    '  Else
    '    .Text = "済"
    '    .BackColor = Color.White
    '    .ForeColor = Color.Black
    '  End If
    'End With

  End Sub

  Private Sub InformationSetting(prmLabel As Label, prmTorikomiJokyoDate As String, prmNohinbi As String, Optional prmKenpinDate As String = "")
    With prmLabel
      If String.IsNullOrWhiteSpace(prmNohinbi) Then
        .Text = ""
        .BackColor = Color.White
        .ForeColor = Color.Black
      ElseIf Not String.IsNullOrWhiteSpace(prmKenpinDate) Then
        .Text = "済"
        .BackColor = Color.White
        .ForeColor = Color.Black
      ElseIf String.IsNullOrWhiteSpace(prmTorikomiJokyoDate) Then
        .Text = "未"
        .BackColor = Color.Red
        .ForeColor = Color.White

      Else
        .Text = "済"
        .BackColor = Color.White
        .ForeColor = Color.Black
      End If
    End With

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "入荷処理(F1)"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#dce7f8")
    BtnMainMenuBase1.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase1.SetAccessKey = Keys.F1

    BtnMainMenuBase2.Title = "総出し(F2)"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#83a0df")
    BtnMainMenuBase2.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase2.SetAccessKey = Keys.F2

    BtnMainMenuBase3.Title = "種まき(F3)"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanemakiImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#335294")
    BtnMainMenuBase3.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase3.SetAccessKey = Keys.F3

    BtnMainMenuBase4.Title = "出荷検品(F4)"
    BtnMainMenuBase4.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ShukkaCheckImage.png")
    BtnMainMenuBase4.ButtonColor = ColorTranslator.FromHtml("#5ddee6")
    BtnMainMenuBase4.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase4.SetAccessKey = Keys.F4

    BtnMainMenuBase5.Title = "棚卸処理(F5)"
    BtnMainMenuBase5.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaoroshiImage.png")
    BtnMainMenuBase5.ButtonColor = ColorTranslator.FromHtml("#3156f1")
    BtnMainMenuBase5.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase5.SetAccessKey = Keys.F5

    BtnMainMenuBase6.Title = "その他処理(F6)"
    BtnMainMenuBase6.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SettingImage.png")
    BtnMainMenuBase6.ButtonColor = ColorTranslator.FromHtml("#7d82f7")
    BtnMainMenuBase6.BtnForeColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase6.SetAccessKey = Keys.F6
  End Sub

  Private Sub BtnMainMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M00", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M10", "EXE", IniFileName)))
  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M20", "EXE", IniFileName)))
  End Sub

  Private Sub BtnMainMenuBase4_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase4.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M30", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase6_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase6.Click
    Call AttachActivateOnExit(Me, ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M50", "EXE", IniFileName))))


  End Sub

  Private Sub BtnMainMenuBase5_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase5.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M40", "EXE", IniFileName)))
  End Sub

End Class