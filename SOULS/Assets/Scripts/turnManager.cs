using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//from /cards/Deck.cs import 

public class turnManager : MonoBehaviour
{
    public bool firstTurn = true;
    
    //make sure player cannot end inactive phase
    public bool isPlayerTurn = false;
    public bool isPlayerAttack = false;
    public bool isOpponentTurn = false;
    public bool isOpponentAttack = false;
    
    public GameObject mainCamera;
    public GameObject tableCamera;

    // Start is called before the first frame update
    void Start()
    {
        //create pool of cards
        //List<Card> cardPool = DeserializeCards();

        //create player and opponent deck
        //Stack<Card> playerDeck = CreateRandomDeck(cardPool);
        //Stack<Card> opponentDeck = CreateRandomDeck(cardPool);
        //draw card X4
        isPlayerTurn = true;
        playerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EndTurn")) 
        {
            if (isPlayerTurn) {
                //disable draw card button
                if (firstTurn) {
                    firstTurn = false;
                    isPlayerTurn = false;
                    Debug.Log("first turn!");
                    opponentFirstTurn();
                }
                else {
                    isPlayerTurn = false;
                    playerAttackPhase();
                }
            }
        }
        if (Input.GetButtonDown("EndAttack")) 
        {
            if (isPlayerAttack) {
                isPlayerAttack = false;
                opponentTurn();
            }
        }
    }

    public void endTurn() {
        if (isPlayerTurn) {
            isPlayerTurn = false;
            if (firstTurn) {
                    firstTurn = false;
                    Debug.Log("first turn!");
                    opponentFirstTurn();
                }
                else {
                    playerAttackPhase();
                }
        }
    }

    public void endAttack() {
        if (isPlayerAttack) {
            isPlayerAttack = false;
            opponentTurn();
        }
    }

    void playerTurn() {
        isPlayerTurn = true;
        //enable draw card button
        //enable end turn button
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        Debug.Log("player's turn--click z!");
    }

    void playerAttackPhase() {
        isPlayerAttack = true;
        //enable card selection/attacking
        //enable end phase button 
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
        Debug.Log("attack phase--click x!");
    }

    void opponentFirstTurn() {
        isOpponentTurn = true;
        //opponent plays cards
        //opponent DOES NOT have an attack phase
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        Debug.Log("opponent's first turn");
        isOpponentTurn = false;
        playerTurn();
    }

    void opponentTurn() {
        isOpponentTurn = true;
        //opponent plays cards
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        Debug.Log("opponent's turn");
        isOpponentTurn = false;
        opponentAttackPhase();
        playerTurn();
    }

    void opponentAttackPhase() {
        isOpponentAttack = true;
        //opponent attacks
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
        Debug.Log("opponent's attack phase");
        isOpponentAttack = false;
    }

}
