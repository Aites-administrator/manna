Imports System.Runtime.InteropServices
Public Delegate Function CallBack(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

Public Class clsMouseHookClass

  Dim WH_MOUSE_LL As Integer = 14
  Shared hHook As Integer = 0

  Private hookproc As CallBack

  <DllImport("kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
  Public Overloads Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
  End Function

  'Import for the SetWindowsHookEx function.
  <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
  Public Overloads Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As CallBack, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
  End Function

  'Import for the CallNextHookEx function.
  <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
  Public Overloads Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
  End Function
  'Import for the UnhookWindowsHookEx function.
  <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
  Public Overloads Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
  End Function

  'Point structure declaration.
  <StructLayout(LayoutKind.Sequential)> Public Structure Point
    Public x As Integer
    Public y As Integer
  End Structure

  <StructLayout(LayoutKind.Sequential)>
  Public Class MouseLLHookStruct
    Public pt As Point
    Public mouseData As Integer
    Public flags As Integer
    Public time As Integer
    Public dwExtraInfo As Integer
  End Class

  ' マウス操作の種類を表す。
  Public Enum MouseMessage
    ' マウスカーソルが移動した。
    Move = &H200
    ' 左ボタンが押された。
    LDown = &H201
    ' 左ボタンが解放された。
    LUp = &H202
    ' 右ボタンが押された。
    RDown = &H204
    ' 左ボタンが解放された。
    RUp = &H205
    ' 中ボタンが押された。
    MDown = &H207
    ' 中ボタンが解放された。
    MUp = &H208
    ' ホイールが回転した。
    Wheel = &H20A
    ' Xボタンが押された。
    XDown = &H20B
    ' Xボタンが解放された。
    XUp = &H20C
  End Enum

  ' マウスホイールの向き
  Public Enum MouseDirection
    ' 上
    UP = 1
    ' 下
    DOWN
  End Enum

  Public Event MouseHook(sender As Object, e As MouseHookEventArgs)
  Public Class MouseHookEventArgs
    Inherits EventArgs

    Private _mousestatus As MouseLLHookStruct
    Private _mousemessage As MouseMessage
    Private _direction As Integer

    Public Sub New(mousemessage As MouseMessage, mousestatus As MouseLLHookStruct, direction As Integer)
      _mousemessage = mousemessage
      _mousestatus = mousestatus
      _direction = direction
    End Sub

    ''' <summary>
    ''' マウスカーソルの位置（スクリーン座標）
    ''' </summary>
    Public ReadOnly Property Point As Point
      Get
        Return _mousestatus.pt
      End Get
    End Property

    ''' <summary>
    ''' マウスの状態
    ''' </summary>
    Public ReadOnly Property Message As MouseMessage
      Get
        Return _mousemessage
      End Get
    End Property

    ''' <summary>
    ''' マウスホイールの向き
    ''' </summary>
    Public ReadOnly Property Direction As Integer
      Get
        Return _direction
      End Get
    End Property
  End Class

  ''' <summary>
  ''' 現在マウスをフックしているか返す
  ''' </summary>
  ''' <returns>False:フックしていない  True:フックしている</returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Hooked As Boolean
    Get
      Return If(hHook = 0, False, True)
    End Get
  End Property

  ''' <summary>
  ''' マウスフックを開始する
  ''' </summary>
  ''' <returns>False:フックに失敗もしくはフック済み True:フックに成功</returns>
  ''' <remarks></remarks>
  Public Function MouseHookStart() As Boolean
    If hHook.Equals(0) Then
      'マウスフックを開始する
      hookproc = AddressOf MouseLLHookProc
      hHook = SetWindowsHookEx(WH_MOUSE_LL, hookproc, GetModuleHandle(IntPtr.Zero), 0)
      If hHook.Equals(0) Then
        Return False
      Else
        Return True
      End If
    Else
      'マウスフックがすでに開始されている
      Return False
    End If

  End Function

  ''' <summary>
  ''' マウスフックを終了する
  ''' </summary>
  ''' <returns>False:フック解除に失敗もしくはフックしていない True:フック解除に成功</returns>
  ''' <remarks></remarks>
  Public Function MouseHookEnd() As Boolean
    If hHook.Equals(0) Then
      'マウスフックが開始されていない
      Return False
    Else
      'マウスフックを終了する
      Dim ret As Boolean = UnhookWindowsHookEx(hHook)

      If ret.Equals(False) Then
        Return False
      Else
        hHook = 0
        Return True
      End If
    End If

  End Function

  ''' <summary>
  ''' マウスフックの設定
  ''' </summary>
  ''' <param name="nCode"></param>
  ''' <param name="wParam"></param>
  ''' <param name="lParam"></param>
  ''' <returns></returns>
  Private Function MouseLLHookProc(ByVal nCode As Integer, ByVal wParam As MouseMessage, ByVal lParam As IntPtr) As Integer

    Dim MyMouseHookStruct As New MouseLLHookStruct()

    If nCode = 0 Then
      MyMouseHookStruct = CType(Marshal.PtrToStructure(lParam, MyMouseHookStruct.GetType()), MouseLLHookStruct)

      Dim direction As Integer = 0

      ' マウスホイールの場合
      If (wParam = MouseMessage.Wheel) Then
        ' マウスホイールの向き判定
        Dim Delta = CShort(MyMouseHookStruct.mouseData >> 16)
        If Delta > 0 Then
          ' Up
          direction = MouseDirection.UP
        ElseIf Delta < 0 Then
          ' Down
          direction = MouseDirection.DOWN
        End If
      End If

      ' イベントを発生させる
      RaiseEvent MouseHook(Nothing, New MouseHookEventArgs(wParam, MyMouseHookStruct, direction))
    End If

    Return CallNextHookEx(hHook, nCode, wParam, lParam)
  End Function

End Class
