using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class EnemyBase : IEntity
    {
        float enemyGold;
        string enemyName;
        GameObject enemyObject;

        public EnemyBase(string _name, float _gold)
        {
            enemyGold = _gold;
            enemyName = _name;
        }

        public GameObject GameObject
        {
            get { return enemyObject; }
            set { enemyObject = value; }
        }

        public void destroy()
        {
            
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
