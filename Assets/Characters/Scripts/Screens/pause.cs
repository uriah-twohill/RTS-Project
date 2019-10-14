using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject Pause;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Pause.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Pause.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Pause.SetActive(true);
                Time.timeScale = 0;
            }
            paused = !paused;
        }
        if (Input.GetKeyDown("m") && paused)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
