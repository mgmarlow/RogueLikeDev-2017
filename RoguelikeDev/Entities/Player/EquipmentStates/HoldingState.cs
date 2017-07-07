using Microsoft.Xna.Framework.Input;

namespace RoguelikeDev.Entities.Player.EquipmentStates
{
    public class HoldingState : ISpriteGamePadState
    {
        public ISpriteGamePadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state)
        {
            // Provide current equipment to shooting state
            //return new ShootingState(this);
            return null;
        }

        public void Update(Sprite sprite)
        {

        }
    }
}
