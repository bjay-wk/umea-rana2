﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Umea_rana
{
    class IA_manager_S : IA_Manager_max
    {


        public IA_manager_S(Texture2D n_textture, Rectangle n_rectangle, int front_sc, int speed)
        {
            ia_manage = new List<vaisseau_IA>();
            this._texture = n_textture;
            this._rectangle = n_rectangle;
            this.speed = speed;
            this.front_sc = front_sc;
        }

        public void Update(objet sprite, ref KeyboardState keyboard)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.Update(sprite, ref keyboard);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.draw(spritebatch);
        }
    }

    public class IA_manager_AR : IA_Manager_max
    {


        public IA_manager_AR(Texture2D n_textture, Rectangle n_rectangle, int front_sc,int speed)
        {
            ia_manage = new List<vaisseau_IA>();
            this._texture = n_textture;
            this._rectangle = n_rectangle;
            this.speed = speed;
            this.front_sc = front_sc;
        }

        public void Update( ref KeyboardState keyboard)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.UpdateAR(ref keyboard);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.draw(spritebatch);
        }
    }


    public class IA_manager_AA : IA_Manager_max
    {

        public IA_manager_AA(Texture2D n_textture, Rectangle n_rectangle, int front_sc, int speed)
        {
            ia_manage = new List<vaisseau_IA>();
            this._texture = n_textture;
            this._rectangle = n_rectangle;
            this.speed = speed;
            this.front_sc = front_sc;
        }

        public void Update(ref KeyboardState keyboard)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.Update_A();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Stalker vaiss in ia_manage)
                vaiss.draw (spritebatch);
        }
    }



}
