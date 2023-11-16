using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cardTracker : MonoBehaviour
{
    public makeDeck deckScript;
    public Dictionary<GameObject, Card> cardObjects = new Dictionary<GameObject, Card>(); //dictionary to pair game objects with scriptables

    public List<GameObject> slotsGameObj = new List<GameObject>(); //slots tracked as game objects
    public List<Card> slotsScriptable = new List<Card>(); //slots tracked as scriptable objects

    public List<GameObject> cardsInHand = new List<GameObject>(); //same thing but for the player's hand

    private GameObject tempObj;
    private Card tempScript;
    private Exception e;

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GetComponent<makeDeck>(); //to reference card class
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
        slotsGameObj.Insert(slot, card);
        slotsScriptable.Insert(slot, getScriptable(card));
    }

    public void clearSlot(int slot){ //clears the slot that has the passed card contained in it
        if(isSlotFilled(slot)){ //if card in slot
            slotsGameObj[slot] = null;
            slotsScriptable[slot] = null;
        } 
    }
    
    public bool isSlotFilled(int slot){ //returns true if slot has card in it, false if empty
        try {
            tempObj = slotsGameObj[slot];
        } catch (Exception e){ //out of bounds or null error means slot doesn't exist
            return false;
        }
        if(tempObj == null){ //extra check for if null
            return false;
        } else {
            return true;
        }
    }
    //two versions
    public GameObject getObjBySlot(int slot){ //returns the game object in the slot
        try {
            tempObj = slotsGameObj[slot];
        } catch { //nothing in slot
            Debug.Log("Error: Could not get card, " + e);
        }
        if(tempObj == null){ //double check for if null
            Debug.Log("Error: Could not get card, Null");
        }
        return tempObj;
    }

    public Card getScriptBySlot(int slot){ //returns the scriptable object in the slot
        try {
            tempScript = slotsScriptable[slot];
        } catch { //nothing in slot
            Debug.Log("Error: Could not get card, " + e);
        }
        if(tempScript == null){ //double check for if null
            Debug.Log("Error: Could not get card, Null");
        }
        return tempScript;
    }
    
}
