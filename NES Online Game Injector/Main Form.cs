﻿using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;
using System.Linq;

namespace NES_Online_Game_Injector
{
    public partial class Form1 : MaterialForm
    {
        Nvntexpkg Nconvert;
        Zdrop Zconvert;

        public Form1()
        {
            InitializeComponent();
            Nconvert = new Nvntexpkg();
            Zconvert = new Zdrop();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red100, TextShade.WHITE);
        }

        private void InjectCompleted()
        {
            MessageBox.Show("Game injected!", "Have fun ;)", MessageBoxButtons.OK);
        }

        private void infoSorttitle_Click(object sender, EventArgs e)
        {
            toolTipSorttitle.SetToolTip(infoSorttitle, "Enter the sort of the game");
        }

        private void infoPublisher_Click(object sender, EventArgs e)
        {
            toolTipPublisher.SetToolTip(infoPublisher, "Enter the name of the publisher");
        }

        private void infoGamecode_Click(object sender, EventArgs e)
        {
            toolTipGamecode.SetToolTip(infoGamecode, "Enter the unique gamecode between (AAAAA and ZZZZZ)\r\nlike (ABCDE)\r\nNote: only big Letters");
        }

        private void infoCopyright_Click(object sender, EventArgs e)
        {
            toolTipCopyright.SetToolTip(infoCopyright, "Enter the copyright of the game");
        }

        private void infoGametitle_Click(object sender, EventArgs e)
        {
            toolTipGametitle.SetToolTip(infoGametitle, "Enter the name of the game");
        }

        private void infoOverscan_Click(object sender, EventArgs e)
        {
            toolTipOverscan.SetToolTip(infoOverscan, "Enter the overscan for the game (one number into each box)\r\nExample of the most games overscan: [0] [0] [9] [3]");
        }

        private void infoSimultanus_Click(object sender, EventArgs e)
        {
            toolTipSimultanus.SetToolTip(infoSimultanus, "Enter the simultanus (true or false) for the game\r\nExample of Mario Bros simultanus: true\r\nExample of Super Mario Bros simultanus: false");
        }

        private void infoFadein_Click(object sender, EventArgs e)
        {
            toolTipFadein.SetToolTip(infoFadein, "Enter the fade in for the game (one number into each box)\r\nExample of Mario Bros fade in: [3] [2]\r\nExample of The Legend of Zelda fade in: [6] [2]");
        }

        private void infoVolume_Click(object sender, EventArgs e)
        {
            toolTipVolume.SetToolTip(infoVolume, "Enter the volume for the game (between 0 and 99)\r\nExample of Mario Bros volume: [74]\r\nExample of The Legend of Zelda volume: [78]");
        }

        private void GameBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog GameBrowse = new OpenFileDialog();
            GameBrowse.Title = "Browse for NES Game";
            GameBrowse.Filter = "NES File (*.nes*)|*.nes*";
            GameBrowse.FilterIndex = 1;

            if (GameBrowse.ShowDialog() == DialogResult.OK)
                GamepathTextbox.Text = GameBrowse.FileName;
        }

        private void Coverpath1BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog Coverpath1Browse = new OpenFileDialog();
            Coverpath1Browse.Title = "Browse for Cover";
            Coverpath1Browse.Filter = "TGA File (*.tga*)|*.tga*";
            Coverpath1Browse.FilterIndex = 1;

            if (Coverpath1Browse.ShowDialog() == DialogResult.OK)
                Coverpath1Textbox.Text = Coverpath1Browse.FileName;
        }

        private void Coverpath2BrowseButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Coverpath2Browse = new OpenFileDialog();
            Coverpath2Browse.Title = "Browse for Cover";
            Coverpath2Browse.Filter = "TGA File (*.tga*)|*.tga*";
            Coverpath2Browse.FilterIndex = 1;

            if (Coverpath2Browse.ShowDialog() == DialogResult.OK)
                Coverpath2Textbox.Text = Coverpath2Browse.FileName;
        }

        private void TitledbBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog TitledbBrowse = new OpenFileDialog();
            TitledbBrowse.Title = "Browse for Title DB";
            TitledbBrowse.Filter = "titlesdb File (*.titlesdb*)|*.titlesdb*";
            TitledbBrowse.FilterIndex = 1;

            if (TitledbBrowse.ShowDialog() == DialogResult.OK)
                TitledbTextbox.Text = TitledbBrowse.FileName;
        }

        private void InjectButton_Click(object sender, EventArgs e)
        {
            if (SortTitleTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the SortTitle!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (PublisherTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Publisher!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (GamecodeTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Game Code!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (GamecodeTextbox.Text.Length < 5 || GamecodeTextbox.Text.Length > 5)
            {
                MessageBox.Show("Enter the unique Game Code (between AAAAA and ZZZZZ)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (CopyrightTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Copyright!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (GametitleTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Game Title!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Overscan box 1", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox.Text.Length < 1 || OverscanTextbox.Text.Length > 1)
            {
                MessageBox.Show("Enter the Overscan box 1 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox2.Text == string.Empty)
            {
                MessageBox.Show("Enter the Overscan box 2", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox2.Text.Length < 1 || OverscanTextbox2.Text.Length > 1)
            {
                MessageBox.Show("Enter the Overscan box 2 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox3.Text == string.Empty)
            {
                MessageBox.Show("Enter the Overscan box 3", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox3.Text.Length < 1 || OverscanTextbox3.Text.Length > 1)
            {
                MessageBox.Show("Enter the Overscan box 3 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox4.Text == string.Empty)
            {
                MessageBox.Show("Enter the Overscan box 4", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (SimultanusTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Simultanus (true or false)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (OverscanTextbox4.Text.Length < 1 || OverscanTextbox4.Text.Length > 1)
            {
                MessageBox.Show("Enter the Overscan box 4 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (FadeinTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Fade In box 1", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (FadeinTextbox.Text.Length < 1 || FadeinTextbox.Text.Length > 1)
            {
                MessageBox.Show("Enter the Fade In box 1 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (FadeinTextbox2.Text == string.Empty)
            {
                MessageBox.Show("Enter the Fade In box 2", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (FadeinTextbox2.Text.Length < 1 || FadeinTextbox2.Text.Length > 1)
            {
                MessageBox.Show("Enter the Fade In box 2 between (0 and 9)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (VolumeTextbox.Text.Length < 1 || VolumeTextbox.Text.Length > 2)
            {
                MessageBox.Show("Enter the Volume (1-99)", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (VolumeTextbox.Text == string.Empty)
            {
                MessageBox.Show("Enter the Volume", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (GamepathTextbox.Text == string.Empty)
            {
                MessageBox.Show("Invalid Game path", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (Coverpath1Textbox.Text == string.Empty)
            {
                MessageBox.Show("Invalid Cover path 400x300", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (Coverpath2Textbox.Text == string.Empty)
            {
                MessageBox.Show("Invalid Cover path 355x512", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (TitledbTextbox.Text == string.Empty)
            {
                MessageBox.Show("Invalid Title DB path", "Error.", MessageBoxButtons.OK);
                return;
            }
            string line;
            using (StreamReader CheckGamecode = new StreamReader(TitledbTextbox.Text))

                if ((line = CheckGamecode.ReadToEnd()) != null)
                {
                    if (line.Contains(GamecodeTextbox.Text))
                    {
                        MessageBox.Show("Gamecode " + GamecodeTextbox.Text + " already exist in the TitleDB", "Error");
                        return;
                    }
                }
            
            string filecheck1 = "cover.xtx";
            if (File.Exists(filecheck1))
            {
                File.Delete(@"cover.xtx");
            }
            string filecheck2 = "screenshot.xtx";
            if (File.Exists(filecheck2))
            {
                File.Delete(@"screenshot.xtx");
            }
            string filecheck3 = "cover.xtx.zlib";
            if (File.Exists(filecheck3))
            {
                File.Delete(@"cover.xtx.zlib");
            }
            string filecheck4 = "screenshot.xtx.zlib";
            if (File.Exists(filecheck4))
            {
                File.Delete(@"screenshot.xtx.zlib");
            }
            string filecheck5 = "temp/cover.tga";
            if (Directory.Exists(filecheck5))
            {
                Directory.Delete("temp/cover.tga");
            }
            string filecheck6 = "temp/screenshot.tga";
            if (Directory.Exists(filecheck6))
            {
                Directory.Delete("temp/screenshot.tga");
            }
            string filecheck7 = "temp/lclassics.titlesdb";
            if (Directory.Exists(filecheck7))
            {
                Directory.Delete("temp/lclassics.titlesdb");
            }
            string filecheck8 = "temp";
            if (Directory.Exists(filecheck8))
            {
                Directory.Delete("temp");
            }

            if (JPChackbox.Checked == false)
            {

                Directory.CreateDirectory("NES_ONLINE_Mod");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100D870045B6000");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100D870045B6000/romfs");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100D870045B6000/romfs/CLV-H-" + GamecodeTextbox.Text);

                Directory.CreateDirectory("temp");
                File.Copy(@Coverpath1Textbox.Text, "temp/cover.tga");
                File.Copy(@Coverpath2Textbox.Text, "temp/screenshot.tga");
                string filecheck9 = "cover.tga";
                if (File.Exists(filecheck9))
                {
                    File.Delete(@"cover.tga");
                }
                string filecheck10 = "screenshot.tga";
                if (File.Exists(filecheck10))
                {
                    File.Delete(@"screenshot.tga");
                }
                File.Move(@"temp/cover.tga", "cover.tga");
                File.Move(@"temp/screenshot.tga", "screenshot.tga");

                Nconvert.RunCommand($"-i cover.tga -o cover.xtx --mip-filter box --minmip 5 -f rgba8");
                Nconvert.RunCommand($"-i screenshot.tga -o screenshot.xtx --mip-filter box --minmip 5 -f rgba8");
                Zconvert.RunCommand($"cover.xtx");

                File.Copy(@"cover.xtx.zlib", "NES_ONLINE_Mod/titles/0100D870045B6000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + ".xtx.z");
                File.Delete(@"cover.xtx");
                File.Delete(@"cover.xtx.zlib");

                Zconvert.RunCommand($"screenshot.xtx");
                File.Copy(@"screenshot.xtx.zlib", "NES_ONLINE_Mod/titles/0100D870045B6000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + "00.xtx.z");
                File.Delete(@"screenshot.xtx");
                File.Delete(@"screenshot.xtx.zlib");

                File.Copy(@GamepathTextbox.Text, "NES_ONLINE_Mod/titles/0100D870045B6000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + ".nes");

                File.Copy(@TitledbTextbox.Text, "temp/lclassics.titlesdb");
                string filecheck11 = "NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb";
                if (File.Exists(filecheck11))
                {
                    File.Delete(@"NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb");
                }
                File.Move(@"temp/lclassics.titlesdb", "NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb");
                Directory.Delete("temp");
                
                var lines2 = File.ReadAllLines("NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb");
                File.WriteAllLines("NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb", lines2.Take(lines2.Length - 2).ToArray());
                using (StreamWriter db = new FileInfo("NES_ONLINE_Mod/titles/0100D870045B6000/romfs/lclassics.titlesdb").AppendText())
                {
                    db.WriteLine("        ,");
                    db.WriteLine("        {");
                    db.WriteLine("            \"sort_title\": \"" + SortTitleTextbox.Text + "\",");
                    db.WriteLine("            \"publisher\": \"" + PublisherTextbox.Text + "\",");
                    db.WriteLine("            \"code\": \"CLV-H-" + GamecodeTextbox.Text + "\",");
                    db.WriteLine("            \"rom\": \"/titles/CLV-H-" + GamecodeTextbox.Text + "/CLV-H-" + GamecodeTextbox.Text + ".nes\",");
                    db.WriteLine("            \"copyright\": \"" + CopyrightTextbox.Text + "\",");
                    db.WriteLine("            \"title\": \"" + GametitleTextbox.Text + "\",");
                    db.WriteLine("            \"volume\": " + VolumeTextbox.Text + ",");
                    db.WriteLine("            \"release_date\": \"1987-12-01\",");
                    db.WriteLine("            \"players_count\": 1,");
                    db.WriteLine("            \"cover\": \"/titles/CLV-H-" + GamecodeTextbox.Text + "/CLV-H-" + GamecodeTextbox.Text + ".xtx.z\",");
                    db.WriteLine("            \"overscan\": [" + OverscanTextbox.Text + ", " + OverscanTextbox2.Text + ", " + OverscanTextbox3.Text + ", " + OverscanTextbox4.Text + "],");
                    db.WriteLine("            \"armet_version\": \"v1\",");
                    db.WriteLine("            \"lcla6_release_date\": \"2018-09-01\",");
                    db.WriteLine("            \"save_count\": 0,");
                    db.WriteLine("            \"simultaneous\": " + SimultanusTextbox.Text + ",");
                    db.WriteLine("            \"fadein\": [" + FadeinTextbox.Text + ", " + FadeinTextbox2.Text + "],");
                    db.WriteLine("            \"details_screen\": \"\",");
                    db.WriteLine("            \"armet_threshold\": 80,");
                    db.WriteLine("            \"sort_publisher\": \"" + PublisherTextbox.Text + "\"");
                    db.WriteLine("        }");
                    db.WriteLine("    ]");
                    db.WriteLine("}");
                    db.Close();
                }
            }
            else if (JPChackbox.Checked)
            {
                Directory.CreateDirectory("NES_ONLINE_Mod");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100B4E00444C000");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100B4E00444C000/romfs");
                Directory.CreateDirectory("NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/CLV-H-" + GamecodeTextbox.Text);

                Directory.CreateDirectory("temp");
                File.Copy(@Coverpath1Textbox.Text, "temp/cover.tga");
                File.Copy(@Coverpath2Textbox.Text, "temp/screenshot.tga");
                string filecheck9 = "cover.tga";
                if (File.Exists(filecheck9))
                {
                    File.Delete(@"cover.tga");
                }
                string filecheck10 = "screenshot.tga";
                if (File.Exists(filecheck10))
                {
                    File.Delete(@"screenshot.tga");
                }
                File.Move(@"temp/cover.tga", "cover.tga");
                File.Move(@"temp/screenshot.tga", "screenshot.tga");

                Nconvert.RunCommand($"-i cover.tga -o cover.xtx --mip-filter box --minmip 5 -f rgba8");
                Nconvert.RunCommand($"-i screenshot.tga -o screenshot.xtx --mip-filter box --minmip 5 -f rgba8");
                Zconvert.RunCommand($"cover.xtx");

                File.Copy(@"cover.xtx.zlib", "NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + ".xtx.z");
                File.Delete(@"cover.xtx");
                File.Delete(@"cover.xtx.zlib");

                Zconvert.RunCommand($"screenshot.xtx");
                File.Copy(@"screenshot.xtx.zlib", "NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + "00.xtx.z");
                File.Delete(@"screenshot.xtx");
                File.Delete(@"screenshot.xtx.zlib");

                File.Copy(@GamepathTextbox.Text, "NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/CLV-H-" + GamecodeTextbox.Text + "\\" + "CLV-H-" + GamecodeTextbox.Text + ".nes");

                File.Copy(@TitledbTextbox.Text, "temp/lclassics.titlesdb");
                string filecheck11 = "NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/lclassics.titlesdb";
                if (File.Exists(filecheck11))
                {
                    File.Delete(@"NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/lclassics.titlesdb");
                }
                File.Move(@"temp/lclassics.titlesdb", "NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/lclassics.titlesdb");
                Directory.Delete("temp");

                string fileContent = File.ReadAllText("NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/lclassics.titlesdb");
                fileContent = fileContent.Remove(fileContent.Length - 2) + 
                    " ,{\"sort_title\": \"" + SortTitleTextbox.Text + "\", " + 
                    "\"publisher\": \"" + PublisherTextbox.Text + "\", " + 
                    "\"code\": \"CLV-H-" + GamecodeTextbox.Text + "\", " + 
                    "\"rom\": \"/titles/CLV-H-" + GamecodeTextbox.Text + "/CLV-H-" + GamecodeTextbox.Text + ".nes\", " + 
                    "\"copyright\": \"" + CopyrightTextbox.Text + "\", " + 
                    "\"title\": \"" + GametitleTextbox.Text + "\", " + 
                    "\"volume\": " + VolumeTextbox.Text + ", " + 
                    "\"release_date\": \"1987-12-01\", " + 
                    "\"players_count\": 1," + 
                    "\"cover\": \"/titles/CLV-H-" + GamecodeTextbox.Text + "/CLV-H-" + GamecodeTextbox.Text + ".xtx.z\"," + 
                    "\"overscan\": [" + OverscanTextbox.Text + ", " + OverscanTextbox2.Text + ", " + OverscanTextbox3.Text + ", " + OverscanTextbox4.Text + "]," + 
                    "\"armet_version\": \"v1\"," + 
                    "\"lcla6_release_date\": \"2018-09-01\"," + 
                    "\"save_count\": 0," + 
                    "\"simultaneous\": " + SimultanusTextbox.Text + "," + 
                    "\"fadein\": [" + FadeinTextbox.Text + ", " + FadeinTextbox2.Text + "]," + 
                    "\"details_screen\": \"/titles/CLV-H-" + GamecodeTextbox.Text + "/CLV-H-" + GamecodeTextbox.Text + "00.xtx.z\"," + 
                    "\"armet_threshold\": 80," + 
                    "\"sort_publisher\": \"" + PublisherTextbox.Text + "\"" + "}]}";
                File.WriteAllText("NES_ONLINE_Mod/titles/0100B4E00444C000/romfs/lclassics.titlesdb", fileContent);
            }
            InjectCompleted();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/8mNFFcC");
        }
    }
}
