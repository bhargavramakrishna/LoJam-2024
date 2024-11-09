using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class RegularCharacter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float jumpBuffer = 0.02f;
    [SerializeField] Vector2 groundCheckBoxSize;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform playerSprite;
    [SerializeField] Animator animator;


    private Rigidbody2D Rigidbody;
    private float horizontal;
    private float vertical;
    private PlayerState currentState = PlayerState.Idle;
    private float jumpTimer = 0;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        UpdateBuffers();
        GroundCheck();
        HandleJump();
        animator.SetInteger("State", (int)currentState);
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
            case PlayerState.Moving:
            case PlayerState.Jumping:
                HandleMovement();
                break;
        }
    }

    private void HandleMovement()
    {
        if (jumpTimer > 0 && canJump) {
            currentState = PlayerState.Jumping;
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = 0;
            canJump = false;
        }

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            Rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, Rigidbody.linearVelocity.y);
            playerSprite.localScale = new(Rigidbody.linearVelocityX > 0 ? 2 : -2, 2, 1);
            
            if (currentState != PlayerState.Jumping)
            {
                currentState = PlayerState.Moving;
            }
        }
        else
        {
            Rigidbody.linearVelocity = new Vector2(0, Rigidbody.linearVelocity.y);

            if (currentState != PlayerState.Jumping)
            {
                currentState = PlayerState.Idle;
            }
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {   
            jumpTimer = jumpBuffer;
        }
    }

    private void GroundCheck() {
        Collider2D col = Physics2D.OverlapBox(groundCheck.position, groundCheckBoxSize, 0, groundLayer);
        if(col != null) 
        {
            if (currentState == PlayerState.Jumping)
            {
                currentState = PlayerState.Idle;
            }

            canJump = true;
        }
    }

    private void UpdateBuffers(){
        jumpTimer -= Time.deltaTime;
    }
   
}
