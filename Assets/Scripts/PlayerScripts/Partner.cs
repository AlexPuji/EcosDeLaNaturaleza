using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 5f; 
    public float shootingRange = 10f; 
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
    public float fireRate = 1f; 
    public float followDistance = 2f; 
    private float nextFireTime = 0f; 

    void Update()
    {
        
        if (target != null)
        {
            
            Vector3 targetPosition = target.position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, shootingRange);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    
                    Shoot(collider.transform.position);
                    break;
                }
            }

            
            Vector3 targetPositionWithDistance = targetPosition - moveDirection * followDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPositionWithDistance, moveSpeed * Time.deltaTime);
        }
    }

    void Shoot(Vector3 targetPosition)
    {
        
        if (Time.time >= nextFireTime)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            
            Vector3 shootDirection = (targetPosition - transform.position).normalized;

            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = shootDirection * bulletSpeed;

            nextFireTime = Time.time + 1f / fireRate; 
        }
    }
}
