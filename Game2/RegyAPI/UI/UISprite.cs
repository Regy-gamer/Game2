using System; 
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game2
{
    class UISprite
    {
        Texture2D texture;
        Vector2 position;
        Color spriteColour = Color.White;
        float x;
        float y;
        float scale = 1f;
        int spriteWidth = 10;
        int spriteHeight= 10;
        float depth;
        
        public UISprite(Texture2D _texture)
        {
            texture = _texture;
            position = new Vector2(x, y);
            spriteWidth = texture.Width;
            spriteHeight = texture.Height;
        }
        public UISprite(Texture2D _texture, int _x, int _y)
        {
            texture = _texture;
            x = _x;
            y = _y;
            position = new Vector2(x, y);
            spriteWidth = texture.Width;
            spriteHeight = texture.Height;
        }
        public UISprite(Texture2D _texture, float _x, float _y, Color _spriteColour, float _scale)
        {
            texture = _texture;
            x = _x;
            y = _y;
            position = new Vector2(x, y);
            spriteColour = _spriteColour;
            scale = _scale;
            spriteWidth = texture.Width;
            spriteHeight = texture.Height;
        }

        public float layerDepth
        {
            get { return depth; }
            set { depth = value; }
        }

        public int Width
        {
            get { return spriteWidth; }
            set { spriteWidth = value; }
        }

        public int Height
        {
            get { return spriteHeight; }
            set { spriteHeight = value; }
        }

        public Color SpriteColour
        {
            get { return spriteColour; }
            set { spriteColour = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public void Update(GameTime gameTime)
        {
            position = new Vector2(x, y);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, spriteWidth, spriteHeight), spriteColour, 0, new Vector2(0, 0), scale, SpriteEffects.None, depth);
            spriteBatch.End();

            if (scale > 0)
            {
                spriteWidth = texture.Width;
                spriteHeight = texture.Height;
            }
        }
    }
}
