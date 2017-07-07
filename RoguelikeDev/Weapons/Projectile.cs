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
        private float _distanceTravelled;

        public Weapon BaseWeapon { get; set; }

        public Projectile(Weapon weapon)
        {
            BaseWeapon = weapon;
            _bulletSpeed = weapon.BulletSpeed;
        }

        public override void Load(ContentManager content, GameWindow window)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (_bulletSpeed > 0) {
                Location += Location.AddScalar(_bulletSpeed);
            }
            else
            {
                // TODO: Remove bullet from bullet collection
            }
            _bulletSpeed -= BaseWeapon.BulletDecay;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
