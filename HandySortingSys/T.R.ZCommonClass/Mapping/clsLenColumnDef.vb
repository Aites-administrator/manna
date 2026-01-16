Public Class clsLenColumnDef

  '入荷データ固定桁数定義
  Public Shared LenColumnInNyuka As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("HACHU_NO", 6),
      Tuple.Create("GYO_NO", 2),
      Tuple.Create("JISYA_SHOHIN_CD", 5),
      Tuple.Create("MAKER_SHOHIN_MEI", 80),
      Tuple.Create("MAKER_KIKAKU_MEI", 30),
      Tuple.Create("NYUKA_YOTEISU_CASE", 4),
      Tuple.Create("NYUKA_YOTEISU_MAKER", 4),
      Tuple.Create("NYUKA_YOTEISU_JISYA", 4),
      Tuple.Create("NYUKA_JISSEKISU_MAKER", 4),
      Tuple.Create("NYUKA_JISSEKISU_JISYA", 4),
      Tuple.Create("MAKER_NIAISU", 2),
      Tuple.Create("MAKER_HACHU_TANI", 6),
      Tuple.Create("JAN", 13),
      Tuple.Create("ITF", 16),
      Tuple.Create("NYUKA_YOTEI_DATE", 8),
      Tuple.Create("GOUKI", 2),
      Tuple.Create("TANTO_CD", 3),
      Tuple.Create("RECEIVE_DATE", 14),
      Tuple.Create("SHOMIKIGEN", 8),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("HACHU_GYO_NO", 9),
      Tuple.Create("TANA_CD", 4)
    }

  '総出し棚データ固定桁数定義
  Public Shared LenColumnInSoudashiTana As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("NOUHINBI", 8),
      Tuple.Create("TANA_CD", 2),
      Tuple.Create("TANA_NAME", 10),
      Tuple.Create("GOUKI", 2),
      Tuple.Create("TANTO_CD", 3),
      Tuple.Create("RECEIVE_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1)
    }

  '総出しデータ固定桁数定義
  Public Shared LenColumnInSoudashi As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("NOUHINBI", 8),
      Tuple.Create("TANA_CD", 2),
      Tuple.Create("TANA_AREA", 6),
      Tuple.Create("JISYA_SHOHIN_CD", 5),
      Tuple.Create("JISYA_SHOHIN_MEI", 80),
      Tuple.Create("JAN", 13),
      Tuple.Create("ITF", 16),
      Tuple.Create("SHUKKA_YOTEISU_CASE", 5),
      Tuple.Create("SHUKKA_YOTEISU_BARA", 5),
      Tuple.Create("SOUDASHI_GOUKI", 2),
      Tuple.Create("SOUDASHI_TANTO_CD", 3),
      Tuple.Create("SOUDASHI_RECEIVE_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("CASE_TANI", 6),
      Tuple.Create("HACHU_TANI", 6),
      Tuple.Create("INDEX_ID", 5)
    }

  '種まきコースデータ固定桁数定義
  Public Shared LenColumnInTanemakiCourse As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("NOUHINBI", 8),
      Tuple.Create("COURSE_CD", 2),
      Tuple.Create("HAISOU_COURSE_MEI", 6),
      Tuple.Create("GOUKI", 2),
      Tuple.Create("TANTO_CD", 3),
      Tuple.Create("SEND_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1)
    }

  '種まきデータ固定桁数定義
  Public Shared LenColumnInTANEMAKI As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("NOUHINBI", 8),
      Tuple.Create("COURSE_CD", 2),
      Tuple.Create("HAISOU_COURSE_MEI", 6),
      Tuple.Create("JISYA_SHOHIN_CD", 5),
      Tuple.Create("JISYA_SHOHIN_MEI", 80),
      Tuple.Create("JAN", 13),
      Tuple.Create("ITF", 16),
      Tuple.Create("SHUKKA_COURSE_YOTEISU_CASE", 4),
      Tuple.Create("SHUKKA_COURSE_YOTEISU_BARA", 4),
      Tuple.Create("JIGYOSHO_CD", 4),
      Tuple.Create("JIGYOSHO_MEI", 50),
      Tuple.Create("SHUKKA_YOTEISU_CASE", 4),
      Tuple.Create("SHUKKA_YOTEISU_BARA", 4),
      Tuple.Create("CASE_TANI", 6),
      Tuple.Create("BARA_TANI", 6),
      Tuple.Create("TANEMAKI_GOUKI", 2),
      Tuple.Create("TANEMAKI_TANTO_CD", 3),
      Tuple.Create("TANEMAKI_RECEIVE_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("INDEX_ID", 5)
    }

  '種まきデータ固定桁数定義
  Public Shared LenColumnInTANEMAKISUM As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("COURSE_CD", 2),
      Tuple.Create("HAISOU_COURSE_MEI", 6),
      Tuple.Create("JISYA_SHOHIN_CD", 5),
      Tuple.Create("JISYA_SHOHIN_MEI", 80),
      Tuple.Create("JAN", 13),
      Tuple.Create("ITF", 16),
      Tuple.Create("SHUKKA_YOTEISU_CASE", 4),
      Tuple.Create("SHUKKA_YOTEISU_BARA", 4),
      Tuple.Create("CASE_TANI", 6),
      Tuple.Create("BARA_TANI", 6),
      Tuple.Create("TANEMAKI_GOUKI", 2),
      Tuple.Create("TANEMAKI_TANTO_CD", 3),
      Tuple.Create("TANEMAKI_RECEIVE_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("INDEX_ID", 5)
    }

  'パスワードデータ固定桁数定義
  Public Shared LenColumnInPASSWORD As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("PASSWORD", 4)
    }

  '出荷検品データ固定桁数定義
  Public Shared LenColumnInShukkaCheck As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("NOUHINBI", 8),
      Tuple.Create("JIGYOSHO_CD", 4),
      Tuple.Create("JIGYOSHO_MEI", 50),
      Tuple.Create("JISYA_SHOHIN_CD", 5),
      Tuple.Create("JISYA_SHOHIN_MEI", 80),
      Tuple.Create("JAN", 13),
      Tuple.Create("ITF", 16),
      Tuple.Create("SHUKKA_YOTEISU_CASE", 4),
      Tuple.Create("SHUKKA_YOTEISU_BARA", 4),
      Tuple.Create("CASE_TANI", 6),
      Tuple.Create("BARA_TANI", 6),
      Tuple.Create("KENPIN_GOUKI", 2),
      Tuple.Create("KENPIN_TANTO_CD", 3),
      Tuple.Create("KENPIN_RECEIVE_DATE", 14),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("INDEX_ID", 5)
    }

  '出荷店舗データ固定桁数定義
  Public Shared LenColumnInShop As New List(Of Tuple(Of String, Integer)) From {
      Tuple.Create("JIGYOSHO_CD", 4),
      Tuple.Create("JIGYOSHO_MEI", 50),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1)
    }

  ' 商品マスタ固定桁数定義
  Public Shared LenColumnInMstItem As New List(Of Tuple(Of String, Integer)) From {
    Tuple.Create("SHOHIN_CD", 5),
    Tuple.Create("SHOHIN_MEI", 80),
    Tuple.Create("JAN", 13),
    Tuple.Create("ITF", 16),
    Tuple.Create("IRISU", 10),
    Tuple.Create("TANKA_TANI", 6),
    Tuple.Create("TANA_CD", 6)
}

  ' 商品マスタ固定桁数定義
  Public Shared LenColumnInMstTanto As New List(Of Tuple(Of String, Integer)) From {
    Tuple.Create("TANTO_CD", 4),
    Tuple.Create("TANTO_MEI", 30)
}
End Class
