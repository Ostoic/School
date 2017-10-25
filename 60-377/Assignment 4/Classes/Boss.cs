using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : DPS
{
    Spells.AoE areaDamage;

    public float minAoE = 0;
    public float maxAoE = 0;

    protected float lastAoEDealt;

    public float GetLastAoEDealt()
    {
        return lastAoEDealt;
    }

    public float GetAoEDamage()
    {
        lastDamageDealt = UnityEngine.Random.Range(minAoE, maxAoE);
        return lastDamageDealt;
    }

    public void ApplyAoE(Unit[] targets)
    {
        lastAoEDealt = 0;
        foreach (Unit unit in targets)
        {
            this.CastSpell(areaDamage, unit);
            lastAoEDealt += lastDamageDealt;
        }
    }
}
