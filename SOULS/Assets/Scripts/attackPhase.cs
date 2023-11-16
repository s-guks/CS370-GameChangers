using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPhase : MonoBehaviour
{
    public cardTracker cardTracker;
    public loseHealth loseHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>(); //referencing
        loseHealth = GameObject.Find("loseHealth").GetComponent<loseHealth>();
    }

    public void startAttack(bool playerTurn){ //true if player's attack, false if opponent's
        //check which front slots have cards
        bool firstCol = cardTracker.isSlotFilled(1) && cardTracker.isSlotFilled(7); //if both filled, true (should attack)
        Debug.Log("firstCol = " + firstCol);
        bool secCol = cardTracker.isSlotFilled(2) && cardTracker.isSlotFilled(8);
        Debug.Log("secCol = " + secCol);
        bool thirdCol = cardTracker.isSlotFilled(3) && cardTracker.isSlotFilled(9);
        Debug.Log("thirdCol = " + thirdCol);

        if(firstCol){ //if cards across from each other (ie. can attack)
            Debug.Log("attacking 1 & 7");
            attackForSlots(1, 7, playerTurn); //send to attack each other
        }
        if(secCol){
            Debug.Log("attacking 2 & 8");
            attackForSlots(2, 8, playerTurn);
        }
        if(thirdCol){
            Debug.Log("attacking 3 & 9");
            attackForSlots(3, 9, playerTurn);
        }
    }

    public void attackForSlots(int playerSlot, int oppoSlot, bool playerTurn){
        GameObject playerCard;
        GameObject oppoCard;
        bool dead;

        playerCard = cardTracker.getObjBySlot(playerSlot); //get cards from player & oppo slots (eg. 1 & 7)
        oppoCard = cardTracker.getObjBySlot(oppoSlot);

        if(playerTurn){ //player attacking
            dead = loseHealth.getsAttackedBy(oppoCard, playerCard); //player is attackingCard
            if(dead){cardTracker.clearSlot(oppoSlot);} //if card died, clear slot
        } else { //opponent attacking
            dead = loseHealth.getsAttackedBy(playerCard, oppoCard); //player is hitCard
            if(dead){cardTracker.clearSlot(playerSlot);} //if card died, clear slot
        }
    }
}
