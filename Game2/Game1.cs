using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont gillbertFont;
        Color fontColor;
        Utility utility = new Utility();
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
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 360;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            GameServices.AddService<GraphicsDevice>(graphics.GraphicsDevice);
            fontColor = utility.ColorConverter("#00FF99");
            base.Initialize();
            this.IsMouseVisible = true;
            
            buttons = new List<Button>();
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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gillbertFont = Content.Load<SpriteFont>("File");
            background = Content.Load<Texture2D>("background");
            peach = Content.Load<Texture2D>("enemy_peach");
            uiBack = Content.Load<Texture2D>("uiBoard");
            uiBackSprite = new UISprite(uiBack, 68, 470);
            gilb = new DynamicText("G", gold, gillbertFont, Color.Gold, 120, 500);
            fight = new DynamicText("FIGHT!!!", gillbertFont, Color.LightBlue, 125, 545);
            item = new DynamicText("ITEM", gillbertFont, fontColor, 250, 575);
            run = new DynamicText("RUN", gillbertFont, Color.Pink, 145, 588);
            
            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(gameTime);
            }


            //textButton.Update(gameTime);

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();
            //textButton.Draw(spriteBatch);
            uiBackSprite.Draw(spriteBatch);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch);
            }
            gilb.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
