using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Entities;
using RoguelikeDev.Services;
using System.Diagnostics;
using RoguelikeDev.Extensions;

namespace RoguelikeDev.World
{
    public class Camera : ICamera
    {
        public Rectangle Bounds { get; set; }
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

        public Rectangle GetBounds()
        {
            return Bounds;
        }

        public void SetLocation(Vector2 newLoc)
        {
            var centeredLocation = new Vector2(-newLoc.X + Bounds.Width * 0.5f, -newLoc.Y + Bounds.Height * 0.5f);
            Location = MapToClampedPosition(centeredLocation);
        }

        public void FollowSprite(Sprite sprite, Vector2 direction)
        {
            if (WithinViewportBounds(sprite, direction))
                Move(direction);
        }

        public bool WithinViewportBounds(Sprite sprite, Vector2 direction)
        {
            IDungeonMap dungeon = ServiceLocator<IDungeonMap>.GetService();
            var map = dungeon.CurrentMap;

            // Upper-left
            var minXCheck = sprite.Location.X > (Bounds.Width * 0.5f) - (sprite.SpriteTexture.Width * 0.5f);
            var minYCheck = sprite.Location.Y > (Bounds.Height * 0.5f) - (sprite.SpriteTexture.Height * 0.5f);

            // Lower-right
            var maxXCheck = sprite.Location.X < ((map.Width * dungeon.TileSize) - (Bounds.Width * 0.5f) - (sprite.SpriteTexture.Width * 0.5f));
            var maxYCheck = sprite.Location.Y < ((map.Height * dungeon.TileSize) - (Bounds.Height * 0.5f) - (sprite.SpriteTexture.Height * 0.5f));

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
            var map = dungeon.CurrentMap;
            var min = new Vector2(Origin.X, Origin.Y);
            var max = new Vector2(
                (-1 * map.Width * dungeon.TileSize) + Bounds.Width,
                (-1 * map.Height * dungeon.TileSize) + Bounds.Height
            );
            return Vector2.Clamp(position, max, min);
        }

    }
}
