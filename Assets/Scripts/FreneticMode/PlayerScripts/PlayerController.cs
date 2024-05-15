using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;//vida del pj
    private float currentHealth;

    private float moveSpeed = 5f; //velocitat

    private static PlayerController instance;

    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            
            Destroy(gameObject);
        }
        else
        {
            
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //sistema de vida 
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player takes damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        gameObject.SetActive(false);
        
    }

    private void Update()
    {
        //intent per delimitar el moviment del personatge dins el area del mapa 
        MapAreaBounds areaBounds = FindObjectOfType<MapAreaBounds>();
        if (areaBounds != null)
        {
            
            Vector2 minBounds = areaBounds.minBounds;
            Vector2 maxBounds = areaBounds.maxBounds;

            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            
            Vector3 desiredPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

            
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            
            transform.position = desiredPosition;
        }
    }
}
