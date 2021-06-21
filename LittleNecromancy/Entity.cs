using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    class Entity
    {
        public Vector2 position;
        public float z;
        public bool dead = false;

        public Entity()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
