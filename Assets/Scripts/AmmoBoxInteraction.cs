using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxInteraction : MonoBehaviour
{
    public int ammoAmount = 40; // Cantidad de munición que proporciona la caja

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador ha recogido una caja de munición!");

            // Obtener el componente AmmoText del Canvas
            AmmoText playerAmmo = FindObjectOfType<AmmoText>();

            if (playerAmmo != null)
            {
                // Restablecer la munición al máximo
                playerAmmo.currentAmmo = playerAmmo.maxAmmo;
                Debug.Log("¡Munición restablecida al máximo!");

                // Actualizar la UI de munición del jugador
                playerAmmo.UpdateAmmoUI();

                // Destruir la caja de munición después de recogerla
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("No se encontró el componente AmmoText.");
            }
        }
    }
}
