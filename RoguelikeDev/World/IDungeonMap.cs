using RogueSharp;

namespace RoguelikeDev.World
{
    public interface IDungeonMap
    {
        IMap GetMap();
        int GetTileSize();
    }
}
