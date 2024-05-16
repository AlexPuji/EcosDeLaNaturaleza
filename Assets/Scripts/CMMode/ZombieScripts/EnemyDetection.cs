using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionDistance = 5f; 
    public float movementSpeed = 3f; 
    public float roamSpeed = 1f; 
    public float roamInterval = 1.5f; 
    private Transform player; 
    private Animator animator;
    private bool isMoving = false;
    private Vector3 roamDirection; 
    private float nextRoamTime; 
    private Rigidbody2D rb; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 

        
        roamDirection = Random.insideUnitCircle.normalized;
        nextRoamTime = Time.time + Random.Range(0f, roamInterval);
    }

    void Update()
    {
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        
        if (distanceToPlayer < detectionDistance)
        {
            
            Vector2 direction = (player.position - transform.position).normalized;

            
            if (direction.x > 0)
            {
                // Mirando hacia la derecha
                transform.localScale = new Vector3(-0.75f, 0.75f, 1); 
            }
            else if (direction.x < 0)
            {
                // Mirando hacia la izquierda
                transform.localScale = new Vector3(0.75f, 0.75f, 1); 
            }

            
            rb.velocity = direction * movementSpeed;

            
            isMoving = true;
        }
        else
        {
            
            Roam();

            
            animator.SetBool("IsMoving", isMoving);
        }
    }

    // Sistema movimiento direcciones
    void Roam()
    {
        
        if (Time.time >= nextRoamTime)
        {
            
            roamDirection = Random.insideUnitCircle.normalized;

            
            nextRoamTime = Time.time + roamInterval;
        }

        
        rb.velocity = roamDirection * roamSpeed;

        
        isMoving = true;
    }

    // empuje contrario para no permitir que un choque lo noquee
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Vector2 pushBackForce = -(collision.transform.position - transform.position).normalized * movementSpeed * 2f;
            rb.AddForce(pushBackForce, ForceMode2D.Impulse);
        }
    }
}
