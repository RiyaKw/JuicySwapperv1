﻿using JuicySwapper.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using JuicySwapper.IO;
using System.IO;
using JuicySwapper.Main.GUI;

namespace JuicySwapper.Main.Item.Pickaxes
{
    public partial class DualRaiders : Form
    {
        public DualRaiders()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        string PakFolder = Properties.Settings.Default.pakPath;

        private void convertButton_Click(object sender, EventArgs e)
        {
            string filePath9 = Settings.Default.pakPath + "/pakchunk10_s9-WindowsClient.pak";

            if (!File.Exists(filePath9))
            {
                PakError a = new PakError(); a.ShowDialog();
                return;
            }

            else
            {
                CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Placeholder_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DualRaidersEnabled == true)
            {
                convertButton.Text = "Revert";
            }
            else
            {
                convertButton.Text = "Convert";
            }
        }


        string Mesh = "/Game/Weapons/FORT_Melee/Pickaxe_Tactical_Fisherman_1h/Meshes/Tactical_Fisherman_1h.Tactical_Fisherman_1h";
        string Mesh1 = "/Game/Weapons/FORT_Melee/Meshes/SK_Pickaxe_PostApocalyptic.SK_Pickaxe_PostApocalyptic";
        string Equip = "/Game/Athena/Sounds/Weapons/PickAxes/TacticalFisherman/PickAxe_TacticalFisherman_Equip_Cue.PickAxe_TacticalFisherman_Equip_Cue";
        string Equip1 = "/Game/Athena/Sounds/Weapons/PickAxes/PickAxe_Lockjaw_Swing_Athena_Cue.PickAxe_Lockjaw_Swing_Athena_Cue";
        string Swing = "/Game/Athena/Sounds/Weapons/PickAxes/TacticalFisherman/PickAxe_TacticalFisherman_Swing_Cue.PickAxe_TacticalFisherman_Swing_Cue";
        string Swing1 = "/Game/Athena/Sounds/Weapons/PickAxes/PickAxe_Lockjaw_Swing_Athena_Cue.PickAxe_Lockjaw_Swing_Athena_Cue";
        string Impact = "/Game/Athena/Sounds/Weapons/PickAxes/TacticalFisherman/PickAxe_TacticalFisherman_EnemyImpact_Cue.PickAxe_TacticalFisherman_EnemyImpact_Cue";
        string Impact1 = "/Game/Sounds/Fort_Impact_Sounds/Flesh/Player_Impact_PA_LockJaw_Cue.Player_Impact_PA_LockJaw_Cue";


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int Offset_Skin_Body = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int Offset_Skin_Head = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string bodypath = Settings.Default.pakPath + Settings.Default.bodypathAPI;
            string headpath = Settings.Default.pakPath + Settings.Default.headpathAPI;
            string pickaxepath = Settings.Default.pakPath + Settings.Default.pickaxepathAPI;
            string pickaxesoundpath = Settings.Default.pakPath + Settings.Default.pickaxesoundpathAPI;
            string backblingpath = Settings.Default.pakPath + Settings.Default.backblingpathAPI;
            string emotespath = Settings.Default.pakPath + Settings.Default.emotespathAPI;
            if (convertButton.Text == "Convert")
            {
                RichTextBoxInfo.Clear();
                RichTextBoxInfo.Text += "[LOG] Starting...";

                bool swap1 = Engine.Convert(offsetpick, pickaxepath, Mesh, Mesh1, 0, 0, false, false);
                if (swap1)
                {
                    RichTextBoxInfo.Text += "\n[LOG] Mesh added";
                    Settings.Default.DualRaidersEnabled = true;
                    Settings.Default.Save();
                }

                bool swap2 = Engine.Convert(offsetpick, pickaxepath, Equip, Equip1, 0, 0, false, false);
                if (swap2)
                    RichTextBoxInfo.Text += "\n[LOG] Equip Sound added";

                bool swap3 = Engine.Convert(offsetpick, pickaxepath, Swing, Swing1, 0, 0, false, false);
                if (swap3)
                    RichTextBoxInfo.Text += "\n[LOG] Swing Sound added";

                bool swap4 = Engine.Convert(offsetpick, pickaxepath, Impact, Impact1, 0, 0, false, false);
                if (swap4)
                    RichTextBoxInfo.Text += "\n[LOG] Impact Sound added";

                convertButton.Text = "Revert";
                stopwatch.Stop();
                double num = (double)stopwatch.Elapsed.Milliseconds;
                RichTextBoxInfo.AppendText("\n[LOG] Done! Converted in " + num + " ms.");
            }
            else
            {
                RichTextBoxInfo.Clear();
                RichTextBoxInfo.Text += "[LOG] Starting...";

                bool swap1 = Engine.Revert(offsetpick, pickaxepath, Mesh, Mesh1, 0, 0, false, false);
                if (swap1)
                {
                    RichTextBoxInfo.Text += "\n[LOG] Mesh removed";
                    Settings.Default.DualRaidersEnabled = false;
                    Settings.Default.Save();
                }

                bool swap2 = Engine.Revert(offsetpick, pickaxepath, Equip, Equip1, 0, 0, false, false);
                if (swap2)
                    RichTextBoxInfo.Text += "\n[LOG] Equip Sound removed";

                bool swap3 = Engine.Revert(offsetpick, pickaxepath, Swing, Swing1, 0, 0, false, false);
                if (swap3)
                    RichTextBoxInfo.Text += "\n[LOG] Swing Sound removed";

                bool swap4 = Engine.Revert(offsetpick, pickaxepath, Impact, Impact1, 0, 0, false, false);
                if (swap4)
                    RichTextBoxInfo.Text += "\n[LOG] Impact Sound removed";

                convertButton.Text = "Convert";
                stopwatch.Stop();
                double num = (double)stopwatch.Elapsed.Milliseconds;
                RichTextBoxInfo.AppendText("\n[LOG] Done! Reverted in " + num + " ms.");

            }
        }
    }
}
