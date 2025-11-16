using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs & Objects")]
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject powerupPrefab;
    public GameObject audioPlayer;   // Object with AudioSource

    [Header("Audio Clips")]
    public AudioClip powerupSound;
    public AudioClip powerdownSound;

    [Header("UI")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerupText;

    [Header("Gameplay Variables")]
    public float horizontalScreenSize;
    public float verticalScreenSize;
    public int score;
    public int cloudMove;

    private bool gameOver;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        cloudMove = 1;
        gameOver = false;

        AddScore(0);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);

        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        StartCoroutine(SpawnPowerup());

        powerupText.text = "No powerups yet!";
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void CreateEnemy()
    {
        Instantiate(
            enemyOnePrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0),
            Quaternion.Euler(180, 0, 0)
        );
    }

    void CreatePowerup()
    {
        Instantiate(
            powerupPrefab,
            new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f),
                        Random.Range(-verticalScreenSize * 0.8f, verticalScreenSize * 0.8f), 
                        0),
            Quaternion.identity
        );
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(
                cloudPrefab,
                new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
                            Random.Range(-verticalScreenSize, verticalScreenSize),
                            0),
                Quaternion.identity
            );
        }
    }

    public void ManagePowerupText(int powerupType)
    {
        switch (powerupType)
        {
            case 1:
                powerupText.text = "Speed!";
                break;
            case 2:
                powerupText.text = "Double Weapon!";
                break;
            case 3:
                powerupText.text = "Triple Weapon!";
                break;
            case 4:
                powerupText.text = "Shield!";
                break;
            default:
                powerupText.text = "No powerups yet!";
                break;
        }
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }

    // 🔊 PLAY SOUNDS — Task 2 Completed
    public void PlaySound(int whichSound)
    {
        AudioSource source = audioPlayer.GetComponent<AudioSource>();

        switch (whichSound)
        {
            case 1:
                source.PlayOneShot(powerupSound);   // ⬅️ POWER-UP SOUND
                break;
            case 2:
                source.PlayOneShot(powerdownSound); // ⬅️ POWER-DOWN SOUND
                break;
        }
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
        cloudMove = 0;
    }
}
