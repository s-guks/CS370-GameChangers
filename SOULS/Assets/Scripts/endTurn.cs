using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endTurn : MonoBehaviour
{
    turnManager turnManagerScript;

    // This method is automatically called when the button is clicked
    public void OnEndTurn()
    {
        // End turn button disabled
        Button endTurnButton = GetComponent<Button>();
        turnManagerScript = GameObject.FindGameObjectWithTag("turnManager").GetComponent<turnManager>();
        if (turnManagerScript != null)
        {
            
            turnManagerScript.playerAttackPhase();
        }
        //endTurnButton.interactable = false;
        Debug.Log("End Turn Button Clicked!"); // Add a console output here
    }
}