using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        GameObject targetObject;
        Vector3 targetPosition;
        Rigidbody body;

        private float speed = 10.0f;

        void Start()
        {
            this.body = this.GetComponent<Rigidbody>();
        }

        public void SetSpeed(float speed)
        {

        }

        public void SetTarget(GameObject target)
        {
            if (target == null) Debug.Log("Invalid projectile target");

            this.targetObject = target;
            this.targetPosition = target.transform.position;
            this.transform.LookAt(this.targetObject.transform);
            this.body.velocity = targetObject.transform.position + Vector3.up;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(this.targetObject.tag))
            {
                targetObject.GetComponent<Classes.Player>().Damage(1);
                Destroy(this.gameObject);
            }
        }

        void Update()
        {
            this.transform.position += transform.forward * (this.speed * Time.deltaTime);
        }
    }
}