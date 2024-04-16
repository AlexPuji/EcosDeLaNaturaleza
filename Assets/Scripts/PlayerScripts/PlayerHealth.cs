using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5; 
    public int currentLives; 

    void Start()
    {
        currentLives = maxLives;
    }

    
    public void ReceiveHit()
    {
        
        currentLives--;

        
        Debug.Log("El jugador ha recibido un golpe. Vidas restantes: " + currentLives);

        
        if (currentLives <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {
        
        gameObject.SetActive(false);

        
        Debug.Log("El jugador ha muerto");
        
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            ReceiveHit();
        }
    }
}

