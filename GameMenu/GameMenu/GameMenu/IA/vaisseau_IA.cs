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

    public class vaisseau_IA : objet
    {

        protected Texture2D _texture;
        protected int _speed, width, front_sc , _damage;
        public int normalspeed{get; protected set;}
        public int  timer_lunch{ get ; protected set;}
        public int dir;
        public string trajectory { get; set; }
        public Bullet_manager bullet;
        protected Color Munition_color, Ia_color;
        public bool attaque;
        public bool attaque_ { get { return attaque; } }
        public int longueur_attaque { get; protected set; }
        public int longueur_Attaque { get { return longueur_attaque; } }

        public int Speed { get { return _speed; } set {_speed= Speed ;}}
        public int timer_Lunche { get { return timer_lunch; } }
        public int damage { get { return _damage; } }

        public int spawn;
        public int FrameLine;
        public int FrameColunm;
        public SpriteEffects Effects;
        public int Timer;
        public float shift = 0;
        /*
     
        public vaisseau_IA(Texture2D _texture, Rectangle n_rectangle, ContentManager Content, int height, int width, int _speed)
        {
            this.rectangle = n_rectangle;
            this._texture = _texture;
            this._speed = _speed;
            //def rectangle collision
            rectangle_Colision = rectangle;
            rectangle_Colision.Width = largeurX;
            rectangle_Colision.Height = hauteurY;
            decallageX = 0;
            decallageY = 0;
        }
        

        public void moveUp()
        {
            rectangle.Y -= _speed;
            rectangle_Colision.Y = rectangle.Y + decallageY;
        }
        public void moveDown()
        {
            rectangle.Y += _speed;
            rectangle_Colision.Y = rectangle.Y + decallageY;
        }
        public void moveRight()
        {
            rectangle.X += _speed;
            rectangle_Colision.X = rectangle.X + decallageX;
        }
        public void moveleft()
        {
            rectangle.Y -= _speed;
            rectangle_Colision.X = rectangle.X + decallageX;
        }

        */


        public virtual void Draw(SpriteBatch spritback)
        {
            spritback.Draw(_texture, rectangle, Ia_color);
        }

        public void move_H()
        {
            switch (trajectory )
            {
                case "sinus":
                    if (shift <= 0f)
                    {
                        shift = 100;
                        dir = -dir;
                    }
                    shift--;
                    rectangle.X += _speed * dir;
                    rectangle.Y--;
                    break ;
                case "exponetielle":

                    break;
                default :
                if (rectangle.Right > width + rectangle.Width)
                {
                    rectangle.X = width - 1;
                    rectangle.Y += rectangle_C.Height;
                    dir = -dir;

                }
                if (rectangle.Left < 0)
                {
                    rectangle.X = 0;
                    rectangle.Y += rectangle_C.Height;
                    dir = -dir;
                }
                rectangle.X += _speed * dir;
                break;
        }
            
        }

        public void Update_ophelia(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up))
                ++rectangle.Y;
            if (keyboard.IsKeyDown(Keys.Down))
                --rectangle.Y;
            Update_rec_collision();
        }

        public void Dipose()
        {
        
          
        }
    }

    public struct BossSEUstruct
    {
        public int life { get; set; }
        public int damage { get; set; }
        public float speed { get; set; }
        public Color bulletcolor { get; set; }
        public float speedball { get; set; }
    }

}
