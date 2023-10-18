using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endTurn : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject tableCamera;

    // This method is automatically called when the button is clicked
    public void OnEndTurn()
    {
        // End turn button disabled
        Button endTurnButton = GetComponent<Button>();
        endTurnButton.interactable = false;
        playerAttackPhase();
    }

    void playerAttackPhase()
    {
        // Switch camera
        // Enable card selection/attacking
        // Enable end phase button
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
        Debug.Log("Attack phase - click x!");
    }
}