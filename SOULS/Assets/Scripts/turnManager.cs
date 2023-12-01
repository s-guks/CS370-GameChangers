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
    public attackPhase attackPhase;
    public cardTracker cardTracker;
    
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
    public GameObject teacher6;
    public GameObject judge7;
    public GameObject waitress8;
    public GameObject detective9;
    public GameObject plumber10;
    public GameObject chef11;
    public GameObject pilot12;
    public GameObject developer13;

    //list of empty opponent slots
    private List<int> emptySlots;
    private List<int> playerEmptySlots;

    //check if no cards are being played
    private int tieCheck;

    // Start is called before the first frame update
    void Start()
    {
        //find other scripts so the turn manager can reference them
        makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
        spawnHand = GameObject.Find("spawnHand").GetComponent<spawnHand>();
        OpponentSlotManager = GameObject.Find("OpponentSlotManager").GetComponent<OpponentSlotManager>();
        PlayerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>();
        attackPhase = GameObject.Find("attackPhase").GetComponent<attackPhase>();
        cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>();
        
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
        //z ends the turn, x ends the attack phase; mostly used for testing
        if (Input.GetButtonDown("EndTurn")) 
        {
            endTurn();
        }
        //testing commands no longer necessary; attack phase ends automatically
        /*
        if (Input.GetButtonDown("EndAttack")) 
        {
            endAttack();
        }
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

    /*
    end the player's turn
    the first turn triggers the opponent's first turn
    every other turn triggers the player's attack phase and then checks the win condition 
    (player defeated all of opponent's cards)
    public, can be referenced by other scripts (the end turn button)
    */
    public void endTurn() {
        //only ends the player's turn if it's currently the player's turn
        if (isPlayerTurn) {
            isPlayerTurn = false;
                if (firstTurn) {    //different first turn
                    firstTurn = false;
                    PlayerSlotManager.moveForward();
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


    //end the attack phase
    //public, can be referenced by other scripts
    public void endAttack() {
        if (isPlayerAttack) {
            isPlayerAttack = false;
            tieChecker();
            opponentTurn();
        }
    }

    //load the You Won scene
    //public, can be referenced by other scripts
    public void winGame() {
        SceneManager.LoadScene("WinGame", LoadSceneMode.Single);
    }

    //load the You Lost scene
    //public, can be referenced by other scripts
    public void loseGame() {
        SceneManager.LoadScene("LoseGame", LoadSceneMode.Single);
    }

    //alter the game state to the player's turn
    private void playerTurn() {
        isPlayerTurn = true;

        //enable draw card button
        drawWasClicked = false;

        //swap the camera to the main camera
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
        Debug.Log("player's turn--click z or the end turn button!");
    }

    //the player's cards attack the opponent's cards
    private void playerAttackPhase() {
        isPlayerAttack = true; 

        //swap the camera to the table camera
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;

        //cards in the back row without a card in front of them move forward
        //this happens once before the attacking starts and once after
        PlayerSlotManager.moveForward();
        
        //cards attack each other
        attackPhase.startAttack(true); //true means it is the player's attack phase

        PlayerSlotManager.moveForward();

        //end player attack phase
        endAttack();
    }

    //alter the game state to the opponent's first turn
    private void opponentFirstTurn() {
        isOpponentTurn = true;

        //swap the camera to the main camera
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;

        //opponent plays cards
        makeDeck.Draw("hand2", "deck2", 1);

        //place 3 or 4 cards
        var rand = new System.Random();
        int r = rand.Next(3, 5);
        int r2 = 0;
        int i = 0;

        int length = makeDeck.Hands["hand2"].Count;

        //create and place card objects
        while (length > 0) {
            if (i < r) {
                Card c = makeDeck.Hands["hand2"][0];
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
                else if (c.id == 6) {
                    cardObj = Instantiate(teacher6, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 7) {
                    cardObj = Instantiate(judge7, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 8) {
                cardObj = Instantiate(waitress8, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 9) {
                    cardObj = Instantiate(detective9, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 10) {
                    cardObj = Instantiate(plumber10, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 11) {
                    cardObj = Instantiate(chef11, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 12) {
                    cardObj = Instantiate(pilot12, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                else if (c.id == 13) {
                    cardObj = Instantiate(developer13, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                }
                cardTracker.addCardToDict(cardObj, c); //add to tracker
                
                cardObj.name = (spawnHand.prefabID.ToString());
                spawnHand.prefabID += 1;

                //get list of empty slots
                emptySlots = OpponentSlotManager.checkEmpty();
                r2 = rand.Next(0, emptySlots.Count);

                //move card to random empty slot
                OpponentSlotManager.moveByClick(cardObj, emptySlots[r2]);
                
                //for testing
                /*
                foreach (int slot in emptySlots) {
                    Debug.Log("empty slots: " + slot);
                }
                
                Debug.Log("moved " + cardObj + " to " + emptySlots[r2]);
                */

                i+=1;
                length = makeDeck.Hands["hand2"].Count;
            }
            else {
                length = -1;
            }
        }

        //opponent DOES NOT have an attack phase

        //if there are cards in the back row, move them forward
        OpponentSlotManager.moveForward();

        //turn is over
        isOpponentTurn = false;
        playerTurn();
    }

    IEnumerator Wait()
    {
        Debug.Log("Before waiting for 2 seconds");
        yield return new WaitForSeconds(2f);
        Debug.Log("After waiting for 2 seconds");
        opponentAttackPhase();
        PlayerSlotManager.moveForward();

        //check if opponent has won after opponsnt's attack phase ends
        playerEmptySlots = PlayerSlotManager.checkEmpty();
        if (playerEmptySlots.Count == 6)
        {
            loseGame();
        }
        playerTurn();
    }

    //alter the game state to the opponent's turn (every turn but the first)
    private void opponentTurn() {

        //double-check that the opponent didn't just lose
        emptySlots = OpponentSlotManager.checkEmpty();
            if (emptySlots.Count == 6) {
                winGame();
            }

        tieCheck += 1;
        
        isOpponentTurn = true;

        //opponent plays cards
        makeDeck.Draw("hand2", "deck2", 1);

        //swap the camera to the main camera
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;

        //get list of empty slots
        emptySlots = OpponentSlotManager.checkEmpty();

        //place some cards
        var rand = new System.Random();
        int r = rand.Next(0, emptySlots.Count);
        int i = 0;

        int length = makeDeck.Hands["hand2"].Count;
                
                while (length > 0) {
                    if (r > 0) {

                        tieCheck = 0;
                        
                        Card c = makeDeck.Hands["hand2"][0]; //always spawn in the first card in the hand
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
                        else if (c.id == 6) {
                            cardObj = Instantiate(teacher6, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 7) {
                            cardObj = Instantiate(judge7, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 8) {
                            cardObj = Instantiate(waitress8, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 9) {
                            cardObj = Instantiate(detective9, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 10) {
                            cardObj = Instantiate(plumber10, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 11) {
                            cardObj = Instantiate(chef11, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 12) {
                            cardObj = Instantiate(pilot12, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else if (c.id == 13) {
                            cardObj = Instantiate(developer13, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        else { //if there's no id just spawn a butcher 
                            cardObj = Instantiate(butcher1, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.identity);
                        }
                        cardTracker.addCardToDict(cardObj, c); //add to tracker

                        //get list of empty slots
                        emptySlots = OpponentSlotManager.checkEmpty();
                        int r2 = rand.Next(0, emptySlots.Count);

                        //move card to random empty slot
                        OpponentSlotManager.moveByClick(cardObj, emptySlots[r2]);

                        //for testing
                        //Debug.Log("moved " + cardObj + " to " + emptySlots[r2]);

                        i+=1;
                        length = makeDeck.Hands["hand2"].Count;
                    }
                    else {
                        length = -1;
                    }
                }

        //if there are cards in the back row with no card in front of them, move them forward
        OpponentSlotManager.moveForward();

        //turn is over
        isOpponentTurn = false;
        StartCoroutine(Wait());
    }

    //opponent's cards attack the player's cards
    private void opponentAttackPhase() {
        isOpponentAttack = true;

        //swap the camera to the table camera
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;

        //opponent attacks
        attackPhase.startAttack(false); //false means it is not the player's attack (ie. it's the opponent's)

        //if there are cards in the back row with no card in front of them, move them forward
        OpponentSlotManager.moveForward();

        tieChecker();

        isOpponentAttack = false;
    }

    //detect unwinnable/unlosable game and break ties
    private void tieChecker() {
        if ((makeDeck.Decks["deck1"].Count <= 1 || makeDeck.Decks["deck2"].Count <= 1) && tieCheck > 3) {
            List<int> emptyOpSlots = OpponentSlotManager.checkEmpty();
            List<int> emptyPlSlots = PlayerSlotManager.checkEmpty();

            //winner is the one with more cards on the table
            //if equal, player wins
            if (emptyOpSlots.Count < emptyPlSlots.Count) {
                loseGame();
            }
            else {
                winGame();
            }
        }
    }

}
