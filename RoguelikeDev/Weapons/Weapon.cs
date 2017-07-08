using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Weapons
{
    public class Weapon : Sprite
    {
        public List<Projectile> Ammunition { get; set; }
        public float BulletSpeed { get; set; }
        public float BulletDecay { get; set; }
        public float ShootDelay { get; set; }
        public int ClipSize { get; set; } 
        public string AmmoType { get; set; }
        public string TexturePath { get; set; }

        public Weapon(int ammoSize, float shootDelay, string texturePath)
        {
            ClipSize = ammoSize;
            TexturePath = texturePath;
            ShootDelay = shootDelay;
            BulletSpeed = 10f;
            BulletDecay = 10f;
        }

        public override void Load(ContentManager content)
        {
            // Load textures
            var bulletTexture = content.Load<Texture2D>(TexturePath);
            var initialPosition = Vector2.Zero;
            base.LoadContent(bulletTexture, initialPosition);
            
            // Populate bullets
            Ammunition = FillAmmo(ClipSize);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in Ammunition)
            {
                if (bullet.IsActive)
                {
                    bullet.Draw(spriteBatch);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var bullet in Ammunition)
            {
                if (bullet.IsActive)
                {
                    bullet.Update(gameTime);
                }
            }
        }

        private List<Projectile> FillAmmo(int ammoSize)
        {
            var result = new List<Projectile>(ammoSize);
            for (var i = 0; i < ammoSize; i++)
            {
                result.Add(new Projectile(this));
            }
            return result;
        }
    }
}
