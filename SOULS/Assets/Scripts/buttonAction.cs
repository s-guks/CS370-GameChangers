using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAction : MonoBehaviour
{
    //public endTurn endTurn = GetComponent<endTurn>(); // Reference to the script containing the endTurn method
    public GameObject mainCamera;
    public GameObject tableCamera;

    // Assign the endTurn script in the Unity Editor
    public void buttonMethod()
    {
        Debug.Log("Button Clicked!"); //temporary notice
        // Future button animation goes here
        //endTurn = GameObject.FindGameObjectWithTag("endTurn").GetComponent<endTurn>();

        if (true)//(endTurn != null)
        {
            //Debug.Log(endTurn);
            //endTurn.EndTurn();
        }
        //else
        //{
        //    Debug.LogError("End Turn Script not found.");
        //}
            /* Then call other functions here like:
                -Draw Card */
    }
}
