using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFM : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));


        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical).normalized;

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            animator.SetBool("IsRunning", true);
            animator.SetFloat("Speed", movementInput.magnitude);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1.15f, 1.15f, 1);
        }
        else if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(1.15f, 1.15f, 1);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        if (isGrounded)
        {
            rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
        }
    }
}
