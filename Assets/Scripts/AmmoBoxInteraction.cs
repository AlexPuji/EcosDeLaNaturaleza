using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxInteraction : MonoBehaviour
{
    public int ammoAmount = 40; // Cantidad de munici�n que proporciona la caja

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�El jugador ha recogido una caja de munici�n!");

            // Obtener el componente AmmoText del Canvas
            AmmoText playerAmmo = FindObjectOfType<AmmoText>();

            if (playerAmmo != null)
            {
                // Restablecer la munici�n al m�ximo
                playerAmmo.currentAmmo = playerAmmo.maxAmmo;
                Debug.Log("�Munici�n restablecida al m�ximo!");

                // Actualizar la UI de munici�n del jugador
                playerAmmo.UpdateAmmoUI();

                // Destruir la caja de munici�n despu�s de recogerla
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("No se encontr� el componente AmmoText.");
            }
        }
    }
}
