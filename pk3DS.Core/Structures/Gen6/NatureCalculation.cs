using System.Drawing;
using TinyMT;

namespace pk3DS.Core.Structures.Gen6
{
    public static class NatureCalculation
    {
        private static readonly string[] NaturesListDetailed = new string[25]
        {
            "Hardy (Neutral)",
            "Lonely (+Atk / -Def)",
            "Brave (+Atk / -Spe)",
            "Adamant (+Atk / -SpA)",
            "Naughty (+Atk / -SpD)",
            "Bold (+Def / -Atk)",
            "Docile (Neutral)",
            "Relaxed (+Def / -Spe)",
            "Impish (+Def / -SpA)",
            "Lax (+Def / -SpD)",
            "Timid (+Spe / -Atk)",
            "Hasty (+Spe / -Def)",
            "Serious (Neutral)",
            "Jolly (+Spe / -SpA)",
            "Naive (+Spe / -SpD)",
            "Modest (+SpA / -Atk)",
            "Mild (+SpA / -Def)",
            "Quiet (+SpA / -Spe)",
            "Bashful (Neutral)",
            "Rash (+SpA / -SpD)",
            "Calm (+SpD / -Atk)",
            "Gentle (+SpD / -Def)",
            "Sassy (+SpD / -Spe)",
            "Careful (+SpD / -SpA)",
            "Quirky (Neutral)"
        };

        private static readonly Color AtkColor = ColorTranslator.FromHtml("#f5ac78");
        private static readonly Color DefColor = ColorTranslator.FromHtml("#fae078");
        private static readonly Color SpAColor = ColorTranslator.FromHtml("#9db7f5");
        private static readonly Color SpDColor = ColorTranslator.FromHtml("#a7db8d");
        private static readonly Color SpeColor = ColorTranslator.FromHtml("#fa92b2");

        private static readonly Color[] NatureColor = new Color[25]
        {
            Color.White,
            AtkColor,
            AtkColor,
            AtkColor,
            AtkColor,
            DefColor,
            Color.White,
            DefColor,
            DefColor,
            DefColor,
            SpeColor,
            SpeColor,
            Color.White,
            SpeColor,
            SpeColor,
            SpAColor,
            SpAColor,
            SpAColor,
            Color.White,
            SpAColor,
            SpDColor,
            SpDColor,
            SpDColor,
            SpDColor,
            Color.White
        };

        public static uint GetNature(int species, int level, int IVs, int tr_class)
        {
            TinyMT32 tinyMT = new((uint)(species + level + IVs));
            for (int i = 0; i < tr_class; i++)
            {
                tinyMT.GetNextUInt32();
            }
            uint personalRand = tinyMT.GetNextUInt32();

            return (personalRand >> 8) % 25;
        }

        public static string GetNatureString(int species, int level, int IVs, int tr_class)
        {
            return NaturesListDetailed[GetNature(species, level, IVs, tr_class)];
        }

        public static string GetNatureString(uint nature)
        {
            return NaturesListDetailed[nature];
        }

        public static Color GetNatureColor(uint nature)
        {
            return NatureColor[nature];
        }
    }
}
