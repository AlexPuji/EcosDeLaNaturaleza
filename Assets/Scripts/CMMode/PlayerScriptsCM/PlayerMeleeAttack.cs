using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeleeAttack : MonoBehaviour
{
    public GameObject meleeAttackPrefab; 
    public float meleeAttackInterval = 1f; //intrval entre cada atac

    private float lastMeleeAttackTime;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > lastMeleeAttackTime + meleeAttackInterval)
        {
            
            PerformMeleeAttack();
            
            lastMeleeAttackTime = Time.time;
        }
    }

    void PerformMeleeAttack()
    {
        //Posicio del mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 direction = (mousePosition - transform.position).normalized;

        
        GameObject meleeAttack = Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);

        //rigidbody del attack a melee
        Rigidbody2D rb = meleeAttack.GetComponent<Rigidbody2D>();
        
        rb.velocity = direction * 3f;

        
        Destroy(meleeAttack, 0.3f); 
    }

    
}
