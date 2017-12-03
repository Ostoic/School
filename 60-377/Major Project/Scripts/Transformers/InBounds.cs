using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    [RequireComponent(typeof(Transform))]
    public class InBounds : MonoBehaviour
    {
        [SerializeField]
        private Rect levelBounds;

        private bool WithinBounds()
        {
            Vector3 position = this.transform.position;

            if (position.y >= levelBounds.yMin &&
                position.y <= this.levelBounds.yMax &&
                position.x >= this.levelBounds.xMin &&
                position.x <= this.levelBounds.xMax)
                return true;

            return false;
        }

        void Update()
        {
            if (!this.WithinBounds())
                Destroy(this.gameObject);
        }
    }
}