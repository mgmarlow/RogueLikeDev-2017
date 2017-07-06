using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.World
{
    public interface ICamera
    {
        void Move(Vector2 dir);
        Rectangle GetBounds();
        void FollowSprite(Sprite sprite, Vector2 direction);
        bool WithinViewportBounds(Sprite sprite, Vector2 direction);
    }
}
