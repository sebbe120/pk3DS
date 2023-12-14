using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pk3DS.Core.Structures.AXExports
{
    // Moves
    public class ExportMoveTxt
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("basePower")]
        public int BasePower { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("multihit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[] Multihit { get; set; }

        public ExportMoveTxt(string t, int bp, string cat, int[] mh)
        {
            Type = t;
            BasePower = bp;
            Category = cat;
            Multihit = null;
            if (mh[0] != 0 || mh[1] != 0)
                Multihit = mh;
        }
    }

    public class ExportMoveListTxt
    {
        [JsonPropertyName("moves")]
        public Dictionary<string, ExportMoveTxt> MoveList { get; set; }

        public ExportMoveListTxt()
        {
            MoveList = new();
        }
    }

    // Pkm
    public class ExportStatBlockTxt
    {
        [JsonPropertyName("hp")]
        public int HP { get; set; }
        [JsonPropertyName("at")]
        public int ATK { get; set; }
        [JsonPropertyName("df")]
        public int DEF { get; set; }
        [JsonPropertyName("sa")]
        public int SPA { get; set; }
        [JsonPropertyName("sd")]
        public int SPD { get; set; }
        [JsonPropertyName("sp")]
        public int SPE { get; set; }

        public ExportStatBlockTxt(int hp, int atk, int def, int spa, int spd, int spe)
        {
            HP = hp;
            ATK = atk;
            DEF = def;
            SPA = spa;
            SPD = spd;
            SPE = spe;
        }
    }

    public class ExportPokemonTxt
    {
        [JsonPropertyName("types")]
        public string[] Types { get; set; }
        [JsonPropertyName("abilities")]
        public string[] Abilities { get; set; }
        [JsonPropertyName("bs")]
        public Dictionary<string, int> BaseStats { get; set; }

        public ExportPokemonTxt()
        {
            BaseStats = new();
        }
    }

    public class ExportPokemonListTxt
    {
        [JsonPropertyName("poks")]
        public Dictionary<string, ExportPokemonTxt> PokemonList { get; set; }

        public ExportPokemonListTxt()
        {
            PokemonList = new();
        }
    }

    // Trainers
    public class ExportTrainerDataTxt
    {
        // General Trainer Info

        [JsonPropertyName("tr_id")]
        public int TrainerID { get; set; }
        [JsonPropertyName("ai")]
        public int AI { get; set; }
        [JsonPropertyName("battle_type")]
        public string BattleType { get; set; }
        [JsonPropertyName("reward_item")]
        public string RewardItem { get; set; }

        // Pokemon Specific Info

        [JsonPropertyName("sub_index")]
        public int PartyPosition { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("form")]
        public int Form { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = "";
        [JsonPropertyName("item")]
        public string HeldItem { get; set; }
        [JsonPropertyName("nature")]
        public string Nature { get; set; }
        [JsonPropertyName("ability")]
        public string Ability { get; set; }
        [JsonPropertyName("moves")]
        public string[] Moves { get; set; } = new string[4] { "", "", "", "" };
        [JsonPropertyName("ivs")]
        public Dictionary<string, int> IVs { get; set; } = new();
        [JsonPropertyName("evs")]
        public Dictionary<string, int> EVs { get; set; } = new() { { "df", 0 } };

        public ExportTrainerDataTxt()
        {

        }
    }

    public class ExportTrainerPokemonTxt
    {
        public Dictionary<string, ExportTrainerDataTxt> TrainerList { get; set; }

        public ExportTrainerPokemonTxt()
        {
            TrainerList = new();
        }
    }

    public class ExportFormattedSetsTxt
    {
        [JsonPropertyName("formatted_sets")]
        public Dictionary<string, Dictionary<string, ExportTrainerDataTxt>> TrPokemonList { get; set; }

        public ExportFormattedSetsTxt()
        {
            TrPokemonList = new();
        }
    }
}
