using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities;
using RoguelikeDev.Services;
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
        public IMapCreationStrategy<Map> Strategy { get; set; }
        public Texture2D FloorTile { get; set; }
        public Texture2D WallTile { get; set; }
        public int TileSize { get; set; }
        public float TileScale { get; set; }

        public DungeonMap(IMapCreationStrategy<Map> strategy, int tileSize=64, float tileScale=1)
        {
            Strategy = strategy;
            TileSize = tileSize;
            TileScale = tileScale;
            CurrentMap = Map.Create(strategy);
            MapLocator.Provide(CurrentMap);
        }

        public void Load(ContentManager content, GameWindow window)
        {
            FloorTile = content.Load<Texture2D>("floor");
            WallTile = content.Load<Texture2D>("wall");
        }

        public void Update(GameTime gameTime)
        {
#if DEBUG
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
            {
                CurrentMap = Map.Create(Strategy);
                MapLocator.Provide(CurrentMap);
            }
#endif
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in CurrentMap.GetAllCells())
            {
                Texture2D currentTile;
                currentTile = cell.IsWalkable ? FloorTile : WallTile;
                DrawTile(currentTile, cell, spriteBatch);
            }
        }

        private void DrawTile(Texture2D texture, Cell cell, SpriteBatch spriteBatch)
        {
            var pos = new Vector2(cell.X * TileSize * TileScale, cell.Y * TileSize * TileScale);
            spriteBatch.Draw(texture, pos, null, null, null, 0.0f, new Vector2(TileScale, TileScale), Color.White);
        }
    }
}
