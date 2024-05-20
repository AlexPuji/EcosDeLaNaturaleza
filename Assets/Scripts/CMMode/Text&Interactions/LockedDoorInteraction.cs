using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorInteraction : MonoBehaviour
{
    public float interactDistance = 2f; 
    public GameObject messageText; 
    public bool isLocked = true; 

    private bool playerInRange = false; 

    private void Update()
    {
        
        if (playerInRange)
        {
            
            if (messageText != null)
            {
                if (isLocked)
                {
                    messageText.SetActive(true); 
                }
                else
                {
                    Debug.Log("Presiona 'E' para entrar."); 
                }
            }
        }
        else
        {
            
            if (messageText != null)
            {
                messageText.SetActive(false); 
            }
        }

        
        if (playerInRange && !isLocked && Input.GetKeyDown(KeyCode.E))
        {
            
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
}
