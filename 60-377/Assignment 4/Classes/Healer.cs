using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Unit
{
    Spells.BigHeal bigHeal;
    Spells.SmallHeal smallHeal;

    void Setup()
    {
        // Set the caster of our spells
        bigHeal.SetCaster(this);
        smallHeal.SetCaster(this);
    }

    public override bool CanAttack()
    {
        return false;
    }
}
