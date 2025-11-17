''' <summary>
''' データグリッドセレクタークラス
''' </summary>
''' <remarks>
''' データグリッドダブルクリック時のチェックマーク表示に使用
''' clsDataGridのコンストラクターで設定することで動作
''' </remarks>
Public Class clsDataGridSelecter

#Region "プロパティー"

  ''' <summary>
  ''' 選択行キー項目
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>
  ''' 選択状態を決定するキー項目を設定
  ''' ex)
  '''   List(Of String)({"KOTAINO","BUICODE"})
  '''   → 選択行（ダブルクリックで指定）と"KOTAINO","BUICODE"が同一の行も選択マークが表示される
  '''      ※選択行を1行に限定したい場合は行単位でユニークになる項目を全て設定すること
  ''' </remarks>
  Public Property SelectKeyList As List(Of String)

  ''' <summary>
  ''' セル幅
  ''' </summary>
  ''' <returns></returns>
  Public Property ColumnWidth As Integer

  ''' <summary>
  ''' 選択時表示文字
  ''' </summary>
  ''' <returns></returns>
  Public Property SelectChar As String

  ''' <summary>
  ''' 選択セルデータソース名
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>
  '''  基本的には変更不要
  '''  他の表示項目と名称がかぶる場合のみ変更して下さい
  ''' </remarks>
  Public Property DataSourcName As String

  ''' <summary>
  ''' 表示位置
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>0始まり</remarks>
  Public Property ColIndex As Integer

  ''' <summary>
  ''' 選択可能条件
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>
  '''   Key(DataSource)の値がVALUEのレコードを選択可能とする
  '''   SelectingCondition([DataSource],[VALUE])
  ''' </remarks>
  Public Property SelectingCondition As Dictionary(Of String, String)

  ''' <summary>
  ''' 選択可能最大数
  ''' </summary>
  ''' <returns></returns>
  Public Property MaxSelectedCount As Long

  ''' <summary>
  ''' チェック動作
  ''' </summary>
  ''' <returns></returns>
  Public Property ClickAction As typClickAction

  ''' <summary>
  ''' チェック変更後画面更新有無
  ''' </summary>
  ''' <returns></returns>
  Public Property Reload As Boolean
#End Region

  Public Enum typClickAction
    Single_Click
    Double_CLick
  End Enum

#Region "コンストラクタ"
  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmSelectKeyList">選択行キー項目</param>
  ''' <param name="prmColumWidth">セル幅</param>
  ''' <param name="prmSelectChar">選択時表示文字</param>
  ''' <param name="prmDataSourcName">データソース名</param>
  ''' <param name="prmColIndex">表示位置</param>
  ''' <param name="prmSelectingCondition">チェック可能条件</param>
  ''' <param name="prmClickAction">チェック動作</param>
  ''' <param name="prmMaxSelectedCount">チェック可能最大数</param>
  ''' <param name="prmReload">チェック変更後一覧更新有無</param>
  Public Sub New(prmSelectKeyList As List(Of String) _
                 , Optional prmColumWidth As Integer = 40 _
                 , Optional prmSelectChar As String = "〇" _
                 , Optional prmDataSourcName As String = "SelecterCol" _
                 , Optional prmColIndex As Integer = 0 _
                 , Optional prmSelectingCondition As Dictionary(Of String, String) = Nothing _
                 , Optional prmMaxSelectedCount As Long = Long.MaxValue _
                 , Optional prmClickAction As typClickAction = typClickAction.Double_CLick _
                 , Optional prmReload As Boolean = True)

    SelectKeyList = prmSelectKeyList

    ColumnWidth = prmColumWidth

    SelectChar = prmSelectChar

    DataSourcName = prmDataSourcName

    ColIndex = prmColIndex

    SelectingCondition = prmSelectingCondition

    MaxSelectedCount = prmMaxSelectedCount

    ClickAction = prmClickAction

    Reload = prmReload
  End Sub
#End Region

End Class
