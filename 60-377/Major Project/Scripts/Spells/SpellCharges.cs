using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class SpellCharges
    {
        public static readonly int Infinity = -1;
        private int chargesLeft = -1;

        public SpellCharges(int charges)
        {
            this.chargesLeft = charges;
        }

        public bool IsFinite()
        {
            return this.chargesLeft != SpellCharges.Infinity;
        }

        public override string ToString()
        {
            if (this.chargesLeft == -1)
                return "∞";
            else
                return this.chargesLeft.ToString();
        }

        public static implicit operator SpellCharges(int num)
        {
            return new SpellCharges(num);
        }

        public static implicit operator int(SpellCharges instance)
        {
            return instance.chargesLeft;
        }
    }
}