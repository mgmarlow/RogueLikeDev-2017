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

            foreach (var cell in dungeon.CurrentMap.GetAllCells())
            {
                if (cell.IsWalkable)
                {
                    Vector2 firstAvailableCell = new Vector2(cell.X * dungeon.TileSize, cell.Y * dungeon.TileSize);
                    camera.SetLocation(firstAvailableCell);
                    return firstAvailableCell;
                }
            }

            throw new InvalidOperationException();
        }
    }
}