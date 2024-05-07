using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnlvl1CM : MonoBehaviour
{
    public GameObject monsterPrefab; // Prefab del monstruo que quieres instanciar
    public int numberOfMonsters = 50; // Número de monstruos que quieres instanciar
    public GameObject[] groundObjects; // Array de objetos que actúan como suelo

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        foreach (GameObject groundObject in groundObjects)
        {
            Collider2D groundCollider = groundObject.GetComponent<Collider2D>();
            if (groundCollider != null)
            {
                // Obtener el área del objeto de suelo
                Bounds bounds = groundCollider.bounds;

                // Instanciar los monstruos dentro del área del objeto de suelo
                for (int i = 0; i < numberOfMonsters; i++)
                {
                    Vector2 spawnPoint = new Vector2(
                        Random.Range(bounds.min.x, bounds.max.x),
                        Random.Range(bounds.min.y, bounds.max.y)
                    );
                    Instantiate(monsterPrefab, spawnPoint, Quaternion.identity);
                }
            }
        }
    }

}
