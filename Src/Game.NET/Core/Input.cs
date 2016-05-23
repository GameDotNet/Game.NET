using System.Collections.Generic;
using OpenTK.Input;

namespace Game.NET.Core
{
    public class Input<T>
    {
        public class KeyInfo
        {
            public Key code;
            public bool action;
            public bool pressed;
            public bool on;
            internal float pressTime;

            public bool IsDown { get { return pressed && on; } }
            public bool IsUp { get { return !pressed && on; } }

            public static implicit operator Key(KeyInfo info) { return info.code; }
            public static implicit operator bool(KeyInfo info) { return info.pressed; }
        }
        
        private static Dictionary<T, KeyInfo> Keys = new Dictionary<T, KeyInfo>();
        public static float KeyRepeat = 0.25f;
        
        public static KeyInfo GetButton(T t)
        {
            return Keys[t];
        }

        public static void GrabInput(GameTime gameTime)
        {
            foreach (var itr in Keys)
            {
                var key = itr.Value;
                var state = Keyboard.GetState();
                var pressed = state[key.code];

                key.on = key.pressed != pressed;
                key.pressed = pressed;

                if (key.IsDown)
                {
                    key.pressTime = gameTime.Time;
                }

                // var elapsed = gameTime.Time - key.pressTime;
                // key.action = key.pressed && (key.on || (elapsed > gameTime.dt && (elapsed % KeyRepeat < gameTime.timeStep)));//.dt)));
            }
        }

        public static void BindButton(Key keyCode, T type)
        {
            Keys[type].code = keyCode;
        }
    }
}