using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float jumpSpeed = 2.0f;
    public float runSpeed = 10.0f;

    private float strafeInput = 0;
    private float jumpInput = 0;
    private float runInput = 0;

    private int jumpsAvailable = 2;

    private Vector3 gravityDirection = -Vector3.up;
    private Vector3 velocity;

    private Rigidbody rigidbdy;

    public void WorldTeleport(Transform target)
    {
        this.transform.position = target.position;
        this.transform.rotation = target.rotation;
    }

    public void ResetVelocity()
    {
        this.rigidbdy.velocity = Vector3.zero;
    }

    bool OnGround()
    {
        float playerHeight = this.transform.localScale.y;

        Debug.Log("Playerheight = " + playerHeight);

        Vector3 vec = this.transform.position;
        Ray ray = new Ray(vec, this.gravityDirection);

        Debug.DrawRay(ray.origin, ray.direction);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, playerHeight))
        {
            if (hit.distance <= playerHeight / 2)
            {
                Debug.Log("Hit");
                this.jumpsAvailable = 2;
                return true;
            }
        }

        return false;
    }

    void Start()
    {
        if (!(this.rigidbdy = GetComponent<Rigidbody>()))
            Debug.LogError("Unable to find rigidbody for transform");

        //if (!(this.collider = GetComponent<Collider>()))
            //Debug.LogError("Object must have a collider");

        this.velocity = rigidbdy.velocity;
    }

    void GetJumpInput()
    {
        // Get jump input
        jumpInput = Input.GetAxis("Jump");
    }

    void GetRunInput()
    {
        // Get run forward/backward input
        if (Input.GetKey(KeyCode.W))
            this.runInput = 1;
        else if (Input.GetKey(KeyCode.S))
            this.runInput = -1;
        else
            this.runInput = 0;

        // Get Strafe left/right input
        if (Input.GetKey(KeyCode.E))
            this.strafeInput = 1;
        else if (Input.GetKey(KeyCode.Q))
            this.strafeInput = -1;
        else
            this.strafeInput = 0;
    }

    void OnRun()
    {
        this.velocity.z = runInput * runSpeed;
    }
    void OnStrafe()
    {
        this.velocity.x = strafeInput * runSpeed;
    }
    void Jump()
    {
        Debug.Log("Jump called");
        this.velocity.y = 0;
        this.velocity += -gravityDirection * this.jumpSpeed;
        this.jumpInput = 0;
        this.jumpsAvailable--;
    }

    bool CanJump()
    {
        return (this.OnGround() || this.jumpsAvailable > 0)
             && this.jumpInput != 0;
    }

    void Update()
    {
        this.GetRunInput();
        this.GetJumpInput();
    }

    void FixedUpdate()
    {
        // Update velocity
        this.velocity = rigidbdy.velocity;
        this.OnRun();
        this.OnStrafe();

        if (this.CanJump())
            this.Jump();

        this.rigidbdy.velocity = velocity;
    }
}
