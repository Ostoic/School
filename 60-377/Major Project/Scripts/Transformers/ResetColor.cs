using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    public class ResetColor : MonoBehaviour
    {
        Renderer r;
        // Use this for initialization
        void Start()
        {
            r = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            r.material.color = Color.white;
        }
    }
}