using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    [DisallowMultipleComponent]
    public class MainCamera : MonoBehaviour
    {
        public float zOffset = -10.0f;
        public float yOffset = 10.0f;

        private Transform target;
        private Vector3 targetPosition;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void Start()
        {
            this.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
            this.targetPosition = new Vector3(this.target.position.x, this.target.position.y + 10, this.target.position.z - 10);
        }

        void UpdateTarget()
        {
            targetPosition.x = this.target.position.x;
            targetPosition.y = this.target.position.y + yOffset;
            targetPosition.z = this.target.position.z + zOffset;
        }

        void LateUpdate()
        {
            this.UpdateTarget();
            transform.position = targetPosition;
            transform.LookAt(this.target);
        }
    }
}