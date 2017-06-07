using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class DynamicText
    {
        Color Textcolor = Color.White;
        string text = "";
        SpriteFont font;
        int x;
        int y;
        float rotation = 0;
        Vector2 origin = new Vector2(0,0);
        int numberValue;
        bool valueSet = false;
        float fontScale = 1;

        public DynamicText(string _text, SpriteFont _font)
        {
            text = _text;
            font = _font;
            valueSet = false;
        }

        public DynamicText(string _text, SpriteFont _font, Color _textCol, int _x, int _y)
        {
            Textcolor = _textCol;
            text = _text;
            font = _font;
            x = _x;
            y = _y;
            valueSet = false;
        }

        public DynamicText(string _text,int _numberValue, SpriteFont _font, Color _textCol, int _x, int _y)
        {
            numberValue = _numberValue;
            Textcolor = _textCol;
            text = _text;
            font = _font;
            x = _x;
            y = _y;
            valueSet = true;
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

        public float Scale
        {
            get { return fontScale; }
            set { fontScale = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public Color Colour
        {
            get { return Textcolor; }
            set { Textcolor = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 RotationOrigin
        {
            get { return origin; }
            set { origin = value; }
        }
        public void Update(GameTime gameTime)
        {
            y = Y;
            x = X;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (valueSet)
            {
                spriteBatch.DrawString(font, text + numberValue, new Vector2(x, y), Textcolor, rotation, origin, fontScale, SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.DrawString(font, text, new Vector2(x, y), Textcolor, rotation, origin, fontScale, SpriteEffects.None, 1);
            }
            spriteBatch.End();
        }

    }    
}