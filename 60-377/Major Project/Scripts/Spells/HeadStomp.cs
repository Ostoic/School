using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : Spell
{
    public HeadStomp(Unit caster) : base(caster)
    { }

    /// <summary>
    /// HeadStomp spell will kill the target unit.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public override bool Cast(Unit target)
    {
        // Ensure all conditions are satisfied to cast the spell.
        if (base.Cast(target))
        {
            target.Damage(1);
            return true;
        }

        return false;
    }
}
