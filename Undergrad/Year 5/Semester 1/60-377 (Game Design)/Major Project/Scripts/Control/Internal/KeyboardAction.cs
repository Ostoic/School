using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Control
{
    namespace Internal
    {
        public class KeyboardAction : InputAction
        {
            KeyCode keycode; 

            public KeyboardAction(KeyCode keycode, Action action)
                : base(action)
            {
                this.keycode = keycode;
            }

            public override bool Check()
            {
                return Input.GetKeyDown(this.keycode);
            }
        }
    }
}