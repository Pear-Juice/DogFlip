using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private int currentScene;
    private int nextScene;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gun;

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
                gun.SetActive(false);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.active = false;
                settingsMenu.active = false;
                gun.SetActive(true);
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
        gun.SetActive(true);
    }

    public void exitToMenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);
        SceneManager.LoadScene(0);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void winExit()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("SavedScene", nextScene);
        SceneManager.LoadScene(0);
    }
}