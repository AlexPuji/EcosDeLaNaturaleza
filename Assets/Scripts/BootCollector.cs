using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootCollector : MonoBehaviour
{
    public int bootsCollected = 0; // Contador de botas recolectadas
    public int bootsToCollect = 10; // Número total de botas a recolectar
    public MissionBoots missionBoots; // Referencia al controlador de texto
    private bool missionCompleted = false; // Variable para controlar si se completó la misión

    void Start()
    {
        // Actualizar el texto inicialmente
        missionBoots.UpdateBootText(bootsCollected, bootsToCollect);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!missionCompleted && other.CompareTag("Boot") && bootsCollected < bootsToCollect)
        {
            // Recolectar la bota y realizar las acciones necesarias
            bootsCollected++;
            missionBoots.UpdateBootText(bootsCollected, bootsToCollect);
            Destroy(other.gameObject); // Destruir la bota recolectada

            // Verificar si se han recolectado todas las botas
            if (bootsCollected >= bootsToCollect)
            {
                // Mostrar mensaje de "Botas recogidas, llévalas al ladrón"
                Debug.Log("Botas recogidas, llévalas al ladrón");
                missionCompleted = true; // Marcar la misión como completada
            }
        }
    }
}
