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
      {"NYUKA_YOTEISU_MAKER", "個口数"},
      {"NYUKA_YOTEISU_CASE", "ケース数"},
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
      {"TORIKOMI_JOKYO_FLG", "取込状況FLG"},
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
      {"NOUHINBI", "納品日"},
      {"TANA_CD", "棚番コード"},
      {"TANA_AREA", "棚番エリア"},
      {"JISYA_SHOHIN_CD", "商品コード"},
      {"JISYA_SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"SHUKKA_YOTEISU_CASE", "出荷予定数_ケース数"},
      {"SHUKKA_YOTEISU_BARA", "出荷予定数_バラ数"},
      {"SOUDASHI_GOUKI", "号機"},
      {"SOUDASHI_TANTO_CD", "担当者"},
      {"SOUDASHI_RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "取込状況FLG"},
      {"CASE_TANI", "ケース単位"},
      {"HACHU_TANI", "バラ単位"},
      {"INDEX_ID", "INDEX_ID"}
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
      {"TANEMAKI_SEND_DATE", "未送信(有無)"},
      {"TORIKOMI_JOKYO_FLG", "種まき済"},
      {"TANEMAKI_SEND_DATE_ZUMI", "送信済み"}
    }


    MappingDictionary("種まきデータ") = New Dictionary(Of String, String) From {
      {"NOUHINBI", "納品日"},
      {"COURSE_CD", "コースコード"},
      {"HAISOU_COURSE_MEI", "コース名"},
      {"JISYA_SHOHIN_CD", "商品コード"},
      {"JISYA_SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"SHUKKA_COURSE_YOTEISU_CASE", "コース商品合計ケース数"},
      {"SHUKKA_COURSE_YOTEISU_BARA", "コース商品合計バラ数"},
      {"JIGYOSHO_CD", "店舗コード"},
      {"JIGYOSHO_MEI", "店舗名"},
      {"SHUKKA_YOTEISU_CASE", "店舗出荷予定ケース数"},
      {"SHUKKA_YOTEISU_BARA", "店舗出荷予定バラ数"},
      {"CASE_TANI", "ケース単位"},
      {"BARA_TANI", "バラ単位"},
      {"TANEMAKI_GOUKI", "号機"},
      {"TANEMAKI_TANTO_CD", "担当者"},
      {"TANEMAKI_RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "取込状況FLG"},
      {"INDEX_ID", "INDEX_ID"}
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

    MappingDictionary("出荷検品データ") = New Dictionary(Of String, String) From {
      {"NOUHINBI", "納品日"},
      {"JIGYOSHO_CD", "店舗コード"},
      {"JIGYOSHO_MEI", "店舗名"},
      {"JISYA_SHOHIN_CD", "商品コード"},
      {"JISYA_SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"SHUKKA_YOTEISU_CASE", "ケース数"},
      {"SHUKKA_YOTEISU_BARA", "バラ数"},
      {"CASE_TANI", "ケース単位"},
      {"KENPIN_GOUKI", "号機"},
      {"KENPIN_TANTO_CD", "担当者"},
      {"KENPIN_RECEIVE_DATE", "作業日時"},
      {"TORIKOMI_JOKYO_FLG", "取込状況FLG"},
      {"INDEX_ID", "INDEX_ID"}
    }

    ' 棚卸マッピング定義
    MappingDictionary("棚卸予定データ") = New Dictionary(Of String, String) From {
    {"TANAOROSHI_DATE", "棚卸日"},
    {"SAGYO_YOTEI_DATE", "作業予定日"},
    {"TANA_CD", "棚番"},
    {"TANA_AREA", "棚エリア"},
    {"JISYA_SHOHIN_CD", "商品コード"},
    {"JISYA_SHOHIN_MEI", "商品名"},
    {"IRISU", "入数"},
    {"JAN", "JAN"},
    {"ITF", "ITF"},
    {"TANA_YOTEISU_CASE", "棚卸予定数_ケース"},
    {"TANA_YOTEISU_BARA", "棚卸予定数_バラ"},
    {"TANA_JISSEKI_CASE", "棚卸実績数_ケース"},
    {"TANA_JISSEKI_BARA", "棚卸実績数_バラ"},
    {"CASE_TANI", "ケース単位"},
    {"BARA_TANI", "バラ単位"},
    {"SHOMIKIGEN", "賞味期限"},
    {"GOUKI", "号機"},
    {"TANTO_CD", "担当者"},
    {"RECEIVE_DATE", "受信日時"},
    {"TORIKOMI_JOKYO_FLG", "取込状況FLG"},
    {"INDEX_ID", "INDEX_ID"}
}


    MappingDictionary("商品マスタ") = New Dictionary(Of String, String) From {
      {"SHOHIN_CD", "商品コード"},
      {"SHOHIN_MEI", "商品名"},
      {"JAN", "JAN"},
      {"ITF", "ITF"},
      {"IRISU", "入り数"},
      {"TANKA_TANI", "単位"},
      {"TANA_CD", "棚番"}
    }

    MappingDictionary("担当者マスタ") = New Dictionary(Of String, String) From {
      {"TANTO_CD", "担当者コード"},
      {"TANTO_MEI", "担当者名"}
    }

    MappingDictionary("コースマスタ") = New Dictionary(Of String, String) From {
      {"COURSE_CD", "コースコード"},
      {"COURSE_MEI", "コース名"},
      {"DISP_ORDER", "表示順"},
      {"ENTRY_DATE", "登録日"},
      {"UPDATE_DATE", "更新日"}
    }

    MappingDictionary("棚番マスタ") = New Dictionary(Of String, String) From {
      {"TANA_CD", "棚番"},
      {"TANA_ONDO", "温度帯"},
      {"FLOOR", "フロア"},
      {"BLOCK", "ブロック"},
      {"ENTRY_DATE", "登録日"},
      {"UPDATE_DATE", "更新日"}
    }


    MappingDictionary("担当者マスタ") = New Dictionary(Of String, String) From {
      {"TANTO_CD", "担当者コード"},
      {"TANTO_NM", "担当者名"},
      {"ENTRY_DATE", "登録日"},
      {"UPDATE_DATE", "更新日"}
    }

    MappingDictionary("商品マスタメンテナンス") = New Dictionary(Of String, String) From {
    {"SHOHIN_RANK", "商品ランク"},
    {"SHOHIN_CD", "商品コード"},
    {"SHOHIN_MEI", "商品名"},
    {"IRISU", "入数"},
    {"AISU", "荷合数"},
    {"ONDO_TAI", "温度帯"},
    {"SHOHI_ZEI", "消費税"},
    {"TANKA_TANI", "単価単位"},
    {"SIIRE_CD", "仕入先コード"},
    {"SIIRE_MEI", "仕入先名"},
    {"HASSOSAKI_CD", "発送先コード"},
    {"HASSOSAKI_MEI", "発送先名"},
    {"MAKER_CD", "メーカーコード"},
    {"JAN", "JAN"},
    {"OLD_JAN", "旧JAN"},
    {"ITF", "ITF"},
    {"KOKEI_KAISIBI", "後継開始日"},
    {"KOKEI_SHOHIN_CD", "後継商品コード"},
    {"KOKEI_SHOHIN_MEI", "後継商品名"},
    {"LAST_USE_DATE", "最終使用日"},
    {"TANA_CD", "棚コード"},
    {"SHOMIKIGEN", "賞味期限"},
    {"ENTRY_DATE", "登録日"},
    {"UPDATE_DATE", "更新日"}
}

    MappingDictionary("商品マスタExcel") = New Dictionary(Of String, String) From {
      {"SHOHIN_RANK", "商品RANK"},
      {"SHOHIN_CD", "商品コード"},
      {"SHOHIN_MEI", "商品名"},
      {"IRISU", "入数"},
      {"AISU", "合数"},
      {"ONDO_TAI", "温度帯"},
      {"SHOHI_ZEI", "消費税（％）"},
      {"TANKA_TANI", "単価単位"},
      {"SIIRE_CD", "仕入先コード"},
      {"SIIRE_MEI", "仕入先名"},
      {"HASSOSAKI_CD", "発注先コード"},
      {"HASSOSAKI_MEI", "発注先名"},
      {"MAKER_CD", "メーカーコード"},
      {"JAN", "ＪＡＮ"},
      {"OLD_JAN", "ＪＡＮ（旧）"},
      {"ITF", "ＩＴＦ"},
      {"KOKEI_KAISIBI", "後継開始日"},
      {"KOKEI_SHOHIN_CD", "後継商品コード"},
      {"KOKEI_SHOHIN_MEI", "後継商品名"},
      {"LAST_USE_DATE", "最終使用日"}
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

  Public Function GetDbColumnName(mappingName As String, jpColumnName As String) As String
    If Not MappingDictionary.ContainsKey(mappingName) Then
      Throw New ArgumentException($"マッピング名 '{mappingName}' は定義されていません。")
    End If

    Dim map = MappingDictionary(mappingName) ' DB → 日本語

    For Each kv In map
      If kv.Value = jpColumnName Then
        Return kv.Key ' DB列名
      End If
    Next

    ' 見つからなければ日本語名のまま返す
    Return jpColumnName
  End Function

  Public Function GetJapaneseColumnList(mappingName As String) As List(Of String)
    If Not MappingDictionary.ContainsKey(mappingName) Then
      Throw New ArgumentException($"マッピング名 '{mappingName}' は定義されていません。")
    End If

    ' Value（日本語名）だけを List にして返す
    Return MappingDictionary(mappingName).Values.ToList()
  End Function


End Class
