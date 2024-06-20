using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieEnemy : MonoBehaviour
{
    public int maxHealth = 50; 
    private int currentHealth; 

    
    public Slider healthSlider;
    public GameObject healthSliderGameObject; 

    private void Start()
    {
        currentHealth = maxHealth;

        
        healthSliderGameObject.SetActive(false);

        
        healthSlider.maxValue = maxHealth;
        
        healthSlider.value = currentHealth;
    }

    //funcio per el dmg del pj al zombie
    public void TakeDamage(int damageAmount)
    {
        
        if (!healthSliderGameObject.activeSelf)
        {
            healthSliderGameObject.SetActive(true);
        }

        currentHealth -= damageAmount;
        Debug.Log("Zombie takes " + damageAmount + " damage. Current health: " + currentHealth);

        
        healthSlider.value = currentHealth;

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    private void Die()
    {
        Debug.Log("Zombie has died.");

        //desactiva la barra de vida
        healthSliderGameObject.SetActive(false);

        
        Destroy(gameObject);
    }
}
