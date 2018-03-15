using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    [RequireComponent(typeof(Transform))]
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float xSpeed = 45;

        [SerializeField]
        private float ySpeed = 45;

        [SerializeField]
        private float zSpeed = 45;

        void Start()
        {
            Quaternion rotation = Quaternion.identity;
            rotation.x = Random.Range(1, 90);
            rotation.y = Random.Range(1, 90);
            rotation.z = Random.Range(1, 90);
            this.transform.rotation = rotation;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(this.xSpeed * Time.deltaTime, this.ySpeed * Time.deltaTime, this.zSpeed * Time.deltaTime);
        }
    }
}