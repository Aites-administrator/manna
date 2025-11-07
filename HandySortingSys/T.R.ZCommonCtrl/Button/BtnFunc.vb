Imports System.Drawing.Text
Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
'----------------------------------------------
' ファンクション用ボタン
' ＜仮作成＞
'----------------------------------------------
Public Class BtnFunc
  Inherits BtnBase

  Public buttonProcessing As Boolean

  Public Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
    Me.buttonProcessing = False
  End Sub

End Class

Public Class BtnF1
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()

    AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F1")

  End Sub

#End Region
End Class

Public Class BtnF2
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F2")

  End Sub
#End Region

#End Region

End Class

Public Class BtnF3
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F3")

  End Sub
#End Region

End Class

Public Class BtnF4
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F4")

  End Sub
#End Region

End Class

Public Class BtnF5
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F5")

  End Sub
#End Region
End Class

Public Class BtnF6
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F6")

  End Sub
#End Region

End Class

Public Class BtnF7
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F7")

  End Sub
#End Region

End Class

Public Class BtnF8
  Inherits BtnFunc

#Region "コンストラクタ"

  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F8")

  End Sub
#End Region

End Class

Public Class BtnF9
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F9")

  End Sub
#End Region

End Class

Public Class BtnF10
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F10")

  End Sub
#End Region

End Class

Public Class BtnF11
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F11")

  End Sub
#End Region

End Class

Public Class BtnF12
  Inherits BtnFunc

#Region "コンストラクタ"
  Public Sub New()
  End Sub
#End Region

#Region "初期化処理"
  ' コントロール配置
  Protected Overrides Sub InitLayout()

    InitSetFunction()

    ' ファンクションキー名設定
    SetFunctionKeyName("F12")

  End Sub

#End Region

End Class

