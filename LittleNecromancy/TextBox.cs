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
        private SpriteFont font;
        private string text;
        private Color color;

        public TextBox(string fontFile, string displayText, Color displayColor)
        {
            font = LittleNecromancy.Resource.GetSpriteFont(fontFile);
            text = displayText;
            color = displayColor;
        }
        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) { }

        public void SetColor(Color newColor)
        {
            color = newColor;
        }
        public Color GetColor()
        {
            return color;
        }
        public void SetText(string newText)
        {
            text = newText;
        }
        public string GetText()
        {
            return text;
        }
        public void SetFont(SpriteFont newFont)
        {
            font = newFont;
        }
        public SpriteFont GetFont()
        {
            return font;
        }
    }
}
