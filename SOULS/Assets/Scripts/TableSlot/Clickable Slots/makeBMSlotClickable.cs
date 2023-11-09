using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added to trigger events

public class makeBMSlotClickable : MonoBehaviour
{
    public PlayerSlotManager playerSlotManager;
    public UnityEvent unityEvent = new UnityEvent(); //variable to call unity events
    public GameObject slot; //variable for slot object

    // Start is called before the first frame update
    void Start()
    {
        playerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>();
        slot = this.gameObject; //setting unity object as slot
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on button
                Debug.Log("Bottom middle slot (5) clicked."); //trigger event in separate script
                playerSlotManager.moveByClick(5);
            }
        }
    }
}
