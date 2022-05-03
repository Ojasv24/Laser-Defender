using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameStatus gameStatus;

    void Start()
    {
        scoreText = GetComponent<Text>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    void Update()
    {
        scoreText.text = gameStatus.GetScore().ToString(); 
    }
}
