using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    class Sprite : Entity
    {
        public Texture2D texture;
        public Sprite(string textureFile)
        {
            texture = LittleNecromancy.resourceManager.GetTexture(textureFile);
        }

    }
}
