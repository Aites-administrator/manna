Imports System.Security.Permissions

Public Class TxtNumericBase
  Inherits TxtBase

  ' 数値入力専用テキストボックス
  Const WM_PASTE As Integer = &H302

  <SecurityPermission(SecurityAction.Demand,
        Flags:=SecurityPermissionFlag.UnmanagedCode)>
  Protected Overrides Sub WndProc(ByRef m As Message)
    If m.Msg = WM_PASTE Then
      Dim iData As IDataObject = Clipboard.GetDataObject()

      Dim ret As Boolean = True
      If Not iData Is Nothing Then
        '関連付けられているすべての形式を列挙する
        For Each fmt As String In iData.GetFormats()
          Console.WriteLine(fmt)
          If (fmt.Equals("MultiRow5")) Then
            ret = False
          End If
        Next
      End If

      If (ret) Then
        If iData.GetDataPresent(GetType(String)) Then

          '文字列がクリップボードにあるか
          If Not iData Is Nothing AndAlso
                    iData.GetDataPresent(DataFormats.Text) Then
            Dim clipStr As String =
                    DirectCast(iData.GetData(DataFormats.Text), String)
            'クリップボードの文字列が数字のみか調べる
            If Not System.Text.RegularExpressions.Regex.IsMatch(
                    clipStr, "^[0-9]+$") Then
              Return
            End If
          End If
        End If
      End If
    End If

    MyBase.WndProc(m)
  End Sub

#Region "メンバ"
#Region "プライベート"
  Private _InputPoint As Boolean
#End Region
#End Region

#Region "コンストラクタ"
  Public Sub New()
    Me.New(10)
  End Sub

  Public Sub New(prmMaxChar As Integer _
                 , Optional prmInputPoint As Boolean = False)
    Me.ImeMode = ImeMode.Alpha        ' IMEモード設定(半角英数字)
    MyBase.SetMaxChar(prmMaxChar)     ' 入力可能最大文字数設定
    _InputPoint = prmInputPoint
    ' Me.TextAlign = HorizontalAlignment.Right
  End Sub

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' キー入力時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub TxtNumericBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
      e.Handled = False
    Else
      ' 数値とバックスペースのみ入力可
      If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) _
      AndAlso e.KeyChar <> ControlChars.Back _
      AndAlso (_InputPoint = False OrElse e.KeyChar <> "."c OrElse SelectionStart > 3) Then
        e.Handled = True
      End If
    End If

  End Sub


#End Region

End Class
