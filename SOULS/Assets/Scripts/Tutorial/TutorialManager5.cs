using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previous4() {
        SceneManager.LoadScene("Tutorial4", LoadSceneMode.Single);
    }
    
    public void next6() {
        SceneManager.LoadScene("Tutorial6", LoadSceneMode.Single);
    }
}
