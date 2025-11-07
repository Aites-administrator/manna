Imports T.R.ZCommonClass.clsCommonFnc

Public Class CmbMstTekiyou
  Inherits CmbMstBase

  Private Const CODE_FORMAT As String = "000000"

#Region "コンストラクタ"

  Public Sub New()

    MyBase.New(CODE_FORMAT)
    lcCallBackCreateSql = AddressOf SqlSelListSrc
    InitCmb()
    ' フォーカス時、表示メッセージ設定
    MyBase.SetMsgLabelText("摘要を選択してください。")

    MyBase.DropDownWidth = 360

    CodeInput = False

  End Sub

#End Region

#Region "メソッド"

#Region "パブリック"

  ''' <summary>
  ''' 入力文字50バイト制限
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbBoxValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

    Me.Text = ShrinkText(Me.Text, 50)

  End Sub

  ''' <summary>
  ''' アクティブ時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CmbMstTekiyou_OnEnter(sender As Object, e As EventArgs) Handles Me.Enter
    ' IMEモードを全角入力に
    Me.ImeMode = ImeMode.Hiragana     'ひらがな
  End Sub

  ' コンボボックスソース抽出用
  Public Function SqlSelListSrc(prmCode As String) As String
    Dim sql As String = String.Empty

    If (ComChkNumeric(prmCode)) Then

      sql &= " SELECT NO AS ItemCode "
      sql &= "      , NAME AS ItemName "
      sql &= " FROM INFO "
      If prmCode <> "" Then
        sql &= "  WHERE NO = " & prmCode & " AND KUBUN = 2 "
      Else
        sql &= "  WHERE KUBUN = 2 "
      End If
      sql &= " ORDER BY NO "

    End If

    Return sql
  End Function

  ''' <summary>
  ''' コンボボックス再設定
  ''' </summary>
  Public Sub ResetCombo()

    ReSetCmb(SqlSelListSrc(""))

  End Sub


#End Region

#End Region

End Class
