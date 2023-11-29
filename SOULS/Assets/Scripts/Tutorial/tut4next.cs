using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added to trigger events


public class tut4next : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent(); //variable to call unity events
    public GameObject button; //variable for button object
    public TutorialManager4 TutorialManager4;

    // Start is called before the first frame update
    void Start()
    {
        TutorialManager4 = GameObject.Find("TutorialManager4").GetComponent<TutorialManager4>();
        button = this.gameObject; //setting unity object as button
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on button
                TutorialManager4.next5(); //trigger event in separate script
            }
        }
    }
}
