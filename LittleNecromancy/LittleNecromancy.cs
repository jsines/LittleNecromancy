using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace LittleNecromancy
{
    public class LN //macros basically, wish c# had them lol
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
        public static GameStateStack Stack;
        public static ResourceManager Resource;
        public static bool Exit = false;

        public LittleNecromancy()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Resource = new ResourceManager(Content);
            Stack = new GameStateStack();
        }

        // After constructor and before main game loop
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            _graphics.ApplyChanges();
            Stack.Push(new MenuState());
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
            if (Exit)
            {
                Exit();
            }
            Stack.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            Stack.Draw(_spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
