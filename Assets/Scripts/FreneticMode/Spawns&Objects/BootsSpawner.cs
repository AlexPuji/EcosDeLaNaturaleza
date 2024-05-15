using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BootsSpawner : MonoBehaviour
{
    public GameObject bootPrefab;
    public int numberOfBoots = 10;
    public Vector2 spawnArea = new Vector2(20f, 10f);

    void Start()
    {
        SpawnBoots();
    }

    void SpawnBoots()
    {
        int maxAttempts = 100;

        for (int i = 0; i < numberOfBoots; i++)
        {
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f), Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f), 0f);

                if (IsPositionValid(randomPosition))
                {
                    Instantiate(bootPrefab, randomPosition, Quaternion.identity);
                    break;
                }
                else
                {
                    attempts++;
                }
            }

            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("No se pudo encontrar una posición válida para la bota " + (i + 1) + ". Ajusta el área de spawn o reduce el número de botas.");
                break;
            }
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);

        // Verifica si hay colisión con algún otro objeto en un radio de 1 unidad
        return colliders.Length == 0;
    }
}
