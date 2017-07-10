using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeDev.Entities;
using RoguelikeDev.Entities.Enemies;
using RoguelikeDev.Entities.Player;
using RoguelikeDev.Services;
using RoguelikeDev.World;
using RogueSharp;
using RogueSharp.MapCreation;
using System.Collections.Generic;

namespace RoguelikeDev
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        List<IGameObject> _gameObjs;
        Camera _camera;
        DungeonMap _dungeonMap;
        EnemySpawner _spawner;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 580;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            var mapStrat = new RandomRoomsMapCreationStrategy<Map>(40, 40, 50, 20, 4);

            _camera = new Camera(GraphicsDevice.Viewport);
            ServiceLocator<ICamera>.Provide(_camera);

            _dungeonMap = new DungeonMap(mapStrat);
            ServiceLocator<IDungeonMap>.Provide(_dungeonMap);

            _spawner = new EnemySpawner(20);
            ServiceLocator<IEnemySpawner>.Provide(_spawner);

            _gameObjs = new List<IGameObject> {
                _dungeonMap,
                new Player(),
                Player.EquippedWeapon,
                _spawner
            };

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var obj in _gameObjs)
            {
                obj.Load(Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var obj in _gameObjs)
            {
                obj.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _camera.TransformMatrix);

            foreach (var obj in _gameObjs)
            {
                obj.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
