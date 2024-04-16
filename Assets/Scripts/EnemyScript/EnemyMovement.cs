using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    private Transform player;

    
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningun objeto con el tag Player"); //Quitar
        }
    }

    
    void Update()
    {
        if(player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        
    }
}
