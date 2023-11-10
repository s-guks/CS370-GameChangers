using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlotManager : MonoBehaviour
{
    private PlayerSlotManager playerSlotManager; // Reference to PlayerSlotManager
    private OpponentSlotManager opponentSlotManager; // Reference to OpponentSlotManager
    private bool playersturn = true;
    private int opponentslot1 = 7;
    private int opponentslot2 = 8;
    private int opponentslot3 = 9;
    private int opponentslot4 = 10;
    private int opponentslot5 = 11;
    private int opponentslot6 = 12;
    

    void Start()
    {
        playerSlotManager = FindObjectOfType<PlayerSlotManager>(); // Find and store the PlayerSlotManager
        opponentSlotManager = FindObjectOfType<OpponentSlotManager>(); // Find and store the OpponentSlotManager
        if(playersturn)
        {
            PlayerSlotManagerUpdate();
            playersturn = false;
        }else{
            OpponentSlotManagerStart();
        }
    }

    void PlayerSlotManagerUpdate()
    {
        playerSlotManager.Update(); // Call a method in PlayerSlotManager
    }

    void OpponentSlotManagerStart()
    {
        opponentSlotManager.Start(); // Call a method in OpponentSlotManager
    }
}
