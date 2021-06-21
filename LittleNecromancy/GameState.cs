﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    class GameState
    {
        private Dictionary<string, Entity> _stateEntities;

        public GameState()
        {
            _stateEntities = new Dictionary<string, Entity>();
        }

        public virtual void Initialize()
        {

        }

        public void Update(GameTime gameTime)
        {
            List<string> removalList = new List<string>();
            List<string> keys = new List<string>(_stateEntities.Keys);
            foreach(string key in keys)
            {
                Entity e = _stateEntities[key];
                if (e.dead)
                {
                    removalList.Add(key);
                }
                else
                {
                    e.Update(gameTime);
                }
            }
            foreach(string key in removalList)
            {
                _stateEntities.Remove(key);
            }
        }
        public void Draw(SpriteBatch sb, GameTime gt)
        {
            // PROBABLY VERY BAD!! FOR CACHE ESPECIALLY!! optimize pls
            // Renders by going over all entities, adding to a list, sorting by z value, and then rendering them
            // I don't like this implementation. I did this because I want to store entites in a dictionary because it makes it easy to assign strings as ids
            // This is basically a conceptual benefit at the cost of a render time increase. If things start to slow down this will probably get the axe quick.
            List<Entity> entityList = new List<Entity>();
            foreach (KeyValuePair<String, Entity> kvp in _stateEntities)
            {
                Entity e = kvp.Value;
                if (!e.dead && e.position != null)
                {
                    Sprite sprite = e as Sprite;
                    TextBox textBox = e as TextBox;
                    AnimatedSprite aSprite = e as AnimatedSprite;

                    bool renderableSprite = (sprite != null && sprite.texture != null);
                    bool renderableText = (textBox != null && textBox.font != null);
                    bool renderableAnimation = (aSprite != null && aSprite.spriteSheet != null);

                    if (renderableSprite || renderableText || renderableAnimation)
                    {
                        entityList.Add(e);
                    }
                }
            }
            entityList.Sort((x, y) => x.z.CompareTo(y.z)); // In place sort
            sb.Begin();
            foreach(Entity e in entityList)
            {
                Sprite sprite = e as Sprite;
                TextBox textBox = e as TextBox;
                AnimatedSprite aSprite = e as AnimatedSprite;
                if(sprite != null)
                {
                    sb.Draw(sprite.texture, sprite.position, null, Color.White);
                }
                else if (textBox != null)
                {
                    sb.DrawString(textBox.font, textBox.text, textBox.position, Color.White);
                }
                else if (aSprite != null)
                {
                    sb.Draw(aSprite.spriteSheet, aSprite.position, aSprite.srcRec, Color.White);
                }
            }
            sb.End();
        }

        public void AddEntity(String name, Entity e)
        {
            _stateEntities[name] = e;
            e.Initialize();
            System.Diagnostics.Debug.WriteLine("Added Entity", name);
        }
        public Entity GetEntity(String name)
        {
            return _stateEntities[name];
        }
        public void DestroyEntity(String name)
        {
            _stateEntities[name].dead = true;
        }
    } 
}