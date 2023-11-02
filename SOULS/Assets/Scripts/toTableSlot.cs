using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toTableSlot : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform spawnPoint;

    // This script will simply instantiate the Prefab when the game starts.
    public void placeSlot()
    {
        Debug.Log("Place Card!"); 
        Instantiate(myPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
