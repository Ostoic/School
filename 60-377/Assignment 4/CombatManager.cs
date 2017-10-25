using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private Unit warrior, rogue, mage, druid, priest;
    private Boss boss;

    private Unit[] players;

    // Use this for initialization
    void Start ()
    {
        warrior = GameObject.Find("Warrior").GetComponent<Unit>();
        rogue = GameObject.Find("Rogue").GetComponent<Unit>();
        mage = GameObject.Find("Mage").GetComponent<Unit>();
        druid = GameObject.Find("Druid").GetComponent<Unit>();
        priest = GameObject.Find("Priest").GetComponent<Unit>();

        players = new Unit[]{ warrior, rogue, mage, druid, priest};

        Error.DebugAssert(ref warrior, "Unable to find instance of warrior character");
        Error.DebugAssert(ref rogue, "Unable to find instance of rogue character");
        Error.DebugAssert(ref mage, "Unable to find instance of mage character");
        Error.DebugAssert(ref druid, "Unable to find instance of druid character");
        Error.DebugAssert(ref priest, "Unable to find instance of priest character");
    }
	
	void Update()
    {
		foreach (Unit player in players)
        {
            // DPS players damage boss
            if (player.CanAttack())
                player.GetComponent<DPS>().AttackTarget(boss);

            // Boss damages every player
            boss.AttackTarget(player);
        }
	}
}
