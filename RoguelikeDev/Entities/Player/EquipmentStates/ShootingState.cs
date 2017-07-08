using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Weapons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!IsFiring(state))
                return new HoldingState();

            Vector2 thumbDir = state.ThumbSticks.Right;
            double rotation = Math.Atan2(thumbDir.X, thumbDir.Y);

            //Fire(rotation);
            if (GetNextBullet(rotation, player) == null)
            {
                // switch to pistol
            }
            return null;
        }

        public void Update(Sprite player)
        {

        }

        public static bool IsFiring(GamePadState state)
        {
            return state.Buttons.RightShoulder == ButtonState.Pressed;
        }

        private Projectile GetNextBullet(double rotation, Sprite player)
        {
            foreach (var bullet in ActiveWeapon.Ammunition)
            {
                // Get first inactive bullet and activate
                if (bullet != null && !bullet.IsActive)
                {
                    return bullet.SetActive(rotation, player.Location);
                }
            }
            return null;
        }
    }
}
