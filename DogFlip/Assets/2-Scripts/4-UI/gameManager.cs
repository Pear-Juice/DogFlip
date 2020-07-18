using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int enemies;

    // Update is called once per frame
    void Update()
    {
        if (enemies <= 0)
        {
            StartCoroutine("nextLevel");
        }
    }

    void enemyDied()
    {
        enemies--;
    }

    private IEnumerator nextLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
