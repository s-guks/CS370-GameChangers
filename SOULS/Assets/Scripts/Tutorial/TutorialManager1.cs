using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    
    public void next2() {
        SceneManager.LoadScene("Tutorial2", LoadSceneMode.Single);
    }
}
