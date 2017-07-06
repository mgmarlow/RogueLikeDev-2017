using Microsoft.Xna.Framework;
using RoguelikeDev.Entities;

namespace RoguelikeDev.World
{
    public interface ICamera
    {
        void Move(Vector2 dir);
        Rectangle GetBounds();
        void SetLocation(Vector2 newLoc);
        void FollowSprite(Sprite sprite, Vector2 direction);
        bool WithinViewportBounds(Sprite sprite, Vector2 direction);
    }
}
