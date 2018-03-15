using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    public class TerminalLife : MonoBehaviour
    {
        [SerializeField]
        private float lifeTime = 5;

        private float elapsed = 0;

        // Update is called once per frame
        void Update()
        {
            this.elapsed += Time.deltaTime;
            if (this.elapsed >= this.lifeTime)
                Destroy(this.gameObject);
        }
    }
}