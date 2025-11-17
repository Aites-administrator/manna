Public Class TxtRecipeCode
  Inherits TxtBase

  Private Const CODE_FORMAT = "00000"

  ''' <summary>
  ''' 配合コード更新後処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub IngredientCodeValidated(sender As Object, e As EventArgs) Handles MyBase.Validated
    Me.Text = Strings.Right((CODE_FORMAT & Me.Text), CODE_FORMAT.Length)
  End Sub

  Public Sub New()
    MyBase.MaxLength = CODE_FORMAT.Length
  End Sub
End Class
