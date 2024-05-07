using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionDistance = 5f; // The distance at which the enemy will detect the player
    public float movementSpeed = 3f; // The speed at which the enemy will move towards the player
    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Finding the player by their tag
        rb = GetComponent<Rigidbody2D>(); // Getting the Rigidbody2D component
        rb.freezeRotation = true; // Freezing the rotation of the enemy
    }

    void Update()
    {
        // Calculating the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within the detection distance
        if (distanceToPlayer < detectionDistance)
        {
            // Calculating the direction towards which the enemy should move
            Vector2 direction = (player.position - transform.position).normalized;

            // Moving the enemy towards the player
            rb.velocity = direction * movementSpeed;
        }
        else
        {
            // Stop the enemy if the player is not within the detection distance
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ignore collision with the player, so the enemy won't be affected by it
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
