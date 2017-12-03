using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Projectile : MonoBehaviour
    {
        GameObject targetObject;
        Rigidbody body;

        void Start()
        {
            this.body = this.GetComponent<Rigidbody>();
        }

        public void SetTarget(GameObject target)
        {
            this.targetObject = target;
            this.body.velocity = targetObject.transform.position + new Vector3(0, 1, 0);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == this.targetObject)
            {
                targetObject.GetComponent<Classes.Player>().Damage(1);
                Destroy(this.gameObject);
            }
        }
    }
}