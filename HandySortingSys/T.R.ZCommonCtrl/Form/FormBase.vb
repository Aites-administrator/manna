Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System.IO
Imports System.Reflection
Imports T.R.ZCommonClass

Public Class FormBase
  Inherits Form

#Region "メンバ"
#Region "プライベート"
  ''' <summary>
  ''' ファンクションキー記憶領域
  ''' </summary>
  Private _FuncBtn As New Dictionary(Of Keys, BtnFunc)

  ''' <summary>
  ''' ボタン二度押し防止フラグ
  ''' </summary>
  Private _IsEventProcessing As Boolean

#End Region
#Region "パブリック"

  'IPC用クラスの生成
  Public WithEvents IpcServiceClass As New IpcService.clsIpcService

  ' 非表示→表示時コールバック（共通）
  Delegate Sub CallBackShowForm(ByVal prmMsg As String)
  Private lcCallBackCallBackShowForm As New CallBackShowForm(AddressOf ShowForm)

  ' 非表示→表示時コールバック（個別）
  Delegate Sub CallBackShowFormLc()
  Public lcCallBackShowFormLc As CallBackShowFormLc

  ''' <summary>
  ''' ボタン二度押し防止フラグ
  ''' </summary>
  ''' <returns></returns>
  Public Property EventProcessing As Boolean
    Get
      Return _IsEventProcessing
    End Get
    Set(value As Boolean)
      _IsEventProcessing = value
    End Set
  End Property

#End Region
#End Region

#Region "メソッド"

#Region "IPC関連"

  ''' <summary>
  ''' IPCサービス初期化
  ''' </summary>
  ''' <param name="prmPrgId">プログラムID</param>
  ''' <remarks>
  ''' 起動後はプログラムIDで再起動メッセージの待ち受けを行い
  ''' 二重起動時は後で起動したプロセスがプログラムIDで再表示メッセージを送信する
  ''' </remarks>
  Public Sub InitIPC(prmPrgId As String)
    'IPCチャネルを用意
    Dim IpcChannel As New IpcServerChannel(prmPrgId)
    ChannelServices.RegisterChannel(IpcChannel, False)
    Dim strSClassName As String = GetType(clsIpcService).Name
    RemotingConfiguration.RegisterWellKnownServiceType(GetType(clsIpcService), strSClassName, WellKnownObjectMode.SingleCall)
    '「ServiceClass」を参照できるように設定
    Dim ref As ObjRef = RemotingServices.Marshal(IpcServiceClass, strSClassName)

    'IPC受信準備
    IpcChannel.StartListening(Nothing)
  End Sub

  ''' <summary>
  ''' IPCメッセージ受信時処理
  ''' </summary>
  ''' <param name="message">プログラムID（使用しません）</param>
  ''' <remarks>
  ''' 二重起動時に後で起動したプロセスから送信されたメッセージ受信時処理
  ''' </remarks>
  Private Sub IpcServiceClass_RaiseClientEvent(ByVal message As String) Handles IpcServiceClass.RaiseClientEvent
    'このイベント処理は、別プロセスのServiceClassからRaiseされるので、
    'このフォームのコントロールにアクセスするにはデリゲート処理を行う
    '(クライアントから受信したメッセージを処理)

    Me.Invoke(lcCallBackCallBackShowForm, New Object() {message})
  End Sub

  ''' <summary>
  ''' 画面再表示
  ''' </summary>
  ''' <param name="prmMsg"></param>
  ''' <remarks>
  ''' 二重起動したプロセスよりIPC経由でコールバックで実行される
  ''' </remarks>
  Private Sub ShowForm(ByVal prmMsg As String)

    Me.ShowInTaskbar = True
    Me.Show()

    ' 再起動時個別処理
    If lcCallBackShowFormLc IsNot Nothing Then
      lcCallBackShowFormLc()
    End If
  End Sub

#End Region

#Region "コントロール制御関連"

  ''' <summary>
  ''' 画面上の全てのコントロールを初期化する
  ''' </summary>
  ''' <param name="prmExclusionControls">除外するコントロールリスト</param>
  ''' <remarks>
  '''  コンボボックスとテキストボックスが対象
  ''' </remarks>
  Public Sub AllClear(Optional prmExclusionControls As List(Of Control) = Nothing)
    Call ComInitCmb(Me, prmExclusionControls)
    Call InitTxt(prmExclusionControls)
  End Sub

  ''' <summary>
  ''' 画面上の全てのコントロールにメッセージラベルを設定
  ''' </summary>
  ''' <param name="prmMsglbl">メッセージを表示するラベル</param>
  ''' <remarks>
  '''  CmbBase,TxtBase,BtnBaseを継承しているコントロールと
  '''  clsDataGridが対象
  ''' </remarks>
  Public Sub SetMsgLbl(prmMsglbl As Label)
    Dim tmpControls As Control() = ComGetAllControls(Me)

    ' CmbBase,TxtBase,BtnBaseを継承しているコントロールにメッセージ表示オブジェクトを設定
    For Each tmpCtrl As Control In tmpControls
      If IsTargetControl(New CmbBase, tmpCtrl) Then
        DirectCast(tmpCtrl, CmbBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New TxtBase, tmpCtrl) Then
        DirectCast(tmpCtrl, TxtBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New BtnBase, tmpCtrl) Then
        DirectCast(tmpCtrl, BtnBase).SetMsgLabel(prmMsglbl)
      End If
    Next

  End Sub


  ''' <summary>
  ''' 画面上の全てのコントロールにメッセージラベルを設定
  ''' </summary>
  ''' <param name="prmMsglbl">メッセージを表示するラベル</param>
  ''' <remarks>
  '''  CmbBase,TxtBase,BtnBaseを継承しているコントロールと
  '''  clsDataGridが対象
  ''' </remarks>
  Public Sub SetMsgLbl(prmMsglbl As Label, pnlFrame As Panel)
    Dim tmpControls As Control() = ComGetAllControls(Me)

    ' CmbBase,TxtBase,BtnBaseを継承しているコントロールにメッセージ表示オブジェクトを設定
    For Each tmpCtrl As Control In tmpControls
      If IsTargetControl(New CmbBase, tmpCtrl) Then
        DirectCast(tmpCtrl, CmbBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New TxtBase, tmpCtrl) Then
        DirectCast(tmpCtrl, TxtBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New BtnBase, tmpCtrl) Then
        DirectCast(tmpCtrl, BtnBase).SetMsgLabel(prmMsglbl)
      End If
    Next

    For Each tmpCtrl In pnlFrame.Controls
      If IsTargetControl(New CmbBase, tmpCtrl) Then
        DirectCast(tmpCtrl, CmbBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New TxtBase, tmpCtrl) Then
        DirectCast(tmpCtrl, TxtBase).SetMsgLabel(prmMsglbl)
      ElseIf IsTargetControl(New BtnBase, tmpCtrl) Then
        DirectCast(tmpCtrl, BtnBase).SetMsgLabel(prmMsglbl)
      End If
    Next

  End Sub


  ''' <summary>
  ''' 画面上の全てのコントロールを非表示にする
  ''' </summary>
  Public Sub AllHide()

    Dim tmpControls As Control() = ComGetAllControls(Me)
    For Each tmpCtrl As Control In tmpControls
      tmpCtrl.Hide()
    Next
  End Sub

  ''' <summary>
  ''' ファンクションキー登録
  ''' </summary>
  ''' <param name="prmBtn">ボタンコントロール</param>
  ''' <param name="prmKey">ファンクションキーコード</param>
  Public Sub FuncBtnAdd(prmBtn As BtnFunc, prmKey As Keys)

    If _FuncBtn.ContainsKey(prmKey) = False Then
      _FuncBtn.Add(prmKey, prmBtn)
    End If

  End Sub

  ''' <summary>
  ''' ファンクションキーかどうか判定し、ファンクイションキーの場合イベントの関連付けを行う
  ''' </summary>
  ''' <param name="prmObjCtr">コントロール</param>
  ''' <param name="prmObjBtn">ボタンコントロール</param>
  ''' <returns></returns>
  Public Function TryGetFuncButton(ByVal prmObjCtr As Control,
                                   ByRef prmObjBtn As BtnFunc) As Boolean
    Dim bRet As Boolean = False

    ' ファンクションキーのイベントの関連付け
    If (IsTargetControl(New BtnFunc, prmObjCtr)) Then
      'ボタンコントロールに変換
      prmObjBtn = DirectCast(prmObjCtr, BtnFunc)

      bRet = True
    End If

    Return bRet

  End Function

  ''' <summary>
  ''' 画面上の全テキストボックス初期化
  ''' </summary>
  ''' <param name="prmExclusionControls">除外対象コントロール</param>
  ''' <remarks>
  ''' TxtBaseを継承したコントロールのみ対象
  ''' </remarks>
  Private Sub InitTxt(Optional prmExclusionControls As List(Of Control) = Nothing)
    Dim tmpControls As Control() = ComGetAllControls(Me)
    For Each tmpCtrl As Control In tmpControls
      If IsTargetControl(New TxtMstBase, tmpCtrl) Then
        ' 除外対象のコントロールで無いなら初期化
        If prmExclusionControls Is Nothing _
          OrElse prmExclusionControls.Contains(tmpCtrl) = False Then
          DirectCast(tmpCtrl, TxtMstBase).Text = ""
        End If
      Else
        If IsTargetControl(New TxtBase, tmpCtrl) Then
          ' 除外対象のコントロールで無いなら初期化
          If prmExclusionControls Is Nothing _
          OrElse prmExclusionControls.Contains(tmpCtrl) = False Then
            DirectCast(tmpCtrl, TxtBase).Text = ""
          End If
        End If
      End If
    Next

  End Sub
#End Region

#End Region

#Region "イベントプロシージャー"

  ''' <summary>
  ''' キーが押された時のイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    ' DataGridView以外でエンターキーが押されたら次のコントロールにフォーカスを移動する
    If e.KeyCode = Keys.Enter _
      AndAlso Me.ActiveControl IsNot Nothing _
      AndAlso Me.ActiveControl.GetType().Name.ToUpper <> "DataGridView".ToUpper Then
      Call SetFocusNextCtrl(Me.ActiveControl)
    End If

    ' ファンクションキーが押された場合、ファンクションキー記憶領域に対応するキーイベントを実行する
    Try

      ' ファンクションキー記憶領域に、入力したキーが存在するかどうか判定
      If (_FuncBtn.ContainsKey(e.KeyCode)) Then

        ' ファンクションキー記憶領域からボタンコントロールを取得
        Dim tmpBtn As BtnFunc = _FuncBtn(e.KeyCode)
        With tmpBtn

          ' ボタン使用不可をチェックする
          If .Enabled = True Then

            .Focus()
            ' ボタンのクリックを実行
            .PerformClick()

            ' KeyDownイベントを発生させない
            e.Handled = True

          End If
        End With

      End If

    Catch ex As Exception

    End Try

  End Sub

  ''' <summary>
  ''' ボタン二度押し防止フラグ解除
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)

    _IsEventProcessing = False

  End Sub

  ''' <summary>
  ''' フォームロード時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Me.KeyPreview = True

    AddHandler Application.Idle, New EventHandler(AddressOf Application_Idle)

    ' コンボボックス初期化
    ComInitCmb(Me)

    ' ダブルバッファリング有効
    Me.DoubleBuffered = True

    ' コントロールがある分だけループ
    For Each objCtr As Control In Me.Controls

      ' ファンクションキー配列設定
      If objCtr.GetType Is GetType(BtnF1) Then
        FuncBtnAdd(objCtr, Keys.F1)
      ElseIf objCtr.GetType Is GetType(BtnF2) Then
        FuncBtnAdd(objCtr, Keys.F2)
      ElseIf objCtr.GetType Is GetType(BtnF3) Then
        FuncBtnAdd(objCtr, Keys.F3)
      ElseIf objCtr.GetType Is GetType(BtnF4) Then
        FuncBtnAdd(objCtr, Keys.F4)
      ElseIf objCtr.GetType Is GetType(BtnF5) Then
        FuncBtnAdd(objCtr, Keys.F5)
      ElseIf objCtr.GetType Is GetType(BtnF6) Then
        FuncBtnAdd(objCtr, Keys.F6)
      ElseIf objCtr.GetType Is GetType(BtnF7) Then
        FuncBtnAdd(objCtr, Keys.F7)
      ElseIf objCtr.GetType Is GetType(BtnF8) Then
        FuncBtnAdd(objCtr, Keys.F8)
      ElseIf objCtr.GetType Is GetType(BtnF9) Then
        FuncBtnAdd(objCtr, Keys.F9)
      ElseIf objCtr.GetType Is GetType(BtnF10) Then
        FuncBtnAdd(objCtr, Keys.F10)
      ElseIf objCtr.GetType Is GetType(BtnF11) Then
        FuncBtnAdd(objCtr, Keys.F11)
      ElseIf objCtr.GetType Is GetType(BtnF12) Then
        FuncBtnAdd(objCtr, Keys.F12)
      End If

    Next

  End Sub

  ''' <summary>
  ''' Shownイベント時
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub BaseForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    Dim verDate As Date = File.GetLastWriteTimeUtc(Assembly.GetExecutingAssembly().Location)
    verDate = verDate + New TimeSpan(9, 0, 0)
    Me.Text = Me.Text & verDate.ToString("(yyyy/MM/dd HH:mm:ss)")

  End Sub

  ''' <summary>
  ''' フォームアクティブ時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    For Each tmpCtrl As Control In ComGetAllControls(Me)
      If IsDataGridView(tmpCtrl) Then
        ' フォーム上の全てのDataGridViewのツールチップを有効にする
        DirectCast(tmpCtrl, DataGridView).ShowCellToolTips = True
      End If
    Next
  End Sub

  ''' <summary>
  ''' フォームアクティブ解除時処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub Form_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
    For Each tmpCtrl As Control In ComGetAllControls(Me)
      If IsDataGridView(tmpCtrl) Then
        ' フォーム上の全てのDataGridViewのツールチップを無効にする
        ' ※ツールチップ表示前にフォーカスを外れると異常終了するバグの対策
        DirectCast(tmpCtrl, DataGridView).ShowCellToolTips = False
      End If
    Next
  End Sub

  Private Sub InitializeComponent()
    Me.SuspendLayout()
    '
    'FormBase
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Name = "FormBase"
    Me.ResumeLayout(False)

  End Sub

  ''' <summary>
  ''' フォーム終了時、プロセスの終了
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub FormBase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    ProcessKill()

  End Sub

#End Region

End Class
