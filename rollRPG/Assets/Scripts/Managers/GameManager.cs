using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //This is the discription text, we need it for initializing into the GlobalVar.
    [SerializeField]
    UnityEngine.UI.Text DiscriptionTextbox;




	// Use this for initialization
	void Start () {
        InitializeGameVars();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeGameVars()
    {
        GlobalVar.DiscriptionText = this.DiscriptionTextbox;

        
    }
}
