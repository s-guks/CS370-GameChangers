using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackPhase : MonoBehaviour
{
    public cardTracker cardTracker;
    public loseHealth loseHealth;
    public PlayerSlotManager PlayerSlotManager;
    public OpponentSlotManager OpponentSlotManager;
    
    // Start is called before the first frame update
    void Start()
    {
        cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>(); //referencing
        loseHealth = GameObject.Find("loseHealth").GetComponent<loseHealth>();
        PlayerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>(); //referencing
        OpponentSlotManager = GameObject.Find("OpponentSlotManager").GetComponent<OpponentSlotManager>(); //referencing
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
    IEnumerator WaitOneSecOppo(float seconds, GameObject oppoCard, GameObject playerCard, int playerSlot, bool dead)
    {
        Debug.Log($"Before waiting for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        Debug.Log($"After waiting for {seconds} seconds");
        PlayerSlotManager.attackAnimation(oppoCard, 0, 0);
        Debug.Log($"Before waiting for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        Debug.Log($"After waiting for {seconds} seconds");
        StartCoroutine(WaitForward(1, oppoCard));
        dead = loseHealth.getsAttackedBy(playerCard, oppoCard); //player is hitCard
        if (dead)
        { //if card died, clear slot
            cardTracker.clearSlot(playerSlot);
            PlayerSlotManager.cardterminate(playerSlot); //player card deaed
        }
    }
    IEnumerator WaitOneSecPlayer(float seconds, GameObject playerCard, GameObject oppoCard, int oppoSlot, bool dead)
    {
        Debug.Log($"Before waiting for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        Debug.Log($"After waiting for {seconds} seconds");
        PlayerSlotManager.attackAnimation(playerCard, 1, 1);
        /*Debug.Log($"Before waiting for {0.5f} seconds");
        yield return new WaitForSeconds(0.5f);
        Debug.Log($"After waiting for {0.5f} seconds");*/
        StartCoroutine(WaitBackward(1, playerCard));
        dead = loseHealth.getsAttackedBy(oppoCard, playerCard); //player is attackingCard
        if (dead)
        { //if card died, clear slot
            cardTracker.clearSlot(oppoSlot);
            OpponentSlotManager.cardterminate(oppoSlot); //opponent card dead
        }

    }
    IEnumerator WaitBackward(float seconds, GameObject playerCard)
    {
        Debug.Log($"Before waiting for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        PlayerSlotManager.attackAnimation(playerCard, 1, 0);
        Debug.Log($"After waiting for {seconds} seconds");
    }
    IEnumerator WaitForward(float seconds, GameObject oppoCard)
    {
        Debug.Log($"Before waiting for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        PlayerSlotManager.attackAnimation(oppoCard, 0, 1);
        Debug.Log($"After waiting for {seconds} seconds");
    }
    public void attackForSlots(int playerSlot, int oppoSlot, bool playerTurn){
        GameObject playerCard;
        GameObject oppoCard;
        bool dead = false;

        playerCard = cardTracker.getObjBySlot(playerSlot); //get cards from player & oppo slots (eg. 1 & 7)
        oppoCard = cardTracker.getObjBySlot(oppoSlot);

        if(playerTurn){ //player attacking
            StartCoroutine(WaitOneSecPlayer(1f, playerCard, oppoCard, oppoSlot, dead));
            
        } else { //opponent attacking
            StartCoroutine(WaitOneSecOppo(1f, oppoCard, playerCard, playerSlot, dead));
        }
    }
}
