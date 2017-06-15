using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Item
{

    #region Resources
    float currentHP;
    float maxHP;

    float currentEG;
    float maxEG;

    float currentMP;
    float maxMP;
    #endregion

    #region Stats
    int Strength;
    int Dexterity;
    int Consitution;
    int Intelligence;
    int Wisdom;
    int Charisma;
    int Armor;
    #endregion
    private void Start()
    {
        if (Strength > Dexterity)
        {
            Armor = 10 + ((Consitution / 2) - 5 + (Strength / 2) - 5);
        }
        else
        {
            Armor = 10 + ((Consitution / 2) - 5 + (Dexterity / 2) - 5);
        }
    }

    public enum STATS
    {
        STR,
        DEX,
        CON,
        INT,
        WIS,
        CHA,
        ARMOR,
        NUMOFSTATS

    }

    public override void Interact()
    {
        //A creature does nothing by default
    }

    public int SaveThrow(STATS StatToSave)
    {
        switch (StatToSave)
        {
            case STATS.STR:
                return (Strength / 2) - 5;

            case STATS.DEX:
                return (Dexterity / 2) - 5;

            case STATS.CON:
                return (Consitution / 2) - 5;

            case STATS.INT:
                return (Intelligence / 2) - 5;

            case STATS.WIS:
                return (Wisdom / 2) - 5;

            case STATS.CHA:
                return (Charisma / 2) - 5;


            default:
                return 0;

        }
    }
}
