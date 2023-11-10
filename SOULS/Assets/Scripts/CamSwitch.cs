using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject tableCamera;

    void Start() 
    {
        mainCamera.GetComponent<Camera>().enabled = true;
        tableCamera.GetComponent<Camera>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("MainCamera")) 
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            tableCamera.GetComponent<Camera>().enabled = false;
        }
        if (Input.GetButtonDown("TableCamera"))
        {
            tableCamera.GetComponent<Camera>().enabled = true;
            mainCamera.GetComponent<Camera>().enabled = false;
        }
    }

    public void switchToTable(){
        mainCamera.GetComponent<Camera>().enabled = false;
        tableCamera.GetComponent<Camera>().enabled = true;
    }
}
