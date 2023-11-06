using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHand : MonoBehaviour
{
    public makeDeck makeDeck;
    private List<int> handList;
    
    // Start is called before the first frame update
    void Start()
    {
         makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    spawnCards() {
        foreach (Card c in makeDeck.Hands["hand1"]) {
            
        }
    }
}
