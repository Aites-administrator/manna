Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc

Public Class TxtMstStaff
  Inherits TxtMstBase

  ' 担当者マスタ入力用テキストボックス

#Region "メンバ"
#Region "private"
  Private DisabledFlg As Boolean = False
#End Region
#End Region


#Region "コンストラクタ"

  Public Sub New()
    MyBase.New("担当者コード", "担当者名")
    MyBase.lcCallBackCreateGridSrcSql = AddressOf CreateGridSrc
    MyBase.lcCallBackUnfinedMaster = AddressOf UnfinedItem
  End Sub
#End Region

#Region "メソッド"

#Region "プライベート"

  ''' <summary>
  ''' 一覧抽出用SQL文作成
  ''' </summary>
  ''' <returns>作成したSQL文</returns>
  Private Function CreateGridSrc() As String
    Dim sql As String = String.Empty

    sql &= " SELECT OPERATOR_CODE  as ItemCode "
    sql &= "      , OPERATOR_NAME  as ItemName "
    sql &= " FROM T_OPERATOR "
    sql &= " WHERE ENABLED <> 0 "

    Return sql

  End Function

  Private Sub UnfinedItem(prmItemCode As String, prmItemName As String)
    Dim tmpDb As New clsSqlServer
    Dim tmpDt As New DataTable

    Try
      tmpDb.GetResult(tmpDt, SqlSelDisabledItem(prmItemCode))
      If tmpDt.Rows.Count <= 0 Then
        MyBase.NameTextBox.Text = prmItemName
      Else
        Call ComMessageBox("担当者コード[" & prmItemCode & "]は使用が禁止されています" _
                          , "" _
                          , typMsgBox.MSG_WARNING _
                          , typMsgBoxButton.BUTTON_OK)
        Me.Text = ""
        DisabledFlg = True
      End If
    Catch ex As Exception
      ComWriteErrLog(ex)
      Throw New Exception("担当者マスタ検索エラー")
    Finally
      tmpDb.Dispose()
    End Try
  End Sub

  Private Function SqlSelDisabledItem(prmItemCode As String) As String
    Dim sql As String = String.Empty

    sql &= " SELECT * "
    sql &= " FROM T_OPERATOR "
    sql &= " WHERE ENABLED = 0 "
    sql &= " AND OPERATOR_CODE ='" & prmItemCode & "'"

    Return sql
  End Function
#End Region

#End Region

#Region "イベントプロシージャー"
  Private Sub TxtMstItem1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
    e.Cancel = DisabledFlg
    DisabledFlg = False
  End Sub

#End Region

End Class
