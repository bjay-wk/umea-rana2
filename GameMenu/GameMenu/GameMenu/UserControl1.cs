﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Threading;

namespace Umea_rana
{
    public partial class UserControl1 : Form
    {
        string life, speed, couleur, onglet1, onglet2, onglet3, onglet4, trajectoir, align, OK, firerate, end;
        string imagefond, vitessefond, vitesseV, open, cancel, load, save, filepath, filepathlabel, onglet5;
        string scrolling, file, damage;
        // tag
        string t_life = "life", t_speed = "speed", t_damage = "damage", t_firerate = "fire", t_nbr = "nbr";
        // type
        string type;
        System.Drawing.Color color2, color4;
        int width, height;
        int seconde;
        public bool IHave_control;
        string imageB;
        float openX, openY;
        IA_manager_T manage_T;
        IA_manager_V manage_V;
        IA_manager_K manage_k;
        Sauveguarde sauve;
        savefile savefile;
        List<string> subdirectory;

        public UserControl1()
        {
            InitializeComponent();
            Initialize();
            this.Hide();
            color4 = System.Drawing.Color.Black;
            imagefond = string.Empty;
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            IHave_control = false;
            //    game = this.game;

            seconde = 0;
            filepath = string.Empty;
            sauve = new Sauveguarde();
            savefile = new savefile();
            savefile.ia_Kamikaze = new List<couple>();
            savefile.ia_tireur = new List<quaintuplet>();
            savefile.ia_viseur = new List<quaintuplet>();
            savefile.levelProfile = new levelProfile();
            subdirectory = new List<string>();
            button9.Enabled = false;
            type = "S_";
            string[] hello = sauve.subdirectory(type );
            if (hello.Length == 0)
            {
                comboBox2.Enabled = false;
                comboBox2.Text = "vide";
            }
            else
            {
                foreach (string h in hello)
                    comboBox2.Items.Add(h);
                comboBox2.Enabled = true;
                comboBox2.Text = "dossier existant";
            }
        }

        public void _show(int X, int y)
        {
            IHave_control = true;
            int decal = 100;
            openX = (float)X / (float)width;
            openY = (float)y / (float)height;

            if (X > width / 2)
                X -= (decal + this.Width);
            else
                X += decal;
            if (y > height / 2)
                y -= (decal + this.Height);
            else
                y += decal;
            this.Location = new System.Drawing.Point(X, y);
            this.Show();

        }

        public void update(ref IA_manager_T manage_T, ref IA_manager_V manage_V, ref IA_manager_K manage_k, ref KeyboardState keybord)
        {
            manage_T = this.manage_T;
            manage_V = this.manage_V;
            manage_k = this.manage_k;
            if (keybord.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
                ++seconde;
            if (keybord.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                --seconde;
        }

        public void LoadContent(IA_manager_T manage_T, IA_manager_V manage_V, IA_manager_K manage_k)
        {
            this.manage_T = manage_T;
            this.manage_V = manage_V;
            this.manage_k = manage_k;
        }

        public void destroy()
        {
            this.Dispose();
        }

        public void hidou()
        {
            this.Hide();
            Initialize();
            IHave_control = false;
        }

        private void intcheck(TextBox texbox)
        {
            int res, n=0;
            if ((string)texbox.Tag == t_damage)
                n = 3;
            else if ((string)texbox.Tag == t_firerate)
                n = 200;
            else if ((string)texbox.Tag == t_life)
                n = 300;
            else if ((string)texbox.Tag == t_nbr)
                n = 17;
            else if ((string)texbox.Tag == t_speed)
                n = 10;

            if (texbox.Text != string.Empty)
                if (int.TryParse(texbox.Text, out res))
                    if (res <= n)
                        texbox.BackColor = System.Drawing.Color.Green;
                    else
                    {
                        texbox.BackColor = System.Drawing.Color.Red;
                    }
                else
                {
                    texbox.BackColor = System.Drawing.Color.Red;
                }
        }

        #region texbox chek


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox3);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox4);
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox5);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox6);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox7);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox8);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox9);
        }

        // textbox 10 namcheck
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox11);
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox12);
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox13);
        }


        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            intcheck(textBox14);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            nameCheck(ref textBox10);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button9.Enabled = true;
        }
        #endregion

        #region dialogopen

        private void button2_Click(object sender, EventArgs e)// tab1 color
        {
            colorDialog1.ShowDialog();
            color2 = colorDialog1.Color;
            button2.BackColor = color2;
        }

        private void button6_Click(object sender, EventArgs e)// tab4 color
        {
            colorDialog2.ShowDialog();
            color4 = colorDialog2.Color;
            button6.BackColor = color4;
        }
        private void button5_Click(object sender, EventArgs e)// tab4 showfile
        {
            open_File_dialogue();
        }

        #endregion

        #region validate button

        private void button3_Click(object sender, EventArgs e)// tab2 kamikaze
        {
            if (textBox4.BackColor == System.Drawing.Color.Green &&
                textBox5.BackColor == System.Drawing.Color.Green &&
                textBox12.BackColor == System.Drawing.Color.Green)
            {
                couple couple = new couple();
                couple.X = openX;
                couple.Y = openY;
                couple.seconde = seconde;
                couple.damage = int.Parse(textBox12.Text);
                couple.speed = int.Parse(textBox5.Text);
                couple.vie = int.Parse(textBox4.Text);
                savefile.ia_Kamikaze.Add(couple);
                manage_k.Add(openX, openY, seconde);
                this.hidou();

            }
        }
        private void button7_Click(object sender, EventArgs e)// cancel
        {
            this.hidou();
        }
        private void button8_Click(object sender, EventArgs e)// save and load
        {
            if (textBox10.BackColor == System.Drawing.Color.Green)
            {
                savefile.levelProfile.levelname = filepath;
                if (savefile.levelProfile.background_name != string.Empty &&
                    savefile.levelProfile.playerLife != 0)
                {
                    savegame();
                    this.hidou();
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)// tab viseur et tireur
        {

            if (textBox1.BackColor == System.Drawing.Color.Green && textBox2.BackColor == System.Drawing.Color.Green &&
                textBox3.BackColor == System.Drawing.Color.Green && textBox6.BackColor == System.Drawing.Color.Green &&
                textBox13.BackColor == System.Drawing.Color.Green &&
                color2 != System.Drawing.Color.Black)//+combobox4 a veriff
            {
                quaintuplet quaint = new quaintuplet();
                quaint.color = new Microsoft.Xna.Framework.Color(color2.R, color2.B, color2.G, color2.A);
                quaint.damage = int.Parse(textBox13.Text);
                quaint.firerate = int.Parse(textBox6.Text);
                quaint.nombre = int.Parse(textBox3.Text);
                quaint.seconde = seconde;
                quaint.speed = int.Parse(textBox2.Text);
                quaint.trajectory = (string)comboBox4.SelectedItem;
                quaint.vie = int.Parse(textBox1.Text);
                quaint.X = openX;
                quaint.Y = openY - 1;

                if (radioButton1.Checked)
                {

                    savefile.ia_tireur.Add(quaint);
                    manage_T.Add(openX, openY, seconde, quaint.nombre, quaint.color);
                    this.hidou();
                }
                else if (radioButton2.Checked)
                {
                    savefile.ia_viseur.Add(quaint);
                    manage_V.Add(openX, openY, seconde, quaint.nombre, quaint.color);
                    this.hidou();
                }

            }
        } // tab1
        private void button4_Click(object sender, EventArgs e) //tab4 bacground
        {
            if (textBox7.BackColor == System.Drawing.Color.Green && imageB != string.Empty)
            {
                savefile.levelProfile.background_name = imageB;
                savefile.levelProfile.fc_speed = int.Parse(textBox7.Text);
                savefile.levelProfile.second_background = (string)comboBox1.SelectedItem;
                savefile.levelProfile.third_bacground = (string)comboBox3.SelectedItem;
                this.hidou();
            }

        }

        private void button9_Click(object sender, EventArgs e)// load
        {

            loadgame((string)comboBox2.SelectedItem);
            textBox10.Text = (string)comboBox2.SelectedItem;
            hidou();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox14.BackColor == System.Drawing.Color.Green && textBox8.BackColor == System.Drawing.Color.Green &&
                textBox9.BackColor == System.Drawing.Color.Green && textBox11.BackColor == System.Drawing.Color.Green &&
                color4 != System.Drawing.Color.Black)
            {
                savefile.levelProfile.color = new Microsoft.Xna.Framework.Color(color4.R, color4.G, color4.B, color4.A);
                savefile.levelProfile.damage = int.Parse(textBox11.Text);
                savefile.levelProfile.firerate = int.Parse(firerate);
                savefile.levelProfile.playerLife = int.Parse(textBox14.Text);
                savefile.levelProfile.player_speed = int.Parse(textBox8.Text);
                hidou();
            }

        }// player profile



        #endregion

        private void nameCheck(ref TextBox textbox)
        {
            string text = string.Empty;
            if (textbox.Text != string.Empty)
            {
                for (int i = 0; i < textbox.Text.Length && textbox.Text[i] != '.'; ++i)
                    text += textbox.Text[i];

                textbox.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                textbox.BackColor = System.Drawing.Color.Red;
            }
            filepath = text;
            textbox.Text = filepath;

        }

        private void Initialize()
        {
            life = "point de vie";
            speed = "vitesse";
            couleur = "couleur de tir";
            onglet1 = "Tireur";
            onglet2 = "Viseur";
            onglet3 = "kamikaze";
            onglet4 = "fond";
            onglet5 = "personnage";
            trajectoir = "trajectoire";
            align = "alignement enemie";
            OK = "OK";
            firerate = "cadence de tir";
            end = "terminer";
            imagefond = "image du fond";
            vitessefond = "vitesse du fond";
            vitesseV = "vitesse";
            open = "ouvrir";
            cancel = "annuler";
            load = "charger";
            save = "sauvegarder";
            filepathlabel = "nom du niveau";
            scrolling = "defilement vertical";
            file = "fichier";
            damage = "degat infligee";


            color2 = System.Drawing.Color.Black;
            //tap page

            tabPage2.Text = onglet1;// +"/" + onglet2;
            tabPage3.Text = onglet3;
            tabPage4.Text = onglet4;
            tabPage1.Text = file;
            tabPage5.Text = onglet5;
            //tab1
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton1.Text = onglet1;
            radioButton2.Text = onglet2;
            label3.Text = life;
            label4.Text = speed;
            label5.Text = trajectoir;
            label6.Text = align;
            label7.Text = couleur;
            button2.Text = couleur;

            label1.Text = firerate;
            button1.Text = OK;
            label19.Text = damage;
            //tab2
            label18.Text = damage;
            button3.Text = OK;

            // tab 3
            label2.Text = imagefond;
            button5.Text = open;
            label10.Text = vitessefond;
            button4.Text = end;
            label15.Text = scrolling + " : 1";
            label16.Text = scrolling + " : 2";
            //tab 4
            button7.Text = cancel;
            button8.Text = save;
            button9.Text = load;
            label14.Text = filepathlabel;
            if (textBox10.Text == string.Empty)
                textBox10.BackColor = System.Drawing.Color.Red;
            else
                textBox10.BackColor = System.Drawing.Color.Green;

            // tab 5
            label11.Text = vitesseV;
            label12.Text = firerate;
            label13.Text = couleur;
            button6.Text = couleur;

            label8.Text = life;
            label9.Text = speed;
            button10.Text = OK;
            label17.Text = damage;
            label20.Text = life;
            // default 
            button6.BackColor = Button.DefaultBackColor;
            button2.BackColor = Button.DefaultBackColor;

            textBox1.BackColor = System.Drawing.Color.White;
            textBox2.BackColor = System.Drawing.Color.White;
            textBox3.BackColor = System.Drawing.Color.White;
            textBox4.BackColor = System.Drawing.Color.White;
            textBox5.BackColor = System.Drawing.Color.White;
            textBox6.BackColor = System.Drawing.Color.White;
            textBox7.BackColor = System.Drawing.Color.White;
            textBox8.BackColor = System.Drawing.Color.White;
            textBox9.BackColor = System.Drawing.Color.White;
            textBox12.BackColor = System.Drawing.Color.White;
            textBox13.BackColor = System.Drawing.Color.White;

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox13.Text = string.Empty;
            //tag
            textBox1.Tag = t_life;
            textBox2.Tag  = t_speed;
            textBox3.Tag = t_nbr;
            textBox4.Tag = t_life;
            textBox5.Tag = t_speed;
            textBox6.Tag = t_firerate;
            textBox7.Tag = t_speed;
            textBox8.Tag = t_speed;
            textBox9.Tag = t_firerate;
        //  / textBox10. Tag = t_speed;
            textBox11.Tag = t_damage;
            textBox12.Tag = t_damage;
            textBox13.Tag = t_damage;
            textBox14.Tag = t_life;
            openX = 0;
            openY = 0;
        }

        private void savegame()
        {
            sauve.save(ref savefile );
        }

        private void loadgame(string file_name)
        {
            sauve.load(ref file_name, ref savefile );

            for (int i = 0; i < savefile.ia_tireur.Count; ++i)
                manage_T.Add(savefile.ia_tireur[i].X, savefile.ia_tireur[i].Y + 1, savefile.ia_tireur[i].seconde, savefile.ia_tireur[i].nombre, savefile.ia_tireur[i].color);
            for (int i = 0; i < savefile.ia_viseur.Count; ++i)
                manage_V.Add(savefile.ia_viseur[i].X, savefile.ia_viseur[i].Y, savefile.ia_viseur[i].seconde, savefile.ia_viseur[i].nombre, savefile.ia_viseur[i].color);
            for (int i = 0; i < savefile.ia_Kamikaze.Count; ++i)
                manage_k.Add(savefile.ia_Kamikaze[i].X, savefile.ia_Kamikaze[i].Y, savefile.ia_Kamikaze[i].seconde);
        }

        private void open_File_dialogue()
        {
            Thread thread = new Thread(() =>
            {
                var yourForm = new OpenFileDialog();
                
                if (yourForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageB = yourForm.FileName;
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

    }
}
