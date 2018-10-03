using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transformers
{
    [RequireComponent(typeof(Renderer))]
    public class SetChildrenMats : MonoBehaviour
    {
        Renderer[] childrenMaterials;
        Renderer parentMaterial;

        // Use this for initialization
        void Start()
        {
            this.childrenMaterials = this.GetComponentsInChildren<Renderer>();
            this.parentMaterial = this.GetComponent<Renderer>();
        }

        // Update is called once per frame
        void LastUpdate()
        {
            foreach (Renderer childMaterial in this.childrenMaterials)
                childMaterial.material.color = this.parentMaterial.material.color;
        }
    }
}