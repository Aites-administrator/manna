Public Class clsMapping
  ' CSV種別 → ヘッダ → カラム名 の辞書
  Private MappingDictionary As New Dictionary(Of String, Dictionary(Of String, String))
  Private DuplicateKeyDictionary As New Dictionary(Of String, List(Of String))

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

    DuplicateKeyDictionary("入荷予定データ") = New List(Of String) From {
    "NYUKA_YOTEI_DATE", "HACHU_NO", "GYO_NO"
  }

    MappingDictionary("出荷データ") = New Dictionary(Of String, String) From {
      {"処理日", "SHORIBI"},
      {"伝票番号", "DENPYO_NO"},
      {"行番号", "GYO_NO"},
      {"伝票区分", "DENPYO_KBN"},
      {"伝票種別", "DENPYO_SBT"},
      {"訂正区分", "TEISEI_KBN"},
      {"訂正カウント", "TEISEI_COUNT"},
      {"UO伝票番号", "UO_DENPYO_NO"},
      {"UO行番号", "UO_GYO_NO"},
      {"地域CD", "AREA_CD"},
      {"入出荷場所", "NYUSHUKKA_BASHO"},
      {"発注先親CD", "HACHUSAKI_OYA_CD"},
      {"発注先枝CD", "HACHUSAKI_EDA_CD"},
      {"発注先親名", "HACHUSAKI_OYA_MEI"},
      {"発注先枝名", "HACHUSAKI_EDA_MEI"},
      {"発注先TEL", "HACHUSAKI_TEL"},
      {"発注先FAX", "HACHUSAKI_FAX"},
      {"配送コース名", "HAISOU_COURSE_MEI"},
      {"配送順", "HAISOU_JUN"},
      {"事業所CD", "JIGYOSHO_CD"},
      {"事業所名", "JIGYOSHO_MEI"},
      {"住所1", "JUSHO1"},
      {"住所2", "JUSHO2"},
      {"事業所TEL", "JIGYOSHO_TEL"},
      {"事業所FAX", "JIGYOSHO_FAX"},
      {"発注日", "HACHUBI"},
      {"納品日", "NOUHINBI"},
      {"使用日", "SIYOBI"},
      {"区分け番号", "KUWAKE_NO"},
      {"区分け名称", "KUWAKE_MEI"},
      {"納品集計", "NOUHIN_SHUKEI"},
      {"商品CD", "ITEM_CD"},
      {"商品名", "ITEM_MEI"},
      {"分類CD", "BUNRUI_CD"},
      {"発注単位", "HACHU_TANI"},
      {"発注数量", "HACHU_SURYO"},
      {"発注単価", "HACHU_TANKA"},
      {"発注金額", "HACHU_KINGAKU"},
      {"自社商品CD", "JISYA_SHOHIN_CD"},
      {"自社商品名1", "JISYA_SHOHIN_MEI1"},
      {"自社商品名2", "JISYA_SHOHIN_MEI2"},
      {"温度帯", "ONDOTAI"},
      {"出荷ラベル区分", "SHUKKA_LABEL"},
      {"自社発注数量", "JISYA_HACHU_SURYO"},
      {"自社単価", "JISYA_TANKA"},
      {"自社金額", "JISYA_KINGAKU"},
      {"出荷順位", "SHUKKA_RANK"},
      {"数量変換割数", "SURYO_HEN_WARI_SU"},
      {"数量変換割数単位", "SURYO_HEN_WARI_TANI"},
      {"棚番", "TANABAN"},
      {"発注方法区分", "HACHU_HOU_KBN"},
      {"発注書区分", "HACHUSHO_KBN"},
      {"発注区分", "HACHU_KBN"},
      {"取込状況FLG", "TORIKOMI_JOKYO_FLG"}
    }

    DuplicateKeyDictionary("出荷データ") = New List(Of String) From {
    "NOUHINBI", "UO_DENPYO_NO", "UO_GYO_NO"
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

  ' 重複キーチェックカラム
  Public Function GetDuplicateKeyColumns(csvType As String) As List(Of String)
    If DuplicateKeyDictionary.ContainsKey(csvType) Then
      Return DuplicateKeyDictionary(csvType)
    Else
      Return New List(Of String)
    End If
  End Function
End Class
