using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    bool firstTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        //create deck
        //create opponent deck
        //draw card X4
        playerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EndTurn")) 
        {
            //disable draw card button
            //disable end turn button
            if (firstTurn) {
                firstTurn = false;
                Debug.Log("first turn!");
                opponentFirstTurn();
            }
            else {
                playerAttackPhase();
            }
        }
        if (Input.GetButtonDown("EndAttack")) 
        {
            opponentTurn();
        }
    }

    void playerTurn() {
        //enable draw card button
        //enable end turn button
        Debug.Log("player's turn--click z!");
    }

    void playerAttackPhase() {
        //switch camera
        //enable card selection/attacking
        //enable end phase button 
        Debug.Log("attack phase--click x!");
    }

    void opponentFirstTurn() {
        //opponent plays cards
        //opponent DOES NOT have an attack phase
        playerTurn();
    }

    void opponentTurn() {
        //opponent plays cards
        opponentAttackPhase();
        playerTurn();
    }

    void opponentAttackPhase() {
        //opponent attacks
    }
}
