using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    namespace Internal
    {
        public class BuffDuration
        {
            public static readonly float Infinity = -1;
            private float duration = BuffDuration.Infinity;

            public BuffDuration(float duration)
            {
                this.duration = duration;
            }

            public bool IsFinite()
            {
                return this.duration != SpellCharges.Infinity;
            }

            public override string ToString()
            {
                if (this.duration == BuffDuration.Infinity)
                    return "∞";
                else
                    return this.duration.ToString() + " seconds";
            }

            public static implicit operator BuffDuration(float duration)
            {
                return new BuffDuration(duration);
            }

            public static implicit operator float(BuffDuration instance)
            {
                if (instance != null)
                    return instance.duration;
                else
                    return BuffDuration.Infinity;
            }
        }
    }
}
