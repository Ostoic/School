using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody))]
    public class Biped : MonoBehaviour
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

        private Rigidbody rb;
        private Vector3 newVelocity;
        private Vector3 gravityDirection = -Vector3.up;

        private void Start()
        {
            this.rb = GetComponent<Rigidbody>();
            newVelocity = Vector3.zero;
        }

        private void SwapFeet()
        {
            Utility.Swap(ref this.feet, ref this.head);
        }

        public void ReverseGravity()
        {
            this.SwapFeet();
            this.gravityDirection *= -1;
        }

        public void Jump()
        {
            this.newVelocity.y = 0;
            this.newVelocity += -gravityDirection * this.jumpSpeed;
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
            Collider[] collisions = Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);

            if (collisions.Length > 0)
                return true;

            return false;
        }

        public Collider[] GetOverlapColliders()
        {
            return Physics.OverlapSphere(feet.transform.position, feet.transform.localScale.y / 2, groundLayer);
        }
    }
}