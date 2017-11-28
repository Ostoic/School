using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells;

namespace Classes
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth = 0;
        private int health = 0;

        [SerializeField]
        private int maxMana = 0;
        private int mana = 0;

        [SerializeField]
        private float runSpeed = 10.0f;

        private List<Spell> activeSpells;

        // Contains all possible spells the unit is able to cast.
        private Dictionary<string, Spell> spellTable;

        void Awake()
        {
            this.spellTable = new Dictionary<string, Spell>();
            this.RestoreHealth(this.maxHealth);
            this.RestoreMana(this.maxMana);
            this.activeSpells = new List<Spell>();
        }

        /// <summary>
        /// Add a spell to the spell table (dictionary).
        /// </summary>
        /// <param name="spellName">The name of the spell (key).</param>
        /// <param name="spell">The spell object (value).</param>
        protected void AddSpell(string spellName, Spell spell)
        {
            if (this.spellTable == null)
                Debug.LogError("Invalid awake order. Make sure derived classes of Unit are instantiated via Start()");

            if (spell != null)
                this.spellTable.Add(spellName, spell);

            else
                Debug.LogError("Invalid spell object");
        }

        public Spell GetSpell(string spellName)
        {
            if (spellTable == null)
            {
                Debug.LogError("Invalid awake order. Make sure derived classes of Unit are instantiated via Start()");
                return null;
            }

            if (this.spellTable.ContainsKey(spellName))
                return this.spellTable[spellName];
            else
                return null;
        }

        public bool HasSpellActive(Spell spell)
        {
            return this.activeSpells.Contains(spell);
        }

        /// <summary>
        /// Get the unit's run speed.
        /// </summary>
        /// <returns>Float value containing the unit's run speed.</returns>
        public float GetRunSpeed()
        {
            return this.runSpeed;
        }

        /// <summary>
        /// Get the maximum amount of mana the unit can have.
        /// </summary>
        /// <returns>The maximum amount of mana.</returns>
        public int GetMaxMana()
        {
            return this.maxMana;
        }

        /// <summary>
        /// Get the maximum amount of health the unit can have.
        /// </summary>
        /// <returns>The maximum amount of health.</returns>
        public int GetMaxHealth()
        {
            return this.maxHealth;
        }

        /// <summary>
        /// Apply damage to the unit.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>
        public void Damage(int amount)
        {
            if (this.health + amount > 0)
                this.health -= amount;
            else
                this.health = 0;
        }

        /// <summary>
        /// Restore health to the unit.
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        public void RestoreHealth(int amount)
        {
            if (this.health + amount < this.maxHealth)
                this.health += amount;
            else
                this.health = this.maxHealth;
        }

        /// <summary>
        /// Use some of the unit's mana.
        /// </summary>
        /// <param name="amount">The amount of mana to use.</param>
        public void UseMana(int amount)
        {
            if (this.mana + amount > 0)
                this.mana -= amount;
            else
                this.mana = 0;
        }

        /// <summary>
        /// Restore mana to the unit.
        /// </summary>
        /// <param name="amount">The amount of mana to restore</param>
        public void RestoreMana(int amount)
        {
            if (this.mana + health < this.maxMana)
                this.mana += amount;
            else
                this.mana = this.maxMana;
        }

        /// <summary>
        /// Check if the player is alive.
        /// </summary>
        /// <returns>True if the player is alive, false otherwise.</returns>
        public bool IsAlive()
        {
            return this.health > 0;
        }

        /// <summary>
        /// Check if the player is dead.
        /// </summary>
        /// <returns>True if the player is dead, false otherwise.</returns>
        public bool IsDead()
        {
            return !this.IsAlive();
        }

        /// <summary>
        /// Cast a spell on the target.
        /// </summary>
        /// <param name="spellName">The name of the spell to cast</param>
        /// <param name="target">The target unit to cast the spell on</param>
        /// <returns>
        /// True: if the spell cast was successfull, 
        /// False: if the given spell name is not in our spell table, if the spell is on cooldown, 
        /// or if the spell costs too much mana.
        /// </returns>
        public bool CastSpell(string spellName, Unit target)
        {
            // Check if our spell table contains the requested spell.
            if (this.spellTable.ContainsKey(spellName))
            {
                // Retrieve spell object
                Spell spell = this.spellTable[spellName];

                // Unit must have enough mana to cast spell
                if (spell.GetManaCost() <= this.mana)
                {
                    // Cast spell
                    if (spell.Cast(target))
                        return true;
                }
            }
            else
                Debug.LogError("Spell not found in Unit's spell table");

            // Spell cast was unsuccessful
            return false;
        }

        /// <summary>
        /// Cast a spell on this unit.
        /// </summary>
        /// <param name="spellName">The name of the spell to cast</param>
        /// <returns>
        /// True:  if the spell cast was successfull, 
        /// False: if the given spell name is not in our spell table, 
        /// False: if the spell is on cooldown, 
        /// False: if the spell costs too much mana.
        /// </returns>
        public bool CastSpell(string spellName)
        {
            return this.CastSpell(spellName, this);
        }
    }
}