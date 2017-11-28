using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private float threshold = 0.1f;
    private int jumpsAvailable = 2;

    int GetJumpInput()
    {
        // Get jump input
        if (Input.GetKeyDown(KeyCode.Space))
            return 1;
        else
            return 0;
    }
    
    public void ResetJumps()
    {
        this.jumpsAvailable = 2;
    }

    public void UseJump()
    {
        this.jumpsAvailable--;
    }

    public bool CanJump()
    {
        return this.jumpsAvailable > 0 && GetJumpInput() != 0;
    }

    public float GetRunInput()
    {
        float runInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(runInput) < this.threshold)
            runInput = 0;

        return runInput;
    }
}
