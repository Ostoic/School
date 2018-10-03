using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : DPS
{
    public int minAoE = 0;
    public int maxAoE = 0;

    protected int lastAoEDealt;

    public int GetLastAoEDealt()
    {
        return lastAoEDealt;
    }

    public int GetAoEDamage()
    {
        lastDamageDealt = UnityEngine.Random.Range(minAoE, maxAoE);
        return lastDamageDealt;
    }

    public void ApplyAoE(Unit[] targets)
    {
        lastAoEDealt = 0;
        foreach (Unit unit in targets)
        {
            this.CastSpell(Spells.SpellTable.AoE, unit);
            lastAoEDealt += lastDamageDealt;
        }
    }
}
