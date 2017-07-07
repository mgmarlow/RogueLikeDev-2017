using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities.Player.EquipmentStates;
using RoguelikeDev.Entities.Player.PlayerStates;
using RoguelikeDev.Extensions;
using RoguelikeDev.Services;
using RoguelikeDev.Weapons;
using RoguelikeDev.World;

namespace RoguelikeDev.Entities.Player
{
    public class Player : Sprite
    {
        private ISpriteGamePadState _state = new StandingState();
        private ISpriteGamePadState _equipment = new HoldingState();

        public static Weapon EquippedWeapon { get; set; }

        public Player()
        {
        }

        public override void Load(ContentManager content, GameWindow window)
        {
            var playerTexture = content.Load<Texture2D>("avatar");
            var dungeon = ServiceLocator<IDungeonMap>.GetService();
            var initialPosition = dungeon.GetInitialPlayerPosition();
            base.LoadContent(playerTexture, initialPosition);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            GamePadCapabilities cap = GamePad.GetCapabilities(PlayerIndex.One);

            if (cap.IsConnected)
            {
                GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);

                _state = HandleStateInput(_state, cap, gamepadState);
                _equipment = HandleStateInput(_equipment, cap, gamepadState);
            }

            _state.Update(this);
            _equipment.Update(this);
        }

        private ISpriteGamePadState HandleStateInput(ISpriteGamePadState currentState, GamePadCapabilities cap, GamePadState gamepadState)
        {
            var newState = currentState.HandleInput(this, cap, gamepadState);
            if (newState != null)
            {
                return newState;
            }
            return currentState;
        }

    }
}
