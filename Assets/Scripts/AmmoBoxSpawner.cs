using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab; // Prefab de la caja de munición
    public int maxNumberOfBoxes = 10; // Número máximo de cajas de munición en el mapa
    public Vector2 spawnArea = new Vector2(20f, 10f); // Tamaño del área de spawn

    private int currentNumberOfBoxes; // Número actual de cajas de munición en el mapa

    void Start()
    {
        currentNumberOfBoxes = 0;
        SpawnAmmoBoxes();
    }

    public void SpawnAmmoBoxes()
    {
        for (int i = currentNumberOfBoxes; i < maxNumberOfBoxes; i++)
        {
            // Generar una posición aleatoria dentro del área de juego
            Vector3 randomPosition = new Vector3(Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f),
                                                 Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f),
                                                 0f);

            // Instanciar la caja de munición en la posición aleatoria
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
