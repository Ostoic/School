using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Control
{
    namespace Internal
    {
        public class InputAction
        {
            private KeyCode keycode;
            private Action action;

            public InputAction(KeyCode keycode, Action action)
            {
                this.keycode = keycode;
                this.action = action;
            }

            public KeyCode GetKey()
            {
                return this.keycode;
            }

            public void Invoke()
            {
                this.action();
            }
        }
    }
}