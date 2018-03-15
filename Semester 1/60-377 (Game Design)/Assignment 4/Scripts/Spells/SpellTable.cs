using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class SpellTable : MonoBehaviour
    {
        public static Spells.AoE AoE = new Spells.AoE();
        public static Spells.Attack Attack = new Spells.Attack();
        public static Spells.BigHeal BigHeal = new Spells.BigHeal();
        public static Spells.SmallHeal SmallHeal = new Spells.SmallHeal();

    }
}