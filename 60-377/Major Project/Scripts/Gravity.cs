using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    static private Vector3 direction = -Vector3.up;

    static public Vector3 GetGravityDirection()
    {
        return Gravity.direction;
    }

    static public void Reverse()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Objects.Player>().SwapFeet();
        Gravity.direction *= -1;
        Physics.gravity *= -1;
    }
}
