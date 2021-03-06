﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RoguelikeDev.Entities
{
    public abstract class Sprite : IGameObject
    {
        public Texture2D SpriteTexture { get; set; }
        public Vector2 Location { get; set; }

        public int Width => SpriteTexture.Width;
        public int Height => SpriteTexture.Height;
        public Rectangle BoundingBox => new Rectangle((int)Location.X, (int)Location.Y, Width, Height);

        public Sprite()
        {
        }

        ////////////////////////////////////

        public abstract void Load(ContentManager content);

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
    }
}
