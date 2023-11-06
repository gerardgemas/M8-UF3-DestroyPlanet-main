using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float timeToExplosion = 4.0f;
    private float timer = 0.0f;
    private GameManager gm = null;
    public GameObject prefabExplosion;
    private AudioSource audioSource;

    // Define AudioClip fields for explosion and defusal sounds
    public AudioClip explosionSound;
    public AudioClip defusalSound;

    void Start()
    {
        GameObject o = GameObject.FindGameObjectWithTag("GameManager");
        audioSource = gameObject.AddComponent<AudioSource>();
       
        if (o == null)
        {
            Debug.LogError("There's no gameObject with GameManager tag.");
        }
        else
        {
            gm = o.GetComponent<GameManager>();
            if (gm == null)
            {
                Debug.LogError("The GameObject with GameManager tag doesn't have the GameManager script attached to it");
            }
        }

        GetComponent<MeshRenderer>().material.color = Color.black;
        transform.LookAt(transform.parent);

    }

    // Update is called once per frame
    void Update()
    {
        //Si han passat 4 segons --> Destroy this gameObject & damage using GameManeger:
        timer += Time.deltaTime;
        if (timer > timeToExplosion)
        {
            timer = 0.0f;
            gm.TakeDamage();
            GameObject.Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            PlayExplosionSound(); // Play the explosion sound
            Destroy(gameObject);
        }

        Color newColor = Color.Lerp(Color.black, Color.red, timer / timeToExplosion);
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    //Si l'usuari fa click sobre la bomba=>
    // Destroy
    private void OnMouseDown()
    {
        gm.AddScore();
        PlayDefusalSound();
        Destroy(gameObject);
        
    }

    public void PlayExplosionSound()
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayDefusalSound()
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(defusalSound);
    }
}
