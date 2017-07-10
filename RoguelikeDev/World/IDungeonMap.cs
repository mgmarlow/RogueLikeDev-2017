using RoguelikeDev.Entities;
using RogueSharp;

namespace RoguelikeDev.World
{
    public interface IDungeonMap
    {
        int TileSize { get; set; }
        IMap CurrentMap { get; set; }
        void UpdateFieldOfView(Sprite player);
    }
}
