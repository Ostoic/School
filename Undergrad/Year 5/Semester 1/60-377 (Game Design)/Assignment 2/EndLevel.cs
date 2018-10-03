using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public Material greenMaterial;

    public void Trigger()
    {
        GetComponent<Renderer>().material = greenMaterial;
    }
}
