using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemObject : MonoBehaviour
{
    public GameObject interactionMessage; 
    public int healingAmount = 20; 
    private bool playerIsNear = false;

    private void Start()
    {
        interactionMessage.SetActive(false); 
    }

    private void Update()
    {
        
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Se ha presionado la tecla E.");
            HealPlayer();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            interactionMessage.SetActive(true); 
            Debug.Log("El jugador está cerca de la poción.");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            interactionMessage.SetActive(false); 
            Debug.Log("El jugador se ha alejado de la poción.");
        }
    }

    
    private void HealPlayer()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>(); 
        if (playerController != null)
        {
            playerController.Heal(healingAmount); 
            Destroy(gameObject); 
            Debug.Log("El jugador ha sido curado.");
        }
        else
        {
            Debug.LogError("No se encontró el script PlayerController en la escena.");
        }
    }
}
