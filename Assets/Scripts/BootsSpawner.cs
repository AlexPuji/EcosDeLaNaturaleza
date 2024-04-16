using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BootsSpawner : MonoBehaviour
{
    public GameObject bootPrefab; // Prefab de la bota
    public int numberOfBoots = 10; // Número de botas a spawnear
    public Tilemap tilemap; // Referencia al Tilemap donde se generarán las botas

    void Start()
    {
        SpawnBoots();
    }

    void SpawnBoots()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        int maxAttempts = 100; // Límite de intentos para evitar bucle infinito

        for (int i = 0; i < numberOfBoots; i++)
        {
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Vector3Int randomPosition = new Vector3Int(
                    Random.Range(bounds.xMin, bounds.xMax),
                    Random.Range(bounds.yMin, bounds.yMax),
                    bounds.z);

                // Verificar si la posición aleatoria está sobre un tile
                if (IsTileWalkable(randomPosition, bounds, allTiles))
                {
                    Vector3 spawnPosition = tilemap.GetCellCenterWorld(randomPosition);
                    Instantiate(bootPrefab, spawnPosition, Quaternion.identity);
                    break; // Salir del bucle while si se encuentra una posición válida
                }
                else
                {
                    attempts++;
                }
            }

            // Verificar si se superó el límite de intentos
            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("No se pudo encontrar una posición válida para la bota " + (i + 1) + ". Ajusta el área del tilemap o reduce el número de botas.");
                break; // Salir del bucle for
            }
        }
    }

    bool IsTileWalkable(Vector3Int position, BoundsInt bounds, TileBase[] tiles)
    {
        if (bounds.Contains(position))
        {
            TileBase tile = tiles[position.x - bounds.xMin + (position.y - bounds.yMin) * bounds.size.x];

            // Si el tile es nulo o no es transitable, devuelve false
            return (tile != null);
        }
        else
        {
            return false;
        }
    }
}
