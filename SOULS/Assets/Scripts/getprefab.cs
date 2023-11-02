using UnityEngine;
public class getprefab : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public Transform spawnPoint;

    // This script will simply instantiate the Prefab when the game starts.
    public void Start()
    {
        Instantiate(myPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}