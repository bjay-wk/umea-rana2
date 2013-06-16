﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Umea_rana
{
    public struct quaintuplet
    {
        public float X;
        public float Y;
        public int seconde;
        public int nombre;
        public int vie;
        public int speed;
        public Color color;
        public int damage;
        public int firerate;
        public int bullet_Speed;
        public string trajectory;
    }
    public struct couple
    {
        public float X;
        public float Y;
        public int vie;
        public int speed;
        public int seconde;
        public int damage;
    }
    public struct levelProfile
    {
        public string levelname;
        public string next_level;
        public string background_name;
        public int fc_speed;
        public string second_background;
        public string third_bacground;
        public int playerLife;
        public int player_speed;
        public int firerate;
        public Color color;
        public int damage;
        public int bullet_speed;
        public string[] musique;
        public string IAcolor;
        public bool image_sprite { get; set; }//vrai= allem, faux = yoh
        public housesafe house { get; set; }
        public bossP bossPlatforme { get; set; }
    }
    public struct Bonus
    {
        public char type;
        public int speed,angle,launch;
        public float X, Y;
    }

    public struct IA_AA
    {
        public float X;
        public float Y;
        public int Vie;
        public int Puissance;
        public int Speed;
    }

    public struct IA_AR
    {
        public float X;
        public float Y;
        public int Vie;
        public int Puissance;
        public int Speed;
    }

    public struct IA_S
    {
        public float X;
        public float Y;
        public int Vie;
        public int Puissance;
        public int Speed;
    }

    public struct Plat
    {
        public float X;
        public float Y;
        public int nbr, speed;
        public float distance;
        public char type;
        public string name { get; set; }

    }

    public struct savefile
    {
        public List<IA_AA> ia_AA;
        public List<IA_AR> ia_AR;
        public List<IA_S> ia_S;
        public List<Plat> plat_f;
        public List<quaintuplet> ia_viseur;
        public List<quaintuplet> ia_tireur;
        public List<couple> ia_Kamikaze;
        public List<Bonus> bonus;
        public levelProfile levelProfile;

        public Boss_setting bossSEU { get; set; }

    }
    public struct PlayerProfile
    {
        int level;
        int life;
        string playername;

        public int _level
        {
            get { return level; }
            set { if (_level > level)level = _level; }
        }
        public int _life
        {
            get { return life; }
            set { if (_life > 0) life = _life; }
        }
        public string _playername
        {
            get { return playername; }
            set { if (_playername != string.Empty) playername = _playername; }
        }
    }
    public struct housesafe
    {
       public float X { get; set; }
       public float Y { get; set; }
    }
    public struct OptionProfile
    {
    }
}
