using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float maxJumpForce = 20f;
    public float wallBounceForce = 7f;
    private bool isGrounded = false;
    private bool isChargingJump = false;
    private bool hasJumped = false;
    private float chargeDirection = 0f;
    
    
    
    private Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (!isChargingJump && !hasJumped)
        {
            float move = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(move * moveSpeed, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isChargingJump = true;
            chargeDirection = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isChargingJump)
        {
            isChargingJump = false;
            hasJumped = true;
            jumpForce = Mathf.Min(jumpForce, maxJumpForce);
            rb2d.velocity = new Vector2(chargeDirection * moveSpeed, jumpForce);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collion2d)
    {
        if (collion2d.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasJumped = false;
        }

        if (collion2d.gameObject.CompareTag("Wall") && hasJumped)
        {
            Vector2 bounceDirection = collion2d.contacts[0].normal + Vector2.up;
            rb2d.velocity = bounceDirection.normalized * wallBounceForce;
        }
    }

    void OnCollisionExit2D(Collision2D collion2d)
    {
        if (collion2d.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
