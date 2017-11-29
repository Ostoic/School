using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    [DisallowMultipleComponent]
    [RequireComponent(
        typeof(Rigidbody),          // Requires object to have Rigidbody,
        typeof(Objects.Biped),      // and a Classes.Player component.
        typeof(Classes.Player))]    // and a Classes.Player component.
    public class PlayerController : MonoBehaviour
    {
        private InputController controller;

        private Objects.Biped biped;
        private Classes.Player player;

        private Queue<System.Action> fixedQueue;

        void TeleportTest()
        {
            GameObject target = GameObject.Find("Target");

            Spells.Teleport teleport = (Spells.Teleport)this.player.GetSpell("Teleport");
            teleport.SetLocation(target.transform.position);
            teleport.Cast();
        }

        void GravitySwitchTest()
        {
            this.player.CastSpell("InvertGravity");
        }

        void Start()
        {
            this.biped = GetComponent<Objects.Biped>();
            this.player = GetComponent<Classes.Player>();

            // XXX Set this in Unity Input manager.
            Physics.gravity *= 2;

            this.fixedQueue = new Queue<System.Action>();
            this.controller = new InputController();

            this.controller.RegisterAction(KeyCode.Space, () => { this.fixedQueue.Enqueue(AttemptJump); });
            this.controller.RegisterAction(KeyCode.T, TeleportTest);
            this.controller.RegisterAction(KeyCode.G, GravitySwitchTest);
        }

        void Update()
        {
            this.controller.InvokeInput();
        }

        void AttemptJump()
        {
            if (this.biped.OnGround())
                this.controller.ResetJumps();

            if (this.controller.JumpAvailable())
            {
                this.biped.Jump();
                this.controller.UseJump();
            }
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
            this.biped.Run(this.controller.GetRunInput());

            this.InvokeFixedActions();

            this.biped.UpdateVelocity();
        }

        void LateUpdate()
        {
            Collider[] collisions = this.biped.GetOverlapColliders();

            if (collisions.Length > 0)
            {
                foreach (Collider collider in collisions)
                    collider.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}