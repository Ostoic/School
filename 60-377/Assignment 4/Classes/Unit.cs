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

    public void RegenerateHealth(int health)
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
        spell.Trigger(target);
    }
}
