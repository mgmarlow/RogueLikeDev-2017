using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities.Player.PlayerStates;
using RoguelikeDev.Extensions;
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
        private ISpriteGamepadState _state = new StandingState();
        public float SpeedThreshold = 0.5f;

        public Player(Microsoft.Xna.Framework.Rectangle gameBounds) : base(gameBounds)
        {
        }

        public override void Load(ContentManager content, GameWindow window)
        {
            var playerTexture = content.Load<Texture2D>("avatar");
            var dungeon = ServiceLocator<IDungeonMap>.GetService();
            var initialPosition = dungeon.PlacePlayer(this);
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

                ISpriteGamepadState playerState = _state.HandleInput(this, cap, state);
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
