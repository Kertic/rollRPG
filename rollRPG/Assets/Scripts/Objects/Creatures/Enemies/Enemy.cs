using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : Creature
{
    [SerializeField]
    Player player;
    

    public override void Start()
    {
        player = GlobalVar.mainPlayer;
        //STICKYNOTE: Remove this stuff later on
        InsertStats(10, 10, 10, 10, 10, 10);
        GameObject weaponObject = (GameObject)Instantiate(Resources.Load("Prefabs/BlankWeapon"));
        Weapon weaponScript = weaponObject.GetComponent<Weapon>();
        weaponScript.InitializeWeapon(4, 1);
        EquipItem(weaponScript, EquipmentSlots.WEAPON);

        
        


        base.Start();
    }

    #region TESTING
    //STICKYNOTE: Remove this function when done.
    public override void Interact()
    {
        player.SetTargetedEnemy(this);
        player.Attack();
        base.Interact();
    }



    #endregion

}
