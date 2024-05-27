using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalDoorInteraction : MonoBehaviour
{
    public GameObject messageText;

    private bool playerInRange = false;

    private void Start()
    {
        if (messageText != null)
        {
            messageText.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (messageText != null)
            {
                messageText.SetActive(true);
            }
        }
        else
        {
            if (messageText != null)
            {
                messageText.SetActive(false);
            }
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Llamar al método para reproducir el sonido del portal
            PortalDoorSoundController.Instance.PlayPortalSound();

            // Comenzar la corutina para cargar la escena después de que termine el sonido
            StartCoroutine(LoadNextSceneAfterSound());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private IEnumerator LoadNextSceneAfterSound()
    {
        // Esperar hasta que el sonido del portal termine de reproducirse
        yield return new WaitForSeconds(PortalDoorSoundController.Instance.GetPortalSoundDuration());

        // Descargar la escena actual y cargar la siguiente escena
        SceneManager.LoadScene("Final Scene", LoadSceneMode.Single);
    }
}
