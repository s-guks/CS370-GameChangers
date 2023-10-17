using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public Button endTurnButton;
    public TurnManager turnManager;

    
    void Start()
    {
        if (endTurnButton != null)
        {
            endTurnButton.onClick.AddListener(OnEndTurnClick);
        }
        else
        {
            Debug.LogError("End Turn Button is not assigned.");
        }
    }

    void OnClickEndTurn()
    {
        // End turn button disabled
        endTurnButton.interactable = false;

        // check first turn
        if (turnManager.firstTurn)
        {
            turnManager.opponentFirstTurn();
            turnManager.playerTurn()
        }
        else
        {
            turnManager.playerAttackPhase();
        }
    }
}