using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCardsClickable : MonoBehaviour
{
    public GameObject card; //variable for button object
    public PlayerSlotManager PlayerSlotManager;
    public GameObject clickedBox; //variable for invisible, clickable box around card
    public Material clickedBubble;
    //public CamSwitch CamSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        clickedBox = this.gameObject; //getting clickable box to highlight
        card = this.transform.parent.gameObject; //getting card object since clickable obj is child
        PlayerSlotManager = GameObject.Find("PlayerSlotManager").GetComponent<PlayerSlotManager>();
        clickedBubble = Resources.Load<Material>("clickedBubble"); //get material for zero sprite
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on card
                clickedBox.GetComponent<MeshRenderer>().material = clickedBubble; //highlight card
                PlayerSlotManager.cardClicked(card); //send card as game object to slot code
            }
        }
    }
}
