using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Creature {

    private void Start()
    {
        GlobalVar.mainPlayer = this;
        GlobalVar.mainPlayer.WriteButtons();
    }







    public void WriteButtons()
    {
        GameObject buttonPanelObject =  GameObject.FindGameObjectsWithTag("ButtonPanel")[0];
        ButtonManager buttonPanel = buttonPanelObject.GetComponent<ButtonManager>();
        Button[] buttons = buttonPanel.GetButtons();

        buttons[0].GetComponentInChildren<Text>().text = "I'm B1";
        buttons[1].GetComponentInChildren<Text>().text = "I'm B2";
        buttons[2].GetComponentInChildren<Text>().text = "I'm B3";
        buttons[3].GetComponentInChildren<Text>().text = "I'm B4";
    }
}
