using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float health;
    public float mana;

    public void ReceiveDamage(float damage)
    {
        this.health -= damage;
    }

    public void RegenerateHealth(float health)
    {
        this.health += health;
    }

    public void RegenerateMana(float mana)
    {
        this.mana += mana;
    }

    public void UseMana(float mana)
    {
        this.mana -= mana;
    }

    public abstract bool CanAttack();

    public void CastSpell(Spell spell, Unit target)
    {
        // Unit must have enough mana to cast spell
        if (spell.ManaCost <= this.mana)
        {
            spell.SetCaster(this);
            spell.Trigger(target);
        }
    }
}
