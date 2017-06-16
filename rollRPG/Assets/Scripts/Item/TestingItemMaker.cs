using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingItemMaker : MonoBehaviour
{
    [SerializeField]
    Player playerToGiveItemsTo;

    Room RoomWeMake;
    // Use this for initialization
    void Start()
    {
        Weapon shortsword = new Weapon(6, 1);

        playerToGiveItemsTo.EquipItem(shortsword, Creature.EquipmentSlots.MAINHAND);//Equip the player with his sword


        //Creating the goblin
        Enemy testEnemy = new Enemy();
        testEnemy.EquipItem(shortsword, Creature.EquipmentSlots.MAINHAND);

        //Creating the room
        RoomObject[] testingObject = new RoomObject[1];
        testingObject[0] = testEnemy;
        RoomWeMake.PopulateObjectsInRoom(testingObject);


        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
