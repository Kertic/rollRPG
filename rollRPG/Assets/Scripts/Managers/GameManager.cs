using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    [SerializeField]
    UnityEngine.UI.Text DiscriptionTextbox;//This is the discription text, we need it for initializing into the GlobalVar.

    [SerializeField]
    GameObject theGameManagerObject;

    [SerializeField]
    Room startingRoom;


	// Use this for initialization
	void Start () {
        InitializeGameVars();

        //STICKYNOTE: This is for testing out the room functionality, delete this and make a better version after
        

        DynArray<RoomObject> objectsToExport = new DynArray<RoomObject>();
        GameObject goobyObject = (GameObject)Instantiate(Resources.Load("Prefabs/Gooby"));
        Enemy goobyEnemy = goobyObject.GetComponent<Enemy>();
        objectsToExport.AddToArray(goobyEnemy);
        
        GlobalVar.currentRoom.PopulateObjectsInRoom(objectsToExport);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeGameVars()
    {
        GlobalVar.DiscriptionText = this.DiscriptionTextbox;

        GlobalVar.managementObject = theGameManagerObject;

        GlobalVar.currentRoom = startingRoom;
    }
}
