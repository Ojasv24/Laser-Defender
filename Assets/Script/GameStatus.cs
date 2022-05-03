using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int Addscore)
    {
        score += Addscore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
