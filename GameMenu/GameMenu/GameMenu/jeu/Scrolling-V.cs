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
    class Scrolling : Background
    {
        private int speed;

        public Scrolling(Texture2D n_texture, Rectangle n_rectangle,int n_speed)
        {
            texture = n_texture;
            rectangle = n_rectangle;
            speed = n_speed;
        }

        public void Update()
        {
            rectangle.Y += speed;
        }
    }
}
