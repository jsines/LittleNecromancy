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
        private static int idCounter = 1;
        static int generateID() { return idCounter++; }
        public int id;
        private Vector2 worldPosition;
        private Vector2 localPosition;
        private Entity parent = null;
        private List<Entity> children;
        public float z;
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
            if(parent == null)
            {
                worldPosition = newPosition;
            }
            else
            {
                localPosition = newPosition;
            }
        }
        public Vector2 GetPosition()
        {
            if(parent == null)
            {
                return worldPosition;
            }
            else
            {
                return parent.GetPosition() + localPosition;
            }
        }
        public void SetParent(Entity e)
        {
            parent = e;
            e.AddChild(this);
        }
        public Entity GetParent()
        {
            return parent;
        }
        public void AddChild(Entity e)
        {
            children.Add(e);
        }
        public void RemoveChild(Entity e)
        {
            children.Remove(e);
        }
    }
}
