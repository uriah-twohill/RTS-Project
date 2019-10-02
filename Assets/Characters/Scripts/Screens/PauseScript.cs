using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("rpgpp_lt_scene_1.0");
        }
        else if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
