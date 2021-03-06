﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities;
using RogueSharp;
using RogueSharp.MapCreation;
using System.Diagnostics;

namespace RoguelikeDev.World
{
    public class DungeonMap : IGameObject, IDungeonMap
    {
        public IMap CurrentMap { get; set; }
        public IMapCreationStrategy<Map> Strategy { get; set; }
        public Texture2D FloorTile { get; set; }
        public Texture2D WallTile { get; set; }
        public int TileSize { get; set; }
        public float TileScale { get; set; }

        public DungeonMap(IMapCreationStrategy<Map> strategy, int tileSize=64, float tileScale=1.0f)
        {
            Strategy = strategy;
            TileSize = tileSize;
            TileScale = tileScale;
            CurrentMap = Map.Create(strategy);
        }

        public void UpdateFieldOfView(Sprite sprite)
        {
            CurrentMap.ComputeFov((int)sprite.Location.X / TileSize, (int)sprite.Location.Y / TileSize, 4, true);
        }

        public void Load(ContentManager content)
        {
            FloorTile = content.Load<Texture2D>("floor");
            WallTile = content.Load<Texture2D>("wall");
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in CurrentMap.GetAllCells())
            {
                if (!cell.IsInFov) continue;
                Texture2D currentTile = cell.IsWalkable ? FloorTile : WallTile;
                DrawTile(currentTile, cell, spriteBatch);
            }
        }

        private void DrawTile(Texture2D texture, Cell cell, SpriteBatch spriteBatch)
        {
            var pos = new Vector2(cell.X * TileSize * TileScale, cell.Y * TileSize * TileScale);
            spriteBatch.Draw(texture, pos, null, null, null, 0.0f, new Vector2(TileScale, TileScale), Color.White, SpriteEffects.None, 0.8f);
        }
    }
}
