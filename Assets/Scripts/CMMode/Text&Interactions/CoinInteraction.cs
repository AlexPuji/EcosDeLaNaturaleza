using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObjectCollector playerCoinCollector = other.GetComponent<PlayerObjectCollector>(); 
            if (playerCoinCollector != null)
            {
                playerCoinCollector.CollectObject(); 
                Destroy(gameObject); 
            }
        }
    }
}
