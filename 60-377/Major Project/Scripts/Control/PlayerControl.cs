using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpSpeed = 2.0f;
    public float runSpeed = 10.0f;
    public float turnSpeed = 120;

    private int jumpInput = 0;
    private float runInput = 0;
    private float threshold = 0.1f;

    private Vector3 gravityDirection = -Vector3.up;
    private Vector3 velocity;
    private Vector3 jumpForce;
    private Rigidbody rigidbdy;
    private Collider collider;

    public LayerMask groundLayer;

    private int jumpsAvailable = 2;


    public void WorldTeleport(Transform target)
    {
        this.transform.position = target.position;
        this.transform.rotation = target.rotation;
    }

    public void ResetVelocity()
    {
        rigidbdy.velocity = Vector3.zero;
    }

    bool OnGround()
    {
        float playerHeight = this.transform.localScale.y;

        Vector3 vec = this.transform.position;
        Ray ray = new Ray(vec, this.gravityDirection);

        Debug.DrawRay(ray.origin, ray.direction);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 2 * playerHeight))
        {
            if (hit.distance <= playerHeight)
            {
                return true;
            }
        }

        return false;
    }

    void Start()
    {
        if (!(this.rigidbdy = GetComponent<Rigidbody>()))
            Debug.LogError("Unable to find rigidbody for transform");

        if (!(this.collider = GetComponent<Collider>()))
            Debug.LogError("Object must have a collider");

        Physics.gravity *= 2;

        this.velocity = rigidbdy.velocity;
        this.jumpForce = Vector3.up;
    }

    void GetJumpInput()
    {
        // Get jump input
        if (Input.GetKeyDown(KeyCode.Space))
            this.jumpInput = 1;
        else
            this.jumpInput = 0;
    }

    void GetRunInput()
    {
        // Get run forward/backward input
        this.runInput = Input.GetAxis("Horizontal");
    }

    void ResetJumps()
    {
        this.jumpsAvailable = 2;
    }

    void Jump()
    {
        Debug.Log("Jump boys");
        this.velocity.y = 0;
        this.velocity += -gravityDirection * this.jumpSpeed;
        this.jumpsAvailable--;
        this.jumpInput = 0;
    }

    bool isRunning()
    {
        return !Mathf.Approximately(runInput, 0);
    }

    void OnRun()
    {
        if (Mathf.Abs(runInput) < threshold)
            this.runInput = 0;

        this.velocity.x = runInput * runSpeed;
    }

    void Update()
    {
        this.GetRunInput();
        this.GetJumpInput();

        if (Input.GetKeyUp(KeyCode.G))
        {
            Physics.gravity *= -1;
            this.gravityDirection *= -1;
        }
    }

    void FixedUpdate()
    {
        // Update velocity
        this.velocity = rigidbdy.velocity;
        this.OnRun();

        if (this.OnGround())
            ResetJumps();

        if (this.jumpsAvailable > 0 && this.jumpInput > 0)
            this.Jump();

        this.velocity.z = 0;
        this.rigidbdy.velocity = velocity;
    }
}