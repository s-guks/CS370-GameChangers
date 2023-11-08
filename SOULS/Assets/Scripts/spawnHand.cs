using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHand : MonoBehaviour
{
    public makeDeck makeDeck;
    private List<int> handList;

    public GameObject butcher1;
    public GameObject lawyer2;
    public GameObject mechanic3;
    public GameObject nurse4;
    public GameObject police5;

    private GameObject[] allObjects;
    

    private float horizontalPos = -0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
         makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCards() {
        
        foreach (Card c in makeDeck.Hands["hand1"]) {
            if (c.id == 1) {
                Instantiate(butcher1, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 2) {
                Instantiate(lawyer2, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 3) {
                Instantiate(mechanic3, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 4) {
                Instantiate(nurse4, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 5) {
                Instantiate(police5, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            
            horizontalPos += 0.65f;
        }
    }

    public void spawnDraw() {
        Card c = makeDeck.Hands["hand1"][makeDeck.Hands["hand1"].Count-1];
        if (c.id == 1) {
                Instantiate(butcher1, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 2) {
                Instantiate(lawyer2, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 3) {
                Instantiate(mechanic3, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 4) {
                Instantiate(nurse4, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            else if (c.id == 5) {
                Instantiate(police5, new Vector3(horizontalPos, -0.2f, -5.7f), Quaternion.Euler(-70f, 0.0f, 0.0f));
            }
            
            horizontalPos += 0.65f;
    }

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
