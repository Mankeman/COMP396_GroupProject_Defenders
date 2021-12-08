using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public bool timePause = false;
    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseTime()
    {
        timePause = !timePause;
        if (timePause)
        {
            WaveSpawner.gamePaused = true;
        }
        else
        {
            WaveSpawner.gamePaused = false;
        }
    }
}
