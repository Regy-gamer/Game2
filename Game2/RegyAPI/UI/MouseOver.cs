using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game2
{


    class MouseOver
    {
        public delegate void mouseOver();
        public event mouseOver OnmouseOver;
        public delegate void mouseExit();
        public event mouseExit OnmouseExit;
        public delegate void buttonPressed();
        public event buttonPressed OnButtonPress;
        enum Item { text, button };
        Item item;
        MouseState oldState;
        UISprite uiSprite;
        Rectangle mouseBounds;
        DynamicText dynamicText;
        Rectangle textBounds;
        bool inBounds = false;

        public MouseOver(UISprite _uiSprite)
        {
            uiSprite = _uiSprite;
            item = Item.button;
        }

        public MouseOver(DynamicText text)
        {
            dynamicText = text;
            textBounds = new Rectangle(text.X, text.Y, (int)text.Font.MeasureString(text.Text).X, (int)text.Font.MeasureString(text.Text).Y);
            item = Item.text;
        }

        public void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState();
            mouseBounds = new Rectangle(newState.X, newState.Y, 1, 1);
            if (item == Item.button)
            {
                if (uiSprite.Texture.Bounds.Contains(newState.X, newState.Y))
                {
                    inBounds = true;
                }
                else
                {
                    inBounds = false;
                }
            }

            if (item == Item.text)
            {
                if (textBounds.Contains(newState.X, newState.Y))
                {
                    inBounds = true;
                }
                else
                {
                    inBounds = false;
                }
            }

            if (inBounds)
            {
                OnmouseOver();
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    OnButtonPress();
                }
            }
            else
            {
                OnmouseExit();
            }

            oldState = newState;
        }



    }
}
