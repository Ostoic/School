using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class DeathZone : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            Classes.Unit unit = collision.gameObject.GetComponent<Classes.Unit>();

            // Kill unit
            if (unit)
                unit.Damage(unit.GetMaxHealth());
        }
    }
}