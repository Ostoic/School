using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    public class Rotator : MonoBehaviour
    {

        [SerializeField]
        private float xSpeed = 45;

        [SerializeField]
        private float ySpeed = 45;

        [SerializeField]
        private float zSpeed = 45;

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        }
    }
}