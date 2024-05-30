using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    private AmmoBoxSpawner ammoBoxSpawner;
    private CollectSoundPlayer collectSoundPlayer;

    void Start()
    {
        ammoBoxSpawner = FindObjectOfType<AmmoBoxSpawner>();
        collectSoundPlayer = GetComponent<CollectSoundPlayer>(); // Obtener el componente CollectSoundPlayer
        if (collectSoundPlayer == null)
        {
            Debug.LogWarning("CollectSoundPlayer no encontrado en el jugador.");
        }
        else if (collectSoundPlayer.collectSoundAudio == null)
        {
            Debug.LogWarning("AudioSource para el sonido de recolección no asignado en CollectSoundPlayer.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AmmoBox"))
        {
            Debug.Log("¡Caja de munición recolectada!");
            ammoBoxSpawner.DecreaseNumberOfBoxes();
            Destroy(other.gameObject);
            ammoBoxSpawner.SpawnAmmoBoxes();

            // Reproducir el sonido de recolección
            if (collectSoundPlayer != null && collectSoundPlayer.collectSoundAudio != null)
            {
                Debug.Log("Reproduciendo sonido de recolección.");
                collectSoundPlayer.PlayCollectSound();
            }
            else
            {
                Debug.LogWarning("CollectSoundPlayer o su AudioSource no está correctamente asignado.");
            }
        }
    }
}
