using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject monsterPrefab;
    public int numberOfMonsters = 50;
    public GameObject[] groundObjects;

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
                //Area pr respawn del terra 
                Bounds bounds = groundCollider.bounds;


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
