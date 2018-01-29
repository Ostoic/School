using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Diagnostics;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody), typeof(Transform), typeof(Classes.Player))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Collider feet;

        [SerializeField]
        private Collider head;

        [SerializeField]
        private LayerMask groundLayer;

        [SerializeField]
        private float jumpSpeed = 10.0f;

        [SerializeField]
        private float runSpeed = 10.0f;

        [SerializeField]
        private MenuUI.PlayerUI playerUI;

        private int jumpsAvailable = 2;

        private Rigidbody rb;
        private Vector3 newVelocity;

        public Classes.Player GetClass()
        {
            return this.GetComponent<Classes.Player>(); ;
        }

        private void Start()
        {
            this.rb = GetComponent<Rigidbody>();
            newVelocity = Vector3.zero;
        }

        public void ResetJumps()
        {
            this.jumpsAvailable = 2;
        }

        public void UseJump()
        {
            this.jumpsAvailable--;
        }

        public void SetColor(Color color)
        {
            this.gameObject.GetComponent<Renderer>().material.color = color;
        }

        public bool IsJumpReady()
        {
            return this.jumpsAvailable > 0;
        }

        public void SwapFeet()
        {
            Utility.Swap(ref this.feet, ref this.head);
        }

        public void Jump()
        {
            this.newVelocity.y = 0;
            this.newVelocity += -Gravity.GetGravityDirection() * this.jumpSpeed;
        }

        public void Run(float runInput)
        {
            this.newVelocity = rb.velocity;
            this.newVelocity.x = runInput * this.runSpeed;
        }

        public void UpdateVelocity()
        {
            this.rb.velocity = this.newVelocity;
        }

        public bool OnGround()
        {
            Collider[] collisions = this.GetOverlapColliders();

            if (collisions.Length > 0)
                return true;

            return false;
        }

        public Collider[] GetOverlapColliders()
        {
            return Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);
        }

        void OnDestroy()
        {
            this.playerUI.PlayerDied();
        }
    }
}