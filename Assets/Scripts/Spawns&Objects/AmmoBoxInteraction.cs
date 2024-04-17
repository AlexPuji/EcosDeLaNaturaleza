using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxInteraction : MonoBehaviour
{
    public int ammoAmount = 40; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador ha recogido una caja de munición!");

           
            AmmoText playerAmmo = FindObjectOfType<AmmoText>();

            if (playerAmmo != null)
            {
                
                playerAmmo.currentAmmo = playerAmmo.maxAmmo;
                Debug.Log("¡Munición restablecida al máximo!");

                
                playerAmmo.UpdateAmmoUI();

                
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("No se encontró el componente AmmoText.");
            }
        }
    }
}
