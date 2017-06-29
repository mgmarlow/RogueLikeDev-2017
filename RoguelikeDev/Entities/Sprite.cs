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
    public abstract class Sprite : IGameObject
    {
        public Texture2D SpriteTexture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle GameBounds { get; set; }

        public int Width => SpriteTexture.Width;
        public int Height => SpriteTexture.Height;
        public Rectangle BoundingBox => new Rectangle((int)Location.X, (int)Location.Y, Width, Height);

        public Sprite(Rectangle gameBounds)
        {
            GameBounds = gameBounds;
        }

        ////////////////////////////////////

        public abstract void Load(ContentManager content, GameWindow window);

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Location, Color.White);
        }

        ////////////////////////////////////

        protected void LoadContent(Texture2D texture, Vector2 location)
        {
            SpriteTexture = texture;
            Location = location;
        }

        protected abstract void CheckBounds();
    }
}
