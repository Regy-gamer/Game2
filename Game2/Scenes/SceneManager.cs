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
        IList<Scene> scenes = new List<Scene>();

        public void Initialize()
        {
            AddScenes();
            for(int i = 0; i < scenes.Count; i++)
            {
                scenes[i].Initialize();
            }
        }

        //adds scenes to the list of scenes
        void AddScenes()
        {

        }
        public void LoadContent()
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].LoadContent();
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
