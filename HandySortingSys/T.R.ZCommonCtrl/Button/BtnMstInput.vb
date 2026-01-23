Imports System.Data
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class BtnMstInput
  Inherits BtnBase

#Region "プライベート"

#End Region

#Region "パブリック"
#End Region

#Region "コンストラクタ"
  ''' <summary>
  ''' 取込ボタンボタン
  ''' </summary>
  Public Sub New()

    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("取込を行います。")

    Me.AccessKey = Keys.F1
    Me.BtnText = "取込"
    MyBase.InitLayout()

  End Sub

  Protected Overrides Sub InitLayout()
    Me.Size = New Size(320, 60)
    Me.FlatStyle = FlatStyle.Standard
    Me.BackColor = SystemColors.ActiveCaption
    Me.ForeColor = Color.Black
    Me.Font = New Font("Meiryo", 24, FontStyle.Bold)
    Me.FlatStyle = FlatStyle.Flat
    Me.FlatAppearance.BorderSize = 0


    MakeRoundedButton(Me, 20)
  End Sub


#End Region


#Region "イベントプロシージャー"


#End Region


End Class