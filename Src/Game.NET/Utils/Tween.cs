using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.NET.Utils
{
    public class Tween
    {
        public delegate double Easing(double X);
        public delegate void SimpleEvent(Tween tween);

        private static List<Tween> _tweens = new List<Tween>();
        public static int Count => _tweens.Count;

        private double _elapsed;

        public bool IsEnabled { get; set; }
        public double Value { get; private set; }
        public double From { get; set; }
        public double Target { get; set; }
        public double Speed { get { return (Target - From) / Time; } set { Time = (Target - From) * value; } }
        public double Time { get; set; }
        public Easing UsedEasing { get; set; }

        public event SimpleEvent OnFinish;
        public event SimpleEvent OnUpdate;

        public Tween()
        {
            _tweens.Add(this);
        }

        public void Start()
        {
            _elapsed = 0;
            IsEnabled = true;
            Value = From;
        }

        public void Destroy()
        {
            _tweens.Remove(this);
        }
        
        private void DoUpdate(double dt, double time)
        {
            var diff = Target - From;
            Value = From + diff * UsedEasing(_elapsed / this.Time);

            if (Math.Abs(Value - Target) < double.Epsilon || _elapsed > this.Time)
            {
                IsEnabled = false;
                Value = Target;
                OnFinish?.Invoke(this);
            }
            else
            {
                _elapsed += dt;
                OnUpdate?.Invoke(this);
            }
        }

        public static double Get(double passed, double duration, Easing easing)
        {
            return easing(passed / duration);
        }

        public static void Update(double dt, double time)
        {
            foreach (var tween in _tweens.Where(tween => tween.IsEnabled))
            {
                tween.DoUpdate(dt, time);
            }
        }
    }

}
