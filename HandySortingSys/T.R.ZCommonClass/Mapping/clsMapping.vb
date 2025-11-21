Public Class clsMapping
  ' CSV種別 → ヘッダ → カラム名 の辞書
  Private MappingDictionary As New Dictionary(Of String, Dictionary(Of String, String))

  Public Sub New()
    ' マッピング定義
    MappingDictionary("入荷予定データ") = New Dictionary(Of String, String) From {
      {"入荷予定日", "NYUKA_YOTEI_DATE"},
      {"自社倉庫CD", "JISYA_SOKO_CD"},
      {"温度帯", "ONDOTAI"},
      {"発注NO", "HACHU_NO"},
      {"発注先親CD", "HACHUSAKI_OYA_NO"},
      {"発注先枝CD", "HACHUSAKI_EDA_NO"},
      {"自社営業所FLG", "JISYA_EIGYOSHO_FLG"},
      {"行NO", "GYO_NO"},
      {"自社商品CD", "JISYA_SHOHIN_CD"},
      {"入荷予定数_メーカー", "NYUKA_YOTEISU_MAKER"},
      {"入荷予定数_自社", "NYUKA_YOTEISU_JISYA"},
      {"発注先名", "HACHUSAKIMEI"},
      {"TEL", "TEL"},
      {"FAX", "FAX"},
      {"自社倉庫名", "JISYA_SOKO_MEI"},
      {"棚番", "TANABAN"},
      {"メーカー名", "MAKER_MEI"},
      {"メーカー商品名", "MAKER_SHOHIN_MEI"},
      {"メーカー規格名", "MAKER_KIKAKU_MEI"},
      {"メーカー荷合数", "MAKER_NIAISU"},
      {"メーカー発注単位", "MAKER_HACHU_TANI"},
      {"発注NO文字", "HACHU_NO_MOJI"},
      {"賞味期限管理FLG", "SHOMIKIGEN_KANRI_FLG"},
      {"取込状況FLG", "TORIKOMI_JOKYO_FLG"}
    }

  End Sub

  ' CSV種別を指定してマッピングを取得
  Public Function GetMapping(csvType As String) As Dictionary(Of String, String)
    If MappingDictionary.ContainsKey(csvType) Then
      Return MappingDictionary(csvType)
    Else
      Return New Dictionary(Of String, String) ' 空を返す
    End If
  End Function
End Class
