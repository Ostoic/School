using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    [DisallowMultipleComponent]
    [RequireComponent(
        typeof(Rigidbody),          // Requires class to have Rigidbody,
        typeof(Objects.Player),      // a Objects.Biped component,
        typeof(Classes.Player))]    // and a Classes.Player component.
    public class PlayerController : MonoBehaviour
    {
        private Internal.InputController controller;

        private Objects.Player biped;
        private Classes.Player player;

        private Queue<System.Action> fixedQueue;

        void BlinkAction()
        {
            Vector3 target = Input.mousePosition;
            target.z = -Camera.main.transform.position.z + this.transform.position.z;
            target = Camera.main.ScreenToWorldPoint(target);

            Spells.Blink blink = (Spells.Blink)this.player.GetSpell("Blink");
            blink.SetLocation(target);
            blink.Cast();
        }

        void LaserAction()
        {
            Vector3 target = Input.mousePosition;
            target.z = -Camera.main.transform.position.z + this.transform.position.z;
            target = Camera.main.ScreenToWorldPoint(target);
            target.z = 0;

            Spells.Laser laser = (Spells.Laser)this.player.GetSpell("Laser");
            laser.SetLocation(target);
            laser.Cast();
        }

        void JumpAction()
        {
            this.fixedQueue.Enqueue(AttemptJump);
        }

        void Start()
        {
            this.biped = GetComponent<Objects.Player>();
            this.player = GetComponent<Classes.Player>();

            // XXX Set this in Unity Input manager.

            this.fixedQueue = new Queue<System.Action>();
            this.controller = new Internal.InputController();

            this.controller.RegisterMouse(1, this.BlinkAction);
            this.controller.RegisterMouse(0, this.LaserAction);

            this.controller.RegisterKey(KeyCode.Space, this.JumpAction);
        }

        void Update()
        {
            this.controller.InvokeInput();
        }

        void AttemptJump()
        {
            if (this.biped.OnGround())
                this.biped.ResetJumps();

            if (this.biped.IsJumpReady())
            {
                this.biped.Jump();
                this.biped.UseJump();
            }
        }

        void InvokeFixedActions()
        {
            // Dequeue every new fixed-update action and invoke it.
            while (this.fixedQueue.Count > 0)
                this.fixedQueue.Dequeue()();
        }

        void FixedUpdate()
        {
            // Update velocity
            this.biped.Run(this.controller.GetRunInput());

            this.InvokeFixedActions();

            this.biped.UpdateVelocity();
        }
    }
}