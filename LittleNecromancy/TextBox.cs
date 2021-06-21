using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    class TextBox : Entity
    {
        public SpriteFont font;
        public string text;

        public TextBox(string fontFile, string displayText)
        {
            font = LittleNecromancy.resourceManager.GetSpriteFont(fontFile);
            text = displayText;
        }
        public virtual void Initialize()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
