using RoguelikeDev.Entities;
using RogueSharp;

namespace RoguelikeDev.World
{
    public interface IDungeonMap
    {
        IMap GetMap();
        int GetTileSize();
        void UpdateFieldOfView(Sprite player);
    }
}
