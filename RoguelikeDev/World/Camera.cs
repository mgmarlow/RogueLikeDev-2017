using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Entities;
using RoguelikeDev.Services;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.World
{
    public class Camera : ICamera
    {
        public Microsoft.Xna.Framework.Rectangle Bounds { get; set; }
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
            Debug.WriteLine(viewport.Bounds);
            Bounds = viewport.Bounds;
            Zoom = 1.0f;
            Location = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        /// <summary>
        /// Move camera relative towards direction vector
        /// </summary>
        /// <param name="dir"></param>
        public void Move(Vector2 dir)
        {
            var newPos = Location + dir;
            Location = MapToClampedPosition(newPos);
        }

        public Microsoft.Xna.Framework.Rectangle GetBounds()
        {
            return Bounds;
        }

        public bool WithinViewportBounds(Player player, Vector2 direction)
        {
            IDungeonMap dungeon = ServiceLocator<IDungeonMap>.GetService();
            var map = dungeon.GetMap();

            // Upper-left
            var minXCheck = player.Location.X > (Bounds.Width * 0.5f) - (player.SpriteTexture.Width * 0.5f);
            var minYCheck = player.Location.Y > (Bounds.Height * 0.5f) - (player.SpriteTexture.Height * 0.5f);

            // Lower-right
            var maxXCheck = player.Location.X < ((map.Width * dungeon.GetTileSize()) - (Bounds.Width * 0.5f) - (player.SpriteTexture.Width * 0.5f));
            var maxYCheck = player.Location.Y < ((map.Height * dungeon.GetTileSize()) - (Bounds.Height * 0.5f) - (player.SpriteTexture.Height * 0.5f));

            return ((minXCheck && maxXCheck) || direction.Y != 0.0f) && ((minYCheck && maxYCheck) || direction.X != 0.0f);
        }

        /// <summary>
        /// Ensure the camera is always within game world, clamps position on movement based on
        /// generated map.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private Vector2 MapToClampedPosition(Vector2 position)
        {
            IDungeonMap dungeon = ServiceLocator<IDungeonMap>.GetService();
            var map = dungeon.GetMap();
            var min = new Vector2(Origin.X, Origin.Y);
            var max = new Vector2(
                (-1 * map.Width * dungeon.GetTileSize()) + Bounds.Width,
                (-1 * map.Height * dungeon.GetTileSize()) + Bounds.Height
            );
            return Vector2.Clamp(position, max, min);
        }

    }
}
