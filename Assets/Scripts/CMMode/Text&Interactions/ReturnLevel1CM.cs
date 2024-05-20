using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToWorld : MonoBehaviour
{
    public Text messageText; 

    private bool playerInRange = false; 

    private void Start()
    {
        
        messageText.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (playerInRange)
        {
            messageText.gameObject.SetActive(true);
        }
        else
        {
            messageText.gameObject.SetActive(false);
        }

        
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            
            SceneManager.LoadScene("Level 1 CM");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            playerInRange = true;
            Debug.Log("Player entered trigger zone."); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            playerInRange = false;
            Debug.Log("Player exited trigger zone."); 
        }
    }
}
