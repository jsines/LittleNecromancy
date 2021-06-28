using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    public class TimeManager
    {
        struct ExpirableTimer
        {
            public double msUntil;
            public double msSince;
            public Action<double, double> repeatedAction; // arguments are msSince and deltaTime
            public Action callback;
        }
        struct RepeatableTimer
        {
            public double msSince;
            public Action<double, double> repeatedAction;
        }
        List<RepeatableTimer> repeatedTimers; // arguments are msSince and deltaTime
        List<ExpirableTimer> expirableTimers;
        public TimeManager()
        {
            repeatedTimers = new List<RepeatableTimer>();
            expirableTimers = new List<ExpirableTimer>();
        }

        public void AddRepeatedHandler(Action<double, double> action)
        {
            RepeatableTimer rt;
            rt.msSince = 0;
            rt.repeatedAction = action;
            repeatedTimers.Add(rt);
        }
        public void AddExpirableHandler(double msLifeSpan, Action<double, double> action, Action callback = null)
        {
            ExpirableTimer et;
            et.msUntil = msLifeSpan;
            et.msSince = 0;
            et.repeatedAction = action;
            et.callback = callback;
            expirableTimers.Add(et);
        }
        public void Update(GameTime gameTime)
        {
            double gap = gameTime.ElapsedGameTime.TotalMilliseconds;
            UpdateExpirables(gap);
            UpdateRepeatables(gap);
        }
        public void UpdateExpirables(double dt)
        {
            int count = expirableTimers.Count;
            for (int i = 0; i < count; i++)
            {
                ExpirableTimer et = expirableTimers[i];
                et.msUntil -= dt;
                et.msSince += dt;
                et.repeatedAction(et.msSince, dt);
                expirableTimers[i] = et;
            }
            for (int i = count - 1; i >= 0; i--)
            {
                ExpirableTimer et = expirableTimers[i];
                if(et.msUntil <= 0)
                {
                    if(et.callback != null) et.callback();
                    expirableTimers.RemoveAt(i);
                }
            }
        }
        public void UpdateRepeatables(double dt)
        {
            int count = repeatedTimers.Count;
            for(int i = 0; i < count; i++)
            {
                RepeatableTimer rt = repeatedTimers[i];
                rt.msSince += dt;
                rt.repeatedAction(rt.msSince, dt);
                repeatedTimers[i] = rt;
            }
        }
    }
}
