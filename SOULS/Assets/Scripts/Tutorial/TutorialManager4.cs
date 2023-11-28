using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previous3() {
        SceneManager.LoadScene("Tutorial3", LoadSceneMode.Single);
    }
    
    public void next5() {
        SceneManager.LoadScene("Tutorial5", LoadSceneMode.Single);
    }
}
