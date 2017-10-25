using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public int ManaCost { get; set; }

    protected Unit caster;
    public void SetCaster(Unit caster)
    {
        this.caster = caster;
    }
    
    public abstract void Trigger(Unit unit);
}
