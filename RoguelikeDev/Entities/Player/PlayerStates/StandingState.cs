using Microsoft.Xna.Framework.Input;

namespace RoguelikeDev.Entities.Player.PlayerStates
{
    public class StandingState : ISpriteGamePadState
    {
        public ISpriteGamePadState HandleInput(Sprite player, GamePadCapabilities cap, GamePadState state)
        {
            if (cap.HasLeftXThumbStick && IsRunning(state))
            {
                return new RunningState();
            }

            return null;
        }

        public void Update(Sprite player)
        {

        }

        private bool IsRunning(GamePadState state)
        {
            return (state.ThumbSticks.Left.X < -RunningState.SpeedThreshold || 
                state.ThumbSticks.Left.X > RunningState.SpeedThreshold || 
                state.ThumbSticks.Left.Y < -RunningState.SpeedThreshold|| 
                state.ThumbSticks.Left.Y > RunningState.SpeedThreshold);
        }
    }
}
