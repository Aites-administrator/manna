Imports T.R.ZCommonClass

<Serializable>
Public Class CmbContent

  Protected _Code As String
  Protected _Name As String

  Public Sub New(ByVal prmCode As String,
                 ByVal prmName As String)
    Me._Code = prmCode
    Me._Name = prmName
  End Sub

  Public ReadOnly Property ItemCode() As String
    Get
      Return _Code
    End Get
  End Property

  Public ReadOnly Property ItemName() As String
    Get
      Return _Name
    End Get
  End Property
End Class


