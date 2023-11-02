using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class makeCardClickable : MonoBehaviour
{
    public makeButton buttonScript; // Reference to the makeButton script

    private void Start()
    {
        // Find the makeButton script in the scene
        buttonScript = FindObjectOfType<makeButton>();

        if (buttonScript != null)
        {
            // Add a custom method to execute when the card is clicked
            buttonScript.unityEvent.AddListener(OnCardClicked);
        }
        else
        {
            Debug.LogError("makeButton script not found in the scene.");
        }
    }

    // Custom method to handle what happens when the card is clicked
    public void OnCardClicked()
    {
        // Implement the functionality you want when the card is clicked.
        
        Debug.Log("Card Clicked: " + name); // Output card name as an example.
    }
}