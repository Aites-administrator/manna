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
  Private Const MAX_TANAOROSHI_TORIKOMI As Integer = 2
  Private Const MAX_COURSE_UPDATE As Integer = 3
  Private Const MAX_TANTO_UPDATE As Integer = 4
  Private Const MAX_TANA_UPDATE As Integer = 5
  Private Const MAX_ITEM_TORIKOMI As Integer = 6
  Private Const MAX_TANTO_SEND As Integer = 7
  Private Const MAX_ITEM_SEND As Integer = 8

  Protected Overrides Sub OnLoad(e As EventArgs)
    Me.KeyPreview = True
    MyBase.OnLoad(e)

  End Sub

  Private Sub frmAdminMaintenance_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    CaptionDateDisp()
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
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM TRN_TANAOROSHI "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(UPDATE_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_COURSE "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(UPDATE_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_TANTO "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(UPDATE_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_TANA "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(ENTRY_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_ITEM "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(SEND_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_TANTO "
    sql &= " UNION ALL "
    sql &= " SELECT  MAX(SEND_DATE) AS MAX_TORIKOMI "
    sql &= " FROM MST_ITEM "

    Return sql

  End Function


  Public Sub CaptionDateDisp()
    Try
      Dim tmpNyukaDt As New DataTable
      SqlServer.GetResult(tmpNyukaDt, SqlSelNyukaMaxDate)

      LblProcDateTime1.Text = tmpNyukaDt.Rows(MAX_NYUKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime2.Text = tmpNyukaDt.Rows(MAX_SHUKKA_TORIKOMI).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime3.Text = tmpNyukaDt.Rows(MAX_TANAOROSHI_TORIKOMI).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime4.Text = tmpNyukaDt.Rows(MAX_COURSE_UPDATE).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime5.Text = tmpNyukaDt.Rows(MAX_TANTO_UPDATE).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime6.Text = tmpNyukaDt.Rows(MAX_TANA_UPDATE).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime7.Text = tmpNyukaDt.Rows(MAX_ITEM_TORIKOMI).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime8.Text = tmpNyukaDt.Rows(MAX_TANTO_SEND).Item("MAX_TORIKOMI").ToString()
      LblProcDateTime9.Text = tmpNyukaDt.Rows(MAX_ITEM_SEND).Item("MAX_TORIKOMI").ToString()

    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try

  End Sub

  Public Sub BottonSetting()
    BtnMainMenuBase1.Title = "入荷検品" & vbCrLf & "ﾃﾞｰﾀ取込(F1)"
    BtnMainMenuBase1.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "NyukaImage.png")
    BtnMainMenuBase1.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase1.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase1.SetAccessKey = Keys.F1

    BtnMainMenuBase2.Title = "出荷ﾃﾞｰﾀ取込" & vbCrLf & "(F2)"
    BtnMainMenuBase2.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "SodashiImage.png")
    BtnMainMenuBase2.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase2.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase2.SetAccessKey = Keys.F2

    BtnMainMenuBase3.Title = "棚卸ﾃﾞｰﾀ取込" & vbCrLf & "(F3)"
    BtnMainMenuBase3.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaoroshiImage.png")
    BtnMainMenuBase3.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase3.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase3.SetAccessKey = Keys.F3

    BtnMainMenuBase4.Title = "ｺｰｽﾏｽﾀ(F4)"
    BtnMainMenuBase4.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "CourseMasterImage.PNG")
    BtnMainMenuBase4.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase4.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase4.SetAccessKey = Keys.F4

    BtnMainMenuBase5.Title = "担当者ﾏｽﾀ(F5)"
    BtnMainMenuBase5.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TantoMasterImage.PNG")
    BtnMainMenuBase5.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase5.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase5.SetAccessKey = Keys.F5

    BtnMainMenuBase6.Title = "棚番ﾏｽﾀ(F6)"
    BtnMainMenuBase6.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaMasterImage.PNG")
    BtnMainMenuBase6.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase6.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase6.SetAccessKey = Keys.F6

    BtnMainMenuBase7.Title = "商品ﾏｽﾀ(F7)"
    BtnMainMenuBase7.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ItemMasterImage.PNG")
    BtnMainMenuBase7.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase7.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase7.SetAccessKey = Keys.F7

    BtnMainMenuBase8.Title = "　ﾊﾟｿｺﾝ⇒ﾊﾝﾃﾞｨ" & vbCrLf & "担当者ﾏｽﾀ(F8)"
    BtnMainMenuBase8.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TantoMasterSendImage.PNG")
    BtnMainMenuBase8.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase8.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase8.SetAccessKey = Keys.F8

    BtnMainMenuBase9.Title = "　ﾊﾟｿｺﾝ⇒ﾊﾝﾃﾞｨ" & vbCrLf & "商品ﾏｽﾀ(F9)"
    BtnMainMenuBase9.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "ItemMasterImage.PNG")
    BtnMainMenuBase9.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase9.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase9.SetAccessKey = Keys.F9

    BtnMainMenuBase10.Title = "棚番" & vbCrLf & "マスタ送信(F10)"
    BtnMainMenuBase10.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "TanaMasterSendImage.PNG")
    BtnMainMenuBase10.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase10.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase10.SetAccessKey = Keys.F10
    BtnMainMenuBase10.Visible = False

    BtnMainMenuBase11.Title = "ｺｰｽﾏｽﾀ" & vbCrLf & "送信(F11)"
    BtnMainMenuBase11.Icon = Image.FromFile(PROJECT_DIR_NAME & IMAGE_FORDER & "CourseSendImage.PNG")
    BtnMainMenuBase11.ButtonColor = ColorTranslator.FromHtml("#ffffff")
    BtnMainMenuBase11.BtnForeColor = ColorTranslator.FromHtml("#000000")
    BtnMainMenuBase11.SetAccessKey = Keys.F11
    BtnMainMenuBase11.Visible = False

    Me.Select()

  End Sub

  Private Sub BtnMenuBase1_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase1.Click

    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M01", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase2_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase2.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M11", "EXE", IniFileName)))

  End Sub

  Private Sub BtnMainMenuBase3_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase3.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M41", "EXE", IniFileName)))

  End Sub


  Private Sub BtnMainMenuBase8_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase8.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M201", "EXE", IniFileName),, True))


  End Sub


  Private Sub BtnMainMenuBase9_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase9.Click
    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M202", "EXE", IniFileName), , True))


  End Sub

  Private Sub BtnMainMenuBase11_Click(sender As Object, e As EventArgs) Handles BtnMainMenuBase11.Click

    AttachActivateOnExit(Me, ComGetProcessByFilePath(GetIniString("M203", "EXE", IniFileName)))

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

End Class
