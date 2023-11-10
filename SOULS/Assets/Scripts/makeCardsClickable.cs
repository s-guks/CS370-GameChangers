using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCardsClickable : MonoBehaviour
{
    public GameObject card; //variable for button object
    public PlayerSlotManager PlayerSlotManager;
    //public CamSwitch CamSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        card = this.transform.parent.gameObject; //getting card object since clickable obj is child
        PlayerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>();
        //CamSwitch = GameObject.Find("CamSwitch").GetComponent<CamSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on button
                //CamSwitch.switchToTable(); //make camera look over table
                PlayerSlotManager.cardClicked(card); //send card as game object to slot code
            }
        }
    }
}
