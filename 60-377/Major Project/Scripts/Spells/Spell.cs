﻿using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

using Classes;

namespace Spells
{
    public abstract class Spell
    {
        private enum ChargeType { Infinite = -1, Finite = 0 };

        private int manaCost;
        private float range;

        private float castEpoch = Single.NegativeInfinity;
        private float cooldown;

        private int chargesLeft = -1;

        protected Unit caster;

        public Spell(Unit caster, float range, int manaCost, int charges, float cooldown)
        {
            this.manaCost = manaCost;
            this.cooldown = cooldown;
            this.chargesLeft = charges;
            this.caster = caster;
            this.range = range;
        }

        public Spell(Unit caster, float range, int manaCost, int charges)
            : this(caster, range, manaCost, charges, 1.0f)
        { }

        public Spell(Unit caster, float range, int manaCost)
            : this(caster, range, manaCost, (int)ChargeType.Infinite)
        { }

        public Spell(Unit caster, float range)
            : this(caster, range, 0)
        { }

        public Spell(Unit caster)
            : this(caster, 5.0f)
        { }

        public int GetManaCost()
        {
            return this.manaCost;
        }

        public float GetRange()
        {
            return this.range;
        }

        /// <summary>
        /// Set the number of charges the spell can use.
        /// </summary>
        /// <param name="charges">the number of charges.</param>
        protected void SetCharges(int charges)
        {
            this.chargesLeft = charges;
        }

        /// <summary>
        /// Determine if the spell has any charges left.
        /// </summary>
        /// <returns>true if the spell has charges left, false otherwise.</returns>
        public bool HasCharges()
        {
            return this.chargesLeft > 0;
        }

        /// <summary>
        /// Use a spell's charge and decrease the number of charges it has left.
        /// </summary>
        private void UseCharge()
        {
            // If the spell has a finite number of charges, decrease its number of charges left.
            if (this.chargesLeft != (int)ChargeType.Infinite) 
                this.chargesLeft--;
        }

        /// <summary>
        /// Check if the spell is on cooldown.
        /// </summary>
        /// <returns>True if the spell is on cooldown, false otherwise.</returns>
        public virtual bool IsOnCooldown()
        {
            return (Time.time - this.castEpoch) <= this.cooldown;
        }

        /// <summary>
        /// Set the spell's global cooldown.
        /// </summary>
        /// <param name="cooldown"></param>
        protected void SetCooldown(float cooldown)
        {
            this.cooldown = cooldown;
        }

        /// <summary>
        /// Get how long the spell's cooldown lasts.
        /// </summary>
        /// <returns></returns>
        public float GetCooldown()
        {
            return this.cooldown;
        }

        /// <summary>
        /// Get the caster of this spell.
        /// </summary>
        /// <returns>A unit object referencing the caster.</returns>
        public Unit GetCaster()
        {
            return this.caster;
        }

        /// <summary>
        /// Cast a spell on the given target.
        /// </summary>
        /// <param name="target">The unit to cast the spell on.</param>
        /// <returns>false if the spell is on cooldown, true otherwise.</returns>
        public virtual bool Cast(Unit target)
        {
            if (this.HasCharges() && !this.IsOnCooldown())
            {
                this.UseCharge();
                this.castEpoch = Time.time;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Self-cast a spell
        /// </summary>
        /// <returns>false if the spell is on cooldown, true otherwise.</returns>
        public virtual bool Cast()
        {
            return this.Cast(this.caster);
        }
    }

}
