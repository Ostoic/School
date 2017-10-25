using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Unit
{
    private Spells.BigHeal bigHeal;
    private Spells.SmallHeal smallHeal;

    public void BigHeal(Unit target)
    {
        CastSpell(bigHeal, target);
    }
    public void SmallHeal(Unit target)
    {
        CastSpell(smallHeal, target);
    }

    public override bool CanAttack()
    {
        return false;
    }
}
