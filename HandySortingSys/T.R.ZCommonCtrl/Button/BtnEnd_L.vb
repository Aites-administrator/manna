Imports System.Drawing.Drawing2D

Public Class BtnEnd_L
  Inherits BtnBase


#Region "コンストラクタ"

  ''' <summary>
  ''' 終了ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("終了します。")

    Me.AccessKey = Keys.Escape
    Me.BtnText = "終了"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()

    'Me.Size = New Size(320, 60)
    Me.BackColor = ColorTranslator.FromHtml("#f4bcbc")
    Me.ForeColor = ColorTranslator.FromHtml("#000000")
    Me.FlatStyle = FlatStyle.Flat

    Me.FlatAppearance.BorderSize = 0

    MakeRoundedButton(Me, 20)
  End Sub

#End Region

#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)

    ' 親フォームを取得して閉じる
    Dim parentForm As Form = Me.FindForm()
    If parentForm IsNot Nothing Then
      parentForm.Close()
    End If

  End Sub


#End Region
  'Private Sub MakeRoundedButton(btn As Button, radius As Integer)
  '  Dim path As New GraphicsPath()
  '  path.AddArc(0, 0, radius, radius, 180, 90)
  '  path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
  '  path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
  '  path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
  '  path.CloseAllFigures()
  '  btn.Region = New Region(path)
  'End Sub


End Class
