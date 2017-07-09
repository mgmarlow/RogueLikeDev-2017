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
        private IMap _map;

        public Enemy(Texture2D texture, Vector2 location)
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
            _map = _dungeon.GetMap();
            SpriteTexture = texture;
            Location = location;
        }

        public override void Load(ContentManager content)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_map.IsInFov((int)Location.X / _dungeon.GetTileSize(), (int)Location.Y / _dungeon.GetTileSize()))
                base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
