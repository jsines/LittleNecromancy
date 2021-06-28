using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    public class TimerUtilities
    {
        private TimeManager tm;
        public TimerUtilities(TimeManager manager)
        {
            tm = manager;
        }

        public Func<double, double> SmoothStopN(int n)
        {
            return (double t) => (1 - Math.Pow(1 - t, n));
        }
        public Func<double, double> SmoothStartN(int n)
        {
            return (double t) => (Math.Pow(t, n));
        } 
        public Func<double, double> Mix(Func<double, double> a, Func<double, double> b, double weightB)
        {
            return (double t) => (1-weightB) * a(t) + weightB * b(t);
        }
        public Func<double, double> Crossfade(Func<double, double> a, Func<double, double> b)
        {
            return (double t) => (1 - t) * a(t) + t * b(t);
        }

        public Func<double, double> SmoothStepN(int n)
        {
            return Mix(SmoothStartN(n), SmoothStopN(n), .5);
        }
        public Func<double, double> SmoothStepN2(int n)
        {
            return Crossfade(SmoothStartN(n), SmoothStopN(n));
        }
        public Func<double, double> SmootherStep()
        {
            return (double t) => (t * t * t * (t * (t * 6 - 15) + 10));
        }
    }
}
