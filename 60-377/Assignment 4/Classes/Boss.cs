using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : DPS
{
    Spells.AoE areaDamage;

    public float minAoE = 0;
    public float maxAoE = 0;

    public float GetAoEDamage()
    {
        return UnityEngine.Random.Range(minAoE, maxAoE);
    }

    public void ApplyAoE(Unit[] targets)
    {
        foreach (Unit unit in targets)
            this.CastSpell(areaDamage, unit);
    }
}
