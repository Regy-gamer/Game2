using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game2
{
    class Button
    {
        bool isPressed;
        MouseOver mouseOver;
        UISprite uisprite;
        int buttonCooldown = 0;
        int buttonLenght = 20;
        enum buttonState { mousePressed, mouseOver, mouseExit};
        enum Item {text, button};
        Item item;
        buttonState state = buttonState.mouseExit;
        Texture2D defaultTexture;
        Texture2D overTexture;
        Texture2D downTexture;
        Color overColour = Color.White;
        Color defaultColour = Color.White;
        Color downColour = Color.White;
        DynamicText buttonText;


        public Button(Texture2D texture, int x, int y)
        {
            item = Item.button;
            uisprite = new UISprite(texture, x, y);
            mouseOver = new MouseOver(uisprite);
            defaultTexture = texture;
            mouseOver.OnmouseOver += new MouseOver.mouseOver(MouseOver);
            mouseOver.OnmouseExit += new MouseOver.mouseExit(MouseExit);
            mouseOver.OnButtonPress += new MouseOver.buttonPressed(ButtonPress);
        }
        public Button(DynamicText text)
        {
            buttonText = text;
            item = Item.text;
            mouseOver = new MouseOver(text);
            defaultColour = buttonText.Colour;
            mouseOver.OnmouseOver += new MouseOver.mouseOver(MouseOver);
            mouseOver.OnmouseExit += new MouseOver.mouseExit(MouseExit);
            mouseOver.OnButtonPress += new MouseOver.buttonPressed(ButtonPress);
        }

        public Button(Texture2D defaultTex, Texture2D overTex, Texture2D downText, int x, int y)
        {
            uisprite = new UISprite(defaultTex, x, y);
            mouseOver = new MouseOver(uisprite);
            defaultTexture = defaultTex;
            overTexture = overTex;
            downTexture = downText;

            mouseOver.OnmouseOver += new MouseOver.mouseOver(MouseOver);
            mouseOver.OnmouseExit += new MouseOver.mouseExit(MouseExit);
            mouseOver.OnButtonPress += new MouseOver.buttonPressed(ButtonPress);
            item = Item.button;
        }


        public Color OverColour
        {
            set { overColour = value; }
        }

        public Color DownColour
        {
            set { downColour = value; }
        }
        public Color DefaultColour
        {
            set { defaultColour = value; }
        }

        public UISprite uiSprite
        {
            get { return uisprite;}
        }

        public DynamicText Text
        {
            get { return buttonText; }
            set { buttonText = value; }
        }

        public void MouseOver()
        {
            state = buttonState.mouseOver;
            if (buttonCooldown <= 0)
            {
                if (item == Item.button)
                {
                    uisprite.SpriteColour = overColour;
                    uiSprite.Texture = overTexture;
                    isPressed = false;
                }
                if(item == Item.text)
                {
                    buttonText.Colour = overColour;
                    isPressed = false;
                }
            }
        }

        public void MouseExit()
        {
            state = buttonState.mouseExit;
            if (buttonCooldown <= 0)
            {
                if (item == Item.text)
                {
                    buttonText.Colour = defaultColour;
                    isPressed = false;
                }
                if (item == Item.button)
                {
                    uisprite.SpriteColour = defaultColour;
                    uiSprite.Texture = defaultTexture;
                    isPressed = false;
                }
            }
           
        }

        public void ButtonPress()
        {
            state = buttonState.mousePressed;
            if (item == Item.text)
            {
                buttonText.Colour = downColour;
                isPressed = true;
            }
           
            buttonCooldown = buttonLenght;
            if (item == Item.button)
            {
                uisprite.SpriteColour = downColour;
                uiSprite.Texture = downTexture;
                isPressed = true;
            }
        }

        public bool Pressed
        {
            get { return isPressed; }
        }

        public void Update(GameTime gameTime)
        {
            mouseOver.Update(gameTime);
            if (item == Item.text)
            {
                buttonText.Update(gameTime);
            }

            if (buttonCooldown > 0)
            {
                buttonCooldown--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (item == Item.button)
            {
                uisprite.Draw(spriteBatch);
            }

            if (item == Item.text)
            {
                buttonText.Draw(spriteBatch);
            }
        }

    }
}
