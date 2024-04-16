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
            // Recolectar la caja de munici�n y realizar las acciones necesarias
            Debug.Log("�Caja de munici�n recolectada!");
            ammoBoxSpawner.DecreaseNumberOfBoxes(); // Disminuir el n�mero de cajas de munici�n
            Destroy(other.gameObject); // Destruir la caja de munici�n despu�s de recolectarla
            ammoBoxSpawner.SpawnAmmoBoxes(); // Llamar a la funci�n para spawnear nuevas cajas de munici�n
            // Agregar l�gica para aumentar la munici�n, etc.
        }
    }
}
