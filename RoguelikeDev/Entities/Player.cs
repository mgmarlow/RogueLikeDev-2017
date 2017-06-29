using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities
{
    public class Player : Sprite
    {
        public Player(Texture2D texture, Vector2 location, Rectangle gameBounds)
            : base(texture, location, gameBounds)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }

        protected override void CheckBounds()
        {
            throw new NotImplementedException();
        }
    }
}
