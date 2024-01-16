using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private float dirX = 0f;
    private float dirY = 0f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    Vector2 movement;

    private enum MovementState {idle, walkF, walkB, walkS }


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        dirX = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        dirY = Input.GetAxisRaw("Vertical");

        UpdateAnimationState();
        attackUpdate();
    }


    // Fixed Update is same as void update but its with a certain refresh rate in time
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

     //animation
    private void UpdateAnimationState()
    {
        MovementState state;
        // If the player is moving to the right
        if (dirX > 0f) 
        {   
            // Set the movement state to "walkS" (sidewalk)
            state = MovementState.walkS; 
            // Set the sprite's flipping to false (facing right)
            sprite.flipX = false; 
        }
            // If the player is moving to the left
        else if (dirX < 0f) 
        {
            // Set the movement state to "walkS" (sidewalk)
            state = MovementState.walkS; 
            // Set the sprite's flipping to true (facing left)
            sprite.flipX = true; 
        }
            // If the player is moving downwards (walking front or)
        else if (dirY < 0f) 
        {
            // Set the movement state to "walkF"
            state = MovementState.walkF; 
        }
            // If the player is moving upwards (walking back or up)
        else if (dirY > 0f) 
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

    private void attackUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Key Clicked");
        }
    }

}


