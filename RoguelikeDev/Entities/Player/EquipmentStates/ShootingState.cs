using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player.EquipmentStates
{
    public class ShootingState : ISpriteGamePadState
    {
        public static float FireThreshold = 0.5f;

        public Weapon ActiveWeapon { get; set; }

        public ShootingState(Weapon weapon)
        {
            ActiveWeapon = weapon;
        }

        public ISpriteGamePadState HandleInput(Sprite player, GamePadCapabilities cap, GamePadState state)
        {
            Vector2 fireVector;

            if (state.ThumbSticks.Right.X < -FireThreshold)
            {
                fireVector = new Vector2(-1, 0);
            }
            else if (state.ThumbSticks.Right.X > FireThreshold)
            {
                fireVector = new Vector2(1, 0);
            }
            else if (state.ThumbSticks.Right.Y < -FireThreshold)
            {
                fireVector = new Vector2(0, -1);
            }
            else if (state.ThumbSticks.Right.Y > FireThreshold)
            {
                fireVector = new Vector2(0, 1);
            }
            else
            {
                return new HoldingState();
            }

            Fire(fireVector);
            return null;
        }

        public void Update(Sprite player)
        {

        }

        private void Fire(Vector2 fireVector)
        {
            // TODO: let loose bullet
        }
    }
}
