using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    namespace Internal
    {
        public class InputController
        {
            private float runInput = 0;

            private float threshold = 0.1f;

            List<InputAction> actions;

            public InputController()
            {
                this.actions = new List<InputAction>();
            }

            void UpdateRunInput()
            {
                this.runInput = Input.GetAxis("Horizontal");
            }

            public float GetRunInput()
            {
                if (Mathf.Abs(this.runInput) < this.threshold)
                    this.runInput = 0;

                return this.runInput;
            }

            /// <summary>
            /// Create new InputAction that will be invoked when the given keycode is pressed.
            /// </summary>
            /// <param name="keycode">The key to poll for input.</param>
            /// <param name="action">The action to invoke.</param>
            public void RegisterKey(KeyCode keycode, System.Action action)
            {
                this.actions.Add(new KeyboardAction(keycode, action));
            }

            /// <summary>
            /// Create new InputAction that will be invoked when the given keycode is pressed.
            /// </summary>
            /// <param name="keycode">The key to poll for input.</param>
            /// <param name="action">The action to invoke.</param>
            public void RegisterMouse(int button, System.Action action)
            {
                this.actions.Add(new MouseAction(button, action));
            }

            public void InvokeInput()
            {
                this.UpdateRunInput();

                // Update action inputs
                foreach (InputAction input in actions)
                {
                    // For each action's key that is pressed, 
                    // invoke the corresponding action.
                    if (input.Check())
                        input.Invoke();
                }
            }
        }
    }
}