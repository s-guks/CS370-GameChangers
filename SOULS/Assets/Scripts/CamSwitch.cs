using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    //declare two public gameobjects for the two cameras
    public GameObject mainCamera;
    public GameObject tableCamera;
//enable main camera and disable table camera on start
    void Start() 
    {
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
    }
//check for button presses between cameras
    void Update()
    {//enables main camera and disables table camera
        if (Input.GetButtonDown("MainCamera")) 
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            tableCamera.GetComponent<Camera>().enabled = false;
        }//reverse
        if (Input.GetButtonDown("TableCamera"))
        {
            tableCamera.GetComponent<Camera>().enabled = true;
            mainCamera.GetComponent<Camera>().enabled = false;
        }
    }
//public switch method
    public void switchToTable(){
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
    }
}
