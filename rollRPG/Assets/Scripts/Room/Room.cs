using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void PopulateObjectsInRoom(RoomObject[] objectsToPopulateWith)
    {
        for (int i = 0; i < objectsToPopulateWith.Length; i++)
        {
            objectsInRoom.AddToArray(objectsToPopulateWith[i]);
        }
    }
}
