using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidade de movimento do jogador
    public float moveSpeed = 5f;
    // For�a do pulo do jogador
    public float jumpForce = 10f;

    // Refer�ncia ao Rigidbody do jogador
    private Rigidbody2D rb;
    // Verifica se o jogador est� no ch�o
    private bool isGrounded;

    // Refer�ncia ao Collider do jogador
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        // Obt�m a refer�ncia ao Rigidbody do jogador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o jogador est� no ch�o
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