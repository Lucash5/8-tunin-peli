using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class QuestNPCScript : MonoBehaviour
{
    bool questaccepted;
    bool dialogueopen;
    public TMP_Text text;
    public TMP_Text text2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (questaccepted == true && text2.text == "5/5" && Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E) && dialogueopen == false && questaccepted == false)
        {
            dialogueopen = true;
            text.text = "Hello traveler, would you like to kill 5 slimes for a reward? (E)";
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogueopen == true && questaccepted == false)
        {
            text.text = "Good luck.";
            text2.text = "0/5";
            questaccepted = true;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.text = "(E)";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueopen = false;
        text.text = "";
    }
    
}
