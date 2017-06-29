using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public Player(Rectangle gameBounds) : base(gameBounds)
        {
        }
        
        public override void Load(ContentManager content, GameWindow window)
        {
            var playerTexture = content.Load<Texture2D>("avatar");
            var playerPos = new Vector2(window.ClientBounds.Width / 2 - playerTexture.Width / 2, window.ClientBounds.Height / 2 - playerTexture.Height / 2);
            LoadContent(playerTexture, playerPos);
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
