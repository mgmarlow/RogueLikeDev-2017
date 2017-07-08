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
        public static Vector2 AddScalar (this Vector2 origin, float offset)
        {
            return new Vector2(origin.X + offset, origin.Y + offset);
        }

        public static Vector2 Halve(this Vector2 origin)
        {
            return new Vector2(origin.X * 0.5f, origin.Y * 0.5f);
        }

        public static float Angle(this Vector2 origin)
        {
            return (float)Math.Atan2((double)origin.Y, (double)origin.X);
        }
    }
}
