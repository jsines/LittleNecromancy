using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    public class Entity
    {
        private static int idCounter = 1;
        static int generateID() { return idCounter++; }
        public int id;
        private Vector2 position;
        private float z;
        private float alpha = 1f;
        private Entity parent = null;
        private List<Entity> children;
        public bool dead = false;


        public Entity()
        {
            children = new List<Entity>();
            id = generateID();
        }

        public virtual void Initialize()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public Vector2 GetPosition()
        {
            if (parent == null)
            {
                return position;
            }
            else
            {
                return parent.GetPosition() + position;
            }
        }
        public void SetX(float newX)
        {
            position.X = newX;
        }
        public void SetY(float newY)
        {
            position.Y = newY;
        }
        public void SetZ(float newZ)
        {
            z = newZ;
        }
        public float GetZ()
        {
            if(parent == null)
            {
                return z;
            }
            else
            {
                return parent.GetZ() + z;
            }
        }
        public void SetAlpha(float f)
        {
            alpha = f;
        }
        public float GetAlpha()
        {
            return alpha;
        }
        public void SetParent(Entity e)
        {
            if (parent != null)
                parent.RemoveChild(e);
            parent = e;
            e.children.Add(this);
        }
        public Entity GetParent()
        {
            return parent;
        }
        public void AddChild(Entity e)
        {
            if (e.parent != null)
                e.parent.RemoveChild(e);
            e.parent = this;
            children.Add(e);
        }
        public void RemoveChild(Entity e)
        {
            children.Remove(e);
        }
    }
}
