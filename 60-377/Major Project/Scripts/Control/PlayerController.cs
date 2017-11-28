using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float jumpSpeed = 2.0f;

        [SerializeField]
        private Collider feet;

        [SerializeField]
        private Collider head;
        
        private Vector3 gravityDirection = -Vector3.up;
        private Vector3 velocity;
        private Rigidbody rigidbdy;

        private InputController controller;

        private Player playerClass;

        delegate void Action();

        private Queue<Action> fixedQueue;

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
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        bool OnGround()
        {
            Collider[] collisions = Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);

            if (collisions.Length > 0)
                return true;

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
            this.fixedQueue = new Queue<Action>();
        }

        void Jump()
        {
            this.velocity.y = 0;
            this.velocity += -gravityDirection * this.jumpSpeed;
            this.controller.UseJump();
        }

        void OnRun()
        {
            this.velocity.x = this.controller.GetRunInput() * this.playerClass.GetRunSpeed();
        }

        void Update()
        {
            this.controller.UpdateInput();

            // If the controller requests a jump, enqueue a jump attempt for
            // FixedUpdate to invoke.
            if (this.controller.JumpRequested())
                this.fixedQueue.Enqueue(AttemptJump);

            if (Input.GetKeyUp(KeyCode.G))
            {
                Swap(ref feet, ref head);
                Physics.gravity *= -1;
                this.gravityDirection *= -1;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                GameObject target = GameObject.Find("Target");

                Spells.Teleport teleport = (Spells.Teleport)this.playerClass.GetSpell("Teleport");
                teleport.SetLocation(target.transform);
                teleport.Cast();
            }
        }

        void AttemptJump()
        {
            if (this.OnGround())
                this.controller.ResetJumps();

            if (this.controller.JumpAvailable())
                this.Jump();
        }

        void FixedUpdate()
        {
            // Update velocity
            this.velocity = rigidbdy.velocity;
            this.OnRun();

            // Get the top delegate from the queue and invoke it.
            if (this.fixedQueue.Count > 0)
                this.fixedQueue.Dequeue()();

            this.rigidbdy.velocity = velocity;
        }

        void LateUpdate()
        {
            Debug.DrawRay(feet.transform.position, -Vector3.up);
            Collider[] collisions = Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);

            if (collisions.Length > 0)
            {
                foreach (Collider collider in collisions)
                    collider.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}