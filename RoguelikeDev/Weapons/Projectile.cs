using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RoguelikeDev.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Extensions;
using RoguelikeDev.Services;
using RoguelikeDev.World;

namespace RoguelikeDev.Weapons
{
    public class Projectile : Sprite
    {
        private float _bulletSpeed;
        private IDungeonMap _dungeon;

        public Weapon BaseWeapon { get; set; }
        public bool IsActive { get; set; }
        public double Rotation { get; set; }

        public Projectile(Weapon weapon)
        {
            BaseWeapon = weapon;
            SpriteTexture = weapon.SpriteTexture;
            // Hold bullet speed internally so we can decrement it over time
            _bulletSpeed = weapon.BulletSpeed;
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
        }

        // Texture loading handled by Weapon
        public override void Load(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Location = Location.AddScalar(_bulletSpeed);

            if (Expired())
                IsActive = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public Projectile SetActive(double rotation, Vector2 location)
        {
            IsActive = true;
            Location = location;
            Rotation = rotation;
            return this;
        }

        public bool Expired()
        {
            var map = _dungeon.GetMap();
            var tileSize = _dungeon.GetTileSize();

            return (Location.X > map.Width * tileSize ||
                Location.X < 0 ||
                Location.Y > map.Height * tileSize ||
                Location.Y < 0);
        }
    }
}
