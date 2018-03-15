using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody), typeof(Transform))]
    public class Laser : MonoBehaviour
    {
        Vector3 target;

        private float speed = 10.0f;

        void Start()
        {
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetTarget(Vector3 target)
        {
            if (target == null) Debug.Log("Invalid projectile target");

            this.target = target;
            this.transform.LookAt(this.target);
        }

        void Update()
        {
            this.transform.position += transform.forward * (this.speed * Time.deltaTime);
        }
    }
}