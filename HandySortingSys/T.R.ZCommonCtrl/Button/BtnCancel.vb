Public Class BtnCancel
  Inherits BtnBase

#Region "コンストラクタ"

  ''' <summary>
  ''' 複写ボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("キャンセルします。")
    Me.AccessKey = Keys.F1
    Me.BtnText = "キャンセル"
    MyBase.InitLayout()
  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(216, 55)
    Me.Font = New Font("Meiryo", 18, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0

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

End Class
