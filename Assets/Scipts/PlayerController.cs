using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : CharacterController
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumforce = 300f;
    private bool isGrounded;
    private float horizontal;   
    private float vertical;
    private float speed = 10f;
    private bool isJumping;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Checkgrounded();
        horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal);
        //vertical = Input.GetAxisRaw("Vertical");
        

        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space");
                Jump();
            }
            //run 
            if (Mathf.Abs(horizontal) > 0.1f && isGrounded)
            {
                ChangeAnim("Run");

            }   
        }
        //check falling
        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnim("Fall");
            isJumping = false;
        }
        //moving
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
        }
        // idle
        else if (isGrounded)
        {
            ChangeAnim("Idle");
            rb.velocity = Vector2.zero;
        }
    }
    public void Jump()
    {
        if (isJumping || !isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeAnim("DoubleJump");
                rb.AddForce(jumforce * Vector2.up);
            }
            return;
        }
        if (isJumping && isGrounded)
        {
            ChangeAnim("Idle");
        }

        isJumping = true;
        ChangeAnim("Jump");
        rb.AddForce(jumforce * Vector2.up);
    }
    private bool Checkgrounded()
    {

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 2.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.1f, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    
}
