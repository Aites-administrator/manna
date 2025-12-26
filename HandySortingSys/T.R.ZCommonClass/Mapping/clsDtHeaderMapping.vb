Public Class clsDtHeaderMapping
  ' CSV種別 → ヘッダ → カラム名 の辞書
  Private MappingDictionary As New Dictionary(Of String, Dictionary(Of String, String))
  Private DuplicateKeyDictionary As New Dictionary(Of String, List(Of String))

  Public Sub New()

    ' 入荷マッピング定義
    MappingDictionary("入荷予定データ") = New Dictionary(Of String, String) From {
      {"HACHU_NO", "発注No"},
      {"GYO_NO", "行No"},
      {"JISYA_SHOHIN_CD", "自社商品CD"},
      {"MAKER_SHOHIN_MEI", "メーカー商品名"},
      {"MAKER_KIKAKU_MEI", "メーカー規格名"},
      {"NYUKA_YOTEISU_CASE", "個口数"},
      {"NYUKA_YOTEISU_MAKER", "ケース数"},
      {"NYUKA_YOTEISU_JISYA", "バラ数量"},
      {"NYUKA_JISSEKISU_MAKER", "実績ケース数"},
      {"NYUKA_JISSEKISU_JISYA", "実績バラ数量"},
      {"MAKER_NIAISU", "荷合数"},
      {"MAKER_HACHU_TANI", "発注単位"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"NYUKA_YOTEI_DATE", "入荷予定日"},
      {"GOUKI", "号機"},
      {"TANTO_CD", "担当コード"},
      {"RECEIVE_DATE", "検品日付"},
      {"SHOMIKIGEN", "賞味期限"},
      {"TORIKOMI_JOKYO_FLG", "取込状況フラグ"},
      {"HACHU_GYO_NO", "発注NO_行NO"},
      {"TANA_CD", "棚番"}
    }

    ' 総出しマッピング定義
    MappingDictionary("棚番リスト") = New Dictionary(Of String, String) From {
      {"TANA_CD", "棚番コード"},
      {"TANA_NAME", "棚番名"},
      {"SOUDASHI_SEND_DATE", "送信済み"},
      {"TORIKOMI_JOKYO_FLG", "総出し済"}
    }


    MappingDictionary("総出しデータ") = New Dictionary(Of String, String) From {
      {"TANA_CD", "棚番コード"},
      {"TANA_AREA", "棚番エリア"},
      {"JISYA_SHOHIN_CD", "商品コード"},
      {"JISYA_SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"SHUKKA_YOTEISU_CASE", "出荷予定数_ケース数"},
      {"SHUKKA_YOTEISU_BARA", "出荷予定数_バラ数"},
      {"GOUKI", "号機"},
      {"TANTO_CD", "担当者"},
      {"RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "ステータス"}
    }

    MappingDictionary("総出し棚データ") = New Dictionary(Of String, String) From {
      {"NOUHINBI", "納品日"},
      {"TANA_CD", "棚番コード"},
      {"TANA_NAME", "棚番名"},
      {"GOUKI", "号機"},
      {"TANTO_CD", "担当者"},
      {"RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "ステータス"}
    }

    ' 種まきマッピング定義

    MappingDictionary("種まきコースリスト") = New Dictionary(Of String, String) From {
      {"COURSE_CD", "コースコード"},
      {"HAISOU_COURSE_MEI", "コース名"},
      {"TANEMAKI_SEND_DATE", "送信済み"},
      {"TORIKOMI_JOKYO_FLG", "種まき済"}
    }


    MappingDictionary("総出しデータ") = New Dictionary(Of String, String) From {
      {"TANA_CD", "棚番コード"},
      {"TANA_AREA", "棚番エリア"},
      {"JISYA_SHOHIN_CD", "商品コード"},
      {"JISYA_SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"SHUKKA_YOTEISU_CASE", "出荷予定数_ケース数"},
      {"SHUKKA_YOTEISU_BARA", "出荷予定数_バラ数"},
      {"GOUKI", "号機"},
      {"TANTO_CD", "担当者"},
      {"RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "ステータス"}
    }

    MappingDictionary("総出し棚データ") = New Dictionary(Of String, String) From {
      {"NOUHINBI", "納品日"},
      {"TANA_CD", "棚番コード"},
      {"TANA_NAME", "棚番名"},
      {"GOUKI", "号機"},
      {"TANTO_CD", "担当者"},
      {"RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "ステータス"}
    }



  End Sub

  Public Function ConvertColumnNamesToJapanese(source As DataTable, mappingName As String) As DataTable
    If Not MappingDictionary.ContainsKey(mappingName) Then
      Throw New ArgumentException($"マッピング名 '{mappingName}' は定義されていません。")
    End If

    Dim mapping = MappingDictionary(mappingName)
    Dim result As New DataTable()

    ' 列定義を変換
    For Each col As DataColumn In source.Columns
      Dim newName As String = If(mapping.ContainsKey(col.ColumnName), mapping(col.ColumnName), col.ColumnName)
      result.Columns.Add(newName, col.DataType)
    Next

    ' データをコピー
    For Each row As DataRow In source.Rows
      Dim newRow = result.NewRow()
      For i = 0 To source.Columns.Count - 1
        newRow(i) = row(i)
      Next
      result.Rows.Add(newRow)
    Next

    Return result
  End Function
End Class
