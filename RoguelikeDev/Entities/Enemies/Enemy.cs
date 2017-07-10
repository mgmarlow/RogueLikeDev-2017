using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Enemies
{
    public class Enemy : Sprite
    {
        private IDungeonMap _dungeon;

        public bool IsActive { get; set; }

        public Enemy(Texture2D texture, Vector2 location)
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
            SpriteTexture = texture;
            Location = location;
            IsActive = true;
        }

        public override void Load(ContentManager content)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_dungeon.CurrentMap.IsInFov((int)Location.X / _dungeon.TileSize, (int)Location.Y / _dungeon.TileSize))
                base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
