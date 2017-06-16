using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{

    //The amount of sides the damage die has, like a d8 would be 8 or a d4 would be 4. 
    [SerializeField]
    int SidesOfDamageDie;
    //The amount of times to roll the damage dice, so 2d6 would be 2 and 1d4 would be 1
    [SerializeField]
    int AmountOfDamageDice;

    

    public void InitializeWeapon(int inSidesOfDamageDice, int inAmountOfDamageDice)
    {
        SidesOfDamageDie = inSidesOfDamageDice;
        AmountOfDamageDice = inAmountOfDamageDice;
    }

    public virtual int DealDamage()
    {
        int tempDamage = 0;

        for (int i = 0; i < AmountOfDamageDice; i++)
        {
            tempDamage += GlobalVar.Roll(SidesOfDamageDie);
        }
        return tempDamage;
    }
}
