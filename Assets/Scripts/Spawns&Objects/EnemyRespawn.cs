using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{

    public float initialDelay = 3f;
    public float waveInterval = 10f;
    public GameObject enemyPrefab;
    public int maxEnemiesPerWave = 5;

    public string spawnerType = "FirstSpawner"; 
    public EnemyRespawn[] newSpawners; 
    private bool spawnerActive = true;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialDelay);

        while (spawnerActive)
        {
            yield return StartCoroutine(SpawnWave());
            yield return new WaitForSeconds(waveInterval);
        }

        Debug.Log("El spawner se detuvo.");

        
        spawnerActive = false;
        gameObject.SetActive(false);

        
        foreach (var spawner in newSpawners)
        {
            if (spawner.spawnerType == "SecondSpawner") 
            {
                StartCoroutine(ActivateSpawner(spawner));
            }
        }
    }

    IEnumerator ActivateSpawner(EnemyRespawn spawner)
    {
        yield return new WaitForSeconds(10f); 

        spawner.gameObject.SetActive(true); 
        Debug.Log("Spawner activado: " + spawner.name);
    }

    IEnumerator SpawnWave()
    {
        if (enemyPrefab == null)
        {
            yield break; 
        }

        int enemiesToSpawn = Random.Range(1, maxEnemiesPerWave + 1);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); 
        }

        Debug.Log("Se generó una oleada de " + enemiesToSpawn + " enemigos.");

        
        yield return new WaitForSeconds(1f);
    }

}
