using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;
using Spells.Internal;

namespace Spells
{
    public abstract class Buff : Spell
    {
        private BuffDuration duration;
        private float startTime = 0;

        private Unit target;

        public Buff(Unit caster, float duration) 
            : base(caster)
        {
            this.target = this.caster;
            this.duration = duration;
        }

        public Buff(Unit caster)
            : base(caster)
        {
            this.target = this.caster;
            this.duration = Internal.BuffDuration.Infinity;
        }

        public void SetDuration(float duration)
        {
            this.duration = duration;
        }

        public Unit GetTarget()
        {
            return this.target;
        }

        public float GetElapsed()
        {
            return Time.time - this.startTime;
        }

        public float GetDuration()
        {
            if (this.duration == BuffDuration.Infinity)
                return System.Single.PositiveInfinity;
            else
                return this.duration;
        }

        public bool IsActive()
        {
            return this.GetElapsed() <= this.GetDuration() && this.HasCharges();
        }

        public abstract void Uncast();

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                this.target = target;
                this.startTime = Time.time;
                return true;
            }

            return false;
        }
    }
}