using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player.PlayerStates
{
    public class StandingState : IPlayerState
    {
        public IPlayerState HandleInput(Player player, GamePadCapabilities cap, GamePadState state)
        {
            if (cap.HasLeftXThumbStick && IsRunning(state))
            {
                return new RunningState();
            }

            return null;
        }

        public void Update(Player player)
        {

        }

        private bool IsRunning(GamePadState state)
        {
            return (state.ThumbSticks.Left.X < -0.5f || 
                state.ThumbSticks.Left.X > 0.5f || 
                state.ThumbSticks.Left.Y < -0.5f || 
                state.ThumbSticks.Left.Y > 0.5f);
        }
    }
}
