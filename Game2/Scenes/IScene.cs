using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    interface IScene
    {
        void Initialize(GraphicsDevice graphicsDevice);
        void LoadContent(ContentManager content);
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void DrawGui(SpriteBatch spriteBatch);
        void DrawGameObjects(SpriteBatch spriteBatch);
    }
}
