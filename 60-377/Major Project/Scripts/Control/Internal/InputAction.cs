using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Control
{
    namespace Internal
    {
        public abstract class InputAction
        {
            private Action action;

            public InputAction(Action action)
            {
                this.action = action;
            }

            public abstract bool Check();

            public void Invoke()
            {
                this.action();
            }
        }
    }
}