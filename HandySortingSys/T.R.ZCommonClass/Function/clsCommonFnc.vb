Imports System.IO
Imports T.R.ZCommonClass.clsComDatabase
Imports T.R.ZCommonClass.clsDataGridSearchControl
Imports T.R.ZCommonClass.clsCommonFnc
Imports IpcService
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System.Text
Imports System.Management
Imports System.Runtime.InteropServices

Public Class clsCommonFnc

#Region " P/Invoke "
    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    ' ウィンドウにメッセージを送信。この関数は、指定したウィンドウのウィンドウプロシージャが処理を終了するまで制御を返さない
    <DllImport("user32.DLL", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(
    ByVal hWnd As IntPtr,
    ByVal wMsg As Integer,
    ByVal wParam As Integer,
    ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindowEx(
    ByVal parentHandle As IntPtr,
    ByVal childAfter As IntPtr,
    ByVal lclassName As String,
    ByVal windowTitle As String) As IntPtr
    End Function

    Private Const EC_LEFTMARGIN As Integer = &H1    ' 左マージンの設定
    Private Const EC_RIGHTMARGIN As Integer = &H2   ' 右マージンの設定
    Private Const EM_SETMARGINS As Integer = &HD3   ' 左右マージンの設定

#End Region

    ' メッセージボックスタイプ
    Public Enum typMsgBox
        MSG_NORMAL = 0
        MSG_WARNING
        MSG_ERROR
    End Enum

    ' メッセージボックスボタンタイプ
    Public Enum typMsgBoxButton
        BUTTON_OK = 0
        BUTTON_ABORTRETRYIGNORE
        BUTTON_OKCANCEL
        BUTTON_YESNOCANCEL
        BUTTON_YESNO
        BUTTON_RETRYCANCEL
        BUTTON_YESNO_DEFAULT_YES
    End Enum

    ' メッセージボックス戻り値タイプ
    Public Enum typMsgBoxResult
        RESULT_NONE = 0
        RESULT_OK
        RESULT_CANCEL
        RESULT_ABORT
        RESULT_RETRY
        RESULT_IGNORE
        RESULT_YES
        RESULT_NO
    End Enum

    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Enum typInput
        NEW_MODE = 0        ' 新規
        EDIT_MODE           ' 修正
        LASTSLIP_MODE       ' 前回伝票  
    End Enum

    Private Const WM_SETREDRAW As Integer = &HB

#Region "メンバ"

#Region "プライベート"

#End Region
    ' プロセスＩＤ
    Private Shared procesID As System.Diagnostics.Process

    ' プロセス強制終了フラグ
    Private Shared procesEndFlg As Boolean = False

    ''' <summary>
    ''' PCA項目名と値の紐づけディレクトリ
    ''' </summary>
    Private Shared _pcaLogDic As New Dictionary(Of String, String)

#End Region

    ''' <summary>
    ''' 任意のプログラムを起動する
    ''' </summary>
    ''' <param name="prmExePath">検索する実行ファイルパス。</param>
    ''' <param name="pArg">コマンドライン引数</param>
    ''' <param name="pRestart">
    '''  対象プロセス起動時再起動フラグ 
    '''   True - 再起動を行う 
    '''   False - 再起動を行わない（Default）
    ''' </param>
    ''' <returns>起動したプロセスオブジェクト</returns>
    Public Shared Function ComGetProcessByFilePath(prmExePath As String _
                                                 , pArg As String _
                                                 , Optional pRestart As Boolean = False) As Process
        Dim tmpFined As Boolean = False
        Dim ret As Process = Nothing

        prmExePath = prmExePath.ToLower()

        'すべてのプロセスを列挙する
        'ExecutablePathが「\(検索する実行ファイル名)」のプロセスを探す
        Dim mos As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ExecutablePath = '" & prmExePath.Replace("\", "\\") & "'")

        If mos.Get().Count > 0 Then
            Dim moc As System.Management.ManagementObjectCollection = mos.[Get]()

            If moc.Count > 0 Then
                ret = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(moc(0)("ProcessId")))
            End If

            moc.Dispose()
        End If

        mos.Dispose()

        If ret Is Nothing Then
            Dim psi As New ProcessStartInfo(prmExePath)
            psi.Arguments = pArg
            ret = Process.Start(psi)
        End If

        ' 起動中のプロセスを返す
        Return ret

    End Function

    Public Shared Sub SetFocusNextCtrl(prmCtrl As Control)
        prmCtrl.Parent.SelectNextControl(prmCtrl, True, True, True, True)
    End Sub

    Public Shared Sub SetFocusPreviousCtrl(prmCtrl As Control)
        prmCtrl.Parent.SelectNextControl(prmCtrl, False, True, True, True)
    End Sub

    ''' <summary>
    ''' 連想配列の値をXML形式に変換する
    ''' </summary>
    ''' <param name="prmSrcData">変換対象の連想配列</param>
    ''' <returns>変換したXML形式テキスト</returns>
    Public Shared Function ComDic2XmlText(prmSrcData As Dictionary(Of String, String)) As String
        Dim ret As String = String.Empty

        For Each tmpKey As String In prmSrcData.Keys
            If prmSrcData(tmpKey).Trim() <> "" Then
                ret &= "<" & tmpKey & ">"
                ret &= prmSrcData(tmpKey).Trim()
                ret &= "</" & tmpKey & ">"
            End If
        Next

        Return ret
    End Function

    ''' <summary>
    ''' 項目設定
    ''' </summary>
    ''' <param name="prmTargetDic"></param>
    ''' <param name="prmKey"></param>
    ''' <param name="prmVal"></param>
    Public Shared Sub ComSetDictionaryVal(ByRef prmTargetDic As Dictionary(Of String, String) _
                                        , prmKey As String _
                                        , prmVal As String)
        If prmTargetDic Is Nothing Then
            prmTargetDic = New Dictionary(Of String, String)
            prmTargetDic.Add(prmKey, prmVal)
        ElseIf prmTargetDic.ContainsKey(prmKey) Then
            prmTargetDic(prmKey) = prmVal
        Else
            prmTargetDic.Add(prmKey, prmVal)
        End If

    End Sub

    ''' <summary>
    ''' 項目設定（PCA項目名と値の紐づけ対応版）
    ''' </summary>
    ''' <param name="prmTargetDic"></param>
    ''' <param name="prmKey"></param>
    ''' <param name="prmVal"></param>
    ''' <param name="prmKeyName"></param>
    Public Shared Sub ComSetDictionaryVal(ByRef prmTargetDic As Dictionary(Of String, String) _
                                        , prmKey As String _
                                        , prmVal As String _
                                        , prmKeyName As String)
        If prmTargetDic Is Nothing Then
            prmTargetDic = New Dictionary(Of String, String)
            prmTargetDic.Add(prmKey, prmVal)
        ElseIf prmTargetDic.ContainsKey(prmKey) Then
            prmTargetDic(prmKey) = prmVal
        Else
            prmTargetDic.Add(prmKey, prmVal)
        End If

        'PCA項目名と値の紐づけディレクトリ保存
        If _pcaLogDic Is Nothing Then
            _pcaLogDic.Add(prmKeyName, prmVal)
        ElseIf _pcaLogDic.ContainsKey(prmKeyName) Then
            _pcaLogDic(prmKeyName) = prmVal
        Else
            _pcaLogDic.Add(prmKeyName, prmVal)
        End If

    End Sub

    ''' <summary>
    ''' PCA項目名と値の紐づけディレクトリの取得
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ComGetPcaDictionary() As Dictionary(Of String, String)

        Return _pcaLogDic

    End Function


    ''' <summary>
    ''' DataTabale → Dictionary(String,String)変換
    ''' </summary>
    ''' <param name="prmSrc">DataTabale（元データ）</param>
    ''' <returns>変換したDictionary</returns>
    Public Shared Function ComDt2Dic(prmSrc As DataTable) As List(Of Dictionary(Of String, String))
        Dim ret As New List(Of Dictionary(Of String, String))
        Dim tmpKeyList As New List(Of String)

        ' 列名をリストに保持
        For Each tmpCol As DataColumn In prmSrc.Columns
            tmpKeyList.Add(tmpCol.ColumnName)
        Next

        ' データテーブルの最終行までデータをループ
        For Each tmpDr As DataRow In prmSrc.Rows
            Dim tmpDic As New Dictionary(Of String, String)

            ' 全列データを連想配列に保持
            For Each tmpKey As String In tmpKeyList
                tmpDic.Add(tmpKey, tmpDr(tmpKey).ToString())
            Next

            ' 連想配列をリストに保持
            ret.Add(tmpDic)
        Next

        Return ret
    End Function

    ''' <summary>
    ''' データテーブルのカラム名一覧を取得する
    ''' </summary>
    ''' <param name="prmTargetDt">対象のデータテーブル</param>
    ''' <returns>カラム名一覧</returns>
    Public Shared Function ComGetColumnNames(prmTargetDt As DataTable) As List(Of String)
        Dim tmpDr As DataRow = Nothing
        Dim ret As New List(Of String)

        With prmTargetDt
            If .Rows.Count > 0 Then
                tmpDr = .Rows(0)
                For Each tmpDc As DataColumn In tmpDr.Table.Columns
                    ret.Add(tmpDc.ColumnName)
                Next
            End If
        End With

        Return ret
    End Function

    ''' <summary>
    ''' 日付範囲チェック
    ''' </summary>
    ''' <param name="prmTargetDate01">チェック対象の日付文字列</param>
    ''' <param name="prmTargetDate02">チェック対象の日付文字列</param>
    ''' <param name="prmMinLimit">許容日数下限</param>
    ''' <param name="prmMaxLimit">許容日数上限</param>
    ''' <returns>
    '''  True  - 範囲内
    '''  False - 範囲外
    ''' </returns>
    ''' <remarks>
    '''  prmTargetDate01 と prmTargetDate02の間が許容範囲内かチェックする
    ''' </remarks>
    Public Shared Function ComChkDateLimit(prmTargetDate01 As String _
                                         , prmTargetDate02 As String _
                                         , Optional prmMinLimit As Integer = 0 _
                                         , Optional prmMaxLimit As Integer = 0) As Boolean
        Dim ret As Boolean = False
        Dim tmpDate01 As Date
        Dim tmpDate02 As Date


        If Date.TryParse(prmTargetDate01, tmpDate01) _
      AndAlso Date.TryParse(prmTargetDate02, tmpDate02) Then

            Dim tmpDiff As Integer = DateDiff(DateInterval.Day, tmpDate02, tmpDate01)

            ret = (tmpDiff >= (prmMinLimit * -1) And tmpDiff <= prmMinLimit)

        End If

        Return ret
    End Function


    ''' <summary>
    ''' 数値判定
    ''' </summary>
    ''' <param name="prmText">チェック対象の文字列</param>
    ''' <returns></returns>
    Public Shared Function ComCkkIsNumeric(prmText As String) As Boolean

        Dim ret As Boolean = False

        If IsNumeric(prmText) Then
            ret = True
        End If

        Return ret

    End Function

    ''' <summary>
    ''' 数値判定
    ''' </summary>
    ''' <param name="prmText"></param>
    ''' <param name="prmIntKeta"></param>
    ''' <param name="prmDecKeta"></param>
    ''' <returns></returns>
    Public Shared Function ComCkkIsNumeric(prmText As String,
                                         prmIntKeta As Integer,
                                         prmDecKeta As Integer) As Boolean

        Dim ret As Boolean = False

        If IsNumeric(prmText) Then

            ' カンマ削除
            prmText = prmText.Replace(",", "")
            ' マイナス符号削除
            prmText = prmText.Replace("-", "")

            Dim intDot As Integer = 0
            Dim intIntegral As Integer = 0
            Dim intDecimal As Integer = 0

            intDot = InStr(prmText.ToString(), ".")
            If intDot = 0 Then
                intIntegral = prmText.ToString().Length
            Else
                intIntegral = intDot - 1
                intDecimal = prmText.ToString().Length - intDot
            End If

            If (intIntegral <= prmIntKeta) Then
                If (intDecimal <= prmDecKeta) Then
                    ret = True
                End If
            End If
        Else
        End If

        Return ret

    End Function


    ''' <summary>
    ''' 金額文字列の比較
    ''' </summary>
    ''' <param name="prmText1"></param>
    ''' <param name="prmText2"></param>
    ''' <returns></returns>
    Public Shared Function ComChkCompareAmount(prmText1 As String,
                                             prmText2 As String) As Boolean

        Dim ret As Boolean = False
        Dim tmpDec1 As Decimal = 0.0
        Dim tmpDec2 As Decimal = 0.0


        If IsNumeric(prmText1) Then
            If IsNumeric(prmText2) Then

                ' カンマ削除
                prmText1 = prmText1.Replace(",", "")
                ' カンマ削除
                prmText2 = prmText2.Replace(",", "")


                tmpDec1 = StringToDecimal(prmText1)
                tmpDec2 = StringToDecimal(prmText2)

                If (tmpDec1 = tmpDec2) Then
                    ret = True
                End If

            End If

        End If

        Return ret

    End Function


    ''' <summary>
    ''' 個体識別番号として正しいかチェック
    ''' </summary>
    ''' <param name="KOTAINO">チェック対象の文字列</param>
    ''' <returns>
    '''  True  -  個体識別番号として正しいです
    '''  False -  個体識別番号として正しくないです
    ''' </returns>
    Public Shared Function ComChkKotaiNo(KOTAINO As String) As Boolean

        On Error GoTo Err_Exit

        Dim strCode() As String
        Dim i As Integer
        Dim intTotal As Integer = 0
        Dim ret As Boolean

        ret = False

        If KOTAINO & "" = "" Then
            GoTo Err_Exit
        ElseIf Len(Trim(KOTAINO & "")) < 8 Then
            GoTo Err_Exit
        Else
            KOTAINO = KOTAINO.PadLeft(10, "0"c)
            If Len(KOTAINO) >= 11 Then
                GoTo Err_Exit
            Else
                ReDim strCode(Len(KOTAINO) - 1)

                For i = 0 To Len(KOTAINO) - 1
                    strCode(i) = Mid(KOTAINO, Len(KOTAINO) - i, 1)
                Next

                For i = 1 To UBound(strCode) Step 2
                    intTotal = intTotal + CInt(strCode(i))
                Next

                intTotal = intTotal * 3

                For i = 2 To UBound(strCode) Step 2
                    intTotal = intTotal + CInt(strCode(i))
                Next
                If Right(CStr(intTotal), 1) = "0" Then
                    intTotal = 0
                Else
                    intTotal = 10 - CInt(Right(CStr(intTotal), 1))
                End If

                If strCode(0) <> intTotal Then GoTo Err_Exit
            End If
        End If

        ret = True

Exit_Fnc:
        Return ret

        Exit Function
Err_Exit:
        ret = False
        GoTo Exit_Fnc
    End Function


    ''' <summary>
    ''' コントロール上の全てのコンボボックスを未選択状態にする
    ''' </summary>
    ''' <param name="prmTargetCtrl">対象のコントロール</param>
    ''' <param name="prmExclusionControls">除外するコンボボックス</param>
    Public Shared Sub ComInitCmb(prmTargetCtrl As Control _
                            , Optional prmExclusionControls As List(Of Control) = Nothing)

        Dim tmpControls As Control() = ComGetAllControls(prmTargetCtrl)
        For Each tmpCtrl As Control In tmpControls
            If IsComboBox(tmpCtrl) Then
                ' 除外対象のコントロールで無いなら初期化
                If prmExclusionControls Is Nothing _
          OrElse prmExclusionControls.Contains(tmpCtrl) = False Then
                    DirectCast(tmpCtrl, ComboBox).SelectedIndex = -1
                End If
            End If
        Next

    End Sub


    ''' <summary>
    ''' 任意のコントロールの型が指定のコントロールか確認
    ''' </summary>
    ''' <param name="prmCtrl">コントロール</param>
    ''' <param name="prmTarget">確認対象のコントロール</param>
    ''' <returns>
    '''  True   - 指定のコントロールです
    '''  Fale   - 指定のコントロールではありません
    ''' </returns>
    ''' <remarks>
    '''   [prmTarget]の型が[prmCtrl]と一致するか確認
    '''   ex)
    '''       if IsTargetControl(new TextBox(),TxtHiduke) then
    '''       ' TxtHidukeはテキストボックスです
    '''       else
    '''       ' TxtHidukeはテキストボックスではありません
    '''       end if
    '''  ※ TextBoxを継承して作成されたコントロールもテキストボックスとして判断する
    ''' </remarks>
    Public Shared Function IsTargetControl(prmCtrl As Control, prmTarget As Control) As Boolean

        If (prmTarget Is Nothing) Then
            Return False
        End If

        Dim TargetBaseTypeName As String = prmCtrl.GetType().BaseType().Name
        Dim TargetTypeName As String = prmCtrl.GetType().Name
        Dim CtrlName As String = GetControlBaseTypeName(prmTarget.GetType, TargetBaseTypeName)
        Return CtrlName.ToLower() = TargetTypeName.ToLower()
    End Function

    ''' <summary>
    ''' 任意のコントロールがテキストボックスか確認
    ''' </summary>
    ''' <param name="prmTarget">確認対象のコントロール</param>
    ''' <returns>
    '''  True   - テキストボックスです
    '''  False  - テキストボックスではありません
    ''' </returns>
    ''' <remarks>テキストボックスを継承して作成されたコントロールもテキストボックスとして判断</remarks>
    Public Shared Function IsTextBox(prmTarget As Control) As Boolean
        Return IsTargetControl(New TextBox, prmTarget)
    End Function

    ''' <summary>
    ''' 任意のコントロールがコンボボックスか確認
    ''' </summary>
    ''' <param name="prmTarget">確認対象のコントロール</param>
    ''' <returns>
    '''  True   - コンボボックスです
    '''  False  - コンボボックスではありません
    ''' </returns>
    ''' <remarks>コンボボックスを継承して作成されたコントロールもコンボボックスとして判断</remarks>
    Public Shared Function IsComboBox(prmTarget As Control) As Boolean
        Return IsTargetControl(New ComboBox, prmTarget)
    End Function

    ''' <summary>
    ''' 任意のコントロールがボタンか確認
    ''' </summary>
    ''' <param name="prmTarget">確認対象のコントロール</param>
    ''' <returns>
    '''  True   - ボタンです
    '''  False  - ボタンではありません
    ''' </returns>
    ''' <remarks>ボタンを継承して作成されたコントロールもボタンとして判断</remarks>
    Public Shared Function IsButton(prmTarget As Control) As Boolean
        Return IsTargetControl(New Button, prmTarget)
    End Function

    ''' <summary>
    ''' 任意のコントロールがDataGridViewか確認
    ''' </summary>
    ''' <param name="prmTarget">確認対象のコントロール</param>
    ''' <returns>
    '''  True   - DataGridViewです
    '''  False  - DataGridViewではありません
    ''' </returns>
    ''' <remarks>DataGridViewを継承して作成されたコントロールもDataGridViewとして判断</remarks>
    Public Shared Function IsDataGridView(prmTarget As Control) As Boolean
        Return IsTargetControl(New DataGridView, prmTarget)
    End Function

    ''' <summary>
    ''' 日付変換
    ''' </summary>
    ''' <param name="prmTargetText">変換対象文字列</param>
    ''' <returns>
    ''' yyyy/MM/dd 形式に変換された文字列
    ''' </returns>
    ''' <remarks>
    '''  日・月日等の形式の文字列をyyyy/MM/dd形式の文字列に変換する
    ''' </remarks>
    Public Shared Function ComCreateDateText(prmTargetText As String) As String
        Dim FormatText As String = String.Empty

        Try
            If prmTargetText.Contains("/") Then
                ' 変換対象に"/"が含まれる
                FormatText = DateTxt2DateTxt(prmTargetText)
            Else
                ' 変換対象に"/"が含まれない
                FormatText = NumTxt2Date(prmTargetText)
            End If

            If FormatText <> "" Then
                ' 日付形式では無い
                If False = IsDate(FormatText) Then Throw New Exception(prmTargetText & "は日付形式ではありません")
                ' 指定範囲外（～ 1999/12/31 ）
                If DateDiff("d", "2000/01/01", CDate(FormatText)) < 0 Then Throw New Exception(prmTargetText & "は指定範囲外です")
            End If

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception("日付文字列変換に失敗しました")
        End Try


        Return FormatText
    End Function


    ''' <summary>
    ''' スラッシュを含む文字列を日付形式の文字列に変換する
    ''' </summary>
    ''' <param name="prmTargetText">変換対象の文字列</param>
    ''' <returns>yyyy/MM/dd 形式に変換された文字列</returns>
    Private Shared Function DateTxt2DateTxt(prmTargetText As String) As String
        ' 判断基準
        ' prmTargetTextに含まれるスラッシュの数で判断
        ' 1 : 本年の 月/日 として判断
        ' 2 : 年/月/日 として判断 


        Dim FormatText As String

        FormatText = Trim(prmTargetText & "")

        Try
            Select Case FormatText.Length - FormatText.Replace("/", "").Length
                Case 1
                    FormatText = ComGetProcYear() _
            & "/" & FormatText.Split("/")(0).PadLeft(2, "0"c) _
            & "/" & FormatText.Split("/")(1).PadLeft(2, "0"c)
                Case 2
                    Dim tmpYear As Integer = Integer.Parse(FormatText.Split("/")(0))

                    If tmpYear < 100 Then
                        tmpYear += 2000
                    End If

                    FormatText = tmpYear.ToString() _
            & "/" & FormatText.Split("/")(1).PadLeft(2, "0"c) _
            & "/" & FormatText.Split("/")(2).PadLeft(2, "0"c)
                Case Else
                    Throw New Exception("日付区切り文字の個数が不正です。")
            End Select

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception(prmTargetText & "は日付形式として正しくありません")
        End Try

        Return FormatText
    End Function

    ''' <summary>
    ''' 数値文字列を日付文字列に変換する
    ''' </summary>
    ''' <param name="prmTargetText">変換対象の文字列</param>
    ''' <returns>yyyy/MM/dd 形式に変換された文字列</returns>
    Private Shared Function NumTxt2Date(prmTargetText As String) As String
        ' 判断基準
        ' prmTargetTextの文字数により入力された値を判断
        '  1～2文字  ：  日付が指定されたと判断
        '  3文字     ：  9以下の月と2桁の日付と判断
        '  4文字     ：  mmdd形式と判断
        '  6文字     ：  yymmdd形式と判断
        '  8文字     ：  yyyymmdd形式と判断
        '  9文字以上 ：  yyyy/mm/dd形式と判断
        ' 上記以外の文字数・変換後の文字列が日付形式として正しく無い・指定範囲外
        ' の場合は例外Errorを発生させる
        Dim FormatText As String

        FormatText = Trim(prmTargetText & "")

        Try

            Select Case FormatText.Length
                Case 0
                    FormatText = ""
                Case 1, 2
                    ' 日付として判断
                    ' 当月の日付を返す
                    FormatText = ComGetProcYearMonth() _
                  & "/" & FormatText.PadLeft(2, "0"c)
                Case 3
                    ' 9以下の月と2桁の日付と判断
                    FormatText = ComGetProcYear() _
                  & "/" & Left(FormatText, 1).PadLeft(2, "0"c) _
                  & "/" & Mid(FormatText, 2).PadLeft(2, "0"c)
                Case 4
                    ' 月、日と判断
                    FormatText = ComGetProcYear() _
                  & "/" & Left(FormatText, 2).PadLeft(2, "0"c) _
                  & "/" & Mid(FormatText, 3).PadLeft(2, "0"c)
                Case 5
                    ' Error
                    Throw New Exception("数字5桁は日付形式に変換できません")
                Case 6
                    ' yy/mm/dd 形式と判断
                    FormatText = "20" & Left(FormatText, 2).PadLeft(2, "0"c) _
                  & "/" & Mid(FormatText, 3, 2).PadLeft(2, "0"c) _
                  & "/" & Mid(FormatText, 5).PadLeft(2, "0"c)
                Case 7
                    ' Error
                    Throw New Exception("数字7桁は日付形式に変換できません")
                Case 8
                    ' yyyy/mm/dd 形式と判断
                    FormatText = Left(FormatText, 4) _
                & "/" & Mid(FormatText, 5, 2) _
                & "/" & Mid(FormatText, 7, 2)
                Case Else
                    ' Error
                    Throw New Exception("入力された数値は日付形式に変換できません[原因不明]")
            End Select

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception(prmTargetText & "は日付形式として正しくありません")
        End Try

        Return FormatText

    End Function

    ''' <summary>
    ''' g→Kg変換
    ''' </summary>
    ''' <param name="prmG">g（文字列）</param>
    ''' <param name="prmDecimalPoint">小数点以下桁数（デフォルト2=10g単位まで）</param>
    ''' <returns>gをKg換算した文字列</returns>
    ''' <remarks>
    '''   指定桁数で切り捨て
    ''' </remarks>
    Public Shared Function ComG2Kg(prmG As String _
                          , Optional prmDecimalPoint As Integer = 2) As String
        Dim ret As String = String.Empty

        ret = (Integer.Parse(ComBlank2ZeroText(prmG)) / 1000).ToString()

        Return ret

    End Function

    ''' <summary>
    ''' Kg→g変換
    ''' </summary>
    ''' <param name="prmKg">Kg（文字列）</param>
    ''' <returns>Kgをg換算した文字列</returns>
    Public Shared Function ComKg2G(prmKg As String) As String
        Dim ret As String = String.Empty


        ret = (Decimal.Parse(ComBlank2ZeroText(prmKg)) * 1000).ToString()

        Return ret
    End Function

    ''' <summary>
    ''' XML制御文字半角→全角変換
    ''' </summary>
    ''' <param name="prmXml">文字列</param>
    ''' <returns>エスケープ対象の文字を全角に変換した文字列</returns>
    ''' <remarks>
    '''   エスケープ対象の文字を全角に変換
    ''' </remarks>
    Public Shared Function ComXmlEscapeToZenkaku(prmXml As String) As String
        Dim ret As String = String.Empty

        ' 特殊文字変換
        ret = prmXml
        ret = ret.Replace("<"c, "＜"c)
        ret = ret.Replace(">"c, "＞"c)
        ret = ret.Replace("&", "＆"c)
        ret = ret.Replace("'", "’")
        ret = ret.Replace(",", "、")
        ret = ret.Replace("""", ChrW(&H201D))

        Return ret

    End Function

    ''' <summary>
    ''' 数値文字列の小数桁数を取得する
    ''' </summary>
    ''' <param name="prmTargetText">対象の数値文字列</param>
    ''' <returns>小数桁数</returns>
    Public Shared Function GetDecimalDigits(prmTargetText As String) As Integer
        Dim ret As Integer = 0
        Dim tmpDecimalVal As Decimal = Decimal.Parse(prmTargetText) * 1000

        If tmpDecimalVal Mod 10 <> 0 Then
            ret = 3
        ElseIf tmpDecimalVal Mod 100 <> 0 Then
            ret = 2
        ElseIf tmpDecimalVal Mod 1000 <> 0 Then
            ret = 1
        End If

        Return ret
    End Function

    ''' <summary>
    ''' SQL文に抽出条件(Where句)を追加する
    ''' </summary>
    ''' <param name="sql">元SQL文</param>
    ''' <param name="SearchCondition">抽出条件</param>
    ''' <returns>抽出条件を追加したSQL文</returns>
    Public Shared Function ComAddSqlSearchCondition(sql As String _
                                        , SearchCondition As String) As String

        '以下の順序で記述されていることを前提とする
        'SELECT
        'FROM
        '[ WHERE ]
        '[ GROUP BY ]   未対応（見つけた人が対応してくださいな）
        '[ HAVING ]     未対応（見つけた人が対応してくださいな）
        '[ Order BY ]

        Dim PosOrderBy As Long
        Dim PosWhere As Long
        Dim tmpSql As String

        tmpSql = sql
        ' 検索条件が存在するなら一覧表示用SQL文に埋め込む
        If SearchCondition <> "" Then

            ' Where句を確認
            PosWhere = InStrRev(tmpSql, "where", -1, vbTextCompare)
            If PosWhere > 0 Then
                ' Where句の直後に検索条件を挿入
                tmpSql = Left(tmpSql, PosWhere + Len("where")) & SearchCondition & " AND " & Mid(tmpSql, PosWhere + Len("where") + 1)
            Else
                ' Where句が無い
                ' Order by 句を確認
                PosOrderBy = InStrRev(tmpSql, "order by", -1, vbTextCompare)
                If PosOrderBy > 0 Then
                    ' Orderby句の直前に "WHERE" + 検索条件を挿入
                    tmpSql = Left(tmpSql, PosOrderBy - 1) & " WHERE " & SearchCondition & Mid(tmpSql, PosOrderBy)
                Else
                    ' [Where] [Order by] ともに無し
                    ' *** Group Byに対応したほーがいーかも
                    ' SQL文の最後に "WHERE" + 検索条件を挿入
                    tmpSql = tmpSql & " WHERE " & SearchCondition
                End If
            End If

        End If

        Return tmpSql
    End Function

    ''' <summary>
    ''' SQL文に抽出条件(Order By句)を追加する
    ''' </summary>
    ''' <param name="sql">元SQL文</param>
    ''' <param name="SearchCondition">抽出条件</param>
    ''' <param name="orderSql">並び替え条件を追加したSQL文</param>
    ''' <returns></returns>
    Public Shared Function ComAddSqlSearchCondition(sql As String _
                                        , SearchCondition As String _
                                        , orderSql As String) As String

        ' 一覧抽出用SQL文に引数の検索条件を追加
        Dim tmpSql As String = ComAddSqlSearchCondition(sql, SearchCondition)

        Dim PosOrderBy As Long

        ' 並び替え条件の置き換え
        PosOrderBy = InStrRev(tmpSql, "order by", -1, vbTextCompare)

        If PosOrderBy > 0 Then
            ' Order by 句を確認
            tmpSql = Left(tmpSql, PosOrderBy - 1) & orderSql
        Else
            ' [Order by] 無し
            tmpSql = tmpSql & orderSql
        End If

        Return tmpSql
    End Function


    ''' <summary>
    ''' Nothing→0変換
    ''' </summary>
    ''' <param name="prmTargetObj">対象オブジェクト</param>
    ''' <returns>
    '''  対象のオブジェクトがNothingなら"0"、Nothingでないならオブジェクトの文字列を返す
    ''' </returns>
    ''' <remarks>
    ''' 使用例）
    '''  コンボボックス未選択時の SelectedValueを0に変換する場合
    ''' </remarks>
    Public Shared Function ComNothing2ZeroText(prmTargetObj As Object) As String
        Dim ret As String = "0"

        If prmTargetObj IsNot Nothing AndAlso prmTargetObj.ToString() <> "" Then
            ret = prmTargetObj.ToString()
        End If

        Return ret
    End Function

    ''' <summary>
    ''' Nothing→0変換
    ''' </summary>
    ''' <param name="prmTargetObj">対象オブジェクト</param>
    ''' <returns>
    '''  対象のオブジェクトがNothing                  - 0
    '''  対象のオブジェクトの文字列が空文字列         - 0
    '''  対象のオブジェクトの文字列が空文字列ではない - 対象文字列
    ''' </returns>
    Public Shared Function ComNothingBlank2ZeroText(prmTargetObj As Object) As String
        Dim ret As String = "0"

        If prmTargetObj IsNot Nothing Then
            Dim prmTargetTxt As String = prmTargetObj.ToString()

            ' Nothing、エンプティー、空白を全て0に変換
            If prmTargetTxt Is Nothing _
      OrElse prmTargetTxt.Equals(String.Empty) _
      OrElse prmTargetTxt.Trim = "" Then
                ret = "0"
            Else
                ret = prmTargetTxt
            End If
        End If

        Return ret
    End Function

    ''' <summary>
    ''' Nothing→空白変換
    ''' </summary>
    ''' <param name="prmTargetObj">対象オブジェクト</param>
    ''' <returns>
    '''  対象のオブジェクトがNothingなら""、Nothingでないならオブジェクトの文字列を返す
    ''' </returns>
    ''' <remarks>
    ''' 使用例）
    '''  コンボボックス未選択時の SelectedValueを0に変換する場合
    ''' </remarks>
    Public Shared Function ComNothingBlank2SpaceText(prmTargetObj As Object) As String
        Dim ret As String = "0"

        If prmTargetObj IsNot Nothing Then
            ret = prmTargetObj.ToString()
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 空文字列→ "NULL"変換
    ''' </summary>
    ''' <param name="prmTargetTxt">対象文字列</param>
    ''' <returns>
    '''  対象文字列が空文字列         - "NULL"
    '''  対象文字列が空文字列ではない - 対象文字列
    ''' </returns>
    Public Shared Function ComBlank2NullText(prmTargetTxt As String) As String
        Dim ret As String = prmTargetTxt

        ' Nothing、エンプティー、空白を全てNULLに変換
        If prmTargetTxt Is Nothing _
      OrElse prmTargetTxt.Equals(String.Empty) _
      OrElse prmTargetTxt.Trim = "" Then
            ret = "NULL"
        End If

        Return ret

    End Function

    ''' <summary>
    ''' 空文字列→0変換
    ''' </summary>
    ''' <param name="prmTargetTxt">対象文字列</param>
    ''' <returns>
    '''  対象文字列が空文字列         - 0
    '''  対象文字列が空文字列ではない - 対象文字列
    ''' </returns>
    Public Shared Function ComBlank2ZeroText(prmTargetTxt As String) As String
        Dim ret As String = prmTargetTxt

        ' Nothing、エンプティー、空白を全て0に変換
        If prmTargetTxt Is Nothing _
      OrElse prmTargetTxt.Equals(String.Empty) _
      OrElse prmTargetTxt.Trim = "" Then
            ret = "0"
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 空文字列 → 0変換
    ''' </summary>
    ''' <param name="prmTargetTxt">対象文字列</param>
    ''' <returns>
    '''  対象文字列が空文字列         - 0
    '''  対象文字列が空文字列ではない - 対象文字列をロングに変換した値
    ''' </returns>
    Public Shared Function ComBlank2Zero(prmTargetTxt As String) As Long
        Return CType(ComBlank2ZeroText(prmTargetTxt), Long)
    End Function

    ''' <summary>
    ''' 文字列からInteger型にデータ変換
    ''' </summary>
    ''' <param name="strVal">元の文字列</param>
    ''' <returns>変換後データ</returns>
    Public Shared Function StringToInt(ByVal strVal As String) As Integer
        Try
            Dim intVal As Integer
            ' TryParseでInteger型に変換
            Dim result As Boolean = Int32.TryParse(strVal, intVal)

            ' ParseでInteger型に変換
            Return intVal

        Catch ex As Exception
            ' 例外発生の場合、「0」で返す
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 文字列からLong型にデータ変換
    ''' </summary>
    ''' <param name="strVal">元の文字列</param>
    ''' <returns>変換後データ</returns>
    Public Shared Function StringToLong(ByVal strVal As String) As Long
        Try
            Dim longVal As Long
            ' TryParseでLong型に変換
            Dim result As Boolean = Long.TryParse(strVal, longVal)

            ' ParseでLong型に変換
            Return longVal

        Catch ex As Exception
            ' 例外発生の場合、「0」で返す
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 文字列からDecimal型にデータ変換
    ''' </summary>
    ''' <param name="strVal">元の文字列</param>
    ''' <returns>変換後データ</returns>
    Public Shared Function StringToDecimal(ByVal strVal As String) As Decimal
        Try
            Dim deciVal As Decimal
            ' TryParseでDecimal型に変換
            Dim result As Boolean = Decimal.TryParse(strVal, deciVal)

            ' ParseでInteger型に変換
            Return deciVal

        Catch ex As Exception
            ' 例外発生の場合、「0」で返す
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 文字列から通貨型にデータ変換
    ''' </summary>
    ''' <param name="prmStr">文字列</param>
    ''' <param name="prmDP">小数点桁数</param>
    ''' <returns>変換後データ</returns>
    Public Shared Function StringToMoney(ByVal prmStr As String,
                                       ByVal prmDP As Integer) As String

        Dim strTemp As String = String.Empty

        Select Case prmDP
            Case 0
                strTemp = StringToDecimal(prmStr).ToString("#,##0")
            Case 1
                strTemp = StringToDecimal(prmStr).ToString("#,##0.0")
            Case 2
                strTemp = StringToDecimal(prmStr).ToString("#,##0.00")
            Case 3
                strTemp = StringToDecimal(prmStr).ToString("#,##0.000")
        End Select

        Return strTemp

    End Function


    Public Shared Function ComSearchType2Text(SearchType As typExtraction) As String
        Dim Extraction As String = String.Empty

        Select Case SearchType
            Case typExtraction.EX_EQ
                Extraction = " = "
            Case typExtraction.EX_GT
                Extraction = " > "
            Case typExtraction.EX_GTE
                Extraction = " >= "
            Case typExtraction.EX_LT
                Extraction = " < "
            Case typExtraction.EX_LTE
                Extraction = " <= "
            Case typExtraction.EX_NEQ
                Extraction = " <> "
            Case typExtraction.EX_LIK _
      , typExtraction.EX_LIKF _
      , typExtraction.EX_LIKB
                Extraction = " LIKE "
        End Select

        Return Extraction
    End Function

    Public Shared Function ComGetLiteralChar(DataType As typColumnKind _
                                  , Provider As typProvider) As String
        Dim LiteralChar As String = String.Empty

        Select Case DataType
            Case typColumnKind.CK_Date
                ' 日付形式
                Select Case Provider
                    Case typProvider.sqlServer
                        LiteralChar = "'"
                    Case typProvider.Accdb
                        LiteralChar = "#"
                    Case typProvider.Mdb
                        LiteralChar = "#"
                End Select
            Case typColumnKind.CK_Number
                ' 数値
                LiteralChar = ""
            Case typColumnKind.CK_Text
                ' 文字列
                LiteralChar = "'"
        End Select

        Return LiteralChar
    End Function

    Public Shared Function ComGetProcDay() As String
        Return Date.Parse(ComGetProcTime()).ToString("dd")
    End Function

    Public Shared Function ComGetProcYear() As String
        Return Date.Parse(ComGetProcTime()).ToString("yyyy")
    End Function

    Public Shared Function ComGetProcYearMonth() As String
        Return Date.Parse(ComGetProcTime()).ToString("yyyy/MM")
    End Function

    '-------------------------------------------------
    ' 関数名：ComGetProcDate
    ' 機　能：データベースより現在日付けを取得する
    ' 戻り値：現在日付(yyyy/mm/dd形式)
    ' 引  数：無し
    ' 作  成：2021/01/10 shiomitsu.T
    '-------------------------------------------------
    Public Shared Function ComGetProcDate() As String
        ComGetProcDate = Date.Parse(ComGetProcTime()).ToString("yyyy/MM/dd")
    End Function

    '-------------------------------------------------
    ' 関数名：ComGetProcTime
    ' 機　能：データベースより現在時刻を取得する
    ' 戻り値：現在時刻(yyyy/mm/dd hh:mm:ss)
    ' 引  数：無し
    ' 作  成：2021/01/01 shiomitsu.T
    '-------------------------------------------------

    ''' <summary>
    ''' 現在日時を取得
    ''' </summary>
    ''' <returns>yyyy/MM/dd HH:mm:ss形式</returns>
    ''' <remarks>
    ''' SQL-Serverより取得
    ''' </remarks>
    Public Shared Function ComGetProcTime() As String
        Dim mainDatabase As New clsSqlServer
        Dim tmpDt As New DataTable

        Try
            Call mainDatabase.GetResult(tmpDt, "SELECT GETDATE() ", True)
        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception("現在時刻の取得に失敗しました")
        Finally
            mainDatabase.Dispose()
        End Try


        Return tmpDt.Rows(0).Item(0).ToString()
    End Function

    Public Shared Sub ComStartPrg(prmPrgId As String _
                                , prmMainForm As Form _
                                , Optional prmActRedisplay As Action(Of String) = Nothing)

        'Mutex名を決める（必ずアプリケーション固有の文字列に変更すること！）
        Dim mutexName As String = prmPrgId
        'Mutexオブジェクトを作成する
        Dim createdNew As Boolean
        Dim mutex As New System.Threading.Mutex(True, mutexName, createdNew)

        'ミューテックスの初期所有権が付与されたか調べる
        If createdNew = False Then
            'されなかった場合は、すでに起動していると判断して、再表示メッセージ送信関数起動
            If prmActRedisplay IsNot Nothing Then
                Call prmActRedisplay(prmPrgId)
            End If

            mutex.Close()
            Return
        End If

        Try
            Application.Run(prmMainForm)
        Catch ex As Exception
            Call ComWriteErrLog(ex, False)
        Finally
            'ミューテックスを解放する
            mutex.ReleaseMutex()
            mutex.Close()
        End Try

    End Sub

    ''' <summary>
    ''' 非表示状態のExeに再起動メッセージを送信する
    ''' </summary>
    ''' <param name="prmPrgId">IPC識別子</param>
    Public Shared Sub ComRedisplay(prmPrgId As String)
        '既存のリモートIPCオブジェクトへの参照を取得する
        Dim strURL As String = "ipc://" & prmPrgId & "/" + GetType(clsIpcService).Name
        Dim objRemote As Object = Activator.GetObject(GetType(clsIpcService), strURL)

        'サーバとの共通クラスの参照(ServiceClass)
        Dim objServiceClass As clsIpcService = CType(objRemote, clsIpcService)
        '共有参照クラスのイベント生成メソッド呼び出し
        objServiceClass.RaiseServerEvent("既に起動しています")

    End Sub

    Private Shared Function GetControlBaseTypeName(prmType As Type, prmTargetBaseTypeName As String) As String
        Dim ctrlName As String = prmType.Name

        If prmType.BaseType.Name.ToLower() <> prmTargetBaseTypeName.ToLower() _
      AndAlso prmType.BaseType.Name.ToLower() <> "Control".ToLower() Then
            ctrlName = GetControlBaseTypeName(prmType.BaseType, prmTargetBaseTypeName)
        End If

        Return ctrlName
    End Function

    ' コントロール一覧を返す
    Public Shared Function ComGetAllControls(ByVal prmTopObject As Control) As Control()
        Dim buf As ArrayList = New ArrayList
        For Each c As Control In prmTopObject.Controls
            buf.Add(c)
            buf.AddRange(ComGetAllControls(c))
        Next
        Return CType(buf.ToArray(GetType(Control)), Control())
    End Function

    ''' <summary>
    ''' ログファイル出力
    ''' </summary>
    ''' <param name="desc">出力内容</param>
    ''' <param name="filePath">出力ファイルフルパス</param>
    Public Shared Sub ComWriteLog(ByVal desc As String, ByVal filePath As String)
        '---
        On Error Resume Next

        '---
        Dim strWr As System.IO.StreamWriter = New System.IO.StreamWriter(filePath, True)
        ''---
        strWr.WriteLine(desc)
        strWr.Close()
        strWr.Dispose()
        strWr = Nothing
        '---
        On Error GoTo 0
        '---
    End Sub

    'エラーログファイルを出力(文字列出力)
    Public Shared Sub ComWriteErrLog(ByVal strMsg As String,
                                   Optional ByVal filePath As String = "")

        '---
        'エラーログファイルパスを設定（指定がない場合のみ）
        If filePath = "" Then filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "err.log")
        '---

        Call ComWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:") & strMsg, filePath)

    End Sub

    'エラーログファイルを出力
    Public Shared Sub ComWriteErrLog(ByVal ex As Exception,
                           Optional ByVal chkNoMsg As Boolean = True, Optional ByVal filePath As String = "")

        Dim tmpExeFileName As String = System.IO.Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)

        '---
        'エラーログファイルパスを設定（指定がない場合のみ）
        If filePath = "" Then filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "err.log")
        '---
        If chkNoMsg = False Then MsgBox(ex.Message)
        Call ComWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") _
                     & ":Exe:" & tmpExeFileName _
                     & "：Source：" & ex.Source _
                     & "：Method：" & ex.TargetSite.Name _
                     & "：Description：" & ex.Message, filePath)
    End Sub

    ''' <summary>
    ''' メッセージボックスを表示
    ''' </summary>
    ''' <param name="msg">表示するメッセージ</param>
    ''' <param name="title">表示するタイトル</param>
    ''' <param name="type">表示する種類（通常・警告・異常）</param>
    ''' <param name="typeButton">表示するボタン</param>
    ''' <returns>押下したボタン情報</returns>
    Public Shared Function ComMessageBox(msg As String _
                                       , title As String _
                                       , type As typMsgBox _
                                       , Optional typeButton As typMsgBoxButton = typMsgBoxButton.BUTTON_OK _
                                       , Optional prmDefaultButton As MessageBoxDefaultButton? = Nothing) As typMsgBoxResult

        Dim typMsgBtn As MessageBoxButtons
        Dim numButton As Integer

        'メッセージボックスに表示するボタンを定義する定数を指定
        Select Case (typeButton)
            Case typMsgBoxButton.BUTTON_OK
                typMsgBtn = MessageBoxButtons.OK
                numButton = 1
            Case typMsgBoxButton.BUTTON_ABORTRETRYIGNORE
                typMsgBtn = MessageBoxButtons.AbortRetryIgnore
                numButton = 3
            Case typMsgBoxButton.BUTTON_OKCANCEL
                typMsgBtn = MessageBoxButtons.OKCancel
                numButton = 2
            Case typMsgBoxButton.BUTTON_YESNOCANCEL
                typMsgBtn = MessageBoxButtons.YesNoCancel
                numButton = 3
            Case typMsgBoxButton.BUTTON_YESNO
                typMsgBtn = MessageBoxButtons.YesNo
                numButton = 2
            Case typMsgBoxButton.BUTTON_YESNO_DEFAULT_YES
                typMsgBtn = MessageBoxButtons.YesNo
                numButton = 1
            Case typMsgBoxButton.BUTTON_RETRYCANCEL
                typMsgBtn = MessageBoxButtons.RetryCancel
                numButton = 2
        End Select

        '始めにフォーカスのあるボタンの設定
        Dim defaultFocus As MessageBoxDefaultButton
        If prmDefaultButton IsNot Nothing Then
            defaultFocus = prmDefaultButton
        Else
            Select Case (numButton)
                Case 1
                    defaultFocus = MessageBoxDefaultButton.Button1
                Case 2
                    defaultFocus = MessageBoxDefaultButton.Button2
                Case 3
                    defaultFocus = MessageBoxDefaultButton.Button3
            End Select
        End If

        Dim result As DialogResult

        'メッセージボックスを表示
        Select Case (type)
      '通常
            Case typMsgBox.MSG_NORMAL
                result = MessageBox.Show(msg,
                                 title,
                                 typMsgBtn,
                                 MessageBoxIcon.Information,
                                 defaultFocus)
      '警告
            Case typMsgBox.MSG_WARNING
                result = MessageBox.Show(msg,
                                 title,
                                 typMsgBtn,
                                 MessageBoxIcon.Warning,
                                 defaultFocus)
      '異常　
            Case typMsgBox.MSG_ERROR
                result = MessageBox.Show(msg,
                                 title,
                                 typMsgBtn,
                                 MessageBoxIcon.Error,
                                 defaultFocus)
        End Select

        'メッセージボックスで押したボタンの戻り値を設定
        Dim typMsgResult As typMsgBoxResult = typMsgBoxResult.RESULT_NONE
        Select Case result
            Case DialogResult.None
                typMsgResult = typMsgBoxResult.RESULT_NONE
            Case DialogResult.OK
                typMsgResult = typMsgBoxResult.RESULT_OK
            Case DialogResult.Cancel
                typMsgResult = typMsgBoxResult.RESULT_CANCEL
            Case DialogResult.Abort
                typMsgResult = typMsgBoxResult.RESULT_ABORT
            Case DialogResult.Retry
                typMsgResult = typMsgBoxResult.RESULT_RETRY
            Case DialogResult.Ignore
                typMsgResult = typMsgBoxResult.RESULT_IGNORE
            Case DialogResult.Yes
                typMsgResult = typMsgBoxResult.RESULT_YES
            Case DialogResult.No
                typMsgResult = typMsgBoxResult.RESULT_NO
        End Select

        Return typMsgResult

    End Function

    ''' <summary>
    ''' 文字列が数値かどうか判定
    ''' </summary>
    ''' <param name="str">数値かどうか判定する文字列</param>
    ''' <returns>
    ''' True :数値である
    ''' False:数値でない
    ''' </returns>
    Public Shared Function ComChkNumeric(str As String) As Boolean

        Dim flag As Boolean = True
        Dim c As Char

        For Each c In str
            '数字以外の文字が含まれているか調べる
            If c < "0"c OrElse "9"c < c Then
                flag = False
                Exit For
            End If
        Next

        Return flag

    End Function


    ''' <summary>
    ''' 読み取り専用の属性を解除するメソッド
    ''' </summary>
    ''' <param name="strFileName">ファイル名</param>
    Public Shared Sub ReleaseReadOnly(strFileName As String)

        Try
            '対象ファイルの属性をオブジェクト化
            Dim fas As FileAttributes = File.GetAttributes(strFileName)
            ' 読み取り専用かどうか確認
            If (fas And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                ' ファイル属性から読み取り専用を削除
                fas = fas And Not FileAttributes.ReadOnly

                ' ファイル属性を設定
                File.SetAttributes(strFileName, fas)
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    ''' <summary>
    ''' スレッドの引数
    ''' </summary>
    Class prmReport
        Public ReadOnly printPreview As String      'プレビューフラグ
        Public ReadOnly strReportName As String     'レポートファイル名

        Sub New(preview As String, fileName As String)
            Me.printPreview = preview
            Me.strReportName = fileName
        End Sub
    End Class

    ''' <summary>
    ''' ACCESSファイルを開く
    ''' </summary>
    ''' <param name="printPreview">プレビューフラグ</param>
    ''' <param name="strReportName">レポートファイル名</param>
    ''' <returns>
    ''' True :ファイルオープン成功
    ''' False:ファイルオープン失敗
    ''' </returns>
    Public Shared Function ComAccessRun(printPreview As Integer, strReportName As String,
         Optional prmWatiFla As Boolean = False) As Boolean
        Try

            ' プロセス強制終了時、印刷処理を行わないようにする
            'If (procesEndFlg) Then
            '  Return True
            'End If

            ' Threadオブジェクトを作成する
            Dim MultiProgram_run = New System.Threading.Thread(AddressOf DoSomething01)
            ' １つ目のスレッドを開始する
            MultiProgram_run.Start(New prmReport(printPreview.ToString, strReportName))

            If (prmWatiFla) Then
                MultiProgram_run.Join()
            End If

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' 印刷スレッド
    ''' </summary>
    ''' <param name="arg"></param>
    Private Shared Sub DoSomething01(arg As Object)

        Dim prm As prmReport = DirectCast(arg, prmReport)
        Dim myPath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, clsGlobalData.REPORT_FILENAME)

        Dim strPrintPrwview As String
        If (prm.printPreview.Equals("1")) Then
            strPrintPrwview = "1"
        Else
            strPrintPrwview = "0"
        End If
        Try

            'ファイルを開く
            procesID = System.Diagnostics.Process.Start(myPath, " /runtime /cmd " & strPrintPrwview & prm.strReportName)

            If procesID IsNot Nothing Then
                '終了するまで待機する
                procesID.WaitForExit()
                procesID = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' プロセスの終了
    ''' </summary>
    Public Shared Sub ProcessKill()


        procesEndFlg = True

        If procesID IsNot Nothing Then
            ' 起動した１つ目のプロセスの終了
            procesID.Kill()
            procesID = Nothing
        End If

    End Sub

    ''' <summary>
    ''' プロセス状態確認
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ProcessStatus() As Boolean

        Dim ret As Boolean = False

        If procesID IsNot Nothing Then
            ret = True
        End If

        Return ret

    End Function

    ''' <summary>
    ''' 指定された文字列を含むウィンドウタイトルを持つプロセスをアクティブにする
    ''' </summary>
    ''' <param name="windowTitle">ウィンドウタイトルに含む文字列。</param>
    Public Shared Sub ProcessActiveByWindowTitle(windowTitle As String)

        'すべてのプロセスを列挙する
        Dim p As System.Diagnostics.Process
        For Each p In System.Diagnostics.Process.GetProcesses()
            '指定された文字列がメインウィンドウのタイトルに含まれているか調べる
            If 0 <= p.MainWindowTitle.IndexOf(windowTitle) Then
                'ウィンドウをアクティブにする
                SetForegroundWindow(p.MainWindowHandle)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 加工賃部位コードを除外するSQL文作成
    ''' </summary>
    ''' <returns>SQL文</returns>
    Public Shared Function SetSqlWageCode() As String

        Dim sql As String = String.Empty

        Dim chkNULL As Boolean = True
        For i = 0 To clsGlobalData.listWageCode.Length - 1
            If String.IsNullOrWhiteSpace(clsGlobalData.listWageCode(i).ToString()) Then
                chkNULL = False
            End If
        Next i

        If chkNULL Then
            ' 加工賃部位コードは対象から除外する
            sql = "   AND  CUTJ.BICODE NOT IN (" & String.Join(",", clsGlobalData.listWageCode) & ")"
        End If

        Return sql

    End Function

    ''' <summary>
    ''' 特定の得意先コードと商品コードを除外もしくは内包するSQL文作成
    ''' </summary>
    ''' <returns>SQL文</returns>
    Public Shared Function SetSqlTkCodeHani() As String

        Dim sql As String = String.Empty

        'sql = "   AND (CUTJ.TKCODE = 7015 "
        'sql &= "   OR  (CUTJ.TKCODE <= 7004 OR CUTJ.TKCODE > 7050) "
        'sql &= "   OR  (CUTJ.TKCODE > 7004 AND CUTJ.TKCODE <= 7050 AND (CUTJ.SHOHINC % 10000) < 7100)) "


        Return sql

    End Function

    ''' <summary>
    ''' INSERTのSQL文作成
    ''' </summary>
    ''' <param name="prmtable">テーブル名</param>
    ''' <param name="prmKeyVal">編集コントロールの値を保持する連想配列</param>
    ''' <returns></returns>

    Public Shared Function SqlInsert(prmtable As String,
                                   prmKeyVal As Dictionary(Of String, String)) As String

        Dim sql As String = String.Empty
        Dim tmpDst As String = String.Empty
        Dim tmpVal As String = String.Empty

        For Each tmpKey As String In prmKeyVal.Keys
            tmpDst = tmpDst & tmpKey & " ,"
            tmpVal = tmpVal & prmKeyVal(tmpKey) & " ,"
        Next
        tmpDst = tmpDst.Substring(0, tmpDst.Length - 1)
        tmpVal = tmpVal.Substring(0, tmpVal.Length - 1)

        sql &= "INSERT INTO " & prmtable
        sql &= "           (" & tmpDst & ")"
        sql &= "    VALUES (" & tmpVal & ")"

        Return sql

    End Function

    ''' <summary>
    ''' UPDATEのSQL文作成
    ''' </summary>
    ''' <param name="prmtable">テーブル名</param>
    ''' <param name="prmKeyVal">編集コントロールの値を保持する連想配列</param>
    ''' <param name="prmWhere">抽出条件</param>
    ''' <returns></returns>
    Public Shared Function SqlUpdate(prmtable As String,
                                   prmKeyVal As Dictionary(Of String, String),
                                   prmWhere As String) As String

        Dim sql As String = String.Empty
        Dim tmpDst As String = String.Empty

        sql &= " UPDATE " & prmtable
        sql &= " SET "

        For Each tmpKey As String In prmKeyVal.Keys
            sql &= tmpKey & "=" & prmKeyVal(tmpKey) & " ,"
        Next

        ' 最終のカンマを削除
        sql = sql.Substring(0, sql.Length - 1)

        ' 抽出条件を設定
        sql &= prmWhere


        Return sql

    End Function

    ''' <summary>
    ''' DELETEのSQL文作成(物理削除)
    ''' </summary>
    ''' <param name="prmtable">テーブル名</param>
    ''' <param name="prmWhere">抽出条件</param>
    ''' <returns></returns>
    Public Shared Function SqlDelete(prmtable As String,
                                   prmWhere As String) As String

        Dim sql As String = String.Empty

        sql &= " DELETE FROM " & prmtable

        ' 抽出条件を設定
        sql &= prmWhere


        Return sql

    End Function

    ''' <summary>
    ''' 文字列を指定バイト数内に切り詰める
    ''' </summary>
    ''' <param name="prmTargetText">対象の文字列</param>
    ''' <param name="prmLimit">指定バイト数</param>
    ''' <returns>切り詰めた文字列</returns>
    ''' <remarks>
    ''' 全角/半角混在の場合は指定バイトより短くなる場合があります
    ''' </remarks>
    Public Shared Function ShrinkNvarCharText(prmTargetText As String, prmLimit As Integer) As String

        Dim tempLen As Integer = Len(prmTargetText)

        ' 引数チェック
        If prmLimit < 0 OrElse prmTargetText.Length <= 0 Then
            Return ""
        End If

        ' 文字列が指定の文字数未満の場合は、入力をそのまま返す
        If tempLen <= prmLimit Then
            Return prmTargetText
        End If

        Dim strTemp As String = prmTargetText.Substring(prmLimit)

        Return strTemp

    End Function

    ''' <summary>
    ''' 文字列を指定バイト数内に切り詰める
    ''' </summary>
    ''' <param name="prmTargetText">対象の文字列</param>
    ''' <param name="prmLimit">指定バイト数</param>
    ''' <returns>切り詰めた文字列</returns>
    ''' <remarks>
    ''' 全角/半角混在の場合は指定バイトより短くなる場合があります
    ''' </remarks>
    Public Shared Function ShrinkText(prmTargetText As String, prmLimit As Integer) As String

        Dim sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim tempLen As Integer = sjis.GetByteCount(prmTargetText)

        ' 引数チェック
        If prmLimit < 0 OrElse prmTargetText.Length <= 0 Then
            Return ""
        End If

        ' 文字列が指定のバイト数未満の場合は、入力をそのまま返す
        If tempLen <= prmLimit Then
            Return prmTargetText
        End If

        Dim bytTemp As Byte() = sjis.GetBytes(prmTargetText)
        Dim strTemp As String = sjis.GetString(bytTemp, 0, prmLimit)

        ' 末尾の漢字が分断されたらバイト数-1で切り取る (VB2005="・"、.NET2003=NullChar）
        If strTemp.EndsWith(ControlChars.NullChar) OrElse strTemp.EndsWith("・") Then
            strTemp = sjis.GetString(bytTemp, 0, prmLimit - 1)
        End If

        Return strTemp

    End Function

    ''' <summary>
    ''' 2つのDictionaryの完全一致判定
    ''' </summary>
    ''' <param name="prmKeyVal1">編集コントロールの値を保持する連想配列その１</param>
    ''' <param name="prmKeyVal2">編集コントロールの値を保持する連想配列その２</param>
    ''' <returns></returns>
    Public Shared Function equalsDictionary(prmKeyVal1 As Dictionary(Of String, String),
                                          prmKeyVal2 As Dictionary(Of String, String)) As Boolean


        Return (prmKeyVal1.OrderBy(Function(o) o.Key).SequenceEqual(prmKeyVal2.OrderBy(Function(o) o.Key)))

    End Function

    ''' <summary>
    ''' 左のマージンを設定する
    ''' </summary>
    ''' <param name="prmHandle">コントロールハンドル</param>
    ''' <param name="prmMargin">マージン幅</param>
    Public Shared Sub SetLeftMargin(prmHandle As IntPtr,
                                  prmMargin As Integer)

        SendMessage(prmHandle, EM_SETMARGINS, EC_LEFTMARGIN, prmMargin)

    End Sub

    ''' <summary>
    ''' 左右のマージンを設定する
    ''' </summary>
    ''' <param name="prmControl">コントロール</param>
    ''' <param name="prmMargin">マージン幅</param>
    Public Shared Sub SetLeftRightMargin(prmControl As Control,
                                       prmMargin As Integer)

        ' 指定したコントロールの編集領域のマージン設定
        SendMessage(prmControl.Handle, EM_SETMARGINS, EC_RIGHTMARGIN Or EC_LEFTMARGIN, prmMargin)
        ' コンボボックスの場合
        If IsComboBox(prmControl) Then
            ' コンボボックスの編集領域のマージン設定
            Dim TexthWnd = FindWindowEx(prmControl.Handle, 0, "EDIT", vbNullString)
            SendMessage(TexthWnd, EM_SETMARGINS, EC_LEFTMARGIN, prmMargin)
        End If

    End Sub

    ''' <summary>
    ''' 左のマージンを設定する
    ''' </summary>
    ''' <param name="prmControl">コントロール</param>
    ''' <param name="prmMargin">マージン幅</param>
    Public Shared Sub SetComboLeftMargin(prmControl As Control,
                                       prmMargin As Integer)

        ' 指定したコントロールの編集領域のマージン設定
        SendMessage(prmControl.Handle, EM_SETMARGINS, EC_LEFTMARGIN, prmMargin)
        ' コンボボックスの場合
        If IsComboBox(prmControl) Then
            ' コンボボックスの編集領域のマージン設定
            Dim TexthWnd = FindWindowEx(prmControl.Handle, 0, "EDIT", vbNullString)
            SendMessage(TexthWnd, EM_SETMARGINS, EC_LEFTMARGIN, prmMargin)
        End If

    End Sub

    ''' <summary>
    ''' コントロール(子コントロールも含む)の描画を停止します
    ''' </summary>
    ''' <param name="prmControl"></param>
    Public Shared Sub BeginUpdate(prmControl As Control)

        SendMessage(New HandleRef(prmControl, prmControl.Handle), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)

    End Sub

    ''' <summary>
    ''' コントロール(子コントロールも含む)の描画を開始します
    ''' </summary>
    ''' <param name="prmControl"></param>
    Public Shared Sub EndUpdate(prmControl As Control)

        SendMessage(New HandleRef(prmControl, prmControl.Handle), WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
        prmControl.Refresh()

    End Sub

    ''' <summary>
    ''' 税区分の情報設定
    ''' </summary>
    Public Shared Function DicTax() As Dictionary(Of String, String)

        ' Dictionaryにデータを追加
        Dim retVal As New Dictionary(Of String, String)
        retVal("0") = ""
        retVal("1") = "外税"
        retVal("2") = "内税"
        retVal("3") = "非"

        Return retVal

    End Function

    ''' <summary>
    ''' 定貫の情報設定
    ''' </summary>
    Public Shared Function DicConstant() As Dictionary(Of String, String)

        ' Dictionaryにデータを追加
        Dim retVal As New Dictionary(Of String, String)
        retVal("0") = "定貫"
        retVal("1") = "不定貫"

        Return retVal

    End Function

    ' ------------------------------------------------------
    ' ini ファイル読み込み
    ' ------------------------------------------------------
    '指定のIniファイルの指定キーの値を取得(文字列)
    ' AUTO版 GetPrivateProfileString
    Public Declare Auto Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileString" (
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpReturnedString As StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpFileName As String) As UInt32

    'プロファイル文字列書込み  
    Private Declare Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String,
         ByVal lpString As String, ByVal lpFileName As String) As Long

    ''' <summary>
    ''' iniファイルから取得する
    ''' </summary>
    ''' <param name="lpAppName"></param>
    ''' <param name="lpKeyName"></param>
    ''' <param name="strPath"></param>
    ''' <returns></returns>
    Public Shared Function GetIniString(ByVal lpAppName As String, ByVal lpKeyName As String, strPath As String) As String

        Dim sb As StringBuilder = New StringBuilder(256)

        Try
            Call GetPrivateProfileString(lpAppName, lpKeyName, "", sb, Convert.ToUInt32(sb.Capacity), strPath)

            Return sb.ToString
        Catch ex As Exception
            Return sb.ToString
        End Try
    End Function

    ''' <summary>
    ''' iniファイルに書き込む
    ''' </summary>
    ''' <param name="lpAppName"></param>
    ''' <param name="lpKeyName"></param>
    ''' <param name="lpValue"></param>
    ''' <param name="strPath"></param>
    ''' <returns></returns>
    Public Shared Function PutIniString(ByVal lpAppName As String, lpKeyName As String, ByVal lpValue As String, ByVal strPath As String) As Boolean

        Dim result As Long = 0

        Try
            result = WritePrivateProfileString(lpAppName, lpKeyName, lpValue, strPath)
            Return result <> 0
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' 印刷確認ファイルの削除
    ''' </summary>
    Public Shared Sub DeletePrintLogFile()

        Try
            '自分自身の存在するフォルダ  
            Dim strPath As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

            ' 印刷確認ファイル名作成  
            Dim printFile As String = System.IO.Path.Combine(strPath, "Print.log")

            ' ファイルの存在有無確認
            If System.IO.File.Exists(printFile) Then
                ' 読み取り禁止の場合、解除する
                clsCommonFnc.ReleaseReadOnly(printFile)
                'ファイルを削除
                Dim fi As New System.IO.FileInfo(printFile)
                fi.Delete()
            End If

            ' 印刷確認ファイル名作成  
            printFile = System.IO.Path.Combine(strPath, "Success.log")

            ' ファイルの存在有無確認
            If System.IO.File.Exists(printFile) Then
                ' 読み取り禁止の場合、解除する
                clsCommonFnc.ReleaseReadOnly(printFile)
                'ファイルを削除
                Dim fi As New System.IO.FileInfo(printFile)
                fi.Delete()
            End If

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception("印刷確認ファイルの削除に失敗しました。")

        End Try

    End Sub

    ''' <summary>
    ''' 印刷確認ファイルの確認
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ChkPrintLogFile() As Boolean

        Dim ret As Boolean = False

        Try
            ' 自分自身の存在するフォルダ  
            Dim strPath As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

            ' 印刷確認ファイル名作成  
            Dim printFile As String = System.IO.Path.Combine(strPath, "Print.log")

            'ファイルの存在有無確認
            If System.IO.File.Exists(printFile) Then
                ret = True
            End If

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception("印刷確認ファイルの確認に失敗しました。")

        End Try

        Return ret

    End Function

    ''' <summary>
    ''' 印刷処理正常終了確認ファイルの確認
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ChkPrintSuccessLogFile() As Boolean

        Dim ret As Boolean = False

        Try
            ' 自分自身の存在するフォルダ  
            Dim strPath As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

            ' 印刷処理正常終了確認ファイル名作成  
            Dim printFile As String = System.IO.Path.Combine(strPath, "Success.log")

            'ファイルの存在有無確認
            If System.IO.File.Exists(printFile) Then
                ret = True
            End If

        Catch ex As Exception
            Call ComWriteErrLog(ex)
            Throw New Exception("印刷処理正常終了確認ファイルの確認に失敗しました。")

        End Try

        Return ret

    End Function


    ''' <summary>
    ''' 印刷ログ出力のSQL文の作成
    ''' </summary>
    ''' <param name="prmKbn"></param>
    ''' <param name="prmStatus">True:成功,False:失敗</param>
    ''' <returns>作成したSQL文</returns>
    Public Shared Function SqlnsertPrintLog(prmKbn As Integer,
                                    prmSalesNo As String,
                                    prmfullAssemblyNmae As String,
                                    prmReportName As String,
                                    prmStatus As String) As String
        Dim sql As String = String.Empty

        ' 初期設定
        Dim tmpProcTime As String = ComGetProcTime()
        '文字列をDateTime値に変換する
        Dim dt As DateTime = DateTime.Parse(tmpProcTime)

        sql &= " INSERT LOG_PRINT "
        sql &= " (KUBUN, "             ' 納品書区分
        sql &= "  KUBUN_NAME, "        ' 納品書区分名
        sql &= "  SALES_NUMBER, "      ' 伝票番号
        sql &= "  PC_NAME, "           ' コンピューター名
        sql &= "  REPORT_NAME, "       ' レポート名
        sql &= "  PROGRAM_NAME, "      ' プログラム名
        sql &= "  STATUS, "            ' 成功/失敗
        sql &= "  ENTRY_DATE "         ' 登録日
        sql &= " ) VALUES "

        sql &= "("

        If (prmKbn = 1) Then
            ' 自社納品書
            sql &= "'10', "
            sql &= "'納品書', "
        ElseIf (prmKbn = 2) Then
            ' 出荷明細書（金額なし)
            sql &= "'90', "
            sql &= "'出荷明細書', "
        ElseIf (prmKbn = 3) Then
            ' 出荷明細書（金額あり）
            sql &= "'91', "
            sql &= "'出荷明細書（金額あり）', "
        End If

        '伝票番号
        sql &= prmSalesNo & ","
        ' コンピューター名
        sql &= "'" & System.Net.Dns.GetHostName() & "',"
        ' レポート名
        sql &= "'" & prmReportName & "',"

        'アセンブリ名のみを取得
        Dim assemblyName = System.IO.Path.GetFileName(prmfullAssemblyNmae)
        ' プログラム名
        sql &= "'" & assemblyName & "',"
        ' 成功/失敗
        sql &= "'" & prmStatus.ToString & "',"
        ' 登録日
        sql &= "'" & dt.ToString("yyyy/MM/dd HH:mm:ss") & "'"

        sql &= ")"

        Return sql
    End Function

    ''' <summary>
    ''' 印刷件数チェック
    ''' </summary>
    ''' <param name="prmCount"></param>
    ''' <param name="prmTitle"></param>
    ''' <returns></returns>
    Public Shared Function ComChkPrint(prmCount As Integer,
                                     prmTitle As String) As Boolean

        Dim rtn As typMsgBoxResult
        Dim ret As Boolean = False

        rtn = ComMessageBox("出力するデータが" & prmCount.ToString & "件あります。" & vbCrLf & vbCrLf & "印刷してもよろしいですか？" _
      , prmTitle _
      , typMsgBox.MSG_NORMAL _
      , typMsgBoxButton.BUTTON_YESNO)

        ' 確認メッセージボックスで、NOボタン選択時
        If rtn = typMsgBoxResult.RESULT_NO Then
            ret = True
        End If

        Return ret

    End Function
End Class
