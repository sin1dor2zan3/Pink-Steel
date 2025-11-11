using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText; // <-- Add this for the score display

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;

        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateCoin", 2, 5);

        UpdateScoreText(); // <-- Initialize the score display at start
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0),
            Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab,
                new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
                            Random.Range(-verticalScreenSize, verticalScreenSize), 0),
                Quaternion.identity);
        }
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0),
            Quaternion.identity);
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        UpdateScoreText(); // <-- Update whenever score changes
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // <-- Actual text update
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
