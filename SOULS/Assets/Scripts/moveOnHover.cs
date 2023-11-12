using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnHover : MonoBehaviour
{
    public float upAmount = 0.2f;
    public float speed = 0.5f;

    private  Vector3 dnPos;
    private  Vector3 upPos;
    private  Vector3 currPos;

    public GameObject card;
    
    void Start() {
        card = this.transform.parent.gameObject;
	    dnPos = card.transform.position;
	    upPos = card.transform.position + Vector3.up * upAmount;
	    currPos = dnPos;
    }

    Ray ray;
	RaycastHit hit;

    void Update() {
            transform.position = Vector3.MoveTowards(card.transform.position, currPos, speed * Time.deltaTime);
            
            /*
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit))
                {
                    print (hit.collider.name);
                }
            */
    }

    void OnMouseEnter() { 
        currPos = upPos; 
        Debug.Log("yahoooo");
    }
    void OnMouseExit()  { 
        currPos = dnPos; 
        Debug.Log("whahoh");
        }


}
