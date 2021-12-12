using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public GameObject enemyParent;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 20f;
    private float countdown = 10f;
    public GameObject winUI;
    public Text waveCountUI;
    public GameObject pauseButton;
    public static bool gamePaused = false;
    private bool gameWon = false;

    //Figure out difficulty and set health accordingly
    private string difficulty;
    private float healthValue;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Awake()
    {
        Time.timeScale = 1f;
        difficulty = PlayerPrefs.GetString("Difficulty");
        switch (difficulty)
        {
            case "Easy":
                healthValue = 50f;
                return;
            case "Medium":
                healthValue = 100f;
                return;
            case "Hard":
                healthValue = 200f;
                return;
            default:
                healthValue = 100f;
                break;
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        Update();
    }
    void Update()
    {
        waveCountUI.text = "Round " + PlayerStats.Rounds;
        if (gameWon && enemyParent.transform.childCount <= 0)
        {
            winUI.SetActive(true);
            pauseButton.SetActive(false);
            this.enabled = false;
        }
        if (enemiesAlive > 0 || enemyParent.transform.childCount > 0)
        {
            countdown = timeBetweenWaves;
            return;
        }
        if(PlayerStats.Rounds >=waves.Length)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        if (gamePaused)
        {
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        if(PlayerStats.Rounds >= waves.Length)
        {
            gameWon = true;
        }
        waveIndex++;
    }
    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        newEnemy.GetComponent<Enemy>().startHealth = newEnemy.GetComponent<Enemy>().startHealth + (healthValue * waveIndex);
        enemiesAlive++;
        newEnemy.transform.parent = enemyParent.transform;
    }
}
