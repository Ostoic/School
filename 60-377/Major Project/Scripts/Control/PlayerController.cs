using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    [DisallowMultipleComponent]
    [RequireComponent(
        typeof(Rigidbody),          // Requires object to have Rigidbody,
        typeof(Classes.Player))]    // and a Classes.Player component.
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

        private Classes.Player player;

        private Queue<System.Action> fixedQueue;

        [SerializeField]
        private LayerMask groundLayer;

        public void ResetVelocity()
        {
            this.rigidbdy.velocity = Vector3.zero;
        }

        bool OnGround()
        {
            Collider[] collisions = Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);

            if (collisions.Length > 0)
                return true;

            return false;
        }

        void TeleportTest()
        {
            GameObject target = GameObject.Find("Target");

            Spells.Teleport teleport = (Spells.Teleport)this.player.GetSpell("Teleport");
            teleport.SetLocation(target.transform.position);
            teleport.Cast();
        }

        void GravitySwitchTest()
        {
            Physics.gravity *= -1;
            this.gravityDirection *= -1;
            Utility.Swap(ref this.feet, ref this.head);
        }

        void Start()
        {
            this.rigidbdy = GetComponent<Rigidbody>();
            this.player = GetComponent<Classes.Player>();

            // XXX Set this in Unity Input manager.
            Physics.gravity *= 2;

            this.velocity = rigidbdy.velocity;
            this.fixedQueue = new Queue<System.Action>();

            this.controller = new InputController();

            this.controller.RegisterAction(KeyCode.Space, () => { this.fixedQueue.Enqueue(AttemptJump); });
            this.controller.RegisterAction(KeyCode.T, TeleportTest);
            this.controller.RegisterAction(KeyCode.G, GravitySwitchTest);
        }

        void Jump()
        {
            this.velocity.y = 0;
            this.velocity += -gravityDirection * this.jumpSpeed;
            this.controller.UseJump();
        }

        void OnRun()
        {
            this.velocity.x = this.controller.GetRunInput() * this.player.GetRunSpeed();
        }

        void Update()
        {
            this.controller.InvokeInput();
        }

        void AttemptJump()
        {
            if (this.OnGround())
                this.controller.ResetJumps();

            if (this.controller.JumpAvailable())
                this.Jump();
        }

        void InvokeFixedActions()
        {
            // Get the top action from the queue and invoke it.
            if (this.fixedQueue.Count > 0)
                this.fixedQueue.Dequeue()();
        }

        void FixedUpdate()
        {
            // Update velocity
            this.velocity = rigidbdy.velocity;
            this.OnRun();

            this.InvokeFixedActions();

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