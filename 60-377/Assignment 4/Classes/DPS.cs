using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : Unit
{
    public int minDps;
    public int maxDps;

    protected int lastDamageDealt;

    public int GetLastDamageDealt()
    {
        return lastDamageDealt;
    }

    public int GetDamage()
    {
        lastDamageDealt = UnityEngine.Random.Range(minDps, maxDps);
        return lastDamageDealt;
    }

    public void AttackTarget(Unit target)
    {
        CastSpell(Spells.SpellTable.Attack, target);
    }

    public override bool CanAttack()
    {
        return true;
    }
}
