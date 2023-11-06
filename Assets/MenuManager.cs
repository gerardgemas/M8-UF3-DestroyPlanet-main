using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject PlayButton;
    public GameObject MainMenu;
    public GameObject InGameMenu;
    public GameObject loseMenu;
    public GameObject winMenu;
    public SpawnManager spawnManager;
    public TMP_Text HighSocre;
    public TMP_Text newHighScore;
    public TMP_Text score;
    public Image fons;
    public bool play;


    void Start()
    {
        int highestScore = PlayerPrefs.GetInt("HighScore", 0); 
        HighSocre.text = "Highest Score: " + highestScore; 
    }

   
    void Update()
    {

    }

    public void StartGame()
    {
        play = true;
        MainMenu.SetActive(false);
        InGameMenu.SetActive(true);
        fons.enabled = false;
        gameManager.lives=3;
        gameManager.score=0;
        spawnManager.initialRespawnTime = 3.0f;
        spawnManager.respawnTime = 0.0f;
        gameManager.UpdateLivesUI();
        gameManager.UpdateScoreUI();
    }
    public void Win()
    {
        play = true;
        fons.enabled = true;
        winMenu.SetActive(true);
        int highestScore = PlayerPrefs.GetInt("HighScore", 0);
        newHighScore.text = "new HighScore: " + highestScore;
    }
    public void Lose()
    {
        play = true;
        fons.enabled = true;
        loseMenu.SetActive(true);
        score.text = "Your Score: " + gameManager.score;
    }

        public void BackToMenu()
    {
        play = false;
        MainMenu.SetActive(true);
        InGameMenu.SetActive(false);
        fons.enabled = true;
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        gameManager.score = 0;
        gameManager.lives = 3;
        spawnManager.initialRespawnTime = 3.0f;
        spawnManager.respawnTime = 0.0f;
        gameManager.UpdateLivesUI();
    }
    public void restart()
    {
        play = true;
        fons.enabled = false;
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        gameManager.score = 0;
        gameManager.lives = 3;
        spawnManager.initialRespawnTime = 3.0f;
        spawnManager.respawnTime = 0.0f;
        gameManager.UpdateLivesUI();
        gameManager.UpdateScoreUI();
    }
}