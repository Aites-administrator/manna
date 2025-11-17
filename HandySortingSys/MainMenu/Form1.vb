Imports T.R.ZCommonClass
Imports T.R.ZCommonClass.clsCommonFnc
Imports T.R.ZCommonCtrl.SFBase

Public Class Form1

  '設定
  ' サブフォーム戻り値のインポート
  ' Imports T.R.ZCommonCtrl.SFBase
  ' サブフォームの作成
  ' sfEdit


  ''' <summary>
  ''' データ入力用サブフォーム表示
  ''' </summary>
  ''' <param name="prmInitialData">サブフォーム初期表示データ</param>
  Private Sub ShowEditForm(Optional prmInitialData As Dictionary(Of String, String) = Nothing)
    Dim tmpSubForm As New sfEdit(Me)

    'サブフォームでデータ更新が行われた場合、一覧表示を更新する
    If typSfResult.SF_OK = tmpSubForm.ShowSubForm(prmInitialData, Me) Then
      MsgBox("OK")
    Else
      MsgBox("Cancel")
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Call ShowEditForm(New Dictionary(Of String, String)() From {{"testdata", "parentformvalue"}})
  End Sub

  Private Function SqlSelXXXX() As String
    Dim sql As String = String.Empty

    sql &= " SELECT * "
    sql &= " FROM "
    sql &= " WHERE 1 = 1"

    Return sql

  End Function

  Private Function SqlInsXXX() As String
    Dim sql As String = String.Empty
    Dim tmpKeyValue As New Dictionary(Of String, String)
    Dim tmpInsertItemz As New Dictionary(Of String, String)

    ComSetDictionaryVal(tmpKeyValue, "[**テーブル項目名**]", "[**設定する値**]")
    tmpInsertItemz = ComCreateInsertItem(tmpKeyValue)

    sql &= " INSERT INTO [**テーブル名**](" & tmpInsertItemz("Keyz") & ") "
    sql &= " VALUES(" & tmpInsertItemz("Valuez") & ") "

    Return sql

  End Function


End Class
