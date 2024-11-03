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

    public float moveSpeed = 5f;
    public float jumpForce = 20f;

    private Rigidbody2D Rigidbody;
    private float horizontal;
    private float vertical;
    private PlayerState currentState = PlayerState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
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
            transform.position += new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
            if (currentState != PlayerState.Jumping)
            {
                currentState = PlayerState.Moving;
            }
        }
        else if (currentState == PlayerState.Moving)
        {
            currentState = PlayerState.Idle;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentState != PlayerState.Jumping)
        {   
            currentState = PlayerState.Jumping;
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (currentState == PlayerState.Jumping)
            {
                currentState = PlayerState.Idle;
            }
        }
    }
}
