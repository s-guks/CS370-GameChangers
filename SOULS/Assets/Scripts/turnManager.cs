using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class turnManager : MonoBehaviour
{
    public bool firstTurn = true;
    public bool drawWasClicked;
    
    //make sure player cannot end inactive phase
    public bool isPlayerTurn = false;
    public bool isPlayerAttack = false;
    public bool isOpponentTurn = false;
    public bool isOpponentAttack = false;
    
    //cameras
    public GameObject mainCamera;
    public GameObject tableCamera;

    //other scripts
    public makeDeck makeDeck;
    public spawnHand spawnHand;
    public OpponentSlotManager OpponentSlotManager;
    public PlayerSlotManager PlayerSlotManager;
    
    //positions cards spawn in (opponent)
        private float horizontalPos = -1.494676f;
        private float verticalPos = -0.5996342f;
        private float depthPos = 0.09293032f;

    //references to prefabs
    public GameObject butcher1;
    public GameObject lawyer2;
    public GameObject mechanic3;
    public GameObject nurse4;
    public GameObject police5;

    //list of empty opponent slots
    private List<int> emptySlots;
    private List<int> playerEmptySlots;

    // Start is called before the first frame update
    void Start()
    {
        makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
        spawnHand = GameObject.Find("spawnHand").GetComponent<spawnHand>();
        OpponentSlotManager = GameObject.Find("OpponentSlotManager").GetComponent<OpponentSlotManager>();
        PlayerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>();
        
        //draw cards
        makeDeck.GameStart();
        spawnHand.spawnCards();

        //start game (player's turn)
        isPlayerTurn = true;
        playerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EndTurn")) 
        {
            endTurn();
        }
        if (Input.GetButtonDown("EndAttack")) 
        {
            endAttack();
        }
        /*
        if (Input.GetButtonDown("Esc")) 
        {
            winGame();
        }
        if (Input.GetButtonDown("Lose")) 
        {
            loseGame();
        }
        */
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

                    //check if player has won after their attack phase ends
                    emptySlots = OpponentSlotManager.checkEmpty();
                    if (emptySlots.Count == 6) {
                        winGame();
                    }
                }
        }
    }

    public void endAttack() {
        if (isPlayerAttack) {
            isPlayerAttack = false;
            opponentTurn();
        }
    }

    public void winGame() {
        SceneManager.LoadScene("WinGame", LoadSceneMode.Single);
    }

    public void loseGame() {
        SceneManager.LoadScene("LoseGame", LoadSceneMode.Single);
    }

    private void playerTurn() {
        isPlayerTurn = true;
        //enable draw card button
        drawWasClicked = false;
        //enable end turn button
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        Debug.Log("player's turn--click z!");
    }

    private void playerAttackPhase() {
        isPlayerAttack = true; 
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;

        PlayerSlotManager.moveForward();

        //cards attack each other

        PlayerSlotManager.moveForward();

        Debug.Log("attack phase--click x!");
    }

    private void opponentFirstTurn() {
        isOpponentTurn = true;

        //switch cammeras
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;

        //opponent plays cards
        makeDeck.Draw("hand2", "deck2", 1);

        //place 3 or 4 cards
        var rand = new System.Random();
        int r = rand.Next(3, 5);
        int r2 = 0;
        int i = 0;
        Debug.Log("r " + r + " i " + i);
        foreach (Card c in makeDeck.Hands["hand2"]) {
            Debug.Log("r " + r + " i " + i);
            if (i < r) {
                GameObject cardObj = null;
                
                if (c.id == 1) {
                    cardObj = Instantiate(butcher1, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 2) {
                    cardObj = Instantiate(lawyer2, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 3) {
                    cardObj = Instantiate(mechanic3, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 4) {
                    cardObj = Instantiate(nurse4, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 5) {
                    cardObj = Instantiate(police5, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }

                //get list of empty slots
                emptySlots = OpponentSlotManager.checkEmpty();
                r2 = rand.Next(0, emptySlots.Count);

                //move card to random empty slot
                OpponentSlotManager.moveByClick(cardObj, emptySlots[r2]);
                foreach (int slot in emptySlots) {
                    Debug.Log("empty slots: " + slot);
                }
                
                Debug.Log("moved " + cardObj + " to " + emptySlots[r2]);

                i+=1;
            }
        }

        //opponent DOES NOT have an attack phase
        
        Debug.Log("opponent's first turn");

        //if there are cards in the back row, move them forward
        OpponentSlotManager.moveForward();

        //turn is over
        isOpponentTurn = false;
        playerTurn();
    }

    private void opponentTurn() {
        isOpponentTurn = true;

        //opponent plays cards
        makeDeck.Draw("hand2", "deck2", 1);

        //switch cammeras
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        
        //Debug.Log("opponent's turn");

        //get list of empty slots
        emptySlots = OpponentSlotManager.checkEmpty();

        //place some cards
        var rand = new System.Random();
        int r = rand.Next(0, emptySlots.Count);
        int i = 0;
        
        if (emptySlots.Count > 0) {
            foreach (Card c in makeDeck.Hands["hand2"]) {
                if (i <= r) {
                    GameObject cardObj = null;
                    
                    if (c.id == 1) {
                        cardObj = Instantiate(butcher1, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                    }
                    else if (c.id == 2) {
                        cardObj = Instantiate(lawyer2, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                    }
                    else if (c.id == 3) {
                        cardObj = Instantiate(mechanic3, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                    }
                    else if (c.id == 4) {
                        cardObj = Instantiate(nurse4, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                    }
                    else if (c.id == 5) {
                        cardObj = Instantiate(police5, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                    }

                    //get list of empty slots
                    emptySlots = OpponentSlotManager.checkEmpty();
                    int r2 = rand.Next(0, emptySlots.Count);

                    //move card to random empty slot
                    OpponentSlotManager.moveByClick(cardObj, emptySlots[r2]);

                    Debug.Log("moved " + cardObj + " to " + emptySlots[r2]);

                    i+=1;
                }
            }
        }


        //if there are cards in the back row, move them forward
        OpponentSlotManager.moveForward();

        //turn is over
        isOpponentTurn = false;
        opponentAttackPhase();

        //check if opponent has won after opponsnt's attack phase ends
        playerEmptySlots = PlayerSlotManager.checkEmpty();
            if (playerEmptySlots.Count == 6) {
                loseGame();
            }
        playerTurn();
    }

    private void opponentAttackPhase() {
        isOpponentAttack = true;
        //opponent attacks
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
        Debug.Log("opponent's attack phase");

        OpponentSlotManager.moveForward();
        isOpponentAttack = false;
    }

}
