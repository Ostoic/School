using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int health;
    public int mana;

    public void ReceiveDamage(int damage)
    {
        this.health -= damage;
    }

    public void RegenerateHealth(int health)
    {
        this.health += health;
    }

    public void RegenerateMana(int mana)
    {
        this.mana += mana;
    }

    public void UseMana(int mana)
    {
        this.mana -= mana;
    }

    public bool IsAlive()
    {
        return this.health > 0;
    }

    public bool IsDead()
    {
        return !this.IsAlive();
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

    public void FreeCastSpell(Spell spell, Unit target)
    {
        // Add to our current mana the spell cost
        this.RegenerateMana(spell.ManaCost);
        this.CastSpell(spell, target);
    }
}
