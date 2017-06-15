using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature  {

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
}
