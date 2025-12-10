Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports ClsHandyCommunication

Public Class BtnSendHandy
  Inherits BtnBase

#Region "プライベート"
  Private SqlServer As New clsSqlServer
#End Region

#Region "パブリック"
  ' プロパティ：ファイル名
  Public Property TargetFileName As String
#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 送信ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("送信を行います。")

    Me.AccessKey = Keys.F5
    Me.BtnText = "F5:送信"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
  End Sub


#End Region


#Region "イベントプロシージャー"
  Protected Overrides Sub OnClick(e As EventArgs)
    MyBase.OnClick(e)
    Dim Handy As New ClsHandyCommunication.clsHandyCommunication(TargetFileName)

    Try
      '通信ツール開示
      Handy.OpenCommunicationTool()


      '状態管理ファイル作成チェック
      If Handy.CreateChkStatusFlagFile() Then
        Console.WriteLine("ファイル作成OK")
      End If
      '状態管理ファイルチェック
      If Handy.ChkStatusFlagFile() Then
        Console.WriteLine("状態管理OK")
      End If
      Handy.CloseCommunicationTool()

      ComMessageBox("送信が完了しました。", "確認", typMsgBox.MSG_NORMAL)
    Catch ex As Exception
      ComWriteErrLog(ex, False)
      Handy.CloseCommunicationTool()
    Finally
    End Try
  End Sub

#End Region



  'なかったので仮に作成したので頂ければ削除！
  Private Function ComCreateInsertItem(prmKeyValuez As Dictionary(Of String, String)) As Dictionary(Of String, String)
    Dim result As New Dictionary(Of String, String)

    ' 列名をカンマ区切りで連結
    Dim keys As String = String.Join(",", prmKeyValuez.Keys)

    ' 値をカンマ区切りで連結（シングルクォートで囲む）
    Dim values As String = String.Join(",", prmKeyValuez.Values.Select(Function(v) $"'{v}'"))

    result("Keyz") = keys
    result("Valuez") = values

    Return result
  End Function

End Class