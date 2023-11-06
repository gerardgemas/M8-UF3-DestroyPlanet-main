using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioClip explosionSound;
    public AudioClip defusalSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    private AudioSource audioSource;
    private bool end = false;
    public GameManager gameManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        gameManager.ScoreIncreased += PlayDefusalSound;
        gameManager.LivesDecreased += PlayExplosionSound;
    }
    public void Update()
    {
        if (gameManager.lives == 0 && gameManager.score < PlayerPrefs.GetInt("HighScore", 0) && !end )
        {
            PlayLoseSound();
            end = true;
        }
        else if (gameManager.lives == 0 && gameManager.score > PlayerPrefs.GetInt("HighScore", 0) && !end)
        {
            PlayWinSound();
            end = true;
        }
    }
    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayDefusalSound()
    {
        audioSource.PlayOneShot(defusalSound);
    }
    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }
    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

}