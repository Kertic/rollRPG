using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testingscript : MonoBehaviour
{
    DynArray<int> testingArray;
    // Use this for initialization
    void Start()
    {
        testingArray = new DynArray<int>();
       


    }

    private void PrintArray()
    {
        int[] temp = testingArray.GetCopyOfArray();

        for (int i = 0; i < temp.Length; i++)
        {
            Debug.Log("The " + i + "th number is: " + temp[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
