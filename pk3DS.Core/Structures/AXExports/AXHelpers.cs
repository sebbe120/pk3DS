using System.Collections.Generic;
using System.Windows.Forms;

namespace pk3DS.Core.Structures.AXExports
{
    public static class AXHelpers
    {
        public static readonly int[] AXTrainerIndexes = new int[]
        {
            // 1-25
            1, 3, 6, 21, 22, 23, 24, 25,
            // 26-50
            26, 27, 28, 29, 30, 31, 32, 36, 37, 39, 40, 41, 43, 44, 45, 46, 47, 48, 49, 50,
            // 51-75
            52, 53, 55, 56, 57, 58, 59, 60, 61, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72,
            // 76-100
            76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 95, 96, 97, 98, 99, 100,
            // 101-125
            104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 121, 122, 123, 124,
            // 126-150
            129, 130, 131, 132, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150,
            // 151-175
            151, 152, 153, 156, 157, 158, 160, 161, 162, 163, 164, 165, 166, 168, 169, 170, 171, 172, 174, 175,
            // 176-200
            176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188,
            // 226-250
            243, 245, 248, 250,
            // 251-275
            269, 270, 271,
            // 276-300
            276,
            // 301-325
            302, 303, 304, 305, 306, 308, 309, 310, 311, 312, 313, 315, 316, 317, 318, 319, 320, 321, 322, 323, 324, 325,
            // 326-350
            326, 327, 328, 329, 330, 331, 332, 333, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344, 345, 346, 347, 348, 349, 350,
            // 351-375
            351, 352, 353, 356, 357, 360, 361, 362, 363, 364, 365, 366, 367, 368, 369, 370, 371, 372,
            // 376-400
            376, 377, 378, 379, 388, 389, 390, 391, 392, 393, 394, 395, 396, 397, 398, 399, 400,
            // 401-425
            401, 402, 403, 404, 406, 408, 409, 410, 411, 412, 413, 414, 415, 416, 419, 420, 421, 422, 423, 424, 425,
            // 426-450
            426, 427, 428, 429, 430, 431, 432, 433, 434, 435, 436, 437, 438, 439,
            // 451-475
            459, 460, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 472, 473,
            // 476-500
            476, 477, 478, 479, 480, 481, 482, 483, 484,
            // 501-525
            524, 525,
            // 526-550
            526, 527, 528, 529, 530, 532, 533, 534, 535, 536, 537, 538, 539, 540, 541, 542, 543, 544, 545, 546, 547, 548, 549, 550,
            // 551-575
            554, 555, 556, 557, 558, 573, 575,
            // 576-600
            576, 577, 578, 579, 580, 581, 582, 583, 584, 585, 586, 587, 588, 589, 590, 591, 592, 593, 594, 595, 596, 597, 598,
            // 601-625
            602, 603, 604, 605, 606, 607, 608, 609, 610, 611, 612, 613
        };

        public static readonly Dictionary<string, string> AXPokemonFormNames = new()
        {
            { "Deoxys 1", "Deoxys (Attack)" },
            { "Deoxys 2", "Deoxys (Defense)" },
            { "Deoxys 3", "Deoxys (Speed)" },
            { "Wormadam 1", "Wormadam (Sandy)" },
            { "Wormadam 2", "Wormadam (Trash)" },
            { "Shaymin 1", "Shaymin (Sky)" },
            { "Giratina 1", "Giratina (Origin)" },
            { "Rotom 1", "Rotom (Heat)" },
            { "Rotom 2", "Rotom (Wash)" },
            { "Rotom 3", "Rotom (Frost)" },
            { "Rotom 4", "Rotom (Fan)" },
            { "Rotom 5", "Rotom (Mow)" },
            { "Castform 1", "Castform (Sunny)" },
            { "Castform 2", "Castform (Rainy)" },
            { "Castform 3", "Castform (Snowy)" },
            { "Cherrim 1", "Cherrim (Sunshine)" },
            { "Darmanitan 1", "Darmanitan (Zen)" },
            { "Meloetta 1", "Meloetta (Pirouette)" },
            { "Kyurem 1", "Kyurem (White)" },
            { "Kyurem 2", "Kyurem (Black)" },
            { "Keldeo 1", "Keldeo (Resolute)" },
            { "Tornadus 1", "Tornadus (Therian)" },
            { "Thundurus 1", "Thundurus (Therian)" },
            { "Landorus 1", "Landorus (Therian)" },
            { "Meowstic 1", "Meowstic (F)" },
            // Furfrous missing but would go here
            { "Charizard 1", "Charizard (Mega) (X)" },
            { "Charizard 2", "Charizard (Mega) (Y)" },
            { "Mewtwo 1", "Mewtwo (Mega) (X)" },
            { "Mewtwo 2", "Mewtwo (Mega) (Y)" },
            { "Aegislash", "Aegislash (Shield)" },
            { "Aegislash 1", "Aegislash (Blade)" },
            { "Pumpkaboo 1", "Pumpkaboo (Small)" },
            { "Pumpkaboo 2", "Pumpkaboo (Large)" },
            { "Pumpkaboo 3", "Pumpkaboo (Super)" },
            { "Gourgeist 1", "Gourgeist (Small)" },
            { "Gourgeist 2", "Gourgeist (Large)" },
            { "Gourgeist 3", "Gourgeist (Super)" },
            // Floette missing but would go here

        };

        public static readonly Dictionary<string, string> AXPokemonFormNamesSite = new()
        {
            { "Castform 1", "Castform-Sunny" },
            { "Castform 2", "Castform-Rainy" },
            { "Castform 3", "Castform-Snowy" },
            { "Deoxys 1", "Deoxys-Attack" },
            { "Deoxys 2", "Deoxys-Defense" },
            { "Deoxys 3", "Deoxys-Speed" },
            { "Burmy 1", "Burmy" }, // Not Sandy since pk3DS currently do have functionality for it - trainers & wild area can still have it
            { "Burmy 2", "Burmy" }, // Not Trash since pk3DS currently do have functionality for it - trainers & wild area can still have it
            { "Wormadam 1", "Wormadam-Sandy" },
            { "Wormadam 2", "Wormadam-Trash" },
            { "Gastrodon 1", "Gastrodon" },// Not East since pk3DS currently do have functionality for it - trainers & wild area can still have it
            { "Shaymin 1", "Shaymin-Sky" },
            { "Giratina 1", "Giratina-Origin" },
            { "Rotom 1", "Rotom-Heat" },
            { "Rotom 2", "Rotom-Wash" },
            { "Rotom 3", "Rotom-Frost" },
            { "Rotom 4", "Rotom-Fan" },
            { "Rotom 5", "Rotom-Mow" },
            { "Cherrim 1", "Cherrim-Sunshine" },
            { "Basculin 1", "Basculin-Blue-Striped" },
            { "Darmanitan 1", "Darmanitan-Zen" },
            { "Meloetta 1", "Meloetta-Pirouette" },
            { "Kyurem 1", "Kyurem-White" },
            { "Kyurem 2", "Kyurem-Black" },
            { "Keldeo 1", "Keldeo-Resolute" },
            { "Tornadus 1", "Tornadus-Therian" },
            { "Thundurus 1", "Thundurus-Therian" },
            { "Landorus 1", "Landorus-Therian" },
            { "Meowstic 1", "Meowstic-Female" },
            // Skipping Furfrous
            { "Charizard 1", "Charizard-Mega-X" },
            { "Charizard 2", "Charizard-Mega-Y" },
            { "Mewtwo 1", "Mewtwo-Mega-X" },
            { "Mewtwo 2", "Mewtwo-Mega-Y" },
            { "Aegislash 1", "Aegislash-Blade" },
            { "Pumpkaboo 1", "Pumpkaboo-Small" },
            { "Pumpkaboo 2", "Pumpkaboo-Large" },
            { "Pumpkaboo 3", "Pumpkaboo-Super" },
            { "Gourgeist 1", "Gourgeist-Small" },
            { "Gourgeist 2", "Gourgeist-Large" },
            { "Gourgeist 3", "Gourgeist-Super" },
            { "Flab\u00E9b\u00E9 1", "Flabébé" }, // "Normalizing" Flabébé formes
            { "Flab\u00E9b\u00E9 2", "Flabébé" }, // "Normalizing" Flabébé formes
            { "Flab\u00E9b\u00E9 3", "Flabébé" }, // "Normalizing" Flabébé formes
            { "Flab\u00E9b\u00E9 4", "Flabébé" }, // "Normalizing" Flabébé formes
            { "Flab\u00E9b\u00E9 5", "Flabébé" }, // "Normalizing" Flabébé formes
            { "Floette 1", "Floette" }, // "Normalizing" Floette formes
            { "Floette 2", "Floette" }, // "Normalizing" Floette formes
            { "Floette 3", "Floette" }, // "Normalizing" Floette formes
            { "Floette 4", "Floette" }, // "Normalizing" Floette formes
            { "Floette 5", "Floette" }, // "Normalizing" Floette formes
            { "Florges 1", "Florges" }, // "Normalizing" Florges formes
            { "Florges 2", "Florges" }, // "Normalizing" Florges formes
            { "Florges 3", "Florges" }, // "Normalizing" Florges formes
            { "Florges 4", "Florges" }, // "Normalizing" Florges formes
            { "Florges 5", "Florges" }, // "Normalizing" Florges formes
        };

        public static readonly Dictionary<int, string> BetterEvoMethodDesc = new()
        {
            // See pk3DS\Subforms\Gen6\EvolutionEditor6.cs for list
            { 8, "Use Item: PARAM" },
            { 12, "Level Up: PARAM (Random)" },
            { 13, "Level Up: PARAM (Random)" },
            { 23, "Level Up: PARAM (Male)" },
            { 34, "Level Up: PARAM (Female, Form Change)" }
        };

        public static string GetJSONPkmName(ComboBox cb, bool fromPersonal = false)
        {
            string pkmName = fromPersonal ? cb.Text.Substring(0, cb.Text.Length - 6) : cb.Text;

            if (pkmName.Contains("Nidoran"))
            {
                if (cb.SelectedIndex == 28 || cb.SelectedIndex == 29)
                    pkmName = pkmName.Substring(0, pkmName.Length - 1) + "-F";
                else if (cb.SelectedIndex == 31 || cb.SelectedIndex == 32)
                    pkmName = pkmName.Substring(0, pkmName.Length - 1) + "-M";
            }

            if (AXPokemonFormNamesSite.ContainsKey(pkmName))
                pkmName = AXPokemonFormNamesSite[pkmName];
            else if (pkmName.Substring(pkmName.Length - 1) == "1")
                pkmName = pkmName.Substring(0, pkmName.Length - 2) + "-Mega";

            return pkmName;
        }

		public static string GetJSONPkmNameFromString(string pkmName)
		{
            if (pkmName.Contains("Nidoran"))
            {
				// Change the output of the nidorans to: Nidoran-F & Nidoran-M
				pkmName = pkmName.Replace("\uE08F", "-F").Replace("\uE08E", "-M");
            }
			if (pkmName.Contains("Unown"))
			{
				pkmName = "Unown";
			}

			if (AXPokemonFormNamesSite.ContainsKey(pkmName))
				pkmName = AXPokemonFormNamesSite[pkmName];
			else if (pkmName.Substring(pkmName.Length - 1) == "1")
				pkmName = pkmName.Substring(0, pkmName.Length - 2) + "-Mega";

			return pkmName;
		}
	}
}
