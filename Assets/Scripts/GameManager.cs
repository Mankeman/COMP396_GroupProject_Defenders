using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public bool timePause = false;
    public GameObject gameOverUI;
    public WaveSpawner waveSpawner;
    public Text fastForwardButtonText;
    private float timeScaler = 1f;

    private void Start()
    {
        GameIsOver = false;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseTime();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayTime();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            FastForwardTime();
        }
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
            PlayTime();
        }
    }
    public void PlayTime()
    {
        Time.timeScale = 1f;
        timeScaler = 1f;
        WaveSpawner.gamePaused = false;
        waveSpawner.PlayGame();
        CheckFF_UI();
    }
    public void FastForwardTime()
    {
        timeScaler++;
        if (timeScaler >= 5f)
        {
            timeScaler = 1f;
        }
        Time.timeScale = timeScaler;
        CheckFF_UI();
    }
    public void CheckFF_UI()
    {
        switch (timeScaler)
        {
            case 1f:
                fastForwardButtonText.text = "x1";
                break;
            case 2f:
                fastForwardButtonText.text = "x2";
                break;
            case 3f:
                fastForwardButtonText.text = "x3";
                break;
            case 4f:
                fastForwardButtonText.text = "x4";
                break;
            default:
                fastForwardButtonText.text = "Error";
                break;
        }
    }
}
