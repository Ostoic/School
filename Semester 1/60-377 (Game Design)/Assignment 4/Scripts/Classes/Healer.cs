using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Unit
{
    public void BigHeal(Unit target)
    {
        CastSpell(Spells.SpellTable.BigHeal, target);
    }
    public void SmallHeal(Unit target)
    {
        CastSpell(Spells.SpellTable.SmallHeal, target);
    }

    public override bool CanAttack()
    {
        return false;
    }
}
