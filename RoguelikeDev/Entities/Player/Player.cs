using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities.Player.PlayerStates;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player
{
    public class Player : Sprite
    {
        private IPlayerState _state = new StandingState();

        public Player(Microsoft.Xna.Framework.Rectangle gameBounds) : base(gameBounds)
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
            spriteBatch.Draw(SpriteTexture, Location, null, null, null, 0.0f, new Vector2(0.65f, 0.65f), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            GamePadCapabilities cap = GamePad.GetCapabilities(PlayerIndex.One);

            if (cap.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                IPlayerState playerState = _state.HandleInput(this, cap, state);
                if (playerState != null)
                {
                    _state = playerState;
                }
            }

            _state.Update(this);
        }

        protected override void CheckBounds()
        {
            throw new NotImplementedException();
        }

    }
}
