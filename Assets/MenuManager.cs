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
    }
    public void Win()
    {
        fons.enabled = true;
        winMenu.SetActive(true);
        int highestScore = PlayerPrefs.GetInt("HighScore", 0);
        newHighScore.text = "new HighScore: " + highestScore;
    }
    public void Lose()
    {
        fons.enabled = true;
        loseMenu.SetActive(true);
        score.text = "Your Score: " + gameManager.score;
    }
}