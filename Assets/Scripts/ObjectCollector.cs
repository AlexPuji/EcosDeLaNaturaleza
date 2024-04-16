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
            // Recolectar la caja de munición y realizar las acciones necesarias
            Debug.Log("¡Caja de munición recolectada!");
            ammoBoxSpawner.DecreaseNumberOfBoxes(); // Disminuir el número de cajas de munición
            Destroy(other.gameObject); // Destruir la caja de munición después de recolectarla
            ammoBoxSpawner.SpawnAmmoBoxes(); // Llamar a la función para spawnear nuevas cajas de munición
            // Agregar lógica para aumentar la munición, etc.
        }
    }
}
