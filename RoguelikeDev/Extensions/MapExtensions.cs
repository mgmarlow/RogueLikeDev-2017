using Microsoft.Xna.Framework;
using RoguelikeDev.Entities.Player;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using System;

namespace RoguelikeDev.Extensions
{
    public static class MapExtensions
    {
        public static Vector2 GetInitialPlayerPosition(this IDungeonMap dungeon)
        {
            ICamera camera = ServiceLocator<ICamera>.GetService();
            var map = dungeon.GetMap();
            foreach (var cell in map.GetAllCells())
            {
                if (cell.IsWalkable)
                {
                    Vector2 firstAvailableCell = new Vector2(cell.X * dungeon.GetTileSize(), cell.Y * dungeon.GetTileSize());
                    camera.SetLocation(firstAvailableCell);
                    return firstAvailableCell;
                }
            }
            throw new InvalidOperationException();
        }
    }
}