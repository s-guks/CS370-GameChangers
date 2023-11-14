using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHand : MonoBehaviour
{
    //other monobehaviors to reference
    public makeDeck makeDeck;
    public cardTracker cardTracker;
    //public moveOnHover moveOnHover;

    //private List<int> handList;
    //private GameObject[] allObjects;

    //references to prefabs
    public GameObject butcher1;
    public GameObject lawyer2;
    public GameObject mechanic3;
    public GameObject nurse4;
    public GameObject police5;
    
    //positions cards spawn in 
    private float horizontalPos = -0.8f;
    private float verticalPos = -0.1f;
    private float depthPos = -5.5f;

    //number of cards held
    private float cardsHeld = 0f;

    //length of the box cards in hand spawn into
    private float boxDistance = 0f;

    //distance between cards
    private float cardLocHorizontal = 0f;
    private float cardLocVertical = 0.05f;
    private float cardLocDepth = -0.1f;

    //move on hover variables
    public float upAmount = 0.2f;
    public float speed = 0.5f;

    private  Vector3 dnPos;
    private  Vector3 upPos;
    //private  Vector3 currPos;
    
    // Start is called before the first frame update
    void Start()
    {
         makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
         cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>();
         //moveOnHover = GameObject.Find("moveOnHover").GetComponent<moveOnHover>();

        //size of spawnable box
         boxDistance = (0.8f) + (1.1f);

         //initial cards in hand and distance between them
         cardsHeld = 4;
         cardLocHorizontal = boxDistance / cardsHeld;
    }

    // Update is called once per frame
    void Update()
    {
        //make sure number of cards in hand and space between them is up to date
        cardsHeld = makeDeck.Hands["hand1"].Count;
        cardLocHorizontal = boxDistance / cardsHeld;

        /*
        //make cards hoverable
        //currently broken
        Ray ray;
	    RaycastHit hit;
                
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        foreach (GameObject c in cardTracker.cardsInHand) {
            dnPos = c.transform.position;
	        upPos = c.transform.position + Vector3.back * upAmount;
            //Debug.Log(dnPos + " " + upPos);
	        //currPos = dnPos;

            if(Physics.Raycast(ray, out hit)
                    && hit.collider.gameObject == c.transform.gameObject) //.transform.parent.gameObject)
            {
                c.transform.position = Vector3.MoveTowards(transform.position, upPos, speed * Time.deltaTime);
            }
            //c.transform.position = Vector3.MoveTowards(transform.position, dnPos, speed * Time.deltaTime);  
        }
        */


    }

    public void spawnCards() {

        //reset initial position
        horizontalPos = -0.8f;
        verticalPos = -0.2f;
        depthPos = -5.5f;

        //destroy existing hand
        while (cardTracker.cardsInHand.Count > 0) {
            GameObject c = cardTracker.cardsInHand[0];
            if (c != null) {
                Destroy(cardTracker.cardsInHand[0]);
            }
            cardTracker.removeFromHand(c);
        }

        //create card objects and add them to the hand container in cardTracker
        int i = 0;
        foreach (Card c in makeDeck.Hands["hand1"]) {

            GameObject cardObj = null;
            
            if (c.id == 1) {
                cardObj = Instantiate(butcher1, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 2) {
                cardObj = Instantiate(lawyer2, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 3) {
                cardObj = Instantiate(mechanic3, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 4) {
                cardObj = Instantiate(nurse4, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 5) {
                cardObj = Instantiate(police5, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            cardTracker.addToHand(cardObj); //adding game object to hand card tracker
            cardTracker.addCardToDict(cardObj, c); //adding game and script object to card dictionary

            //doesn't work?
            //cardObj.AddComponent<moveOnHover>();
            
            //calculate space between cards
            horizontalPos += cardLocHorizontal;
            if (i % 2 == 0) {
                depthPos += cardLocDepth;
                verticalPos -= cardLocVertical;
            }
            else {
                depthPos -= cardLocDepth;
                verticalPos += cardLocVertical;
            }
            i+=1;
            
            //verticalPos += cardLocVertical;
        }
    }

/*
    public void spawnDraw() {
        Card c = makeDeck.Hands["hand1"][makeDeck.Hands["hand1"].Count-1];
        if (c.id == 1) {
                Instantiate(butcher1, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 2) {
                Instantiate(lawyer2, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 3) {
                Instantiate(mechanic3, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 4) {
                Instantiate(nurse4, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 5) {
                Instantiate(police5, new Vector3(horizontalPos, verticalPos, depthPos), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            
            horizontalPos += cardLocHorizontal;
            depthPos += cardLocDepth;
    }
*/
/*
//Destroy all cards in hand and remake them all
//or recalculate their positions whenever an update is made? I'm not sure how to do this
    public void onDiscard() {
        allObjects = Object.FindObjectsOfType(GameObject);
            foreach(GameObject obj in allObjects) {
                if(obj.transform.name == "mechanicCard(Clone)"){
                    Destroy(obj);
                }
            }
        spawnCards();
    }
*/
}
