using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities
{
    public interface IGameObject
    {
        void Load(ContentManager content, GameWindow window);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
