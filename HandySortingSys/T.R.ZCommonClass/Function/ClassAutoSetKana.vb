Imports System.Runtime.InteropServices

Namespace KanaAutoSet

  '----------------------------------------------------------------
  '   変換イベントクラス
  '----------------------------------------------------------------
  Public Class ConvertedEventArgs
    Inherits EventArgs
    Private m_Furigana As String
    Private m_Result As String

    Public Sub New(ByVal f As String, ByVal r As String)
      m_Furigana = f
      m_Result = r
    End Sub

    Public ReadOnly Property FuriganaString() As String
      Get
        Return m_Furigana
      End Get
    End Property

    Public ReadOnly Property ResultString() As String
      Get
        Return m_Result
      End Get
    End Property
  End Class

  '----------------------------------------------------------------
  '   ふりがなクラス
  '----------------------------------------------------------------
  Public Class ClassAutoSetKana

    '----------------------------------------------------------------
    '   ローカル変数
    '----------------------------------------------------------------
    Private m_TargetControl As Control
    Private WithEvents m_MsgListner As MsgListner

#Region " IMEAPI定義 "

    Private Const WM_CHAR As Integer = &H102
    Private Const WM_KEYUP As Integer = &H101

    Private Const WM_IME_STARTCOMPOSITION As Integer = &H10D
    Private Const WM_IME_ENDCOMPOSITION As Integer = &H10E
    Private Const WM_IME_COMPOSITION As Integer = &H10F

    Private Const GCS_COMPREADSTR As Integer = &H1
    Private Const GCS_COMPREADATTR As Integer = &H2
    Private Const GCS_COMPREADCLAUSE As Integer = &H4
    Private Const GCS_COMPSTR As Integer = &H8
    Private Const GCS_COMPATTR As Integer = &H10
    Private Const GCS_COMPCLAUSE As Integer = &H20
    Private Const GCS_CURSORPOS As Integer = &H80
    Private Const GCS_DELTASTART As Integer = &H100
    Private Const GCS_RESULTREADSTR As Integer = &H200
    Private Const GCS_RESULTREADCLAUSE As Integer = &H400
    Private Const GCS_RESULTSTR As Integer = &H800
    Private Const GCS_RESULTCLAUSE As Integer = &H1000

    Private Const IMM_ERROR_NODATA As Integer = -1
    Private Const IMM_ERROR_GENERAL As Integer = -2

    '----------------------------------------------------------------
    '   コンテキストハンドルの取得
    '----------------------------------------------------------------
    <DllImport("Imm32.dll", CharSet:=CharSet.Ansi)>
    Private Shared Function ImmGetContext(ByVal hWnd As Integer) As Integer
    End Function

    '----------------------------------------------------------------
    '   コンテキストハンドルの開放
    '----------------------------------------------------------------
    <DllImport("Imm32.dll", CharSet:=CharSet.Ansi)>
    Private Shared Function ImmReleaseContext(ByVal hWnd As Integer, ByVal hIMC As Integer) As Integer
    End Function

    '----------------------------------------------------------------
    '   IMEよりフリガナ等の文字列を取得する
    '----------------------------------------------------------------
    <DllImport("Imm32.dll", CharSet:=CharSet.Ansi)>
    Private Shared Function ImmGetCompositionString(ByVal hIMC As Integer, ByVal dwIndex As Integer, ByRef lpBuf As Byte, ByVal dwBufLen As Integer) As Integer
    End Function

    '----------------------------------------------------------------
    '   Windowの検索
    '----------------------------------------------------------------
    <DllImport("User32.dll", CharSet:=CharSet.Ansi)>
    Private Shared Function FindWindowEx(ByVal hwndParent As Integer, ByVal hwndChildAfter As Integer, ByVal lpszClass As String, ByVal lpszWindow As String) As Integer
    End Function

    '----------------------------------------------------------------
    '   IMEの状態取得
    '----------------------------------------------------------------
    <DllImport("Imm32.dll", CharSet:=CharSet.Ansi)>
    Private Shared Function ImmGetOpenStatus(ByVal hIMC As Integer) As Integer
    End Function

#End Region

    '----------------------------------------------------------------
    '   ふりがなへの変換を完了したことを通知するイベント
    '----------------------------------------------------------------
    '   f - ふりがな文字列
    '   r - 変換結果文字列
    '----------------------------------------------------------------
    Public Event Converted(ByVal sender As System.Object, ByVal e As ConvertedEventArgs)

#Region " Window Message Listner "
    Private Class MsgListner
      Inherits NativeWindow

      Private m_Enabled As Boolean = True

      Public Event Converted(ByVal f As String, ByVal r As String)

      Public Property Enabled() As Boolean
        Get
          Return m_Enabled
        End Get
        Set(ByVal Value As Boolean)
          m_Enabled = Value
        End Set
      End Property

      '----------------------------------------------------------------
      '   ふりがな取得対象コントロールのウィンドウプロシージャ
      '----------------------------------------------------------------
      Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Dim hIMC As Integer
        Dim intLength As Integer

        If m_Enabled Then
          Select Case m.Msg

            Case WM_IME_COMPOSITION

              Dim bytBuff() As Byte
              Dim strResult As String = ""
              Dim strFurigana As String = ""

              hIMC = ImmGetContext(Me.Handle.ToInt32)

              '-- 変換後文字列の取得
              intLength = ImmGetCompositionString(hIMC, GCS_RESULTSTR, 0, 0)
              If intLength > 0 Then
                ReDim bytBuff(intLength - 1)
                ImmGetCompositionString(hIMC, GCS_RESULTSTR, bytBuff(0), intLength)
                strResult = System.Text.Encoding.Default.GetString(bytBuff)
              End If

              '-- ふりがな文字列
              intLength = ImmGetCompositionString(hIMC, GCS_RESULTREADSTR, 0, 0)
              If intLength > 0 Then
                ReDim bytBuff(intLength - 1)
                ImmGetCompositionString(hIMC, GCS_RESULTREADSTR, bytBuff(0), intLength)
                strFurigana = System.Text.Encoding.Default.GetString(bytBuff)
                'イベント起動
                RaiseEvent Converted(strFurigana, strResult)
              End If

              ImmReleaseContext(Me.Handle.ToInt32, hIMC)

            Case WM_CHAR    '半角英数字

              hIMC = ImmGetContext(Me.Handle.ToInt32)
              If ImmGetOpenStatus(hIMC) = 0 Then
                If m.WParam.ToInt32 >= 32 Then
                  'イベント起動
                  RaiseEvent Converted(Chr(m.WParam.ToInt32), Chr(m.WParam.ToInt32))
                End If
              End If
              ImmReleaseContext(Me.Handle.ToInt32, hIMC)

          End Select

        End If

        MyBase.WndProc(m)

      End Sub

      Public Sub New(ByVal Target As IntPtr)
        AssignHandle(Target)
      End Sub

      Protected Overrides Sub Finalize()
        ReleaseHandle()
        MyBase.Finalize()
      End Sub

    End Class

#End Region

    Public ReadOnly Property TargetControl() As Control
      Get
        Return m_TargetControl
      End Get
    End Property

    Public Property Enabled() As Boolean
      Get
        Return m_MsgListner.Enabled
      End Get
      Set(ByVal Value As Boolean)
        m_MsgListner.Enabled = Value
      End Set
    End Property

    Public Sub New(ByVal Target As Control)
      m_TargetControl = Target
      If TypeOf Target Is Windows.Forms.ComboBox Then
        Dim hwndFind As Integer
        hwndFind = FindWindowEx(Target.Handle.ToInt32, 0, "Edit", "")
        If hwndFind Then
          m_MsgListner = New MsgListner(New IntPtr(hwndFind))
        End If
      Else
        m_MsgListner = New MsgListner(m_TargetControl.Handle)
      End If

    End Sub

    Public Sub New(ByVal Target As IntPtr)
      m_MsgListner = New MsgListner(Target)
    End Sub

    Public Sub New(ByVal Target As Integer)
      m_MsgListner = Nothing
    End Sub

    Private Sub m_MsgListner_Converted(ByVal f As String, ByVal r As String) Handles m_MsgListner.Converted
      RaiseEvent Converted(m_TargetControl, New ConvertedEventArgs(f, r))
    End Sub
  End Class

End Namespace
