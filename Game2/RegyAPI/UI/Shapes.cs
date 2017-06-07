using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Shapes
    {

        public Texture2D texture;
        public int x;
        public int y;
        public int height;
        public int width;
        public Color color;

        public Shapes(int _x, int _y, int _height, int _width, Color _col)
        {
            height = _height;
            width = _width;
            x = _x;
            y = _y;
            color = _col;
            texture = new Texture2D(GameServices.GetService<GraphicsDevice>(), width, height);
        }
        

        public virtual void createShape()
        {
            Color[] data = new Color[50 * 50];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                //the function applies the color according to the specified pixel
                data[pixel] = Color.White;
            }

            //set the color
            texture.SetData(data);
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Color Colour
        {
            get { return color; }
            set { color = value; }
        }

        public void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Vector2(x,y), new Rectangle(0, 0, height, width), color, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
