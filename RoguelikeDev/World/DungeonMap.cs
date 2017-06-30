using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Entities;
using RogueSharp;
using RogueSharp.MapCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.World
{
    public class DungeonMap : IGameObject
    {
        public Map CurrentMap { get; set; }
        public Texture2D FloorTile { get; set; }
        public Texture2D WallTile { get; set; }

        public DungeonMap(IMapCreationStrategy<Map> strategy)
        {
            CurrentMap = Map.Create(strategy);
        }

        public void Load(ContentManager content, GameWindow window)
        {
            FloorTile = content.Load<Texture2D>("floor");
            WallTile = content.Load<Texture2D>("wall");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int tileSize = 64;
            float scale = .25f;

            foreach (Cell cell in CurrentMap.GetAllCells())
            {
                if (cell.IsWalkable)
                {
                    var pos = new Vector2(cell.X * tileSize * scale, cell.Y * tileSize * scale);
                    spriteBatch.Draw(FloorTile, pos, null, null, null, 0.0f, new Vector2(scale, scale), Color.White);
                }
                else
                {
                    var pos = new Vector2(cell.X * tileSize * scale, cell.Y * tileSize * scale);
                    spriteBatch.Draw(WallTile, pos, null, null, null, 0.0f, new Vector2(scale, scale), Color.White);
                }
            }
        }
    }
}
