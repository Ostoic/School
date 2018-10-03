using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float jumpSpeed = 2.0f;
    public float runSpeed = 10.0f;
    public float turnSpeed = 120;

    private float jumpInput = 0;
    private float runInput = 0;
    private float turnInput = 0;
    private float strafeInput = 0;

    private bool onGround = false;

    private Quaternion rotation;
    private Vector3 velocity;
    private Vector3 jumpForce;
    private Rigidbody rigidbdy;
    private Collider collider;
    

    public void WorldTeleport(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    public void ResetVelocity()
    {
        rigidbdy.velocity = Vector3.zero;
    }

    void OnCollisionEnter()
    {
        onGround = true;
    }

    void OnCollisionStay2D()
    {
        onGround = true;
    }

    void OnCollisionExit()
    {
        onGround = false;
    }

    bool OnGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + 0.1f);
    }
    
    void Start()
    {
        if (!(rigidbdy = GetComponent<Rigidbody>()))
            Debug.LogError("Unable to find rigidbody for transform");

        if (!(collider = GetComponent<Collider>()))
            Debug.LogError("Object must have a collider");

        rotation = transform.rotation;
        velocity = rigidbdy.velocity;
        jumpForce = Vector3.up;
    }

    void GetTurnInput()
    {
        // Get turn left/right input
        if (Input.GetKey(KeyCode.D))
            turnInput = 1;
        else if (Input.GetKey(KeyCode.A))
            turnInput = -1;
        else
            turnInput = 0;
    }
    void GetJumpInput()
    {
        // Get jump input
        if (Input.GetKeyDown(KeyCode.Space))
            jumpInput = 1;
        else
            jumpInput = 0;
    }

    void GetRunInput()
    {
        // Get run forward/backward input
        if (Input.GetKey(KeyCode.W))
            runInput = 1;
        else if (Input.GetKey(KeyCode.S))
            runInput = -1;
        else
            runInput = 0;

        // Get Strafe left/right input
        if (Input.GetKey(KeyCode.E))
            strafeInput = 1;
        else if (Input.GetKey(KeyCode.Q))
            strafeInput = -1;
        else
            strafeInput = 0;
    }

    void OnTurn()
    {
        rotation *= Quaternion.AngleAxis(turnSpeed * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = rotation;
    }

    void OnRun()
    {
        velocity.z = runInput * runSpeed;
    }
    void OnStrafe()
    {
        velocity.x = strafeInput * runSpeed;
    }
    void Jump()
    {
        rigidbdy.AddForce(jumpForce * jumpSpeed, ForceMode.Impulse);
    }
    void Update()
    {
        GetRunInput();
        GetTurnInput();
        GetJumpInput();
        OnTurn();
    }
    void FixedUpdate()
    {
        // Update velocity
        velocity = rigidbdy.velocity;
        OnRun();
        OnStrafe();
        rigidbdy.velocity = velocity;

        if (onGround && jumpInput > 0)
        {
            Jump();
        }
    }
}
