using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class SceneManager
    {
        //Add levels scenes to list
        IList<IScene> scenes = new List<IScene>();
        BattleScene bettle = new BattleScene();
        public void Initialize(GraphicsDevice graphicsDevice)
        {
            AddScenes();
            for(int i = 0; i < scenes.Count; i++)
            {
                scenes[i].Initialize(graphicsDevice);
            }
        }

        //adds scenes to the list of scenes
        void AddScenes()
        {
            scenes.Add(bettle);
        }
        public void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].LoadContent(Content);
            }
        }


        public void UnloadContent()
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].Update(gameTime);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].Draw(spriteBatch);
            }
        }
    }
}
