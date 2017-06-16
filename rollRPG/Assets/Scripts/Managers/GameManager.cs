using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    [SerializeField]
    UnityEngine.UI.Text DiscriptionTextbox;//This is the discription text, we need it for initializing into the GlobalVar.

    [SerializeField]
    GameObject theGameManagerObject;




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

        GlobalVar.managementObject = theGameManagerObject;
    }
}
