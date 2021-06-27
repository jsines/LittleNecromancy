using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    public class TimeManager
    {
        Dictionary<string, Action> repeatedActions;
        List<(double, Action, Action)> expirableActions;
        public TimeManager()
        {
            repeatedActions = new Dictionary<string, Action>();
            expirableActions = new List<(double, Action, Action)>();
        }

        public void AddRepeatedHandler(string name, Action action)
        {
            if (repeatedActions[name] != null)
                LN.Log(String.Format("ERROR: Tried to add a handler with a duplicate name! {0}", name));
            else
                repeatedActions[name] = action;
        }
        public void AddExpirableHandler(double lifeSpan, Action action, Action callback = null)
        {
            expirableActions.Add((lifeSpan, action, callback));
        }
        public void Update(GameTime gameTime)
        {
            double gap = gameTime.ElapsedGameTime.TotalMilliseconds;
            
        }
        public void UpdateExpirables(double dt)
        {
            List<(double, Action, Action)> newList = new List<(double, Action, Action)>();
            foreach(var x in expirableActions)
            {
                x.Item2();
                var y = x; // foreach makes x members nonmutable, this is hacky but it works :p
                newList.Add((y.Item1 -= dt, y.Item2, y.Item3));
            }
            int count = newList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if(expirableActions[i].Item1 <= 0)
                {
                    expirableActions[i].Item3();
                    expirableActions.RemoveAt(i);
                }
            }

        }
    }
}
