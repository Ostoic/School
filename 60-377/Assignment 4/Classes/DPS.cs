using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : Unit
{
    Spells.Attack attack;
    public float minDps;
    public float maxDps;

    protected float lastDamageDealt;

    public float GetLastDamageDealt()
    {
        return lastDamageDealt;
    }

    public float GetDamage()
    {
        lastDamageDealt = UnityEngine.Random.Range(minDps, maxDps);
        return lastDamageDealt;
    }

    public void AttackTarget(Unit target)
    {
        CastSpell(attack, target);
    }

    public override bool CanAttack()
    {
        return true;
    }
}
