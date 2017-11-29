using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    [RequireComponent(typeof(Renderer))]
    public class ResetColor : MonoBehaviour
    {
        Renderer r;
        // Use this for initialization
        void Start()
        {
            this.r = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            this.r.material.color = Color.white;
        }
    }
}