using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previous5() {
        SceneManager.LoadScene("Tutorial5", LoadSceneMode.Single);
    }
    
    public void backToMenu2() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
