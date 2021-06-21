using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    public class ResourceManager
    {
        private ContentManager contentManager;
        private Dictionary<string, Texture2D> _texturesDic;
        private Dictionary<string, SpriteFont> _fontsDic;

        public ResourceManager(ContentManager c)
        {
            contentManager = c;
            _texturesDic = new Dictionary<string, Texture2D>();
            _fontsDic = new Dictionary<string, SpriteFont>();
        }

        public Texture2D GetTexture(string s)
        {
            if (_texturesDic.ContainsKey(s))
            {
                return _texturesDic[s];
            }
            else
            {
                Texture2D desiredTexture = contentManager.Load<Texture2D>(s);
                _texturesDic[s] = desiredTexture;
                return desiredTexture;
            }
        }

        public SpriteFont GetSpriteFont(string s)
        {
            if (_fontsDic.ContainsKey(s))
            {
                return _fontsDic[s];
            }
            else
            {
                SpriteFont desiredFont = contentManager.Load<SpriteFont>(s);
                _fontsDic[s] = desiredFont;
                return desiredFont;
            }
        }
    }
}
