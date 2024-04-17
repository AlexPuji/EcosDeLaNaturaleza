using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    private AmmoBoxSpawner ammoBoxSpawner;

    void Start()
    {
        ammoBoxSpawner = FindObjectOfType<AmmoBoxSpawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AmmoBox"))
        {
            
            Debug.Log("¡Caja de munición recolectada!");
            ammoBoxSpawner.DecreaseNumberOfBoxes(); 
            Destroy(other.gameObject); 
            ammoBoxSpawner.SpawnAmmoBoxes(); 
            
        }
    }
}
