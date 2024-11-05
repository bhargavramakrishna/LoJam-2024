using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum PlayerState
{
    Idle,
    Moving,
    Jumping
}

public class ChracterMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] Vector2 groundCheckBoxSize;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;


    private Rigidbody2D Rigidbody;
    private float horizontal;
    private float vertical;
    private PlayerState currentState = PlayerState.Idle;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {        
        horizontal = Input.GetAxisRaw("Horizontal");
        GroundCheck();
        HandleJump();
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
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            Rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, Rigidbody.linearVelocity.y);

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
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {   
            currentState = PlayerState.Jumping;
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {

    //     }
    // }

    private void GroundCheck(){
        Collider2D col = Physics2D.OverlapBox(groundCheck.position, groundCheckBoxSize, 0, groundLayer);
        if(col != null) 
        {
            if (currentState == PlayerState.Jumping)
            {
                currentState = PlayerState.Idle;
            }
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
   
}
