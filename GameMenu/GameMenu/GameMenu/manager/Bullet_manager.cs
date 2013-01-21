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
    class Bullet_manager
    {
        Texture2D texture;
        Rectangle rectangle;
        SoundEffect soundeffect;
        public bool enableFire;

        int time1, tem2 = 0;

        public List<munition> bullet = new List<munition>();
        int speed;

        public Bullet_manager(Texture2D n_texture, Rectangle n_rectangle, int nb, int speed, SoundEffect n_soundeffect)
        {
            texture = n_texture;
            rectangle = n_rectangle;
            bullet.Capacity = nb;

            this.speed = speed;
            soundeffect = n_soundeffect;
            time1 = 30;
            enableFire = true;
        }

        public void Bullet_Update(KeyboardState keyboard, sripte_V sprite, KeyboardState oldkey)
        {
            if (keyboard.IsKeyDown(Keys.Space) && oldkey.IsKeyDown(Keys.Space) && tem2 <= 0 && enableFire) //autorisation de tire
            {

                tem2 = time1;
                bullet.Add(new munition(texture, new Rectangle(sprite.rectangle.Left + sprite.rectangle.Width / 2 - sprite.rectangle.Width / 8, sprite.rectangle.Top - sprite.rectangle.Height / 2, sprite.rectangle.Width / 4, sprite.rectangle.Height), speed));

                soundeffect.Play(); //lance un son lors du tire

            }
            tem2--;
            //update che chaque missile
            for (int i = 0; i < bullet.Count; i++)
            {
                bullet[i].update2();
                if (bullet[i].rectangle.Bottom < 0)
                    bullet.RemoveAt(i);
            }

        }

        public void Bullet_draw(SpriteBatch spritebach)
        {
            for (int i = 0; i < bullet.Count; i++)
                bullet[i].Draw(spritebach);
        }


    }
}