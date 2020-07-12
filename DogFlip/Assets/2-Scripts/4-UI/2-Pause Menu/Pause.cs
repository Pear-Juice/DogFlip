using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private int currentScene;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        Time.timeScale = 1;
        pauseMenu.active = false;
        settingsMenu.active = false;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.active = true;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.active = false;
                settingsMenu.active = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void exitToMenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);
        SceneManager.LoadScene(0);
    }
}