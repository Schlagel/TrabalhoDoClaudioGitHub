using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidade de movimento do jogador
    public float moveSpeed = 5f;
    // Força do pulo do jogador
    public float jumpForce = 10f;

    // Referência ao Rigidbody do jogador
    private Rigidbody2D rb;
    // Verifica se o jogador está no chão
    private bool isGrounded;

    // Referência ao Collider do jogador
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        // Obtém a referência ao Rigidbody do jogador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Movimento horizontal do jogador
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Verifica se o jogador pode pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}