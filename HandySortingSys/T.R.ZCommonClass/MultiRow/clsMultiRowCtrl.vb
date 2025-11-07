Imports T.R.ZCommonClass.clsDataRepeater
''' <summary>
''' MultiRowコントロールクラス
''' </summary>
''' <remarks>
''' </remarks>
Public Class clsMultiRowCtrl

#Region "プロパティー"

  ''' <summary>
  ''' 型
  ''' </summary>
  ''' <returns></returns>
  Public Property Type As typDataTable

  ''' <summary>
  ''' 下部メッセージ
  ''' </summary>
  ''' <returns></returns>
  Public Property MsgLabel As String

  ''' <summary>
  ''' カラム名
  ''' </summary>
  ''' <returns></returns>
  Public Property ColumName As String

  ''' <summary>
  ''' ダブルクリックイベント実行有無フラグ
  ''' </summary>
  ''' <returns></returns>
  Public Property UseDoubleClick As Boolean

  ''' <summary>
  ''' コンボコントロールＳＱＬ文
  ''' </summary>
  ''' <returns></returns>
  Public Property cmbControl As Boolean

  ''' <summary>
  ''' コンボコントロール有無
  ''' </summary>
  ''' <returns></returns>
  Public Property sql As String

  ''' <summary>
  ''' コンボコントロール項番
  ''' </summary>
  ''' <returns></returns>
  Public Property tabIndex As Integer


#End Region

#Region "コンストラクタ"

  ''' <summary>
  ''' 初期処理
  ''' </summary>
  ''' <param name="prmType"></param>
  ''' <param name="prmMsgLabel"></param>
  ''' <param name="prmColumName"></param>
  ''' <param name="prmUseDoubleClick"></param>
  Public Sub New(ByVal prmType As typDataTable,
                 ByVal prmMsgLabel As String,
                 ByVal prmColumName As String,
                 ByVal prmUseDoubleClick As Boolean,
                 ByVal prmRTabIndex As Integer)

    Type = prmType
    MsgLabel = prmMsgLabel
    ColumName = prmColumName
    UseDoubleClick = prmUseDoubleClick
    sql = String.Empty
    cmbControl = False
    tabIndex = prmRTabIndex

  End Sub

#End Region

End Class
