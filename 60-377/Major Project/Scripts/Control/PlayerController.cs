using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 2.0f;

    [SerializeField]
    private Collider feet;

    private Vector3 gravityDirection = -Vector3.up;
    private Vector3 velocity;
    private Rigidbody rigidbdy;

    private InputController controller;

    private Player playerClass;

    [SerializeField]
    private LayerMask groundLayer;


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

        //Physics.OverlapSphere()

        return false;
    }

    void Start()
    {
        this.rigidbdy = GetComponent<Rigidbody>();
        this.playerClass = GetComponent<Player>();
        this.controller = GetComponent<InputController>();

        // XXX Set this in Unity Input manager.
        Physics.gravity *= 2;

        this.velocity = rigidbdy.velocity;
    }

    void Jump()
    {
        this.velocity.y = 0;
        this.velocity += -gravityDirection * this.jumpSpeed;
        this.controller.UseJump();
    }

    bool isRunning()
    {
        return !Mathf.Approximately(this.controller.GetRunInput(), 0);
    }

    void OnRun()
    {
        this.velocity.x = this.controller.GetRunInput() * this.playerClass.GetRunSpeed();
    }

    void Update()
    {
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
            this.controller.ResetJumps();

        if (this.controller.CanJump())
            this.Jump();

        this.velocity.z = 0;
        this.rigidbdy.velocity = velocity;
    }
}