Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonClass.clsGlobalData
Public Class BtnOk
  Inherits BtnBase

  Public Property PrgTitle As String
  Public Property txtPassword As String
  Public Property TargetFileName As String = String.Empty
  Private EntryCount As Integer = 0
  Private Const RETRY_MAX As Integer = 5
#Region "コンストラクタ"

  ''' <summary>
  ''' 複写ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("OK")
    Me.AccessKey = Keys.F2
    Me.BtnText = "OK"
    MyBase.InitLayout()
  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(147, 55)
    Me.Font = New Font("Meiryo", 18, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0

  End Sub


#End Region

#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)
    'Dim parentForm As Form = Me.FindForm()
    'If parentForm Is Nothing Then
    '  Exit Sub
    'End If
    'If RETRY_MAX < EntryCount Then
    '  ComMessageBox("試行回数を越えました。プログラムを終了します。", PrgTitle, typMsgBox.MSG_ERROR)
    '  ' 親フォームを取得して閉じる

    '  If parentForm IsNot Nothing Then
    '    parentForm.Close()
    '  End If

    'Else
    '  If ReadSettingIniFile("PASS", "VALUE") = txtPassword Then
    '    Call ComGetProcessByFilePath(My.Application.Info.DirectoryPath & "\" & TargetFileName)
    '  Else
    '    EntryCount += 1
    '  End If
    'End If

  End Sub

#End Region
End Class
