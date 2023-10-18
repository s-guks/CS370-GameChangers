using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAction : MonoBehaviour
{
    public endTurn endTurnScript; // Reference to the script containing the endTurn method

    // Assign the endTurn script in the Unity Editor
    public void SetEndTurnScript(endTurn script)
    {
        endTurnScript = script;
    }

    public void buttonMethod() {
        Debug.Log("Button Clicked!"); //temporary notice
        // Future button animation goes here
        // Call the End Turn method if the reference to the endTurn script is available
        if (endTurnScript != null)
        {
            endTurnScript.OnEndTurn();
            Debug.Log("End Turn!");
        }
        /* Then call to other functions here like:
            -End Turn
            -Draw Card  */
    }
}
