using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.World
{
    public class Camera
    {
        private Rectangle _bounds;

        public float Zoom { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }

        public Matrix TransformMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(Location.X, Location.Y, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                    Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 0));
            }
        }

        public Camera(Viewport viewport)
        {
            _bounds = viewport.Bounds;
            Zoom = 1.0f;
            Location = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        public void Move(Vector2 dir)
        {
            Location += dir;
        }

    }
}
