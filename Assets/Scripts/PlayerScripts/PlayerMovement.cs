using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Tilemap tilemap;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical);
    }

    void FixedUpdate()
    {
        
        MovePlayer();
    }

    void MovePlayer()
    {
        
        movementInput.Normalize();

        Vector2 newPosition = rb.position + movementInput * speed * Time.fixedDeltaTime;

        
        if (tilemap.HasTile(tilemap.WorldToCell(newPosition)))
        {
            
            rb.MovePosition(newPosition);
        }

    }
    
    
}

