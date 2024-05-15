using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab; 
    public int maxNumberOfBoxes = 10; 
    public Vector2 spawnArea = new Vector2(20f, 10f); 

    private int currentNumberOfBoxes; 

    void Start()
    {
        currentNumberOfBoxes = 0;
        SpawnAmmoBoxes();
    }

    public void SpawnAmmoBoxes()
    {
        for (int i = currentNumberOfBoxes; i < maxNumberOfBoxes; i++)
        {
            
            Vector3 randomPosition = new Vector3(Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f), Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f), 0f);




            Instantiate(ammoBoxPrefab, randomPosition, Quaternion.identity);
            currentNumberOfBoxes++;
        }
    }

    public void DecreaseNumberOfBoxes()
    {
        currentNumberOfBoxes--;
        if (currentNumberOfBoxes < 0)
        {
            currentNumberOfBoxes = 0;
        }
    }
}
