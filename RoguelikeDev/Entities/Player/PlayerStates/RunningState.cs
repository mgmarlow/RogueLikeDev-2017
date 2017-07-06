using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player.PlayerStates
{
    public class RunningState : IPlayerState
    {
        private float _playerSpeed = 7.0f;
        private IDungeonMap _dungeon;

        public RunningState()
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();

        }

        public IPlayerState HandleInput(Player player, GamePadCapabilities cap, GamePadState state)
        {
            ICamera camera = ServiceLocator<ICamera>.GetService();

            if (state.ThumbSticks.Left.X < -0.5f)
            {
                player.Location = new Vector2(player.Location.X - _playerSpeed, player.Location.Y);
                camera.FollowSprite(player, new Vector2(_playerSpeed, 0.0f));
            }
            else if (state.ThumbSticks.Left.X > 0.5f)
            {
                player.Location = new Vector2(player.Location.X + _playerSpeed, player.Location.Y);
                camera.FollowSprite(player, new Vector2(-_playerSpeed, 0.0f));
            }
            else if (state.ThumbSticks.Left.Y < -0.5f)
            {
                player.Location = new Vector2(player.Location.X, player.Location.Y + _playerSpeed);
                camera.FollowSprite(player, new Vector2(0.0f, -_playerSpeed));
            }
            else if (state.ThumbSticks.Left.Y > 0.5f)
            {
                player.Location = new Vector2(player.Location.X, player.Location.Y - _playerSpeed);
                camera.FollowSprite(player, new Vector2(0.0f, _playerSpeed));
            }
            else
            {
                return new StandingState();
            }

            return null;
        }

        public void Update(Player player)
        {

        }

        private bool NextCellIsWalkable(Vector2 newPosition)
        {
            // TODO: Check cell at next pos
            var nextCell = _dungeon.GetMap().GetCell((int)newPosition.X, (int)newPosition.Y);
            return nextCell.IsWalkable;
        }
    }
}
