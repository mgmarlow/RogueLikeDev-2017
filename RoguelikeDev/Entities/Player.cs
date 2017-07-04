using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities
{
    public class Player : Sprite
    {
        float _playerSpeed = 7.0f;

        public Player(Rectangle gameBounds) : base(gameBounds)
        {
        }
        
        public override void Load(ContentManager content, GameWindow window)
        {
            var playerTexture = content.Load<Texture2D>("avatar");
            var initialPosition = new Vector2(
                window.ClientBounds.Width / 2 - playerTexture.Width / 2, 
                window.ClientBounds.Height / 2 - playerTexture.Height / 2
            );
            base.LoadContent(playerTexture, initialPosition);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            spriteBatch.Draw(SpriteTexture, Location, null, null, null, 0.0f, new Vector2(0.75f, 0.75f), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
        }

        protected override void CheckBounds()
        {
            throw new NotImplementedException();
        }

        private void HandleInput()
        {
            GamePadCapabilities cap = GamePad.GetCapabilities(PlayerIndex.One);
            if (!cap.IsConnected) return;

            // Grab camera to follow player movement
            ICamera camera = CameraLocator.GetCamera();

            GamePadState state = GamePad.GetState(PlayerIndex.One);
            if (cap.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X < -0.5f)
                {
                    Location = new Vector2(Location.X - _playerSpeed, Location.Y);
                    camera.Move(new Vector2(_playerSpeed, 0.0f));
                }

                if (state.ThumbSticks.Left.X > 0.5f)
                {
                    Location = new Vector2(Location.X + _playerSpeed, Location.Y);
                    camera.Move(new Vector2(-_playerSpeed, 0.0f));
                }

                if (state.ThumbSticks.Left.Y < -0.5f)
                {
                    Location = new Vector2(Location.X, Location.Y + _playerSpeed);
                    camera.Move(new Vector2(0.0f, -_playerSpeed));
                }

                if (state.ThumbSticks.Left.Y > 0.5f)
                {
                    Location = new Vector2(Location.X, Location.Y - _playerSpeed);
                    camera.Move(new Vector2(0.0f, _playerSpeed));
                }
            }
        }
    }
}
