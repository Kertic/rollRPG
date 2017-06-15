using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    DynArray<Item> itemsInRoom;
	// Use this for initialization
	void Start () {
        itemsInRoom = new DynArray<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
