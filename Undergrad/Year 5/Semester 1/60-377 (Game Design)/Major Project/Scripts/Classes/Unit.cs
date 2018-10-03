using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells;

namespace Classes
{
    [RequireComponent(typeof(Renderer), typeof(Transform))]
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth = 1;

        private int health ;

        private bool invulnerable = false;

        private List<Buff> activeBuffs;

        // Contains all possible spells the unit is able to cast.
        private Dictionary<string, Spell> spellTable;

        void Awake()
        {
            this.spellTable = new Dictionary<string, Spell>();
            this.RestoreHealth(this.maxHealth);
            this.activeBuffs = new List<Buff>();
        }

        /// <summary>
        /// Add a spell to the spell table (dictionary).
        /// </summary>
        /// <param name="spellName">The name of the spell (key).</param>
        /// <param name="spell">The spell object (value).</param>
        protected void LearnSpell(string spellName, Spell spell)
        {
            if (this.spellTable == null)
                Debug.LogError("Invalid awake order. Make sure derived classes of Unit are instantiated via Start()");

            if (spell != null)
                this.spellTable.Add(spellName, spell);

            else
                Debug.LogError("Invalid spell object");
        }

        public void SetTransparent(bool state)
        {
            float a = (state) ? 0.5f : 1;

            Material material = this.GetComponent<Renderer>().material;

            if (state)
                Utility.ChangeRenderMode(material, Utility.RenderingMode.Transparent);
            else
                Utility.ChangeRenderMode(material, Utility.RenderingMode.Opaque);

            Color newColor = material.color;

            newColor.a = a;
            material.color = newColor;
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
            {
                Debug.LogError("Unit does not know this spell!");
                return null;
            }
        }

        public List<Buff> GetActiveBuffs()
        {
            return this.activeBuffs;
        }

        public Buff GetBuff(string buffName)
        {
            foreach (Buff buff in this.activeBuffs)
            {
                if (buff.ToString().Contains(buffName))
                    return buff;
            }

            return null;
        }

        public bool HasBuff(string buffName)
        {
            return this.GetBuff(buffName) != null;
        }

        public void ReceiveBuff(Buff buff)
        {
            if (!this.activeBuffs.Contains(buff))
            {
                this.activeBuffs.Add(buff);
                buff.StartBuff();
            }
        }

        public bool HasExpired(Buff buff)
        {
            return !this.activeBuffs.Contains(buff) || !buff.IsActive();
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
        /// Get the maximum amount of health the unit can have.
        /// </summary>
        /// <returns>The maximum amount of health.</returns>
        public int GetHealth()
        {
            return this.health;
        }

        /// <summary>
        /// Apply damage to the unit.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>
        public void Damage(int amount)
        {
            if (this.invulnerable) return;

            if (this.health + amount > 0)
                this.health -= amount;
            else
                this.health = 0;
        }

        /// <summary>
        /// Set whether the unit is invulnerable or not.
        /// </summary>
        /// <param name="state">The state of invulnerability.</param>
        public void SetInvulnerable(bool state)
        {
            this.invulnerable = state;
        }

        /// <summary>
        /// Determine if the unit is invulnerable or not.
        /// </summary>
        /// <returns>true if the unit is invulnerable, false otherwise.</returns>
        public bool IsInvulnerable()
        {
            return this.invulnerable;
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

        public bool IsFullHealth()
        {
            return this.health == this.maxHealth;
        }

        /// <summary>
        /// Overheal the unit
        /// </summary>
        /// <param name="amount">The amount of health to heal.</param>
        public void Overheal(int amount)
        {
            this.health += amount;
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

                // Cast spell
                if (spell.Cast(target))
                    return true;
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

        private void UpdateBuffs()
        {
            foreach (Buff buff in this.activeBuffs)
            {
                // If the buff has expired, uncast it, then remove it from
                // the active buffs list.
                if (this.HasExpired(buff))
                {
                    buff.Uncast();
                    this.activeBuffs.Remove(buff);
                    break;
                }
            }
        }

        private void UpdateHealth()
        {
            if (this.IsDead())
            {
                Destroy(this.gameObject);
                // Game over event here
            }
        }

        /// <summary>
        /// Update the unit's buff statuses.
        /// </summary>
        protected virtual void Update()
        {
            this.UpdateBuffs();
            this.UpdateHealth();
        }

        protected virtual void OnDestroy()
        {

        }
    }
}