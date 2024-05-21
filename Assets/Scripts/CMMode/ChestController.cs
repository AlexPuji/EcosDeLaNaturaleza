using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite closedChestSprite;
    public Sprite openChestSprite;
    public GameObject interactionMessage; // Referencia al objeto de texto
    public GameObject[] itemsToSpawn; // Array de prefabs de los objetos a soltar
    public int numberOfItemsToSpawn = 5; // Número de objetos a soltar
    public float spawnRadius = 1.0f; // Radio alrededor del cofre para soltar los objetos

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    private bool playerIsNear = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChestSprite;
        interactionMessage.SetActive(false); // Asegúrate de que el mensaje esté desactivado al inicio
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openChestSprite;
        interactionMessage.SetActive(false);
        SpawnItems(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            playerIsNear = true;
            interactionMessage.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            interactionMessage.SetActive(false); 
        }
    }

    void SpawnItems()
    {
        if (isOpen)
        {
            for (int i = 0; i < numberOfItemsToSpawn; i++)
            {
               
                GameObject itemToSpawn = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
                
                Vector3 spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
                
                if (itemToSpawn != null)
                {
                    Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
