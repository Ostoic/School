using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    [DisallowMultipleComponent]
    public class MenuCamera : MonoBehaviour
    {
        public float zOffset = -10.0f;
        public float yOffset = 4;

        private Transform target;
        private Vector3 targetPosition;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void Start()
        {
            this.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
            this.targetPosition = new Vector3(this.target.position.x, this.target.position.y + yOffset, this.target.position.z + zOffset);
        }

        void UpdateTarget()
        {
            this.targetPosition.x = this.target.position.x;
            this.targetPosition.y = this.target.position.y + yOffset;
            this.targetPosition.z = this.target.position.z + zOffset;
        }

        void LateUpdate()
        {
            this.UpdateTarget();
            this.transform.position = targetPosition;
            this.transform.LookAt(this.target);
        }
    }
}