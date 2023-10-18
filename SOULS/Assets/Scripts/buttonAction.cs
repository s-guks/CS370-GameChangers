using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAction : MonoBehaviour
{
    endTurn endTurnScript; // Reference to the script containing the endTurn method
    public GameObject mainCamera;
    public GameObject tableCamera;

    // Assign the endTurn script in the Unity Editor
    public void buttonMethod()
    {
        Debug.Log("Button Clicked!"); //temporary notice
        // Future button animation goes here
        endTurnScript = GameObject.FindGameObjectWithTag("endTurn").GetComponent<endTurn>();

        if (endTurnScript != null)
        {
            Debug.Log(endTurnScript);
            endTurnScript.OnEndTurn();
        }
        else
        {
            Debug.LogError("End Turn Script not found.");
        }
            /* Then call other functions here like:
                -Draw Card */
    }
}
