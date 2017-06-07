using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game2
{
    class Utility
    {
        public Color ColorConverter(string hex)
        {
            int r;
            int g;
            int b;
            string color;

            color = hex[1].ToString() + hex[2].ToString();
            r = Convert.ToInt32(color, 16);
            color = hex[3].ToString() + hex[4].ToString();
            g = Convert.ToInt32(color, 16);
            color = hex[5].ToString() + hex[6].ToString();
            b = Convert.ToInt32(color, 16);

            return new Color(r, g, b);
        }
    }
}
