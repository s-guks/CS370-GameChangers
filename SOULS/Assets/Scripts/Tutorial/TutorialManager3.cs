using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previous2() {
        SceneManager.LoadScene("Tutorial2", LoadSceneMode.Single);
    }
    
    public void next4() {
        SceneManager.LoadScene("Tutorial4", LoadSceneMode.Single);
    }
}
