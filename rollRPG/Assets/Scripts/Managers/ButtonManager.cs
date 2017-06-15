using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    [SerializeField]
    Button menuButton1;
    [SerializeField]
    Button menuButton2;
    [SerializeField]
    Button menuButton3;
    [SerializeField]
    Button menuButton4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Returns an array of the 4 buttons in order of 1,2,3,4
    /// </summary>
    /// <returns></returns>
    public Button[] GetButtons()
    {
        Button[] temp = { menuButton1, menuButton2, menuButton3, menuButton4 };
        return temp;
    }
}
