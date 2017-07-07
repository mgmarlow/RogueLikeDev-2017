using Microsoft.Xna.Framework.Input;

namespace RoguelikeDev.Entities.Player.EquipmentStates
{
    public class HoldingState : ISpriteGamePadState
    {
        public ISpriteGamePadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state)
        {
            if (cap.HasRightXThumbStick && ShootingState.IsFiring(state))
            {
                return new ShootingState(Player.EquippedWeapon);
            }
            return null;
        }

        public void Update(Sprite sprite)
        {

        }

    }
}
