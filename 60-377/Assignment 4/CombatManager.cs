using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    int totalDamageDoneToBoss = 0;
    int totalDamageDoneToParty = 0;

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

        boss = GameObject.Find("Boss").GetComponent<Boss>();

        Error.DebugAssert(ref warrior, "Unable to find instance of warrior character");
        Error.DebugAssert(ref rogue, "Unable to find instance of rogue character");
        Error.DebugAssert(ref mage, "Unable to find instance of mage character");
        Error.DebugAssert(ref druid, "Unable to find instance of druid character");
        Error.DebugAssert(ref priest, "Unable to find instance of priest character");
        Error.DebugAssert(ref boss, "Unable to find instance of boss character");
    }

    void BasicCombat()
    {
        // DPS stage
        // Boss applies AoE damage within 5-20 to the dps and healer players
        boss.ApplyAoE(nonTanks);
        totalDamageDoneToParty += boss.GetLastAoEDealt(); // log aoe damage dealt to players

        // Boss deals regular damage within 45-55 to the tank
        boss.AttackTarget(warrior);
        totalDamageDoneToParty += boss.GetLastDamageDealt(); // log damage dealt to tank

        foreach (Unit player in players)
        {
            // DPS players and tank all damage boss
            if (player.CanAttack())
            {
                DPS dps = player.GetComponent<DPS>();
                dps.AttackTarget(boss);
                totalDamageDoneToBoss += dps.GetLastDamageDealt(); // log damage dealt to boss
            }
        }

        // Healing stage
        {
            Healer priestHealer = priest.GetComponent<Healer>();

            // Cast BigHeal on the tank
            priestHealer.BigHeal(warrior);

            float rand = Random.value;
            if (rand <= 0.2) // priest has 20% chance of casting small heal on itself
            {
                priestHealer.SmallHeal(priest);
            }
            else if (rand <= 0.3) // priest has 10% chance of casting small heal on others
            {
                // Randomly select non-tank player
                int index = Random.Range(0, 4); 

                // Then cast small heal on them
                priestHealer.SmallHeal(nonTanks[index]); 
            }
        }

        // The priest regenerates 2 mana per second
        priest.RegenerateMana(2);
}

    // No extra economoical feedback
    void Level1Combat()
    {
        BasicCombat();
    }

    Spell RandomlyChooseHeal()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            return Spells.SpellTable.BigHeal;
        else
            return Spells.SpellTable.SmallHeal;
    }

    // Negative feedback
    void Level2Combat()
    {
        BasicCombat();

        // If the tank's health is below 1500, the healer should will free cast an extra heal.
        // The heal is either BigHeal or SmallHeal, chosen randomly.
        if (warrior.health <= 1500)
        {
            Healer priestHealer = priest.GetComponent<Healer>();
            priestHealer.FreeCastSpell(RandomlyChooseHeal(), warrior);
        }
    }

    // Positive feedback
    void Level3Combat()
    {
        BasicCombat();

        // Apply 1/100th of the total damage done to the party, to the tank each frame.
        int extraDamage = (int)(totalDamageDoneToParty / 100); 
        warrior.ReceiveDamage(extraDamage);
    }

    bool PlayersAreAlive()
    {
        foreach (Unit player in players)
            if (player.IsDead())
                return false;

        return true;
    }

    // A single frame of combat
    void Update()
    {
        if (PlayersAreAlive())
            Level2Combat();

        else
        {
            // stop scene
            // display back button prompt
        }

        Debug.Log("Damage to Boss: " + totalDamageDoneToBoss);
        Debug.Log("Damage to Party: " + totalDamageDoneToParty);
    }
}
