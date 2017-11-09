using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float jumpSpeed = 2.0f;
	public float runSpeed = 10.0f;
	public float turnSpeed = 120;

	private float jumpInput = 0;
	private float runInput = 0;

	private bool onGround = false;

	private Vector3 velocity;
	private Vector3 jumpForce;
	private Rigidbody rigidbdy;
	private Collider collide;

	private int jumpsAvailable = 2;


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
		return Physics.Raycast(transform.position, -Vector3.up, collide.bounds.extents.y + 0.1f);
	}

	void Start()
	{
		if (!(rigidbdy = GetComponent<Rigidbody>()))
			Debug.LogError("Unable to find rigidbody for transform");

		if (!(collide = GetComponent<Collider>()))
			Debug.LogError("Object must have a collider");

		velocity = rigidbdy.velocity;
		jumpForce = Vector3.up;
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
		runInput = Input.GetAxis("Horizontal");
	}

	void ResetJumps()
	{
		jumpsAvailable = 2;
	}

	void Jump() 
	{
		rigidbdy.AddForce(jumpForce * jumpSpeed, ForceMode.VelocityChange);
		jumpsAvailable--;
	}

	void OnRun()
	{
		velocity.x = runInput * runSpeed;
	}

	void Update()
	{
		GetRunInput();
		GetJumpInput();
	}

	void FixedUpdate()
	{
		// Update velocity
		velocity = rigidbdy.velocity;
		OnRun();

		rigidbdy.velocity = velocity;
		if (onGround && jumpInput > 0)
		{
			Jump();
		}
	}
}
