using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Extensions
{
    public static class Utilities
    {
        public static Vector2 Add(this Vector2 origin, Vector2 offset)
        {
            return new Vector2(origin.X + offset.X, origin.Y + offset.Y);
        }

        public static Vector2 Halve(this Vector2 origin)
        {
            return new Vector2(origin.X * 0.5f, origin.Y * 0.5f);
        }
    }
}
