using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float waitSeconds = 1f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(DealyGameOverScene());
    }

    public void LoadGameScene()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator DealyGameOverScene()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(2);   
    }
} 


