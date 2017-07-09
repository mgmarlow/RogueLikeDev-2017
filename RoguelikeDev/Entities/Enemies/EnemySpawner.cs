using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Enemies
{
    public class EnemySpawner : IGameObject
    {
        private List<Enemy> _badDudes;
        private Texture2D _texture;
        private IDungeonMap _dungeon;

        public EnemySpawner ()
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
        }

        public void Load (ContentManager content)
        {
            _texture = content.Load<Texture2D>("bad_dude");   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in _badDudes)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var enemy in _badDudes)
            {
                enemy.Update(gameTime);
            }
        }

        public void SpawnNewEnemy()
        {
            var map = _dungeon.GetMap();
            //foreach (var cell in map.GetAllCells())
            //{
            //    if (cell.IsWalkable && !cell.IsInFov)
            //}
            // TODO: Get random location
            Vector2 loc = Vector2.Zero;
            SpawnEnemyAtLocation(loc);
        }

        public void SpawnEnemyAtLocation(Vector2 location)
        {
            _badDudes.Add(new Enemy(_texture, location));
        }

    }
}
