Public Class clsLenColumnDef

  '固定桁数定義
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
      Tuple.Create("KENPIN_DATE", 14),
      Tuple.Create("SHOMIKIGEN", 8),
      Tuple.Create("TORIKOMI_JOKYO_FLG", 1),
      Tuple.Create("HACHU_GYO_NO", 9)
    }
  'Tuple.Create("KENPIN_DATE", 14),

End Class
