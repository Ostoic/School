using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Control
{
    namespace Internal
    {
        public class MouseAction : InputAction
        {
            int button;

            public MouseAction(int button, Action action)
                : base(action)
            {
                this.button = button;
            }

            public override bool Check()
            {
                return Input.GetMouseButtonDown(this.button);
            }
        }
    }
}