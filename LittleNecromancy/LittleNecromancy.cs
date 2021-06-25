using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace LittleNecromancy
{
    public class LN //logger
    {
        public static void Log(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
    }
    public class LittleNecromancy : Game
    {
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 720;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameStateStack _gameStateStack;
        public static ResourceManager resourceManager;

        public LittleNecromancy()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            resourceManager = new ResourceManager(Content);
            _gameStateStack = new GameStateStack();
        }

        // After constructor and before main game loop
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            _graphics.ApplyChanges();
            _gameStateStack.Push(new MenuState());
            base.Initialize();
        }

        // Called by the Initialize method before loop
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private float tick = 2000;
        private float delta;
        private const float gap = 2000;
        protected override void Update(GameTime gameTime)
        {
            delta = (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            tick += delta;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3) && tick >= gap)
            {
                _gameStateStack.Push(new ERDebugState(_gameStateStack.GetCurrentState().GetEntities()));
                tick = 0;
            }
            _gameStateStack.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            _gameStateStack.Draw(_spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
