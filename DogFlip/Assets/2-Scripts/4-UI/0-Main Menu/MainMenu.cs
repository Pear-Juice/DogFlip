using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int sceneContinue;

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        sceneContinue = PlayerPrefs.GetInt("SavedScene");

        if(sceneContinue != 0)
        
        SceneManager.LoadScene(sceneContinue);
        else return;
        
    }

    public void LevelSelect(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    public void GameExit()
    {
        Application.Quit();
    }
}
