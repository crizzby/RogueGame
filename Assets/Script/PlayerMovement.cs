using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the Rigidbody2D component for applying physics to the player
    public Rigidbody2D rb;

    // Speed at which the player moves horizontally
    // Variable to store horizontal movement input
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    // Force applied to the player when they jump
    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    int jumpsRemaining;

    // Position of the ground check to detect if the player is grounded
    // Size of the ground check box
    // Layer mask to specify which layers count as ground
    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 10f;
    public float fallSpeedMultiplier = 2f;

    // Update is called once per frame
    void Update()
    {
        // Set the player's horizontal velocity based on input and movement speed
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
        GroundCheck();
        Gravity();
    }
    private void Gravity()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    // Method called when the player moves (input action)
    public void Move(InputAction.CallbackContext context)
    {
        // Read the horizontal input value (x component of a Vector2)
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    // Method called when the player jumps (input action)
    public void Jump(InputAction.CallbackContext context)
    {
        // Check if the player is grounded before allowing them to jump
        if (jumpsRemaining > 0)
        {
        
            // If the jump action is performed (button pressed)
            if (context.performed)
            {
                // Apply vertical velocity to the player for jumping
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsRemaining--;
            }
            // If the jump action is canceled (button released)
            else if (context.canceled)
            {
                // Reduce the upward velocity to create a jump cut-off effect
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemaining--;
            }
        }
    } //mistakes were made

    // Method to check if the player is grounded
    private void GroundCheck()
    {
        // Check for collisions with the ground layer at the ground check position
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
        
    }

    // Method to draw gizmos in the editor for the ground check position and size
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
