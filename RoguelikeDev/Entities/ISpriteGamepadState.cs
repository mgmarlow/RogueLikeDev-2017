using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities
{
    public interface ISpriteGamepadState
    {
        ISpriteGamepadState HandleInput(Sprite sprite, GamePadCapabilities cap, GamePadState state);
        void Update(Sprite sprite);
    }
}
