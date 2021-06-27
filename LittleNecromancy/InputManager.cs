using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    public class InputManager
    {
        private KeyboardState _keys, _oldkeys = Keyboard.GetState();
        private Dictionary<Keys, List<Action>> _onKeyPress = new Dictionary<Keys, List<Action>>();

        public void AddKeyPressHandler(Keys key, Action handler)
        {
            if (!_onKeyPress.ContainsKey(key))
            {
                _onKeyPress.Add(key, new List<Action>());
            }
            _onKeyPress[key].Add(handler);
        }

        public void ClearKeyPressHandler()
        {
            _onKeyPress.Clear();
        }

        public void Update()
        {
            _keys = Keyboard.GetState();
            foreach(Keys x in Enum.GetValues(typeof(Keys)))
                if(!_keys.IsKeyDown(x) && _oldkeys.IsKeyDown(x) && _onKeyPress.ContainsKey(x))
                    foreach (var handler in _onKeyPress[x])
                        handler();
            _oldkeys = _keys;
        }
    }
}
