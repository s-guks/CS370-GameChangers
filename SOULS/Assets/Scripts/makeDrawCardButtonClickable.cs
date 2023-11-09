using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added to trigger events


public class makeDrawCardButtonClickable : MonoBehaviour
{
    //public UnityEvent unityEvent = new UnityEvent(); //variable to call unity events
    public GameObject button; //variable for button object
    public makeDeck makeDeck;
    public spawnHand spawnHand;
    public turnManager turnManager;

    // Start is called before the first frame update
    void Start()
    {
        makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
        spawnHand = GameObject.Find("spawnHand").GetComponent<spawnHand>();
        turnManager = GameObject.Find("turnManager").GetComponent<turnManager>();
        button = this.gameObject; //setting unity object as button
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on button
                if (turnManager.isPlayerTurn && !turnManager.drawWasClicked) {
                    //draw card into database
                    makeDeck.Draw("hand1", "deck1", 1); 

                    //spawn card
                    spawnHand.spawnDraw();

                    //can only draw one card per turn
                    turnManager.drawWasClicked = true;
                    
                    //for testing
                    foreach (Card c in makeDeck.Hands["hand1"]) Debug.Log(c.idObj);
                }
            }
        }
    }
}
