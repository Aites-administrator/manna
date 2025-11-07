<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormComboBox
  Inherits T.R.ZCommonCtrl.FormMultiRowBase

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Windows フォーム デザイナーで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
  'Windows フォーム デザイナーを使用して変更できます。  
  'コード エディターを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim ShortcutKeyManager1 As GrapeCity.Win.MultiRow.ShortcutKeyManager = New GrapeCity.Win.MultiRow.ShortcutKeyManager()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormComboBox))
    Me.lblTitle = New T.R.ZCommonCtrl.LabelTitleBase()
    Me.BtnF9End = New T.R.ZCommonCtrl.BtnF9()
    Me.BtnF12Decision = New T.R.ZCommonCtrl.BtnF12()
    Me.FormComboBoxTemplate1 = New T.R.ZCommonCtrl.FormComboBoxTemplate()
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.MR1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GcMultiRow1
    '
    Me.GcMultiRow1.AllowAutoExtend = True
    Me.GcMultiRow1.AllowUserToDeleteRows = False
    Me.GcMultiRow1.EditMode = GrapeCity.Win.MultiRow.EditMode.EditOnEnter
    Me.GcMultiRow1.Location = New System.Drawing.Point(40, 52)
    Me.GcMultiRow1.MultiSelect = False
    Me.GcMultiRow1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveUp, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveLeft, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveRight, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftLeft, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftRight, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCellInRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCellInRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.PageUp), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[Next]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F2))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CancelEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Escape))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CommitRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F4))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollUp, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollLeft, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollRight, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToLastPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Space))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToLastPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToLastPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ComponentActions.SelectPreviousControl, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ComponentActions.SelectNextControl, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
    ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ReverseSelectCurrentRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Space))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
    ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToPreviousRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToPreviousRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToNextRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToNextRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.PageUp), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[Next]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F2))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CancelEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Escape))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CommitRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F4))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
    ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
    Me.GcMultiRow1.ShortcutKeyManager = ShortcutKeyManager1
    Me.GcMultiRow1.Size = New System.Drawing.Size(565, 400)
    Me.GcMultiRow1.Template = Me.FormComboBoxTemplate1
    '
    'lblTitle
    '
    Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.lblTitle.BorderColor = System.Drawing.Color.Black
    Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblTitle.BorderThickness = 0
    Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 22.0!)
    Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.lblTitle.Location = New System.Drawing.Point(140, 9)
    Me.lblTitle.Name = "lblTitle"
    Me.lblTitle.Size = New System.Drawing.Size(380, 40)
    Me.lblTitle.TabIndex = 0
    Me.lblTitle.Text = "得意先分類コード１検索"
    Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnF9End
    '
    Me.BtnF9End.BackColor = System.Drawing.Color.Transparent
    Me.BtnF9End.FlatAppearance.BorderSize = 0
    Me.BtnF9End.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
    Me.BtnF9End.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
    Me.BtnF9End.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnF9End.Image = CType(resources.GetObject("BtnF9End.Image"), System.Drawing.Image)
    Me.BtnF9End.Location = New System.Drawing.Point(139, 472)
    Me.BtnF9End.Name = "BtnF9End"
    Me.BtnF9End.Size = New System.Drawing.Size(115, 48)
    Me.BtnF9End.TabIndex = 14
    Me.BtnF9End.TabStop = False
    Me.BtnF9End.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnF9End.UseVisualStyleBackColor = False
    '
    'BtnF12Decision
    '
    Me.BtnF12Decision.BackColor = System.Drawing.Color.Transparent
    Me.BtnF12Decision.FlatAppearance.BorderSize = 0
    Me.BtnF12Decision.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
    Me.BtnF12Decision.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
    Me.BtnF12Decision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnF12Decision.Image = CType(resources.GetObject("BtnF12Decision.Image"), System.Drawing.Image)
    Me.BtnF12Decision.Location = New System.Drawing.Point(391, 472)
    Me.BtnF12Decision.Name = "BtnF12Decision"
    Me.BtnF12Decision.Size = New System.Drawing.Size(115, 48)
    Me.BtnF12Decision.TabIndex = 15
    Me.BtnF12Decision.TabStop = False
    Me.BtnF12Decision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnF12Decision.UseVisualStyleBackColor = False
    '
    'FormComboBox
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(644, 532)
    Me.Controls.Add(Me.BtnF12Decision)
    Me.Controls.Add(Me.BtnF9End)
    Me.Controls.Add(Me.lblTitle)
    Me.Name = "FormComboBox"
    Me.Controls.SetChildIndex(Me.GcMultiRow1, 0)
    Me.Controls.SetChildIndex(Me.lblTitle, 0)
    Me.Controls.SetChildIndex(Me.BtnF9End, 0)
    Me.Controls.SetChildIndex(Me.BtnF12Decision, 0)
    CType(Me.GcMultiRow1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.MR1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents lblTitle As T.R.ZCommonCtrl.LabelTitleBase
  Friend WithEvents BtnF9End As T.R.ZCommonCtrl.BtnF9
  Friend WithEvents BtnF12Decision As T.R.ZCommonCtrl.BtnF12
  Friend WithEvents FormComboBoxTemplate1 As FormComboBoxTemplate
End Class
