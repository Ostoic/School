using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    // Assert value of type is not null, and otherwise output a message to the debug log.
    public static void DebugAssert<T>(ref T t, string message)
    {
        if (t == null)
            Debug.Log(message);
    }
}
