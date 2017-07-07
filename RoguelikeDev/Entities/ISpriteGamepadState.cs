using Microsoft.Xna.Framework.Input;

namespace RoguelikeDev.Entities
{
    public interface ISpriteGamePadState
    {
        ISpriteGamePadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state);
        void Update(Sprite sprite);
    }
}
