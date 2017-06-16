using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Creature {
    [SerializeField]
    Creature enemy;
    public override void Start()
    {
        GlobalVar.mainPlayer = this;
        GlobalVar.mainPlayer.WriteButtons();
        InsertStats(10, 10, 10, 10, 10, 10);
        GameObject weaponObject = (GameObject)Instantiate(Resources.Load("Prefabs/BlankWeapon"));
        Weapon weaponScript = weaponObject.GetComponent<Weapon>();
        weaponScript.InitializeWeapon(6, 2);
        EquipItem(weaponScript, EquipmentSlots.WEAPON);


        base.Start();
    }






    #region TESTING
    //STICKYNOTE: Remove these two functions
    public void WriteButtons()
    {
        GameObject buttonPanelObject =  GameObject.FindGameObjectsWithTag("ButtonPanel")[0];
        ButtonManager buttonPanel = buttonPanelObject.GetComponent<ButtonManager>();
        Button[] buttons = buttonPanel.GetButtons();

        Button myButton = buttons[0];
        myButton.GetComponentInChildren<Text>().text = "Attack the Goblins!";
        myButton.onClick.AddListener(this.Attack);
    }

    /// <summary>
    /// This is for the first run, the MVP run.
    /// </summary>
    /// <param name="creatureToAttack"></param>
    public void Attack()
    {

        this.Attack(enemy);




       // int toHit = GlobalVar.Roll(20) + this.GetModifier(STATS.STR);
       // Debug.Log("You rolled a " + toHit + " vs their armor which is: " + enemy.GetModifier(STATS.ARMOR));
       // if (toHit >= enemy.GetModifier(STATS.ARMOR))
       // {
       //     enemy.TakeDamage(GlobalVar.Roll(6));
       // }
       // else
       // {
       //     Debug.Log("You missed :(");
       // }
    }

    #endregion
}
