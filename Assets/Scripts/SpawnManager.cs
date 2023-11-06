using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bombParent;
    public float initialRespawnTime = 3.0f; 
    public float respawnTime; 
    public GameObject prefabBomb;
    public MenuManager menuManager;
    private int bombsSpawned = 0;

    void Start()
    {
        respawnTime = initialRespawnTime;
    }
   
    void Update()
    {
        if (menuManager.play == true)
        {
            respawnTime += Time.deltaTime;
            if (respawnTime > initialRespawnTime)
            {
                respawnTime = 0.0f;
                CreateNewBomb();
                bombsSpawned++;

                // fem que cada 3 bombes que spawnejin vagi tot mes rapid
                if (bombsSpawned > 3 && initialRespawnTime > 1.2)
                {
                    initialRespawnTime -= 0.4f; // Reduce spawn time
                    bombsSpawned = 0;
                }
            }
        }
    }

    private void CreateNewBomb()
    {
        if (menuManager.play == true)
        {
            Vector3 randPosition = Random.onUnitSphere * 0.5f;
            Instantiate(prefabBomb, randPosition, Quaternion.identity, bombParent.transform);
        }
    }

    public void StopSpawning()
    {
        initialRespawnTime = float.MaxValue;
        foreach (Transform child in bombParent.transform)
    {
        Destroy(child.gameObject);
    }
    }
}