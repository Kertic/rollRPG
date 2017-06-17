using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Creature
{
    [SerializeField]
    Creature targetedEnemy;
    public override void Start()
    {
        GlobalVar.mainPlayer = this;
     
        InsertStats(10, 10, 10, 10, 10, 10);
        GameObject weaponObject = (GameObject)Instantiate(Resources.Load("Prefabs/BlankWeapon"));
        Weapon weaponScript = weaponObject.GetComponent<Weapon>();
        weaponScript.InitializeWeapon(6, 2);
        EquipItem(weaponScript, EquipmentSlots.WEAPON);


        base.Start();
    }






    
    /// <summary>
    /// This attacks the currently target enemy. We can't just give an enemy, because we need buttons to call this function
    /// </summary>
    public void Attack()
    {

        Attack(targetedEnemy);
    }




    public void SetTargetedEnemy(Enemy enemyToTarget)
    {
        if (enemyToTarget)
        {
            targetedEnemy = enemyToTarget;
        }
        else
        {
            Debug.Log("You tried to target a null enemy");
        }

    }
}
