using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    public class GameStateStack
    {
        Stack<GameState> _stateStack;

        public GameStateStack()
        {
            _stateStack = new Stack<GameState>();
        }

        public void Push(GameState g)
        {
            g.Initialize();
            _stateStack.Push(g);
        }

        public void Pop()
        {
            _stateStack.Pop();
        }

        public GameState GetCurrentState()
        {
            return _stateStack.Peek();
        }

        public void Update(GameTime gameTime)
        {
            _stateStack.Peek().UpdateState(gameTime);
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            _stateStack.Peek().Draw(sb, gt);
        }
    }
}
