using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    [SerializeField] private float moveSpeed = 100f;
    public float horizontal;
    public float vertical;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent <Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.W) )
        {
            Rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, Rigidbody.linearVelocityY);
        
    }

}
