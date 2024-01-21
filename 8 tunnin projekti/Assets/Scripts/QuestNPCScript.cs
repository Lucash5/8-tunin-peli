using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class QuestNPCScript : MonoBehaviour
{
    bool dialogueopen;
    public TMP_Text text;
    public TMP_Text text2;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.E) && dialogueopen == false)
        {
            dialogueopen = true;
            text.text = "Hello traveler, would you like to kill 5 slimes for a reward? (E)";
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogueopen == true)
        {
            text.text = "Good luck.";
            text2.text = "0/5";
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
