﻿using Microsoft.Xna.Framework;
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
            Vector2 thumbDir = state.ThumbSticks.Right;
            double rotation = Math.Atan2(thumbDir.X, thumbDir.Y);

            if (!IsFiring(state))
            {
                return new HoldingState();
            }

            Fire(rotation);
            return null;
        }

        public void Update(Sprite player)
        {

        }

        public static bool IsFiring(GamePadState state)
        {
            return (state.ThumbSticks.Right.X < -FireThreshold|| 
                state.ThumbSticks.Right.X > FireThreshold || 
                state.ThumbSticks.Right.Y < -FireThreshold|| 
                state.ThumbSticks.Right.Y > FireThreshold);
        }

        private void Fire(double rotation)
        {
            // TODO: let loose bullet
        }
    }
}