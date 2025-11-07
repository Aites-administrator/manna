Imports GrapeCity.Win.MultiRow

Public Class CustomMoveToNextControl
  Implements IAction

  ' 最後のセルインデックス
  Private _cellEndIndex As Integer = 0

  ''' <summary>
  ''' コンストラクタ
  ''' </summary>
  ''' <param name="prmCellIndex">最後のセルインデックス</param>
  Sub New(prmCellIndex As Integer)

    _cellEndIndex = prmCellIndex

  End Sub

  ''' <summary>
  ''' 現在の状態でアクションを実行できるかどうかを判断します。  
  ''' </summary>
  ''' <param name="target"></param>
  ''' <returns></returns>
  Public Function CanExecute(ByVal target As GcMultiRow) As Boolean Implements IAction.CanExecute
    Return True
  End Function

  ''' <summary>
  ''' アクションの名前を取得します。これは、アクションの主な機能を簡潔に説明する短い文字列です。  
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property DisplayName() As String Implements IAction.DisplayName
    Get
      Return Me.ToString()
    End Get
  End Property

  ''' <summary>
  ''' アクションを実行するときに呼び出されるメソッドを定義します。  
  ''' </summary>
  ''' <param name="target"></param>
  Public Sub Execute(ByVal target As GcMultiRow) Implements IAction.Execute
    Dim isLastRow As Boolean = (target.CurrentCellPosition.RowIndex = target.RowCount - 1)
    Dim isLastCell As Boolean = (target.CurrentCellPosition.CellIndex = _cellEndIndex)

    If (isLastRow) Then
      If (_cellEndIndex > target.CurrentCellPosition.CellIndex) Then
        ' 最後のセル以外のセルでは次のセルへ移動します。
        SelectionActions.MoveToNextCell.Execute(target)
      Else
        ' カレント行の最初のセルに移動する。
        SelectionActions.MoveToFirstCellInRow.Execute(target)
        If (target.Rows(target.CurrentCellPosition.RowIndex).Cells(0).TabStop = False) Then
          ' 最後のセル以外のセルでは次のセルへ移動します。
          SelectionActions.MoveToNextCell.Execute(target)
        End If
      End If
    Else
      ' 最後のセル以外のセルでは次のセルへ移動します。
      SelectionActions.MoveToNextCell.Execute(target)
    End If

  End Sub

End Class
