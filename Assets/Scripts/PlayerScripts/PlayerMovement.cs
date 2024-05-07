using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //identificar suelo
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));

        //movimiento del personaje
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical).normalized;
        
        if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Mover al jugador con contacto al suelo
        if (isGrounded)
        {
            rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
        }
    }
}

