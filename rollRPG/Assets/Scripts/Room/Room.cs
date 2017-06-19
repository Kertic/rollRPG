using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour {


    //If we have 5 or more items, use the scrolling protocol. Otherwise use the 4 button protocol. One item must always a way out design wise.
    
    DynArray<RoomObject> objectsInRoom;


	// Use this for initialization
	void Start () {
        objectsInRoom = new DynArray<RoomObject>();

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PopulateObjectsInRoom(DynArray<RoomObject> objectsToPopulateWith)
    {
        if (objectsInRoom == null)
        {
            objectsInRoom = new DynArray<RoomObject>();
        }

        for (int i = 0; i < objectsToPopulateWith.GetSize(); i++)
        {
            objectsInRoom.AddToArray(objectsToPopulateWith[i]);
        }
        WriteButtons();
    }

    public void WriteButtons()
    {
        GameObject buttonPanelObject = GameObject.FindGameObjectsWithTag("ButtonPanel")[0];
        ButtonManager buttonPanel = buttonPanelObject.GetComponent<ButtonManager>();
        Button[] buttons = buttonPanel.GetButtons();
        //If our DynArray size is 4 or less, 
        if (objectsInRoom.GetSize() <= 4)
        {
            //for each button, 
            for (int i = 0; i < objectsInRoom.GetSize(); i++)
            {
                //update its text to be the room object's button text
                buttons[i].GetComponentInChildren<Text>().text = objectsInRoom[i].ButtonText;
                
                //Update its function to be the buttons Interact function
                buttons[i].onClick.AddListener(objectsInRoom[i].Interact);
            }



        }


        //If its 5 or more, set the first two buttons to be the buttons text and their functions to be interact
        //Set the next two buttons to be previous and next button (which we will write out)


        
        
        

        
    }


    
}
