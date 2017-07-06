﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Player.EquipmentStates
{
    public class DefaultWeaponState : ISpriteGamepadState
    {
        public static float FireThreshold = 0.5f;
        public ISpriteGamepadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state)
        {
            if (state.ThumbSticks.Right.X < -FireThreshold)
            {
                // Provide current equipment to shooting state
                //return new ShootingState(this);
            }
            return null;
        }

        public void Update(Sprite sprite)
        {

        }
    }
}