using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RoguelikeDev.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace RoguelikeDev.Weapons
{
    public class Projectile : Sprite
    {
        public float Speed { get; set; }

        public Projectile()
        {
        }

        public override void Load(ContentManager content, GameWindow window)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
