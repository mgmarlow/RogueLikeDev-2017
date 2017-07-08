using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RoguelikeDev.Entities
{
    public interface IGameObject
    {
        void Load(ContentManager content);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
