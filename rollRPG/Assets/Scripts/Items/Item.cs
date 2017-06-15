using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;

/// <summary>
/// This is an item that can be interacted with, these are to be placed in rooms. These are things like enemies, doors, objects, etc. 
/// </summary>


public abstract class Item : MonoBehaviour {

    public abstract void Interact();
     
	
}
