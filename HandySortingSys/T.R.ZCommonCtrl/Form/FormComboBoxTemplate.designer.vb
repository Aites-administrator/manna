<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.ComponentModel.ToolboxItem(True)>
Partial Class FormComboBoxTemplate
  Inherits GrapeCity.Win.MultiRow.Template

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'MultiRow テンプレート デザイナで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは MultiRow テンプレート デザイナで必要です。
  'MultiRow テンプレート デザイナを使用して変更できます。 
  'コード エディタを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim CellStyle3 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim CellStyle5 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim Border1 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
    Dim CellStyle6 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim Border2 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
    Dim CellStyle7 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim Border3 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
    Dim CellStyle8 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
    Dim Border4 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
    Me.ColumnHeaderSection1 = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
    Me.lblItemCode = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
    Me.lblItemName = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
    Me.CornerHeaderCell1 = New GrapeCity.Win.MultiRow.CornerHeaderCell()
    Me.ItemCode = New GrapeCity.Win.MultiRow.TextBoxCell()
    Me.ItemName = New GrapeCity.Win.MultiRow.TextBoxCell()
    Me.RowHeaderCell1 = New GrapeCity.Win.MultiRow.RowHeaderCell()
    '
    'Row
    '
    Me.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.Row.Cells.Add(Me.ItemCode)
    Me.Row.Cells.Add(Me.ItemName)
    Me.Row.Cells.Add(Me.RowHeaderCell1)
    Me.Row.Height = 25
    Me.Row.Width = 560
    '
    'ColumnHeaderSection1
    '
    Me.ColumnHeaderSection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.ColumnHeaderSection1.Cells.Add(Me.lblItemCode)
    Me.ColumnHeaderSection1.Cells.Add(Me.lblItemName)
    Me.ColumnHeaderSection1.Cells.Add(Me.CornerHeaderCell1)
    Me.ColumnHeaderSection1.Height = 26
    Me.ColumnHeaderSection1.Name = "ColumnHeaderSection1"
    Me.ColumnHeaderSection1.Width = 560
    '
    'lblItemCode
    '
    Me.lblItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.lblItemCode.Location = New System.Drawing.Point(20, 0)
    Me.lblItemCode.Name = "lblItemCode"
    Me.lblItemCode.Size = New System.Drawing.Size(139, 26)
    CellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(176, Byte), Integer))
    CellStyle3.ForeColor = System.Drawing.Color.White
    Me.lblItemCode.Style = CellStyle3
    Me.lblItemCode.TabIndex = 0
    Me.lblItemCode.Value = "区分"
    '
    'lblItemName
    '
    Me.lblItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.lblItemName.Location = New System.Drawing.Point(160, 0)
    Me.lblItemName.Name = "lblItemName"
    Me.lblItemName.Size = New System.Drawing.Size(399, 26)
    CellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(176, Byte), Integer))
    CellStyle4.ForeColor = System.Drawing.Color.White
    Me.lblItemName.Style = CellStyle4
    Me.lblItemName.TabIndex = 1
    Me.lblItemName.Value = "区分名"
    '
    'CornerHeaderCell1
    '
    Me.CornerHeaderCell1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.CornerHeaderCell1.Location = New System.Drawing.Point(0, 0)
    Me.CornerHeaderCell1.Name = "CornerHeaderCell1"
    Me.CornerHeaderCell1.Size = New System.Drawing.Size(20, 26)
    Me.CornerHeaderCell1.Style = New GrapeCity.Win.MultiRow.NamedCellStyle("HeaderCellStyle1")
    Me.CornerHeaderCell1.TabIndex = 20
    '
    'ItemCode
    '
    Me.ItemCode.Location = New System.Drawing.Point(20, 0)
    Me.ItemCode.Name = "ItemCode"
    Me.ItemCode.Size = New System.Drawing.Size(139, 25)
    CellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    CellStyle1.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.TopLeft
    Me.ItemCode.Style = CellStyle1
    Me.ItemCode.TabIndex = 0
    '
    'ItemName
    '
    Me.ItemName.Location = New System.Drawing.Point(160, 0)
    Me.ItemName.Name = "ItemName"
    Me.ItemName.Size = New System.Drawing.Size(399, 25)
    CellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.ItemName.Style = CellStyle2
    Me.ItemName.TabIndex = 5
    '
    'RowHeaderCell1
    '
    Me.RowHeaderCell1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.RowHeaderCell1.Location = New System.Drawing.Point(0, 0)
    Me.RowHeaderCell1.Name = "RowHeaderCell1"
    Me.RowHeaderCell1.Size = New System.Drawing.Size(20, 25)
    Me.RowHeaderCell1.Style = New GrapeCity.Win.MultiRow.NamedCellStyle("HeaderCellStyle1")
    Me.RowHeaderCell1.TabIndex = 20
    '
    'FormComboBoxTemplate
    '
    Me.AlternatingRowsDefaultCellStyle = New GrapeCity.Win.MultiRow.NamedCellStyle("AlternatingRowsDefaultCellStyle1")
    Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.ColumnHeaderSection1})
    CellStyle5.BackColor = System.Drawing.SystemColors.Control
    CellStyle5.BackgroundGradientEffect = New GrapeCity.Win.MultiRow.GradientEffect(Nothing, GrapeCity.Win.MultiRow.GradientStyle.None, GrapeCity.Win.MultiRow.GradientDirection.Center)
    CellStyle5.Border = Border1
    CellStyle5.DisabledBackColor = System.Drawing.SystemColors.Control
    CellStyle5.DisabledForeColor = System.Drawing.SystemColors.GrayText
    CellStyle5.DisabledGradientEffect = New GrapeCity.Win.MultiRow.GradientEffect(Nothing, GrapeCity.Win.MultiRow.GradientStyle.None, GrapeCity.Win.MultiRow.GradientDirection.Center)
    CellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
    CellStyle5.Format = ""
    CellStyle5.GradientDirection = GrapeCity.Win.MultiRow.GradientDirection.Center
    CellStyle5.GradientStyle = GrapeCity.Win.MultiRow.GradientStyle.None
    CellStyle5.ImageAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
    CellStyle5.ImeMode = System.Windows.Forms.ImeMode.NoControl
    CellStyle5.ImeSentenceMode = GrapeCity.Win.MultiRow.ImeSentenceMode.NoControl
    CellStyle5.InputScope = GrapeCity.Win.MultiRow.InputScopeNameValue.[Default]
    CellStyle5.LineAdjustment = GrapeCity.Win.MultiRow.LineAdjustment.None
    CellStyle5.Margin = New System.Windows.Forms.Padding(0)
    CellStyle5.MouseOverGradientEffect = New GrapeCity.Win.MultiRow.GradientEffect(Nothing, GrapeCity.Win.MultiRow.GradientStyle.None, GrapeCity.Win.MultiRow.GradientDirection.Center)
    CellStyle5.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[True]
    CellStyle5.Padding = New System.Windows.Forms.Padding(0)
    CellStyle5.PatternColor = System.Drawing.SystemColors.WindowText
    CellStyle5.PatternStyle = GrapeCity.Win.MultiRow.MultiRowHatchStyle.None
    CellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
    CellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    CellStyle5.SelectionGradientEffect = New GrapeCity.Win.MultiRow.GradientEffect(Nothing, GrapeCity.Win.MultiRow.GradientStyle.None, GrapeCity.Win.MultiRow.GradientDirection.Center)
    CellStyle5.TextAdjustment = GrapeCity.Win.MultiRow.TextAdjustment.Near
    CellStyle5.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
    CellStyle5.TextAngle = 0!
    CellStyle5.TextEffect = GrapeCity.Win.MultiRow.TextEffect.Flat
    CellStyle5.TextImageRelation = GrapeCity.Win.MultiRow.MultiRowTextImageRelation.Overlay
    CellStyle5.TextIndent = 0
    CellStyle5.TextVertical = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
    CellStyle5.UseCompatibleTextRendering = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
    CellStyle5.WordWrap = GrapeCity.Win.MultiRow.MultiRowTriState.[True]
    Me.ColumnHeadersDefaultHeaderCellStyle = CellStyle5
    Me.Height = 51
    CellStyle6.BackgroundGradientEffect = New GrapeCity.Win.MultiRow.GradientEffect(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(216, Byte), Integer)), System.Drawing.Color.White}, GrapeCity.Win.MultiRow.GradientStyle.Horizontal, GrapeCity.Win.MultiRow.GradientDirection.Forward)
    Border2.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.LightGray)
    CellStyle6.Border = Border2
    CellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(124, Byte), Integer))
    CellStyle6.GradientDirection = GrapeCity.Win.MultiRow.GradientDirection.Forward
    CellStyle6.GradientStyle = GrapeCity.Win.MultiRow.GradientStyle.Horizontal
    CellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer))
    Border3.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.LightGray)
    CellStyle7.Border = Border3
    CellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    CellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(243, Byte), Integer))
    Border4.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.LightGray)
    CellStyle8.Border = Border4
    CellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
    Me.NamedCellStyles.AddRange(New GrapeCity.Win.MultiRow.NamedCellStyleDictionaryEntry() {New GrapeCity.Win.MultiRow.NamedCellStyleDictionaryEntry("HeaderCellStyle1", CellStyle6), New GrapeCity.Win.MultiRow.NamedCellStyleDictionaryEntry("RowsDefaultCellStyle1", CellStyle7), New GrapeCity.Win.MultiRow.NamedCellStyleDictionaryEntry("AlternatingRowsDefaultCellStyle1", CellStyle8)})
    Me.RowsDefaultCellStyle = New GrapeCity.Win.MultiRow.NamedCellStyle("RowsDefaultCellStyle1")
    Me.Width = 560

  End Sub


  Private ColumnHeaderSection1 As GrapeCity.Win.MultiRow.ColumnHeaderSection
  Private lblItemCode As GrapeCity.Win.MultiRow.ColumnHeaderCell
  Private lblItemName As GrapeCity.Win.MultiRow.ColumnHeaderCell
  Private CornerHeaderCell1 As GrapeCity.Win.MultiRow.CornerHeaderCell
  Private ItemCode As GrapeCity.Win.MultiRow.TextBoxCell
  Private ItemName As GrapeCity.Win.MultiRow.TextBoxCell
  Private RowHeaderCell1 As GrapeCity.Win.MultiRow.RowHeaderCell
End Class
