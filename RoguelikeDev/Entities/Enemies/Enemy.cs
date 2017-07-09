using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Enemies
{
    public class Enemy : Sprite
    {
        public Enemy(Texture2D texture, Vector2 location)
        {
            SpriteTexture = texture;
            Location = location;
        }

        public override void Load(ContentManager content)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
