using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int enemies;
    public GameObject winScreen;

    // Update is called once per frame
    void Update()
    {
        if (enemies <= 0)
        {

            StartCoroutine(nextLevel());
        }
    }

    void enemyDied()
    {
        enemies--;
    }

    private IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1f);
        winScreen.SetActive(true);
    }
}

//public void exitToMenu()
  //  {
       // currentScene = SceneManager.GetActiveScene().buildIndex;
       // PlayerPrefs.SetInt("SavedScene", currentScene);
        //SceneManager.LoadScene(0);
        //}