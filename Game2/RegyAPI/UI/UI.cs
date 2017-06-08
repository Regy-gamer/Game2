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
    class UI
    {
        DynamicText text;
        Button button;
        SquareShape square;
        UISprite image;
        int x = 0;
        int y = 0;
        Texture2D texture;
        bool drawSquare = false;
        bool drawImage = false;
        bool drawText = false;
        bool drawButton = false;


        public void Button(Texture2D _texture, int _x, int _y)
        {
            _x = x;
            _y = y;
            texture = _texture;
            button = new Button(texture, _x, _y);
            drawButton = true;
        }

        public void Square(int _x, int _y, int _height, int _width, Color _col)
        {
            _x = x;
            _y = y;
            square = new SquareShape(_x, _y,_height,_width,_col);
            drawSquare = true;
        }

        public void Text(string _text, SpriteFont _font, Color _textCol,int _x, int _y)
        {
            _x = x;
            _y = y;
            text = new DynamicText(_text, _font, _textCol, _x, _y);
            drawText = true;

        }

        public void TextButton(string _text, SpriteFont _font, Color _textCol, int _x, int _y)
        {
            _x = x;
            _y = y;
            text = new DynamicText(_text, _font, _textCol, _x, _y);
            button = new Button(text);
            drawButton = true;
        }

        public void Image(Texture2D _texture,int _x, int _y, Color _spriteColour, float _scale)
        {
            _x = x;
            _y = y;
            image = new UISprite(_texture,_x,_y,_spriteColour,_scale);
            drawImage = true;
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
        public void Update(GameTime gameTime)
        {
            if (drawButton)
            {
                button.Update(gameTime);
            }
            if (drawImage)
            {
                image.Update(gameTime);
            }
            if (drawText)
            {
                text.Update(gameTime);
            }
            if (drawSquare)
            {
                square.Update(gameTime);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (drawButton)
            {
                button.Draw(spriteBatch);
            }
            if (drawImage)
            {
                image.Draw(spriteBatch);
            }
            if (drawText)
            {
                text.Draw(spriteBatch);
            }
            if (drawSquare)
            {
                square.Draw(spriteBatch);
            }
        }
    }
}
