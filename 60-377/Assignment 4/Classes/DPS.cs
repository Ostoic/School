using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : Unit
{
    Spells.Attack attack;
    public float minDps;
    public float maxDps;

    public float GetDamage()
    {
        return UnityEngine.Random.Range(minDps, maxDps);
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
