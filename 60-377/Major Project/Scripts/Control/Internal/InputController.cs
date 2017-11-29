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
            private int jumpsAvailable = 2;

            List<InputAction> actions;

            public InputController()
            {
                this.actions = new List<InputAction>();
            }

            public void ResetJumps()
            {
                this.jumpsAvailable = 2;
            }

            public void UseJump()
            {
                this.jumpsAvailable--;
            }

            public bool JumpAvailable()
            {
                return this.jumpsAvailable > 0;
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
            public void RegisterAction(KeyCode keycode, System.Action action)
            {
                this.actions.Add(new InputAction(keycode, action));
            }

            public void InvokeInput()
            {
                this.UpdateRunInput();

                // Update action inputs
                foreach (InputAction input in actions)
                {
                    // For each action's key that is pressed, 
                    // invoke the corresponding action.
                    if (Input.GetKeyDown(input.GetKey()))
                        input.Invoke();
                }
            }
        }
    }
}