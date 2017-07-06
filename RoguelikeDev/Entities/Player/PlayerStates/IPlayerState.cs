using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player.PlayerStates
{
    public interface IPlayerState
    {
        IPlayerState HandleInput(Player player, GamePadCapabilities cap, GamePadState state);
        void Update(Player player);
    }
}
