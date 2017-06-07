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
    class BattleScene : IScene
    {
        GraphicsDevice graphicsDevice; //= GameServices.GetService<GraphicsDevice>();
        Game1 game1 = GameServices.GetService<Game1>();
        //ContentManager Content = GameServices.GetService<Game1>().Content;
        Utility utility = new Utility();
        SpriteFont gillbertFont;
        Color fontColor;
        UISprite uiBackSprite;
        Texture2D background;
        Texture2D peach;
        Texture2D uiBack;
        DynamicText gilb;
        DynamicText run;
        DynamicText fight;
        DynamicText item;
        KeyboardState currentKeyboardState = Keyboard.GetState();
        KeyboardState previousKeyboardState = Keyboard.GetState();
        Button buttonRun;
        Button buttonFight;
        Button buttonItem;
        List<Button> buttons;
        int gold = 16327;


       

        public void Initialize(GraphicsDevice _graphicsDevice)
        {
            fontColor = utility.ColorConverter("#00FF99");
            buttons = new List<Button>();
            graphicsDevice = _graphicsDevice;
        }
        
        public void LoadContent(ContentManager Content)
        {
            Game1 game1 = GameServices.GetService<Game1>();
            
            gillbertFont = Content.Load<SpriteFont>("File");
            background = Content.Load<Texture2D>("background");
            peach = Content.Load<Texture2D>("enemy_peach");
            uiBack = Content.Load<Texture2D>("uiBoard");
            uiBackSprite = new UISprite(uiBack, 68, 470);
            gilb = new DynamicText("G", gold, gillbertFont, Color.Gold, 120, 500);
            fight = new DynamicText("FIGHT!!!", gillbertFont, Color.LightBlue, 125, 545);
            item = new DynamicText("ITEM", gillbertFont, fontColor, 250, 575);
            run = new DynamicText("RUN", gillbertFont, Color.Pink, 145, 588);

            buttonFight = new Button(fight);
            buttonItem = new Button(item);
            buttonRun = new Button(run);
            buttons.Add(buttonFight);
            buttons.Add(buttonRun);
            buttons.Add(buttonItem);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].DownColour = Color.DarkGray;
                buttons[i].OverColour = Color.LightGray;
            }

            for (int i = 1; i < buttons.Count; i++)
            {
                buttons[i].Text.Rotation = -0.1f;
                buttons[i].Text.Scale = 0.85f;
            }

            fight.Scale = 1.10f;
            fight.Rotation = -0.11f;
            gilb.Rotation = -0.09f;
        }

        public void UnloadContent ()
        {

        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game1.Exit();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();
            DrawGameObjects(spriteBatch);
            DrawGui(spriteBatch);
        }
        public void DrawGameObjects(SpriteBatch spriteBatch)
        {

        }
        public void DrawGui(SpriteBatch spriteBatch)
        {
            uiBackSprite.Draw(spriteBatch);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch);
            }
            gilb.Draw(spriteBatch);
        }

    }
}
