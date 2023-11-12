using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cardTracker : MonoBehaviour
{
    public makeDeck deckScript;
    public List<GameObject> cardObjects = new List<GameObject>(); //tracked as game objects
        //gameObject = equivalent to the individual instance of GameObject that this script is currently attached to
    public List<Card> cardsBySlot = new List<Card>(); //tracked as card scriptable objects
    public List<GameObject> cardsInHand = new List<GameObject>(); //same thing but for the player's hand
    private Card temp;
    private Exception e;

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GetComponent<makeDeck>(); //to reference card class
    }

    public void addCard(GameObject card){ //add game object cards to list
        cardObjects.Add(card); //cards must be added in order to preserve id
    }

    public GameObject getObjectByID(int cardID){ //returns card object with corresponding id
        return cardObjects[cardID]; //card id corresponds to index
    }

    public int getIDbyObject(GameObject card){
        int index = cardObjects.IndexOf(card);
        return index;
    }

    public void addToSlot(Card card, int slot){ //adds card (scriptable) to list, using index to track slot
        cardsBySlot.Insert(slot, card);
        //removeFromHand(card);
    }

    public void addToHand(GameObject card){ //same thing but for the hand
        cardsInHand.Add(card);
    }

    public void removeFromHand(GameObject card) { //card is played
        cardsInHand.Remove(card);
    }

    public void clearSlot(int slot){ //clears the slot that has the passed card contained in it
        if(isSlotFilled(slot)){ //if card in slot
            cardsBySlot[slot] = null;
        } 
    }
    
    public bool isSlotFilled(int slot){ //returns true if slot has card in it, false if empty
        try {
            Card temp = cardsBySlot[slot];
        } catch (Exception e){ //out of bounds or null error means slot doesn't exist
            return false;
        }
        if(temp == null){ //extra check for if null
            return false;
        } else {
            return true;
        }
    }

    public Card getCardBySlot(int slot){
        try {
            Card temp = cardsBySlot[slot];
        } catch { //nothing in slot
            Debug.Log("Error: Could not get card, " + e);
        }
        if(temp == null){ //double check for if null
            Debug.Log("Error: Could not get card, Null");
        }
        return temp;
    }
}
