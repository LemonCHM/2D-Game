using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGMGFX : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState {idle, walkF, walkB, walkS }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        // If the player is moving to the right
        if (rb.velocity.x >= 0.1f) 
        {   
            // Set the movement state to "walkS" (sidewalk)
            state = MovementState.walkS; 
            // Set the sprite's flipping to false (facing right)
            sprite.flipX = false; 
        }
            // If the player is moving to the left
        else if (rb.velocity.x <= 0.1f) 
        {
            // Set the movement state to "walkS" (sidewalk)
            state = MovementState.walkS; 
            // Set the sprite's flipping to true (facing left)
            sprite.flipX = true; 
        }
            // If the player is moving downwards (walking front or)
        else if (rb.velocity.y <= 0.1f) 
        {
            // Set the movement state to "walkF"
            state = MovementState.walkF; 
        }
            // If the player is moving upwards (walking back or up)
        else if (rb.velocity.y >= 0.1f) 
        {
            // Set the movement state to "walkB"
            state = MovementState.walkB; 
        }
            // If the player is not moving
        else 
        {
            // Set the movement state to "idle"
            state = MovementState.idle; 
        }

        /* Set the animation state to the corresponding value  
        of the movement state */
        anim.SetInteger("state", (int)state); 
    }
}
