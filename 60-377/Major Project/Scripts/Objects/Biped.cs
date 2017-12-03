using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private int jumpsAvailable = 2;

        private Rigidbody rb;
        private Vector3 newVelocity;
        private Vector3 gravityDirection = -Vector3.up;

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

        public bool IsJumpReady()
        {
            return this.jumpsAvailable > 0;
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

        void ColorColliders()
        {
            Collider[] collisions = this.GetOverlapColliders();

            if (collisions.Length > 0)
            {
				foreach (Collider collider in collisions) 
				{
					if (collider.GetComponent<Collider> ().CompareTag ("Exit")  && this.CompareTag("Player"))
						SceneManager.LoadScene ("TitleScreen");

					if (collider.GetComponent<Collider> ().CompareTag ("End")  && this.CompareTag("Player"))
						SceneManager.LoadScene ("MainMenu");

					if (collider.GetComponent<Collider> ().CompareTag ("Level1"))
						SceneManager.LoadScene ("Level1");

					if (collider.GetComponent<Collider> ().CompareTag ("Level2"))
						SceneManager.LoadScene ("Level2");

					if (collider.GetComponent<Collider> ().CompareTag ("Level3"))
						SceneManager.LoadScene ("Level3");

					if (collider.GetComponent<Collider> ().CompareTag ("About"))
						SceneManager.LoadScene ("About");
				}
				
            }
        }

        void LateUpdate()
        {
            ColorColliders();
        }
    }
}