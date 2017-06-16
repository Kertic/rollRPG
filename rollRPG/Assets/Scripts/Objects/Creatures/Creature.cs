using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : RoomObject
{
    

    #region Constructors

    #endregion

    #region Resources
    int currentHP;
    int maxHP;

    int currentEP;
    int maxEP;

    int currentMP;
    int maxMP;
    #endregion

    #region Stats
    int Strength;
    int Dexterity;
    int Consitution;
    int Intelligence;
    int Wisdom;
    int Charisma;
    int Armor;

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
    #endregion

    #region Inventory
    DynArray<Item> itemsInInventory;
    Weapon EquippedWeapon;

    //Armor will go here
    public enum EquipmentSlots
    {
        WEAPON,
        ARMOR,
        NUMOFEQUIPSLOTS
    }
    #endregion


    public virtual void Start()
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



    public override void Interact()
    {
        //A creature does nothing by default
    }

    public int GetModifier(STATS StatToSave)
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

            case STATS.ARMOR:
                return Armor;

            default:
                return 0;

        }
    }

    #region Creation
    public void InsertStats(int inStr, int inDex, int inCon, int inInt, int inWis, int inCha)
    {
        Strength = inStr;
        Dexterity = inDex;
        Consitution = inCon;
        Intelligence = inInt;
        Wisdom = inWis;
        Charisma = inCha;


    }

    #endregion


    #region Combat
    /// <summary>
    /// This will take in a ToHitRoll and tell if it will hit or not.
    /// </summary>
    /// <param name="ToHitRoll">The number the dice rolled</param>
    /// <returns>If the attack hits or not</returns>
    public bool GetAttacked(int ToHitRoll)
    {
        if (ToHitRoll >= Armor)
        {
            return true;
        }
        return false;
    }

    public void TakeDamage(int incomingDamage)
    {
        if (incomingDamage > currentHP)
        {
            currentHP = 0;
        }
        else
        {
            currentHP -= incomingDamage;
        }

       
    }

    public void Attack(Creature creatureToAttack)
    {
        string stringToWriteToDiscription = "";
        int attackRoll = GlobalVar.Roll(20) + GetModifier(STATS.STR);//This last part should change depending on what kind of weapon
        stringToWriteToDiscription += "\nYou rolled a " + attackRoll + " vs an armor class of " + creatureToAttack.GetModifier(STATS.ARMOR);
        bool didWeHit = creatureToAttack.GetAttacked(attackRoll);
        //If it succeeds, call our weapons successful attack script which will return damage dealt, 
        if (didWeHit)
        {
            int damageDealt = EquippedWeapon.DealDamage();
            creatureToAttack.TakeDamage(damageDealt);
            stringToWriteToDiscription += "\n" + this.name + " took " + damageDealt + " damage.";
        }
        else
        {
            stringToWriteToDiscription += "\nYou missed";
        }
        GlobalVar.FormatText(stringToWriteToDiscription, true);
        
    }



    #endregion

    #region Interaction
    public void GetItem(Item ItemToGet)
    {
        itemsInInventory.AddToArray(ItemToGet);
    }
    public void EquipItem(Item ItemToEquip, EquipmentSlots SlotToEquipIn)
    {
        switch (SlotToEquipIn)
        {
            case EquipmentSlots.WEAPON:
                if (ItemToEquip.GetType() == typeof(Weapon))
                {
                    EquippedWeapon = (Weapon)ItemToEquip;
                }
                break;

            case EquipmentSlots.ARMOR:
                break;
            case EquipmentSlots.NUMOFEQUIPSLOTS:
                break;
            default:
                break;
        }
    }

    #endregion
}
