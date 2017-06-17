using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVar
{

    public static Player mainPlayer;//The protagonist
    public static Room currentRoom;
    public static UnityEngine.UI.Text DiscriptionText;
    public static GameObject managementObject;

    


    /// <summary>
    /// This will roll a dice with (numOfSides) sides, and return the result
    /// </summary>
    /// <param name="numOfSides">The number of sides the dice has</param>
    /// <returns></returns>
    public static int Roll(int numOfSides)
    {
        return (int)((Random.value * 100) % numOfSides) + 1;
    }


    #region Discription box interaction

    /// <summary>
    /// This function will take the text inside of DiscriptionText and format it to fit within the text box
    /// </summary>
    public static void FormatText()
    {
        //Font size = number of characters / ratio, where ratio changes on a exponential decay rate
        int NumOfChars = DiscriptionText.text.Length;
        
        if (NumOfChars < 31)
        {
            DiscriptionText.fontSize = 75;
        }
        if (NumOfChars >= 31 && NumOfChars < 60)
        {
            DiscriptionText.fontSize = 50;
        }
        if (NumOfChars >= 60 && NumOfChars < 120)
        {
            DiscriptionText.fontSize = 40;
        }
        if (NumOfChars >= 120 && NumOfChars < 351)
        {
            DiscriptionText.fontSize = 35;
        }
        if (NumOfChars >= 351)
        {
            DiscriptionText.fontSize = 30;
        }
        managementObject.GetComponent<MonoBehaviour>().StopCoroutine(TypewriterText());
        managementObject.GetComponent<MonoBehaviour>().StartCoroutine(TypewriterText());
    }

    /// <summary>
    /// This will take the text TextToAdd and add it to the current text, and then format it to fit the text box
    /// </summary>
    /// <param name="TextToAdd">Text to add to current text</param>
    /// <param name="overrideCurrentText"> Do we want to erase the current text thats already there?</param>
    public static void FormatText(string TextToAdd ,bool overrideCurrentText)
    {
        if (overrideCurrentText)
            DiscriptionText.text = "";
        

        
        DiscriptionText.text += TextToAdd;
        FormatText();
    }
    /// <summary>
    /// This will take the text inside of DiscriptionText and write it out one character at a time. This is normally only called during FormatText(), after the text size has been made.
    /// </summary>
    static IEnumerator TypewriterText()
    {

        #region Disable buttons
        GameObject buttonPanelObject = GameObject.FindGameObjectsWithTag("ButtonPanel")[0];
        ButtonManager buttonPanel = buttonPanelObject.GetComponent<ButtonManager>();
        UnityEngine.UI.Button[] buttons = buttonPanel.GetButtons();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
        #endregion


        float TimeToWrite = 0.8f;
        string TextToType = DiscriptionText.text;
        DiscriptionText.text = "";

        for (int i = 0; i < TextToType.Length; i++)
        {
            
            DiscriptionText.text += TextToType[i];
            yield return new WaitForSeconds(TimeToWrite / TextToType.Length);
        }



        #region Enable buttons
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }
        #endregion

    }
    #endregion



}
