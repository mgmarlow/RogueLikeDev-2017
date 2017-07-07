using Microsoft.Xna.Framework.Input;

namespace RoguelikeDev.Entities.Player.EquipmentStates
{
    public class HoldingState : ISpriteGamePadState
    {
        public ISpriteGamePadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state)
        {
            if (cap.HasRightXThumbStick && IsFiring(state))
            {
                return new ShootingState(Player.EquippedWeapon);
            }
            return null;
        }

        public void Update(Sprite sprite)
        {

        }

        private bool IsFiring(GamePadState state)
        {
            return (state.ThumbSticks.Right.X < -ShootingState.FireThreshold|| 
                state.ThumbSticks.Right.X > ShootingState.FireThreshold || 
                state.ThumbSticks.Right.Y < -ShootingState.FireThreshold|| 
                state.ThumbSticks.Right.Y > ShootingState.FireThreshold);
        }

    }
}
