using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    private Transform target; // Transform del objetivo

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null && playerObject.activeSelf)
        {
            target = playerObject.transform;
        }
        else
        {
            GameObject[] playerReserveObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerReserveObject in playerReserveObjects)
            {
                if (playerReserveObject.activeSelf)
                {
                    target = playerReserveObject.transform;
                    break;
                }
            }
        }

        if (target == null)
        {
            Debug.LogError("No se encontró ningún objeto activo con el tag Player");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
