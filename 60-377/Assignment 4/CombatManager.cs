using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    float chanceToSmallHeal = 0.2f;

    float totalDamageDoneToBoss = 0.0f;
    float totalDamageDoneToParty = 0.0f;

    private Unit warrior, rogue, mage, druid, priest;
    private Boss boss;

    private Unit[] players;
    private Unit[] nonTanks;

    // Use this for initialization
    void Start ()
    {
        warrior = GameObject.Find("Warrior").GetComponent<Unit>();
        rogue = GameObject.Find("Rogue").GetComponent<Unit>();
        mage = GameObject.Find("Mage").GetComponent<Unit>();
        druid = GameObject.Find("Druid").GetComponent<Unit>();
        priest = GameObject.Find("Priest").GetComponent<Unit>();

        players = new Unit[]{ warrior, rogue, mage, druid, priest};
        nonTanks = new Unit[] { rogue, mage, druid, priest };

        Error.DebugAssert(ref warrior, "Unable to find instance of warrior character");
        Error.DebugAssert(ref rogue, "Unable to find instance of rogue character");
        Error.DebugAssert(ref mage, "Unable to find instance of mage character");
        Error.DebugAssert(ref druid, "Unable to find instance of druid character");
        Error.DebugAssert(ref priest, "Unable to find instance of priest character");
    }
	
    // A single frame of combat
	void Update()
    {
        // DPS stage
        // Boss applies AoE damage within 5-20 to the dps and healer players
        boss.ApplyAoE(nonTanks);

        // Boss deals regular damage within 45-55 to the tank
        boss.AttackTarget(warrior);

        foreach (Unit player in players)
        {
            // DPS players and tank all damage boss
            if (player.CanAttack())
                player.GetComponent<DPS>().AttackTarget(boss);
        }

        // Healing stage
        // Cast BigHeal on tank
        priest.GetComponent<Healer>().BigHeal(warrior);

        if (Random.value <= chanceToSmallHeal)

        // The priest regenerates 2 mana per second
        priest.RegenerateMana(2.0f);
	}
}
