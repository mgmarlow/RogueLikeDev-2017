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

namespace RoguelikeDev.Weapons
{
    public class Projectile : Sprite
    {
        private float _bulletSpeed;
        //private float _distanceTravelled;

        public Weapon BaseWeapon { get; set; }
        public bool IsActive { get; set; }
        public double Rotation { get; set; }

        public Projectile(Weapon weapon)
        {
            BaseWeapon = weapon;
            SpriteTexture = weapon.SpriteTexture;
            // Hold bullet speed internally so we can decrement it over time
            _bulletSpeed = weapon.BulletSpeed;
        }

        public override void Load(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (_bulletSpeed > 0) {
                Location = Location.AddScalar(_bulletSpeed);
            }
            else
            {
                // TODO: Remove bullet from bullet collection
                //int bulletIndex = BaseWeapon.Ammunition.IndexOf(this);
                //BaseWeapon.Ammunition[bulletIndex] = null;
            }
            // TODO: Bullet decay or max distance?
            //_bulletSpeed -= BaseWeapon.BulletDecay;
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
    }
}
