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

    //public GameObject card;
    
    void Start() {
        //card = this.transform.parent.gameObject;
	    dnPos = transform.position;
	    upPos = transform.position + Vector3.back * upAmount;
	    currPos = dnPos;

        //Debug.Log("dnPos" + dnPos);
        //Debug.Log("upPos" + upPos);
    }

    Ray ray;
	RaycastHit hit;

    private bool hovered = false;

    void Update() {
            transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
                
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);



                //shoidfhsaifdhskjlabshfdosahf
                //i hate this so much
                //I'm just trying to make the cards move forward on hover
                //and move back when the mouse leaves
                //hit.collider.gameObject never equals this.gameObject
                //the issue is that the invisible clicky box is only on the nurse card :(
                //the Other issue is that I can't get component the clickableNurse component for some reason
                if(Physics.Raycast(ray, out hit)
                    //&& hit.collider.gameObject == this.gameObject.GetComponent<clickableNurse>()
                    && !hovered)// && hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log(hit.collider.gameObject);
                    Debug.Log(this.gameObject);
                    hovered = true;
                    currPos = upPos; 
                    Debug.Log("yahoooo");
                    //print (hit.collider.name);
                }
                if(hovered) {
                    hovered = false;
                    currPos = dnPos; 
                    Debug.Log("whahoh");
                }
                
            
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
