using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previous1() {
        SceneManager.LoadScene("Tutorial1", LoadSceneMode.Single);
    }
    
    public void next3() {
        SceneManager.LoadScene("Tutorial3", LoadSceneMode.Single);
    }
}
