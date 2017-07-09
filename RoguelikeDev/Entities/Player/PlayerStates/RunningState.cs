using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Services;
using RoguelikeDev.World;

namespace RoguelikeDev.Entities.Player.PlayerStates
{
    public class RunningState : ISpriteGamePadState
    {
        private float _playerSpeed = 7.0f;
        private IDungeonMap _dungeon;

        public static float SpeedThreshold = 0.5f;

        public RunningState()
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
        }

        public ISpriteGamePadState HandleInput(Sprite player, GamePadCapabilities cap, GamePadState state)
        {
            ICamera camera = ServiceLocator<ICamera>.GetService();
            Vector2 newLocation, cameraVector;

            if (state.ThumbSticks.Left.X < -SpeedThreshold)
            {
                newLocation = new Vector2(player.Location.X - _playerSpeed, player.Location.Y);
                cameraVector = new Vector2(_playerSpeed, 0.0f);
            }
            else if (state.ThumbSticks.Left.X > SpeedThreshold)
            {
                newLocation = new Vector2(player.Location.X + _playerSpeed, player.Location.Y);
                cameraVector = new Vector2(-_playerSpeed, 0.0f);
            }
            else if (state.ThumbSticks.Left.Y < -SpeedThreshold)
            {
                newLocation = new Vector2(player.Location.X, player.Location.Y + _playerSpeed);
                cameraVector = new Vector2(0.0f, -_playerSpeed);
            }
            else if (state.ThumbSticks.Left.Y > SpeedThreshold)
            {
                newLocation = new Vector2(player.Location.X, player.Location.Y - _playerSpeed);
                cameraVector = new Vector2(0.0f, _playerSpeed);
            }
            else
            {
                return new StandingState();
            }

            if (WithinBounds(player, newLocation))
            {
                player.Location = newLocation;
                camera.FollowSprite(player, cameraVector);
                _dungeon.UpdateFieldOfView(player);
            }
            return null;
        }

        public void Update(Sprite player)
        {

        }

        private bool WithinBounds(Sprite player, Vector2 newPosition)
        {
            var topLeftPos = new Vector2(newPosition.X, newPosition.Y);
            var bottomRightPos = new Vector2(newPosition.X + player.SpriteTexture.Width, newPosition.Y + player.SpriteTexture.Height);
            return NextCellIsWalkable(topLeftPos) && NextCellIsWalkable(bottomRightPos);
        }

        private bool NextCellIsWalkable(Vector2 newPosition)
        {
            var tileSize = _dungeon.GetTileSize();
            var nextCell = _dungeon.GetMap().GetCell((int)newPosition.X / tileSize, (int)newPosition.Y / tileSize);
            return nextCell.IsWalkable;
        }
    }
}
