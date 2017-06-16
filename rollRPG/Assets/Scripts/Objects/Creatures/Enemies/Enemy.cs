using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : Creature
{
    [SerializeField]
    Creature player;
    

    public override void Start()
    {
        WriteButtons();
        InsertStats(10, 10, 10, 10, 10, 10);
        GameObject weaponObject = (GameObject)Instantiate(Resources.Load("Prefabs/BlankWeapon"));
        Weapon weaponScript = weaponObject.GetComponent<Weapon>();
        weaponScript.InitializeWeapon(4, 1);
        EquipItem(weaponScript, EquipmentSlots.WEAPON);



        base.Start();
    }

    #region TESTING
    //STICKYNOTE: Remove these two functions


    public void WriteButtons()
    {
        GameObject buttonPanelObject = GameObject.FindGameObjectsWithTag("ButtonPanel")[0];
        ButtonManager buttonPanel = buttonPanelObject.GetComponent<ButtonManager>();
        Button[] buttons = buttonPanel.GetButtons();

        Button myButton = buttons[1];
        myButton.GetComponentInChildren<Text>().text = "Attack the Player!";
        myButton.onClick.AddListener(this.Attack);
    }
    /// <summary>
    /// This is for the first run, the MVP run.
    /// </summary>
    /// <param name="creatureToAttack"></param>
    public void Attack()
    {
        this.Attack(player);

       // int toHit = GlobalVar.Roll(20) + this.GetModifier(STATS.STR);
       // Debug.Log("You rolled a " + toHit + " vs their armor which is: " + player.GetModifier(STATS.ARMOR));
       // if (toHit >= player.GetModifier(STATS.ARMOR))
       // {
       //     player.TakeDamage(GlobalVar.Roll(6));
       // }
       // else
       // {
       //     Debug.Log("You missed :(");
       // }
    }

    #endregion

}
