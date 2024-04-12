﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using pk3DS.Properties;
using pk3DS.Core;
using pk3DS.Core.Randomizers;
using pk3DS.Core.Structures;
using System.Text.Json;
using System.Collections.Generic;
using pk3DS.Core.Structures.AXExports;
using System.Diagnostics;

namespace pk3DS
{
    public partial class EvolutionEditor6 : Form
    {
        public EvolutionEditor6(byte[][] infiles)
        {
            files = infiles;
            InitializeComponent();

            specieslist[0] = movelist[0] = itemlist[0] = "";
            Array.Resize(ref specieslist, Main.Config.MaxSpeciesID + 1);

            string[] evolutionMethods =
            {
                "",
                "Level Up with Friendship",
                "Level Up at Morning with Friendship",
                "Level Up at Night with Friendship",
                "Level Up",
                "Trade",
                "Trade with Held Item",
                $"Trade for opposite {specieslist[588]}/{specieslist[616]}", // Shelmet&Karrablast
                "Used Item",
                "Level Up (Attack > Defense)",
                "Level Up (Attack = Defense)",
                "Level Up (Attack < Defense)",
                "Level Up (Random < 5)",
                "Level Up (Random > 5)",
                $"Level Up ({specieslist[291]})", // Ninjask
                $"Level Up ({specieslist[292]})", // Shedinja
                "Level Up (Beauty)",
                "Used Item (Male)", // Kirlia->Gallade
                "Used Item (Female)", // Snorunt->Froslass
                "Level Up with Held Item (Day)",
                "Level Up with Held Item (Night)",
                "Level Up with Move",
                "Level Up with Party",
                "Level Up Male",
                "Level Up Female",
                "Level Up at Electric",
                "Level Up at Forest",
                "Level Up at Cold",
                "Level Up with 3DS Upside Down",
                "Level Up with 50 Affection + MoveType",
                $"{typelist[16]} Type in Party",
                "Overworld Rain",
                "Level Up (@) at Morning",
                "Level Up (@) at Night",
                "Level Up Female (SetForm 1)",
            };

            mb = new[] { CB_M1, CB_M2, CB_M3, CB_M4, CB_M5, CB_M6, CB_M7, CB_M8 };
            pb = new[] { CB_P1, CB_P2, CB_P3, CB_P4, CB_P5, CB_P6, CB_P7, CB_P8 };
            rb = new[] { CB_I1, CB_I2, CB_I3, CB_I4, CB_I5, CB_I6, CB_I7, CB_I8 };
            pic = new[] { PB_1, PB_2, PB_3, PB_4, PB_5, PB_6, PB_7, PB_8 };

            foreach (ComboBox cb in mb) { foreach (string s in evolutionMethods) cb.Items.Add(s); }
            foreach (ComboBox cb in rb) { foreach (string s in specieslist) cb.Items.Add(s); }

            CB_Species.Items.Clear();
            foreach (string s in specieslist) CB_Species.Items.Add(s);

            CB_Species.SelectedIndex = 1;
            RandSettings.GetFormSettings(this, GB_Randomizer.Controls);
        }

        private readonly byte[][] files;
        private readonly ComboBox[] pb;
        private readonly ComboBox[] rb;
        private readonly ComboBox[] mb;
        private readonly PictureBox[] pic;
        private int entry = -1;
        private readonly string[] specieslist = Main.Config.GetText(TextName.SpeciesNames);
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private readonly string[] typelist = Main.Config.GetText(TextName.Types);
        private bool dumping;
        private EvolutionSet evo = new EvolutionSet6(new byte[EvolutionSet6.SIZE]);

        private void GetList()
        {
            entry = Array.IndexOf(specieslist, CB_Species.Text);
            byte[] input = files[entry];
            if (input.Length != EvolutionSet6.SIZE) return; // error
            evo = new EvolutionSet6(input);

            for (int i = 0; i < evo.PossibleEvolutions.Length; i++)
            {
                if (evo.PossibleEvolutions[i].Method > 34) return; // Invalid!

                try
                {
					mb[i].SelectedIndex = evo.PossibleEvolutions[i].Method; // Which will trigger the params cb to reload the valid params list
					pb[i].SelectedIndex = evo.PossibleEvolutions[i].Argument;
					rb[i].SelectedIndex = evo.PossibleEvolutions[i].Species;
				}
				// Can be caused by selecting used item male/female and inputting a number instead of level up male/female
				catch (Exception)
				{
                    Debug.WriteLine(evo.PossibleEvolutions[i].Method);
                    Debug.WriteLine(evo.PossibleEvolutions[i].Species);
					mb[i].SelectedIndex = 18; // Level up Male
					pb[i].SelectedIndex = 666; // Houndoomite
					rb[i].SelectedIndex = 206; // Dunsparce
				}
            }
        }

        private void SetList()
        {
            if (entry < 1 || dumping) return;

            for (int i = 0; i < 8; i++)
            {
                evo.PossibleEvolutions[i].Method = mb[i].SelectedIndex;
                evo.PossibleEvolutions[i].Argument = pb[i].SelectedIndex;
                evo.PossibleEvolutions[i].Species = rb[i].SelectedIndex;
            }
            files[entry] = evo.Write();
        }

        private void ChangeEntry(object sender, EventArgs e)
        {
            SetList();
            GetList();
        }

        private void B_RandAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Randomize all resulting species?", "Evolution methods and parameters will stay the same."))
                return;

            SetList();
            // Set up advanced randomization options
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.rBST = CHK_BST.Checked;
            evoRand.Randomizer.rEXP = CHK_Exp.Checked;
            evoRand.Randomizer.rType = CHK_Type.Checked;
            evoRand.Randomizer.L = CHK_L.Checked;
            evoRand.Randomizer.E = CHK_E.Checked;
            evoRand.Randomizer.Initialize();
            evoRand.Execute();
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();

            WinFormsUtil.Alert("All Pokémon's Evolutions have been randomized!");
        }

        private void B_Trade_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Remove all trade evolutions?", "Evolution methods will be altered so that evolutions will be possible with only one game."))
                return;

            SetList();
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.Initialize();
            evoRand.ExecuteTrade();
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();

            WinFormsUtil.Alert("All trade evolutions have been removed!", "Trade evolutions will now occur after reaching a certain Level, or after leveling up while holding its appropriate trade item.");
        }

        private void B_EveryLevel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Modify evolutions?", "This will make it to where your Pokémon will evolve into something random every time it levels up."))
                return;

            SetList();
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.rBST = CHK_BST.Checked;
            evoRand.Randomizer.rEXP = CHK_Exp.Checked;
            evoRand.Randomizer.rType = CHK_Type.Checked;
            evoRand.Randomizer.L = CHK_L.Checked;
            evoRand.Randomizer.E = CHK_E.Checked;
            evoRand.Randomizer.Initialize();
            evoRand.ExecuteEvolveEveryLevel();
            evoRand.Execute(); // randomize right after
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();
            SystemSounds.Asterisk.Play();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Dump all Evolutions to Text File?"))
                return;

            dumping = true;
            string result = "";
            for (int i = 0; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species
                result += "======" + Environment.NewLine + entry + " " + CB_Species.Text + Environment.NewLine + "======" + Environment.NewLine;
                for (int j = 0; j < 8; j++)
                {
                    int methodval = mb[j].SelectedIndex;
                    // int param = pb[j].SelectedIndex;
                    int poke = rb[j].SelectedIndex;
                    if (poke > 0 && methodval > 0)
                        result += mb[j].Text + (pb[j].Visible ? " [" + pb[j].Text + "]" : "") + " into " + rb[j].Text + Environment.NewLine;
                }

                result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog { FileName = "Evolutions.txt", Filter = "Text File|*.txt" };

            SystemSounds.Asterisk.Play();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                File.WriteAllText(path, result, Encoding.Unicode);
            }
            dumping = false;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SetList();
            RandSettings.SetFormSettings(this, GB_Randomizer.Controls);
        }

        private void ChangeMethod(object sender, EventArgs e)
        {
            int op = Array.IndexOf(mb, sender as ComboBox);
            ushort[] methodCase =
            {
                0,0,0,0,1,0,2,0,2,1,1,1,1,1,1,1,5,2,2,2,2,3,4,1,1,0,0,0, // 27, Past Methods
                // New Methods
                1, // 28 - Dark Type Party
                6, // 29 - Affection + MoveType
                1, // 30 - UpsideDown 3DS
                1, // 31 - Overworld Rain
                1, // 32 - Level @ Day
                1, // 33 - Level @ Night
                1, // 34 - Gender Branch
            };

            pb[op].Visible = pic[op].Visible = rb[op].Visible = mb[op].SelectedIndex > 0;

            pb[op].Items.Clear();
            int cv = methodCase[mb[op].SelectedIndex];
            switch (cv)
            {
                case 0: // No Parameter Required
                    { pb[op].Visible = false; pb[op].Items.Add(""); break; }
                case 1: // Level
                    { for (int i = 0; i <= 100; i++) pb[op].Items.Add(i.ToString()); break; }
                case 2: // Items
                    { foreach (string t in itemlist) pb[op].Items.Add(t); break; }
                case 3: // Moves
                    { foreach (string t in movelist) pb[op].Items.Add(t); break; }
                case 4: // Species
                    { foreach (string t in specieslist) pb[op].Items.Add(t); break; }
                case 5: // 0-255 (Beauty)
                    { for (int i = 0; i <= 255; i++) pb[op].Items.Add(i.ToString()); break; }
                case 6:
                    { foreach (string t in typelist) pb[op].Items.Add(t); break; }
            }
            pb[op].SelectedIndex = 0;
        }

        private void ChangeInto(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb)
                return;
            pic[Array.IndexOf(rb, cb)].Image = (Bitmap)Resources.ResourceManager.GetObject("_" + Array.IndexOf(specieslist, cb.Text));
        }

        private void B_Export_Site(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Export evos for Site?"))
                return;

            Dictionary<string, ExportEvoSite> evoDict = new();

            for (int i = 1; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i;

                string pkmName = AXHelpers.GetJSONPkmName(CB_Species);

                ExportEvoSite evo = new();

                for (int j = 0; j < 8; j++)
                {
                    int pokeIdx = rb[j].SelectedIndex;
                    int methodIdx = mb[j].SelectedIndex;

                    string method = mb[j].Text + ": " + pb[j].Text;
                    if (AXHelpers.BetterEvoMethodDesc.ContainsKey(methodIdx))
                        method = AXHelpers.BetterEvoMethodDesc[methodIdx].Replace("PARAM", pb[j].Text);

                    method = method.Replace("’", "'");

                    if (pokeIdx > 0 && methodIdx > 0)
                    {
                        string evolvePkmName = AXHelpers.GetJSONPkmName(rb[j]);

                        try
                        {
                            evo.EvolvesInto.Add(evolvePkmName, method);
                        }
                        catch (ArgumentException)
                        {
                            if (evolvePkmName == "Darmanitan")
                                evo.EvolvesInto.Add(evolvePkmName + "-Zen", method);
                            else if (evolvePkmName == "Meowstic")
                                evo.EvolvesInto.Add(evolvePkmName + "-Female", method);
                            else
                                throw new Exception("Attempting to place a duplicate key for an unexpected form evolution.");
                        }

                        ExportEvoSite fromEvo = new()
                        {
                            EvolvesFrom = pkmName,
                            FromMethod = method
                        };

                        try
                        {
                            evoDict.Add(evolvePkmName, fromEvo);
                        }
                        catch (ArgumentException)
                        {
                            /*evoDict[evolvePkmName].EvolvesFrom = fromEvo.EvolvesFrom;
                            evoDict[evolvePkmName].FromMethod = fromEvo.FromMethod;*/
                            if (evolvePkmName == "Darmanitan")
                                evoDict.Add(evolvePkmName + "-Zen", fromEvo);
                            else if (evolvePkmName == "Meowstic")
                                evoDict.Add(evolvePkmName + "-Female", fromEvo);
                            else
                            {
                                evoDict[evolvePkmName].EvolvesFrom = fromEvo.EvolvesFrom;
                                evoDict[evolvePkmName].FromMethod = fromEvo.FromMethod;
                                //throw new Exception("Attempting to place a duplicate key for an unexpected form evolution.");
                            }
                        }
                    }
                }

                try
                {
                    evoDict.Add(pkmName, evo);
                }
                catch (ArgumentException)
                {
                    evoDict[pkmName].EvolvesInto = evo.EvolvesInto;
                }
            }

            SaveFileDialog sfd = new() { FileName = "evolutions.json", Filter = "JSON|*.json" };
            SystemSounds.Asterisk.Play();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                string json = JsonSerializer.Serialize(evoDict);
                File.WriteAllText(path, json);
            }
        }
    }
}
