using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control {
    public class InputController : MonoBehaviour {

        private bool jumpInput = false;
        private float runInput = 0;

        private float threshold = 0.1f;
        private int jumpsAvailable = 2;



        public void ResetJumps()
        {
            Debug.Log("Reset");
            this.jumpsAvailable = 2;
        }

        public void UseJump()
        {
            Debug.Log("UseJump");
            this.jumpsAvailable--;
            this.jumpInput = false;
        }

        public bool JumpRequested()
        {
            return this.jumpInput;
        }

        public bool JumpAvailable()
        {
            return this.jumpsAvailable > 0;
        }

        public void UpdateJumpInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.jumpInput = true;
            }
            else
                this.jumpInput = false;
        }

        public void UpdateInput()
        {
            this.UpdateJumpInput();
            this.UpdateRunInput();
        }

        public void UpdateRunInput()
        {
            this.runInput = Input.GetAxis("Horizontal");
        }

        public float GetRunInput()
        {
            if (Mathf.Abs(this.runInput) < this.threshold)
                this.runInput = 0;

            return this.runInput;
        }
    }
}