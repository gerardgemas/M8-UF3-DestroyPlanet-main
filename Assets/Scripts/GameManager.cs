using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;

    public TMP_Text lbl_Score;
    public TMP_Text lbl_Lives;
    

    public event Action ScoreIncreased;
    public event Action LivesDecreased;
    public MenuManager MenuManager;
    public SpawnManager spawnManager; 
    private bool shouldStopSpawning = false; 

 
    void Start()
    {
        UpdateScoreUI();
        UpdateLivesUI();
    }


    void Update()
    {
 
        if (lives <= 0 && !shouldStopSpawning)
        {
            // Stop spawning
            shouldStopSpawning = true;
            spawnManager.StopSpawning();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                MenuManager.Win();
            }
            else
            {
                MenuManager.Lose();
            }
        }
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();
        ScoreIncreased?.Invoke(); 
    }

    public void TakeDamage()
    {
        lives--;
        UpdateLivesUI();
        LivesDecreased?.Invoke(); 
    }

    private void UpdateScoreUI()
    {
        lbl_Score.text = "Score: " + score;
    }

    
    private void UpdateLivesUI()
    {
        lbl_Lives.text = "Lives: " + lives;
    }
}