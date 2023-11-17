using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cardTracker : MonoBehaviour
{
    public makeDeck deckScript;
    public Dictionary<GameObject, Card> cardObjects = new Dictionary<GameObject, Card>(); //dictionary to pair game objects with scriptables

    //public List<GameObject> slotsGameObj = new List<GameObject>(); //slots tracked as game objects
    //public List<Card> slotsScriptable = new List<Card>(); //slots tracked as scriptable objects
    public GameObject[] slotsGameObj;

    public List<GameObject> cardsInHand = new List<GameObject>(); //same thing but for the player's hand

    private GameObject tempObj;
    private Card tempScript;
    private Exception e;

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GetComponent<makeDeck>(); //to reference card class
        //BUGFIX: the length of the array is 12, even though it indexes 0 - 11
        slotsGameObj = new GameObject[12]; //will need to reference as (slot-1)
    }   

    //Global Tracker
    public void addCardToDict(GameObject obj, Card script){ //adds the game and scriptable objects to the dictionary
        cardObjects.Add(obj, script);
    }

    public Card getScriptable(GameObject obj){ //gets the scriptable object with the game object as key
        if(cardObjects.ContainsKey(obj)){
            return cardObjects[obj];
        }
        Debug.Log("Error getScriptable: No matching game object found."); //if not exist
        return null; 
    }

    //Hand Tracker
    public void addToHand(GameObject card){ //same thing but for the hand
        cardsInHand.Add(card);
    }

    public void removeFromHand(GameObject card) { //card is played
        cardsInHand.Remove(card);
    }
    
    
    //Slot Tracker
    public void addToSlot(GameObject card, int slot){ //adds card to list, using index to track slot
        int realSlot = slot-1;
        Debug.Log("add to slot in card tracker " + realSlot);
        slotsGameObj[realSlot] = card;
    }

    
    public void clearSlot(int slot){ //clears the slot that has the passed card contained in it
        if(isSlotFilled(slot)){ //if card in slot
            slotsGameObj[(slot-1)] = null;
        } 
    }
    
    public bool isSlotFilled(int slot){ //returns true if slot has card in it, false if empty
        if(slotsGameObj[(slot-1)] != null){
            return true;
        } else {
            return false;
        }
    }
    
    public GameObject getObjBySlot(int slot){ //returns the game object in the slot
        if(isSlotFilled(slot)){ //if there is a card in the slot
            int realSlot = slot-1;
            return slotsGameObj[realSlot];
        } else { //no card
            Debug.Log("cardTracker: no card in slot");
            return null;
        }
    }
}
