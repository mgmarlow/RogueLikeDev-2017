using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using RogueSharp;
using RogueSharp.Random;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int InitialEnemies { get; set; }

        public EnemySpawner (int numEnemies)
        {
            _dungeon = ServiceLocator<IDungeonMap>.GetService();
            _badDudes = new List<Enemy>(numEnemies);
            InitialEnemies = numEnemies;
        }

        public void Load (ContentManager content)
        {
            _texture = content.Load<Texture2D>("bad_dude");   
            SpawnEnemies(InitialEnemies);
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

        public void SpawnEnemies(int n)
        {
            var map = _dungeon.GetMap();
            var tileSize = _dungeon.GetTileSize();
            var random = new DotNetRandom();

            for (var i = 0; i < n; i++)
                _badDudes.Add(SpawnNewEnemy(map, tileSize, random));
        }

        public Enemy SpawnNewEnemy(IMap map, int tileSize, DotNetRandom random)
        {
            while (true)
            {
                int x = random.Next(map.Width - 1);
                int y = random.Next(map.Height - 1);

                if (map.IsWalkable(x, y) && !map.IsInFov(x, y))
                {
                    var enemyPos = new Vector2(x * tileSize, y * tileSize);

                    bool exists = _badDudes
                        .Select(b => b.Location.X == enemyPos.X && b.Location.Y == enemyPos.Y)
                        .FirstOrDefault();
                    if (exists) continue;

                    return new Enemy(_texture, enemyPos);
                }
            }

        }

    }
}
