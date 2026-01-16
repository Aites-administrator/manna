Imports T.R.ZCommonClass.clsGlobalData
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass
Imports T.R.ZCommonCtrl
Public Class frmAdminMaintenance
  Inherits FormBase
  Private SqlServer As New clsSqlServer
  Private IniFileName As String

  Private Const MAX_NYUKA_TORIKOMI As Integer = 0
  Private Const MAX_SHUKKA_TORIKOMI As Integer = 1

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M01", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M11", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
  End Sub


  Private Sub BtnMainMenuBase8_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase8.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M201", "EXE", IniFileName)))


  End Sub


  Private Sub BtnMainMenuBase9_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase9.Click
    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M202", "EXE", IniFileName)))


  End Sub

  Private Sub BtnMainMenuBase11_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase11.Click

    Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
                              , IO.Path.GetFileName(GetIniString("M203", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase4_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase4.Click
    Dim frm As New FormComMasterMente(New clsCourseMasterDefine())
    frm.ShowDialog()
    'Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
    '                          , IO.Path.GetFileName(GetIniString("M101", "EXE", IniFileName)) & " " & GetIniString("M101", "ARG", IniFileName))

  End Sub

  Private Sub BtnMainMenuBase6_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase6.Click
    Dim frm As New FormComMasterMente(New clsTanaMasterDefine())
    frm.ShowDialog()
    'Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
    '                          , IO.Path.GetFileName(GetIniString("M102", "EXE", IniFileName)) & " " & GetIniString("M102", "ARG", IniFileName))

  End Sub

  Private Sub BtnMainMenuBase5_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase5.Click
    Dim frm As New FormComMasterMente(New clsTantoMasterDefine())
    frm.ShowDialog()
    'Call ComGetProcessByFilePath(Application.StartupPath & "\" & PASSWORD_ENTRY_MODULE & ".exe" _
    '                          , IO.Path.GetFileName(GetIniString("M103", "EXE", IniFileName)) & " " & GetIniString("M103", "ARG", IniFileName))

  End Sub

  Private Sub BtnMainMenuBase7_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase7.Click
    Dim frm As New FormComMasterMente(New clsItemMasterDefine())
    frm.ShowDialog()

  End Sub


  Private Sub frmAdminMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IniFileName = PROJECT_DIR_NAME & "INI\menu.ini"
    Dim path As String = PROJECT_DIR_NAME & IMAGE_FORDER & "AuthMenuBackGroundImage.png"
    SetBackGroundImage(Me, path)


    path = PROJECT_DIR_NAME & IMAGE_FORDER & "DataImportImage.PNG"
    If IO.File.Exists(path) Then

      Panel1.BackColor = ColorTranslator.FromHtml("#dce7f8")
      With Label1
        .Text = "データ取込"
        .ForeColor = Color.Black
        .Font = New Font("Meiryo UI", 18, FontStyle.Bold)
        .BackColor = Color.Transparent
      End With

      With PictureBox1
        .Image = Image.FromFile(path)
        .SizeMode = PictureBoxSizeMode.Zoom
        .BackColor = Color.Transparent
      End With
      With Panel4
        .BackColor = ColorTranslator.FromHtml("#83a0df")

      End With

    End If

    path = PROJECT_DIR_NAME & IMAGE_FORDER & "DataImportImage.PNG"
    If IO.File.Exists(path) Then

      Panel2.BackColor = ColorTranslator.FromHtml("#76b2eb")
      With Label2
        .Text = "マスタメンテナンス"
        .ForeColor = Color.Black
        .Font = New Font("Meiryo UI", 18, FontStyle.Bold)
        .BackColor = Color.Transparent
      End With

      With PictureBox2
        .Image = Image.FromFile(path)
        .SizeMode = PictureBoxSizeMode.Zoom
        .BackColor = Color.Transparent
      End With

      With Panel5
        .BackColor = ColorTranslator.FromHtml("#83a0df")

      End With

    End If

    path = PROJECT_DIR_NAME & IMAGE_FORDER & "DataImportImage.PNG"
    If IO.File.Exists(path) Then
      Panel3.BackColor = ColorTranslator.FromHtml("#7d82f7")
      With Label3
        .Text = "ハンディマスタ送信"
        .ForeColor = Color.Black
        .Font = New Font("Meiryo UI", 18, FontStyle.Bold)
        .BackColor = Color.Transparent
      End With
      With PictureBox3
        .Image = Image.FromFile(path)
        .SizeMode = PictureBoxSizeMode.Zoom
        .BackColor = Color.Transparent
      End With

      With Panel6
        .BackColor = ColorTranslator.FromHtml("#83a0df")

      End With

    End If

    BottonSetting()
    CaptionDateDisp()

  End Sub
  Private Function SqlSelNyukaMaxDate() As String
    Dim sql As String = String.Empty

    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM TRN_NYUKA "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM TRN_SHUKKA "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Dim tmpNyukaDt As New DataTable
    SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

    LblProcDateTime1.Text = tmpNyukaDt.Rows(MAX_NYUKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
    LblProcDateTime2.Text = tmpNyukaDt.Rows(MAX_SHUKKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
    LblProcDateTime3.Text = ""
    LblProcDateTime4.Text = ""
    LblProcDateTime5.Text = ""
    LblProcDateTime6.Text = ""
    LblProcDateTime7.Text = ""
    LblProcDateTime8.Text = ""
    LblProcDateTime9.Text = ""

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "F1:入荷検品" & vbCrLf & "データ取込"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase1.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase1.SetAccessKey = Keys.F1

    BtnMainMenuBase2.Title = "F2:出荷データ" & vbCrLf & "取込"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase2.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase2.SetAccessKey = Keys.F2

    BtnMainMenuBase3.Title = "F3:棚卸データ" & vbCrLf & "取込"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaoroshiImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase3.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase3.SetAccessKey = Keys.F3

    BtnMainMenuBase4.Title = "F4:コース" & vbCrLf & "マスタ"
    BtnMainMenuBase4.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "CourseMasterImage.PNG")
    BtnMainMenuBase4.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase4.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase4.SetAccessKey = Keys.F4

    BtnMainMenuBase5.Title = "F5:担当者" & vbCrLf & "マスタ"
    BtnMainMenuBase5.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TantoMasterImage.PNG")
    BtnMainMenuBase5.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase5.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase5.SetAccessKey = Keys.F5

    BtnMainMenuBase6.Title = "F6:棚番マスタ"
    BtnMainMenuBase6.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaMasterImage.PNG")
    BtnMainMenuBase6.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase6.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase6.SetAccessKey = Keys.F6

    BtnMainMenuBase7.Title = "F7:商品マスタ"
    BtnMainMenuBase7.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ItemMasterImage.PNG")
    BtnMainMenuBase7.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase7.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase7.SetAccessKey = Keys.F7

    BtnMainMenuBase8.Title = "F8:担当者" & vbCrLf & "マスタ送信"
    BtnMainMenuBase8.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TantoMasterSendImage.PNG")
    BtnMainMenuBase8.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase8.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase8.SetAccessKey = Keys.F8

    BtnMainMenuBase9.Title = "F9:商品　" & vbCrLf & "マスタ送信"
    BtnMainMenuBase9.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ItemMasterImage.PNG")
    BtnMainMenuBase9.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase9.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase9.SetAccessKey = Keys.F9

    BtnMainMenuBase10.Title = "F10:棚番" & vbCrLf & "マスタ送信"
    BtnMainMenuBase10.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaMasterSendImage.PNG")
    BtnMainMenuBase10.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase10.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase10.SetAccessKey = Keys.F10
    BtnMainMenuBase10.Visible = False

    BtnMainMenuBase11.Title = "F11:コース" & vbCrLf & "マスタ送信"
    BtnMainMenuBase11.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "CourseSendImage.PNG")
    BtnMainMenuBase11.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase11.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase11.SetAccessKey = Keys.F11
    BtnMainMenuBase11.Visible = False
  End Sub

End Class
